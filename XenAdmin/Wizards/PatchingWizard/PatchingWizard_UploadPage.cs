﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XenAdmin.Actions;
using XenAdmin.Controls;
using XenAdmin.Core;
using XenAdmin.Dialogs;
using XenAPI;
using XenAdmin.Alerts;
using System;
using System.IO;

namespace XenAdmin.Wizards.PatchingWizard
{
    public partial class PatchingWizard_UploadPage : XenTabPage
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DownloadAndUnzipXenServerPatchAction downloadAction = null;
        private const int EllipsiseValueDownDescription = 50;

        public PatchingWizard_UploadPage()
        {
            InitializeComponent();
        }

        public override string Text { get { return Messages.PATCHINGWIZARD_UPLOADPAGE_TEXT; } }

        private string pageTitle = Messages.PATCHINGWIZARD_UPLOADPAGE_TITLE_ONLY_UPLOAD; 
        public override string PageTitle { get { return pageTitle; } }

        public override string HelpID { get { return "UploadPatch"; } }

        #region Accessors
        public List<Host> SelectedMasters { private get; set; }
        public List<Host> SelectedServers { private get; set; }
        public UpdateType SelectedUpdateType { private get; set; }
        public string SelectedNewPatchPath { get; set; }
        public Pool_patch SelectedExistingPatch { private get; set; }
        public Alert SelectedUpdateAlert { private get; set; }

        public readonly Dictionary<Pool_patch, string> NewUploadedPatches = new Dictionary<Pool_patch, string>();
        private Dictionary<string, List<Host>> uploadedUpdates = new Dictionary<string, List<Host>>();
        private Pool_patch _patch;
        public Pool_patch Patch
        {
            get { return _patch; }
        }

        public Dictionary<string, string> AllDownloadedPatches = new Dictionary<string, string>();
        public readonly List<VDI> AllCreatedSuppPackVdis = new List<VDI>();
        public Dictionary<Host, VDI> SuppPackVdis = new Dictionary<Host, VDI>();

        #endregion

        public override void PageLoaded(PageLoadedDirection direction)
        {
            base.PageLoaded(direction);
            
            canUpload = true;
            canDownload = true;
            UpdateButtons();

            if (SelectedUpdateType == UpdateType.Existing)
                _patch = SelectedExistingPatch;

            if (direction == PageLoadedDirection.Forward)           
            {
                flickerFreeListBox1.Items.Clear();
                var selectedPatch = SelectedUpdateAlert != null ? ((XenServerPatchAlert)SelectedUpdateAlert).Patch : null;
                if (selectedPatch != null && String.IsNullOrEmpty(SelectedNewPatchPath) &&
                    (!AllDownloadedPatches.Any(kvp => kvp.Key == selectedPatch.Uuid)
                        || String.IsNullOrEmpty(AllDownloadedPatches[selectedPatch.Uuid]) 
                        || !File.Exists(AllDownloadedPatches[selectedPatch.Uuid])))
                {
                    DownloadFile();
                    label2.Text = Messages.PATCHINGWIZARD_UPLOADPAGE_MESSAGE_DOWNLOAD_AND_UPLOAD;
                    pageTitle = Messages.PATCHINGWIZARD_UPLOADPAGE_TITLE_DOWNLOAD_AND_UPLOAD; 
                }
                else
                {
                    label2.Text = Messages.PATCHINGWIZARD_UPLOADPAGE_MESSAGE_ONLY_UPLOAD;
                    pageTitle = Messages.PATCHINGWIZARD_UPLOADPAGE_TITLE_ONLY_UPLOAD; 
                    if (selectedPatch != null && AllDownloadedPatches.ContainsKey(selectedPatch.Uuid))
                        SelectedNewPatchPath = AllDownloadedPatches[selectedPatch.Uuid];
                    PrepareUploadActions();
                    TryUploading();
                }
            }
        }

        private void DownloadFile()
        {            
            string patchUri = ((XenServerPatchAlert)SelectedUpdateAlert).Patch.PatchUrl;
            if (string.IsNullOrEmpty(patchUri))
                return;

            Uri address = new Uri(patchUri);
            string tempFile = Path.GetTempFileName();

            downloadAction = new DownloadAndUnzipXenServerPatchAction(SelectedUpdateAlert.Name, address, tempFile);          

            if (downloadAction != null)
            {
                downloadAction.Changed += singleAction_Changed;
                downloadAction.Completed += singleAction_Completed;
            }

            downloadAction.RunAsync();

            flickerFreeListBox1.Items.Clear();
            flickerFreeListBox1.Items.Add(downloadAction);
            flickerFreeListBox1.Refresh();
            OnPageUpdated();

            UpdateActionProgress(downloadAction);
        }

        public override void PageCancelled()
        {
            foreach (var action in uploadActions.Values.Where(action => action != null && !action.IsCompleted))
            {
                CancelAction(action);
            }
            if (downloadAction != null)
            {
                CancelAction(downloadAction);
            }
        }

        public override bool EnableNext()
        {
            return uploadActions.Values.All(action => action == null || action.Succeeded) && (downloadAction == null || downloadAction.Succeeded);
        }

        public override bool EnablePrevious()
        {
            return !canUpload || uploadActions.Values.All(action => action == null || action.IsCompleted) && (downloadAction == null || downloadAction.IsCompleted) ;
        }

        private Dictionary<Host, AsyncAction> uploadActions = new Dictionary<Host, AsyncAction>();

        private static bool PatchExistsOnPool(Pool_patch patch, Host poolMaster)
        {
            var poolPatches = new List<Pool_patch>(poolMaster.Connection.Cache.Pool_patches);

            return (poolPatches.Exists(p => p.uuid == patch.uuid));
        }

        private void PrepareUploadActions()
        {
            OnPageUpdated();
            SuppPackVdis.Clear();
            uploadActions.Clear();

            //Upload the patches to the masters if it is necessary
            List<Host> masters = SelectedMasters;

            foreach (Host selectedServer in masters)
            {
                AsyncAction action = null;
                switch (SelectedUpdateType)
                {
                    case UpdateType.NewRetail:
                        if (CanUploadUpdateOnHost(SelectedNewPatchPath, selectedServer))
                        {
                            bool deleteFileOnCancel = AllDownloadedPatches.ContainsValue(SelectedNewPatchPath);
                            action = new UploadPatchAction(selectedServer.Connection, SelectedNewPatchPath, true, deleteFileOnCancel);
                            AddToUploadedUpdates(SelectedNewPatchPath, selectedServer);
                        }
                        break;
                    case UpdateType.Existing:
                        if (!PatchExistsOnPool(_patch, selectedServer))
                        {
                            //Download patch from server Upload in the selected server
                            action = new CopyPatchFromHostToOther(SelectedExistingPatch.Connection, selectedServer,
                                                                  SelectedExistingPatch);
                        }
                        break;
                    case UpdateType.NewSuppPack:
                        if (CanUploadUpdateOnHost(SelectedNewPatchPath, selectedServer))
                        {
                            action = new UploadSupplementalPackAction(
                            selectedServer.Connection,
                            SelectedServers.Where(s => s.Connection == selectedServer.Connection).ToList(),
                            SelectedNewPatchPath,
                            true);

                            AddToUploadedUpdates(SelectedNewPatchPath, selectedServer);
                        }
                        break;
                }
                if (action != null)
                {
                    action.Changed += singleAction_Changed;
                    action.Completed += singleAction_Completed;
                }
                else
                {
                    _patch = GetPatchFromPatchPath();
                }
                uploadActions.Add(selectedServer, action);
            }

            foreach (KeyValuePair<Host, AsyncAction> uploadAction in uploadActions)
            {
                flickerFreeListBox1.Items.Add(uploadAction);
            }

            flickerFreeListBox1.Refresh();
            OnPageUpdated();
        }

        private bool canUpload = true;
        private bool canDownload = true;
        private DiskSpaceRequirements diskSpaceRequirements;

        private bool CanUploadUpdateOnHost(string patchPath, Host host)
        {
            return !uploadedUpdates.ContainsKey(patchPath) || !uploadedUpdates[patchPath].Contains(host);
        }

        private void AddToUploadedUpdates(string patchPath, Host host)
        {
            if(!uploadedUpdates.ContainsKey(patchPath))
            {
                List<Host> hosts = new List<Host>();
                hosts.Add(host);
                uploadedUpdates.Add(patchPath, hosts);
            }
            else if(!uploadedUpdates[patchPath].Contains(host))
            {
                uploadedUpdates[patchPath].Add(host);
            }
        }

        private void TryUploading()
        {
            // reset progress bar and action progress description
            UpdateActionProgress(null);

            // Check if we can upload the patches to the masters if it is necessary.
            // This check is only available for Cream or greater hosts.
            // If we can upload (i.e. there is enough disk space) then start the upload.
            // Otherwise display error.
            canUpload = true;
            diskSpaceRequirements = null;
            var diskSpaceActions = new List<AsyncAction>();
            foreach (Host master in SelectedMasters.Where(master => Helpers.CreamOrGreater(master.Connection)))
            {
                AsyncAction action = null;
                switch (SelectedUpdateType)
                {
                    case UpdateType.NewRetail:
                        action = new CheckDiskSpaceForPatchUploadAction(master, SelectedNewPatchPath, true);
                        break;
                    case UpdateType.Existing:
                        if (SelectedExistingPatch != null && !PatchExistsOnPool(SelectedExistingPatch, master))
                            action = new CheckDiskSpaceForPatchUploadAction(master, SelectedExistingPatch, true);
                        break;
                }

                if (action != null)
                {
                    action.Changed += delegate
                    {
                        Program.Invoke(Program.MainWindow, () => UpdateActionDescription(action));
                    };
                    diskSpaceActions.Add(action);
                }
            }

            if (diskSpaceActions.Count == 0)
            {
                StartUploading(); 
                return;
            }

            using (var multipleAction = new MultipleAction(Connection, "", "", "", diskSpaceActions, true, true, true))
            {
                multipleAction.Completed += delegate
                {
                    Program.Invoke(Program.MainWindow, () =>
                    {
                        if (multipleAction.Exception is NotEnoughSpaceException)
                        {
                            canUpload = false;
                            diskSpaceRequirements = (multipleAction.Exception as NotEnoughSpaceException).DiskSpaceRequirements;
                        }
                        UpdateButtons();
                        OnPageUpdated();
                        if (canUpload)
                            StartUploading();
                    });
                };
                multipleAction.RunAsync();
            }
        }

        private Pool_patch GetPatchFromPatchPath()
        {
            foreach (var kvp in NewUploadedPatches)
            {
                if (kvp.Value == SelectedNewPatchPath)
                {
                    return kvp.Key;
                }
            }
            return null;
        }

        private void StartUploading()
        {
            // reset progress bar and action progress description
            UpdateActionProgress(null);

            // start the upload
            var actions = uploadActions.Values.Where(a => a != null).ToList();
            if (actions.Count == 0) 
                return;

            using (var multipleAction = new MultipleAction(Connection, Messages.UPLOAD_PATCH_TITLE, Messages.UPLOAD_PATCH_DESCRIPTION, Messages.UPLOAD_PATCH_END_DESCRIPTION, actions, true, true, true))
            {
                multipleAction.Completed += multipleAction_Completed;
                multipleAction.RunAsync();
            }
        }

        private void UpdateButtons()
        {
            if (!canUpload && diskSpaceRequirements != null)
            {
                errorLinkLabel.Visible = true;
                errorLinkLabel.Text = diskSpaceRequirements.GetMessageForActionLink();
            }
            else if (!canDownload)
            {
                errorLinkLabel.Visible = true;
                errorLinkLabel.Text = Messages.PATCHINGWIZARD_MORE_INFO;
            }
            else
                errorLinkLabel.Visible = false;
        }

        private void UpdateActionProgress(AsyncAction action)
        {
            UpdateActionDescription(action);
            progressBar1.Value = action == null ? 0 : action.PercentComplete;
        }

        private void UpdateActionDescription(AsyncAction action)
        {
            if (action == null) // reset action description
            {
                labelProgress.Text = "";
                labelProgress.ForeColor = SystemColors.ControlText;
            }
            else if (action.StartedRunning) // update description for started actions
            {
                labelProgress.Text = GetActionDescription(action);
                labelProgress.ForeColor = !action.IsCompleted || action.Succeeded ? SystemColors.ControlText : Color.Red;
            }
        }

        private static string GetActionDescription(AsyncAction action)
        {
            return !action.StartedRunning ? "" :
                action.Exception == null
                ? action.Description
                : action.Exception is CancelledException ? Messages.CANCELLED_BY_USER : action.Exception.Message;
        }

        private void CancelAction(AsyncAction action)
        {
            Program.AssertOnEventThread();
            OnPageUpdated();
            action.Changed -= singleAction_Changed;
            action.Completed -= singleAction_Completed;
            action.Cancel();
        }

        private void singleAction_Changed(object sender)
        {
            var action = sender as AsyncAction;
            if (action == null)
                return;

            Program.Invoke(this, () =>
            {
                UpdateActionProgress(action);
                flickerFreeListBox1.Refresh();
                OnPageUpdated();
            });
        }

        private void singleAction_Completed(ActionBase sender)
        {
            var action = sender as AsyncAction;
            if (action == null)
                return;

            action.Changed -= singleAction_Changed;
            action.Completed -= singleAction_Completed;

            Program.Invoke(this, () =>
            {
                if (action.Succeeded)
                {
                    Host master = Helpers.GetMaster(action.Connection);

                    if (action is UploadPatchAction)
                        _patch = (action as UploadPatchAction).PatchRefs[master];
                    if (action is CopyPatchFromHostToOther && action.Host != null)
                        _patch = action.Host.Connection.Cache.Resolve((action as CopyPatchFromHostToOther).NewPatchRef);

                    if (_patch != null && !NewUploadedPatches.ContainsKey(_patch))
                        NewUploadedPatches.Add(_patch, SelectedNewPatchPath);

                    if (action is UploadSupplementalPackAction)
                    {
                        foreach (var vdiRef in (action as UploadSupplementalPackAction).VdiRefs)
                            SuppPackVdis[vdiRef.Key] = action.Connection.Resolve(vdiRef.Value);
                        AllCreatedSuppPackVdis.AddRange(SuppPackVdis.Values.Where(vdi => !AllCreatedSuppPackVdis.Contains(vdi)));
                    }
                    if (action is DownloadAndUnzipXenServerPatchAction)
                    {
                        SelectedNewPatchPath = ((DownloadAndUnzipXenServerPatchAction)action).PatchPath;
                        if (SelectedUpdateAlert is XenServerPatchAlert && (SelectedUpdateAlert as XenServerPatchAlert).Patch != null)
                        {
                            AllDownloadedPatches.Add((SelectedUpdateAlert as XenServerPatchAlert).Patch.Uuid, SelectedNewPatchPath);
                        }
                        _patch = null;
                        PrepareUploadActions();
                        TryUploading();
                    }
                }
            });
        }

        private void multipleAction_Completed(object sender)
        {
            var action = sender as AsyncAction;
            if (action == null)
                return;

            action.Completed -= multipleAction_Completed;

            canDownload = !(action.Exception is PatchDownloadFailedException);

            Program.Invoke(this, () =>
            {
                labelProgress.Text = GetActionDescription(action);
                UpdateButtons();
            });
            
        }

        private void flickerFreeListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {            
            if(e.Index >= 0 && (flickerFreeListBox1.Items[e.Index] is DownloadAndUnzipXenServerPatchAction)) 
            {
                DownloadAndUnzipXenServerPatchAction downAction = (DownloadAndUnzipXenServerPatchAction)flickerFreeListBox1.Items[e.Index];
                drawActionText(Properties.Resources._000_Patch_h32bit_16, 
                               downAction.Title, 
                               GetActionDescription(downAction).Ellipsise(EllipsiseValueDownDescription), 
                               GetTextColor(downAction), 
                               e);
                return;
            }

            if (e.Index < 0 || !(flickerFreeListBox1.Items[e.Index] is KeyValuePair<Host, AsyncAction>))
                return;
            var hostAndAction = (KeyValuePair<Host, AsyncAction>)flickerFreeListBox1.Items[e.Index];
            var host = hostAndAction.Key;
            var action = hostAndAction.Value;
            
            using (SolidBrush backBrush = new SolidBrush(flickerFreeListBox1.BackColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            var poolOrHost = Helpers.GetPool(host.Connection) ?? (IXenObject)host;

            string text = action == null ? Messages.UPLOAD_PATCH_ALREADY_UPLOADED : GetActionDescription(action);
            drawActionText(Images.GetImage16For(poolOrHost),poolOrHost.Name, text, GetTextColor(action), e);
        }

        private void drawActionText(Image icon, string actionTitle, string actionDescription, Color textColor,DrawItemEventArgs e)
        {
            int width = Drawing.MeasureText(actionDescription, flickerFreeListBox1.Font).Width;
            e.Graphics.DrawImage(icon, e.Bounds.Left, e.Bounds.Top);
            Drawing.DrawText(e.Graphics, actionTitle, flickerFreeListBox1.Font,
                             new Rectangle(e.Bounds.Left + icon.Width, e.Bounds.Top, e.Bounds.Right - (width + icon.Width), e.Bounds.Height),
                             flickerFreeListBox1.ForeColor,
                             TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
            Drawing.DrawText(e.Graphics, actionDescription, flickerFreeListBox1.Font,
                             new Rectangle(e.Bounds.Right - width, e.Bounds.Top, width, e.Bounds.Height),
                             textColor, flickerFreeListBox1.BackColor);
        }

        private Color GetTextColor(AsyncAction action)
        {
            Color textColor;
            if (action == null || !action.StartedRunning) // not started yet
                textColor = flickerFreeListBox1.ForeColor;
            else if (!action.IsCompleted) // in progress
                textColor = Color.Blue;
            else textColor = action.Succeeded ? Color.Green : Color.Red; // completed
            return textColor;
        }

        private void errorLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!canDownload)
            {
                var msgtemplate = SelectedExistingPatch.host_patches.Count > 0 ? Messages.PATCH_DOWNLOAD_FAILED_MORE_INFO : Messages.PATCH_DOWNLOAD_FAILED_MORE_INFO_NOT_APPLIED;
                var msg = string.Format(msgtemplate, SelectedExistingPatch.name_label, SelectedExistingPatch.Connection.Name);
                new ThreeButtonDialog(
                   new ThreeButtonDialog.Details(SystemIcons.Error, msg))
                   .ShowDialog(this);
            }

            if (diskSpaceRequirements == null)
                return;

            if (diskSpaceRequirements.CanCleanup)
            {
                ThreeButtonDialog d = new ThreeButtonDialog(
                    new ThreeButtonDialog.Details(SystemIcons.Warning, diskSpaceRequirements.GetSpaceRequirementsMessage()),
                    new ThreeButtonDialog.TBDButton(Messages.OK, DialogResult.OK),
                    new ThreeButtonDialog.TBDButton(Messages.CANCEL, DialogResult.Cancel));

                if (d.ShowDialog(this) == DialogResult.OK)
                {
                    // do the cleanup and retry uploading
                    CleanupDiskSpaceAction action = new CleanupDiskSpaceAction(diskSpaceRequirements.Host, null, true);

                    action.Completed += delegate
                                        {
                                            if (action.Succeeded)
                                            {
                                                Program.Invoke(Program.MainWindow, TryUploading);
                                            }
                                        };
                    action.RunAsync();
                }
            }
            else
            {
                new ThreeButtonDialog(
                    new ThreeButtonDialog.Details(SystemIcons.Warning, diskSpaceRequirements.GetSpaceRequirementsMessage()))
                    .ShowDialog(this);
            }
        }
    }
}