﻿/* Copyright (c) Citrix Systems Inc. 
 * All rights reserved. 
 * 
 * Redistribution and use in source and binary forms, 
 * with or without modification, are permitted provided 
 * that the following conditions are met: 
 * 
 * *   Redistributions of source code must retain the above 
 *     copyright notice, this list of conditions and the 
 *     following disclaimer. 
 * *   Redistributions in binary form must reproduce the above 
 *     copyright notice, this list of conditions and the 
 *     following disclaimer in the documentation and/or other 
 *     materials provided with the distribution. 
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND 
 * CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF 
 * MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR 
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
 * BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR 
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE 
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF 
 * SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Citrix.XenCenter;
using XenAdmin;
using XenAdmin.Core;
using XenAdmin.Network;


namespace XenAPI
{
    public partial class Host : IComparable<Host>, IEquatable<Host>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public enum Edition
        {
            Free,
            Advanced,
            Enterprise,
            Platinum,
            EnterpriseXD,
            PerSocket,     //Added in Clearwater (PR-1589)
            XenDesktop,    //Added in Clearwater (PR-1589) and is new form of "EnterpriseXD"
            EnterprisePerSocket,   // Added in Creedence (enterprise-per-socket)
            EnterprisePerUser,     // Added in Creedence (enterprise-per-user)
            StandardPerSocket,     // Added in Creedence (standard-per-socket)
            Desktop,               // Added in Creedence (desktop)
            DesktopPlus            // Added in Creedence (desktop-plus)
        }

        public static string LicenseServerWebConsolePort = "8082";

        public override string Name
        {
            get
            {
                return name_label;
            }
        }


        public static Edition GetEdition(string editionText)
        {
            switch (editionText)
            {
                case "advanced":
                    return Edition.Advanced;
                case "enterprise":
                    return Edition.Enterprise;
                case "enterprise-xd":
                    return Edition.EnterpriseXD;
                case "platinum":
                    return Edition.Platinum;
                case "xendesktop":
                    return Edition.XenDesktop;
                case "per-socket":
                    return Edition.PerSocket;
                case "enterprise-per-socket":
                    return Edition.EnterprisePerSocket;
                case "enterprise-per-user":
                    return Edition.EnterprisePerUser;
                case "standard-per-socket":
                    return Edition.StandardPerSocket;
                case "desktop":
                    return Edition.Desktop;
                case "desktop-plus":
                    return Edition.DesktopPlus;
                default:
                    return Edition.Free;
            }
        }


        public bool CanSeeNetwork(XenAPI.Network network)
        {
            System.Diagnostics.Trace.Assert(network != null);

            // Special case for local networks.
            if (network.PIFs.Count == 0)
                return true;

            foreach (PIF pif in network.Connection.ResolveAll(network.PIFs))
            {
                if (pif.host != null && pif.host.opaque_ref == opaque_ref)
                    return true;
            }

            return false;
        }

        public static string GetEditionText(Edition edition)
        {
            switch (edition)
            {
                case Edition.Advanced:
                    return "advanced";
                case Edition.Enterprise:
                    return "enterprise";
                case Edition.Platinum:
                    return "platinum";
                case Edition.EnterpriseXD:
                    return "enterprise-xd";
                case Edition.XenDesktop:
                    return "xendesktop";
                case Edition.PerSocket:
                    return "per-socket";
                case Edition.EnterprisePerSocket:
                    return "enterprise-per-socket";
                case Edition.EnterprisePerUser:
                    return "enterprise-per-user";
                case Edition.StandardPerSocket:
                    return "standard-per-socket";
                case Edition.Desktop:
                    return "desktop";
                case Edition.DesktopPlus:
                    return "desktop-plus";
                default:
                    return "free";
            }
        }

        public string iscsi_iqn
        {
            get { return Get(other_config, "iscsi_iqn") ?? ""; }
            set
            {
                if (iscsi_iqn != value)
                {
                    Dictionary<string, string> new_other_config =
                        other_config == null ?
                            new Dictionary<string, string>() :
                            new Dictionary<string, string>(other_config);
                    new_other_config["iscsi_iqn"] = value;
                    other_config = new_other_config;
                }
            }
        }

        public override string ToString()
        {
            return this.name_label;
        }

        public override string Description
        {
            get
            {
                if (name_description == "Default install of XenServer")  // i18n: CA-30372
                    return Messages.DEFAULT_INSTALL_OF_XENSERVER;
                else if (name_description == null)
                    return "";
                else
                    return name_description;
            }
        }

        /// <summary>
        /// The expiry date of this host's license in UTC.
        /// </summary>
        public virtual DateTime LicenseExpiryUTC
        {
            get
            {
                if (license_params != null && license_params.ContainsKey("expiry"))
                    return TimeUtil.ParseISO8601DateTime(license_params["expiry"]);
                return new DateTime(2030, 1, 1);
            }
        }

        private bool _RestrictRBAC
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_rbac"); }
        }
        public static bool RestrictRBAC(Host h)
        {
            return h._RestrictRBAC;
        }

        private bool _RestrictDMC
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_dmc"); }
        }
        public static bool RestrictDMC(Host h)
        {
            return h._RestrictDMC;
        }

        private bool _RestrictHotfixApply
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_hotfix_apply"); }
        }

        /// <summary>
        /// Added for Clearwater
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public static bool RestrictHotfixApply(Host h)
        {
            return h._RestrictHotfixApply;
        }

        private bool _RestrictCheckpoint
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_checkpoint"); }
        }
        public static bool RestrictCheckpoint(Host h)
        {
            return h._RestrictCheckpoint;
        }

        public static bool RestrictCifs(Host h)
        {
            return h._RestrictCifs;
        }

        private bool _RestrictCifs
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_cifs"); }
        }

        public static bool RestrictVendorDevice(Host h)
        {
            return h._RestrictVendorDevice;
        }

        private bool _RestrictVendorDevice
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_pci_device_for_auto_update"); }
        }

        private bool _RestrictWLB
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_wlb"); }
        }
        public static bool RestrictWLB(Host h)
        {
            return h._RestrictWLB;
        }

        private bool _RestrictVSwitchController
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_vswitch_controller"); }
        }
        public static bool RestrictVSwitchController(Host h)
        {
            return h._RestrictVSwitchController;
        }

        public static bool RestrictVMProtection(Host h)
        {
            return h._RestrictVMProtection;
        }

        private bool _RestrictVMProtection
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_vmpr"); }
        }

        public static bool RestrictVMAppliances(Host h)
        {
            return h._RestrictVMAppliances;
        }

        private bool _RestrictVMAppliances
        {
            get { return false; }
        }

        public static bool RestrictDR(Host h)
        {
            return h._RestrictDR;
        }

        private bool _RestrictDR
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_dr"); }
        }

        public static bool RestrictCrossPoolMigrate(Host h)
        {
            return h._RestrictCrossPoolMigrate;
        }

        private bool _RestrictCrossPoolMigrate
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_storage_xen_motion"); }
        }

        public virtual bool IsFreeLicense()
        {
            return edition == "free";
        }

        private bool _RestrictHA
        {
            get { return !BoolKey(license_params, "enable_xha"); }
        }

        public static bool RestrictHA(Host h)
        {
            return h._RestrictHA;
        }

        private bool _RestrictAlerts
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_email_alerting"); }
        }
        public static bool RestrictAlerts(Host h)
        {
            return h._RestrictAlerts;
        }

        private bool _RestrictStorageChoices
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_netapp"); }
        }
        public static bool RestrictStorageChoices(Host h)
        {
            return h._RestrictStorageChoices;
        }

        private bool _RestrictPerformanceGraphs
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_historical_performance"); }
        }
        public static bool RestrictPerformanceGraphs(Host h)
        {
            return h._RestrictPerformanceGraphs;
        }

        private bool _RestrictCpuMasking
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_cpu_masking"); }
        }
        public static bool RestrictCpuMasking(Host h)
        {
            return h._RestrictCpuMasking;
        }

        private bool _RestrictGpu
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_gpu"); }
        }

        public static bool RestrictGpu(Host h)
        {
            return h._RestrictGpu;
        }

        private bool _RestrictVgpu
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_vgpu"); }
        }
        public static bool RestrictVgpu(Host h)
        {
            return h._RestrictVgpu;
        }

        private bool _RestrictIntegratedGpuPassthrough
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_integrated_gpu_passthrough"); }
        }

        public static bool RestrictIntegratedGpuPassthrough(Host h)
        {
            return h._RestrictIntegratedGpuPassthrough;
        }

        private bool _RestrictExportResourceData
        {
            get
            {
                if (Helpers.CreedenceOrGreater(Connection)) 
                {
                    return BoolKeyPreferTrue(license_params, "restrict_export_resource_data");
                }
                // Pre-Creedence hosts:
                // allowed on Per-Socket edition for Clearwater hosts and Advanced, Enterprise and Platinum editions for older hosts
                var hostEdition = GetEdition(edition);
                if (hostEdition == Edition.PerSocket || hostEdition == Edition.Advanced ||
                    hostEdition == Edition.Enterprise || hostEdition == Edition.Platinum)
                {
                    return LicenseExpiryUTC < DateTime.UtcNow - Connection.ServerTimeOffset; // restrict if the license has expired
                }
                return true;
            }
        }

        public static bool RestrictExportResourceData(Host h)
        {
            return h._RestrictExportResourceData;
        }

        private bool _RestrictReadCaching
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_read_caching"); }
        }

        public static bool RestrictReadCaching(Host h)
        {
            return h._RestrictReadCaching;
        }

        private bool _RestrictHealthCheck
        {
            get { return BoolKeyPreferTrue(license_params, "restrict_health_check"); }
        }

        public static bool RestrictHealthCheck(Host h)
        {
            return h._RestrictHealthCheck;
        }

        /// <summary>
        /// Vss feature is restricted only if the "restrict_vss" key exists and it is true
        /// </summary>
        private bool _RestrictVss
        {
            get { return BoolKey(license_params, "restrict_vss"); }
        }

        public static bool RestrictVss(Host h)
        {
            return h._RestrictVss;
        }

        public bool HasPBDTo(SR sr)
        {
            foreach (XenRef<PBD> pbd in PBDs)
            {
                PBD thePBD = sr.Connection.Resolve<PBD>(pbd);
                if (thePBD != null && thePBD.SR.opaque_ref == sr.opaque_ref)
                {
                    return true;
                }
            }
            return false;
        }

        public PBD GetPBDTo(SR sr)
        {
            foreach (XenRef<PBD> pbd in PBDs)
            {
                PBD thePBD = sr.Connection.Resolve<PBD>(pbd);
                if (thePBD != null && thePBD.SR.opaque_ref == sr.opaque_ref)
                {
                    return thePBD;
                }
            }
            return null;
        }

        // Constants for other-config from CP-329
        public const String MULTIPATH = "multipathing";
        public const String MULTIPATH_HANDLE = "multipathhandle";
        public const String DMP = "dmp";

        public bool MultipathEnabled
        {
            get { return BoolKey(other_config, MULTIPATH); }
        }

        public String MultipathHandle
        {
            get { return Get(other_config, MULTIPATH_HANDLE); }
        }

        public override int CompareTo(Host other)
        {
            // CA-20865 Sort in the following order:
            // * Masters first
            // * Then connected slaves
            // * Then disconnected servers
            // Within each group, in NaturalCompare order

            bool thisConnected = (Connection.IsConnected && Helpers.GetMaster(Connection) != null);
            bool otherConnected = (other.Connection.IsConnected && Helpers.GetMaster(other.Connection) != null);

            if (thisConnected && !otherConnected)
                return -1;
            else if (!thisConnected && otherConnected)
                return 1;
            else if (thisConnected)
            {
                bool thisIsMaster = IsMaster();
                bool otherIsMaster = other.IsMaster();

                if (thisIsMaster && !otherIsMaster)
                    return -1;
                else if (!thisIsMaster && otherIsMaster)
                    return 1;
            }

            return base.CompareTo(other);
        }

        public virtual bool IsMaster()
        {
            Pool pool = Helpers.GetPoolOfOne(Connection);
            if (pool == null)
                return false;

            Host master = Connection.Resolve<Host>(pool.master);
            return master == null ? false : master.uuid == this.uuid;
        }

        /// <summary>
        /// Return this host's product version triplet (e.g. 5.6.100), or null if it can't be found.
        /// </summary>
        public virtual string ProductVersion
        {
            get { return Get(software_version, "product_version"); }
        }

        private string MarketingVersion(string field)
        {
            string s = Get(software_version, field);
            return string.IsNullOrEmpty(s) ? ProductVersion : s;
        }

        /// <summary>
        /// Return this host's marketing version number (e.g. 5.6 Feature Pack 1),
        /// or ProductVersion (which can still be null) if it can't be found, including pre-Cowley hosts.
        /// </summary>
        public string ProductVersionText
        {
            get { return MarketingVersion("product_version_text"); }
        }

        /// <summary>
        /// Return this host's marketing version number in short form (e.g. 5.6 FP1),
        /// or ProductVersion (which can still be null) if it can't be found, including pre-Cowley hosts.
        /// </summary>
        public string ProductVersionTextShort
        {
            get { return MarketingVersion("product_version_text_short"); }
        }

        /// <summary>
        /// Return this host's XCP version triplet (e.g. 1.0.50), or null if it can't be found,
        /// including all pre-Tampa hosts.
        /// </summary>
        public virtual string PlatformVersion
        {
            get { return Get(software_version, "platform_version"); }
        }

        /// <summary>
        /// Return the build number of this host, or -1 if none can be found.  This will often be
        /// 0 or -1 for developer builds, so comparisons should generally treat those numbers as if
        /// they were brand new.
        /// </summary>
        public int BuildNumber
        {
            get
            {
                string bn = BuildNumberRaw;
                if (bn == null)
                    return -1;
                while (bn.Length > 0 && !char.IsDigit(bn[bn.Length - 1]))
                {
                    bn = bn.Substring(0, bn.Length - 1);
                }
                int result;
                if (int.TryParse(bn, out result))
                    return result;
                else
                    return -1;
            }
        }

        /// <summary>
        /// Return the build number of this host, without stripping off the final letter etc.; or null if none can be found.
        /// </summary>
        public virtual string BuildNumberRaw
        {
            get { return Get(software_version, "build_number"); }
        }

        /// <summary>
        /// Return this host's product version and build number (e.g. 5.6.100.72258), or null if product version can't be found.
        /// </summary>
        public virtual string LongProductVersion
        {
            get
            {
                string productVersion = ProductVersion;
                return productVersion != null ? string.Format("{0}.{1}", productVersion, BuildNumber) : null;
            }
        }

        /// <summary>
        /// Return the hg_id (Mercurial changeset number) of xapi on this host, or null if none can be found.
        /// </summary>
        public string hg_id
        {
            get { return Get(software_version, "hg_id"); }
        }

        /// <summary>
        /// Return the product_brand of this host, or null if none can be found.
        /// </summary>
        public string ProductBrand
        {
            get { return Get(software_version, "product_brand"); }
        }

        /// <summary>
        /// Whether this host is an XCP host
        /// </summary>
        public bool IsXCP
        {
            get
            {
                return
                    ProductVersion == null && PlatformVersion != null ||  // for Tampa and later
                    ProductBrand == "XCP";  // for Boston and earlier
            }
        }

        /// <summary>
        /// The remote syslog target. May return null if not set on the server. Set to null to unset.
        /// </summary>
        public string SysLogDestination
        {
            get { return logging != null && logging.ContainsKey("syslog_destination") ? logging["syslog_destination"] : null; }
            set
            {
                if (SysLogDestination != value)
                {
                    Dictionary<string, string> new_logging =
                        logging == null ?
                            new Dictionary<string, string>() :
                            new Dictionary<string, string>(logging);

                    if (value == null)
                    {
                        new_logging.Remove("syslog_destination");
                    }
                    else
                    {
                        new_logging["syslog_destination"] = value;
                    }

                    logging = new_logging;
                }
            }
        }

        public static bool IsFullyPatched(Host host,IEnumerable<IXenConnection> connections)
        {
            List<Pool_patch> patches = Pool_patch.GetAllThatApply(host,connections);

            List<Pool_patch> appliedPatches
                = host.AppliedPatches();

            if (appliedPatches.Count == patches.Count)
                return true;

            foreach (Pool_patch patch in patches)
            {
                Pool_patch patch1 = patch;
                if (!appliedPatches.Exists(otherPatch => patch1.uuid == otherPatch.uuid))
                    return false;
            }

            return true;
        }

        public virtual List<Pool_patch> AppliedPatches()
        {
            List<Pool_patch> patches = new List<Pool_patch>();

            foreach (Host_patch hostPatch in Connection.ResolveAll(this.patches))
            {
                Pool_patch patch = Connection.Resolve(hostPatch.pool_patch);
                if (patch != null)
                    patches.Add(patch);
            }

            return patches;
        }

        public string XAPI_version
        {
            get
            {
                return Get(software_version, "xapi");
            }
        }

        public bool LinuxPackPresent
        {
            get
            {
                return software_version.ContainsKey("xs:linux");
            }
        }

        public bool HasCrashDumps
        {
            get
            {
                return crashdumps != null && crashdumps.Count > 0;
            }
        }

        public bool IsLive
        {
            get
            {
                if (Connection == null)
                    return false;

                Host_metrics hm = Connection.Resolve(metrics);
                return hm == null ? false : hm.live;
            }
        }

        public const string MAINTENANCE_MODE = "MAINTENANCE_MODE";

        public bool MaintenanceMode
        {
            get
            {
                return BoolKey(other_config, MAINTENANCE_MODE);
            }
        }

        public const string BOOT_TIME = "boot_time";

        public double BootTime
        {
            get
            {
                if (other_config == null)
                    return 0.0;

                if (!other_config.ContainsKey(BOOT_TIME))
                    return 0.0;

                double bootTime;

                if (!double.TryParse(other_config[BOOT_TIME], NumberStyles.Number,
                    CultureInfo.InvariantCulture, out bootTime))
                    return 0.0;

                return bootTime;
            }
        }


        public PrettyTimeSpan Uptime
        {
            get
            {
                double bootTime = BootTime;
                if (bootTime == 0.0)
                    return null;
                return new PrettyTimeSpan(DateTime.UtcNow - Util.FromUnixTime(bootTime) - Connection.ServerTimeOffset);
            }
        }

        public const string AGENT_START_TIME = "agent_start_time";

        public double AgentStartTime
        {
            get
            {
                if (other_config == null)
                    return 0.0;

                if (!other_config.ContainsKey(AGENT_START_TIME))
                    return 0.0;

                double agentStartTime;

                if (!double.TryParse(other_config[AGENT_START_TIME], System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out agentStartTime))
                    return 0.0;

                return agentStartTime;
            }
        }

        public PrettyTimeSpan AgentUptime
        {
            get
            {
                double startTime = AgentStartTime;
                if (startTime == 0.0)
                    return null;
                return new PrettyTimeSpan(DateTime.UtcNow - Util.FromUnixTime(startTime) - Connection.ServerTimeOffset);
            }
        }

        // Get the path counts from the Multipath Boot From SAN feature (see PR-1034 and CP-1696).
        // Returns true if the Host.other_config contains the multipathed and mpath-boot keys,
        // and the mpath-boot key is parseable. In this case, current and max will contain the result;
        // otherwise they will contain zero.
        public bool GetBootPathCounts(out int current, out int max)
        {
            current = max = 0;
            return (BoolKey(other_config, "multipathed") &&
                other_config.ContainsKey("mpath-boot") &&
                PBD.ParsePathCounts(other_config["mpath-boot"], out current, out max));
        }

        #region Save Evacuated VMs for later

        public const String MAINTENANCE_MODE_EVACUATED_VMS_MIGRATED = "MAINTENANCE_MODE_EVACUATED_VMS_MIGRATED";
        public const String MAINTENANCE_MODE_EVACUATED_VMS_SUSPENDED = "MAINTENANCE_MODE_EVACUATED_VMS_SUSPENDED";
        public const String MAINTENANCE_MODE_EVACUATED_VMS_HALTED = "MAINTENANCE_MODE_EVACUATED_VMS_HALTED";

        /// <summary>
        /// Save the list of VMs on this host, so we can try and put them back when finished.
        /// This may get run multiple times, after which some vms will have been suspended / shutdown.
        /// </summary>
        /// <param name="session">Pass in the session you wish to use for the other config writing</param>
        public void SaveEvacuatedVMs(Session session)
        {
            //Program.AssertOffEventThread();

            XenRef<Host> opaque_ref = get_by_uuid(session, uuid);

            List<VM> migratedVMs = GetVMs(MAINTENANCE_MODE_EVACUATED_VMS_MIGRATED);
            List<VM> suspendedVMs = GetVMs(MAINTENANCE_MODE_EVACUATED_VMS_SUSPENDED);
            List<VM> haltedVMs = GetVMs(MAINTENANCE_MODE_EVACUATED_VMS_HALTED);

            List<VM> allVMs = new List<VM>();
            allVMs.AddRange(migratedVMs);
            allVMs.AddRange(suspendedVMs);
            allVMs.AddRange(haltedVMs);

            // First time round there will be no saved VMs, 
            // (or less saved VMs than currently resident)
            // so just save them all as migrated
            // don't forget the control domain

            if (allVMs.Count < resident_VMs.Count - 1)
            {
                SaveVMList(session, opaque_ref, MAINTENANCE_MODE_EVACUATED_VMS_MIGRATED,
                    Connection.ResolveAll(resident_VMs));
                return;
            }

            // We've been round once, so just make sure all the vms are in the correct list
            // and then save the lists again

            migratedVMs.Clear();
            suspendedVMs.Clear();
            haltedVMs.Clear();

            foreach (VM vm in allVMs)
            {
                switch (vm.power_state)
                {
                    case vm_power_state.Halted:
                        haltedVMs.Add(vm);
                        break;

                    case vm_power_state.Running:
                        migratedVMs.Add(vm);
                        break;

                    case vm_power_state.Suspended:
                        suspendedVMs.Add(vm);
                        break;
                }
            }

            SaveVMList(session, opaque_ref, MAINTENANCE_MODE_EVACUATED_VMS_MIGRATED, migratedVMs);
            SaveVMList(session, opaque_ref, MAINTENANCE_MODE_EVACUATED_VMS_HALTED, haltedVMs);
            SaveVMList(session, opaque_ref, MAINTENANCE_MODE_EVACUATED_VMS_SUSPENDED, suspendedVMs);
        }

        private static void SaveVMList(Session session, String serverOpaqueRef, String key, List<VM> vms)
        {
            //Program.AssertOffEventThread();

            List<String> vmUUIDs = new List<String>();
            foreach (VM vm in vms)
            {
                if (vm.is_control_domain)
                    continue;

                vmUUIDs.Add(vm.uuid);
            }

            Host.remove_from_other_config(session, serverOpaqueRef, key);
            Host.add_to_other_config(session, serverOpaqueRef, key, String.Join(",", vmUUIDs.ToArray()));
        }

        private List<VM> GetVMs(String key)
        {
            List<VM> vms = new List<VM>();

            if (other_config == null || !other_config.ContainsKey(key))
                return vms;

            String vmUUIDs = other_config[key];
            if (String.IsNullOrEmpty(vmUUIDs))
                return vms;

            foreach (String vmUUID in vmUUIDs.Split(new char[] { ',' }))
                foreach (VM vm in Connection.Cache.VMs)
                    if (vm.uuid == vmUUID)
                    {
                        if (!vms.Contains(vm))
                            vms.Add(vm);

                        break;
                    }

            return vms;
        }

        public void ClearEvacuatedVMs(Session session)
        {
            XenRef<Host> serverOpaqueRef1 = get_by_uuid(session, uuid);
            remove_from_other_config(session, serverOpaqueRef1, MAINTENANCE_MODE_EVACUATED_VMS_MIGRATED);
            remove_from_other_config(session, serverOpaqueRef1, MAINTENANCE_MODE_EVACUATED_VMS_HALTED);
            remove_from_other_config(session, serverOpaqueRef1, MAINTENANCE_MODE_EVACUATED_VMS_SUSPENDED);
        }

        public List<VM> GetMigratedEvacuatedVMs()
        {
            return GetEvacuatedVMs(MAINTENANCE_MODE_EVACUATED_VMS_MIGRATED, vm_power_state.Running);
        }

        public List<VM> GetSuspendedEvacuatedVMs()
        {
            return GetEvacuatedVMs(MAINTENANCE_MODE_EVACUATED_VMS_SUSPENDED, vm_power_state.Suspended);
        }

        public List<VM> GetHaltedEvacuatedVMs()
        {
            return GetEvacuatedVMs(MAINTENANCE_MODE_EVACUATED_VMS_HALTED, vm_power_state.Halted);
        }

        private List<VM> GetEvacuatedVMs(String key, vm_power_state expectedPowerState)
        {
            List<VM> vms = GetVMs(key);
            foreach (VM vm in vms.ToArray())
                if (vm.power_state != expectedPowerState)
                    vms.Remove(vm);

            return vms;
        }

        #endregion

        /// <summary>
        /// Will return null if cannot find connection or any control domain in list of vms
        /// </summary>
        public VM ControlDomain
        {
            get
            {
                if (Connection == null)
                    return null;
                foreach (VM vm in Connection.ResolveAll<VM>(resident_VMs))
                {
                    if (vm.is_control_domain)
                        return vm;
                }
                return null;
            }
        }

        /// <summary>
        /// Interpret a value from the software_version dictionary as a int, or 0 if we couldn't parse it.
        /// </summary>
        private int GetSVAsInt(string key)
        {
            string s = Get(software_version, key);
            if (s == null)
                return 0;
            return (int)Helper.GetAPIVersion(s);
        }

        /// <summary>
        /// The xencenter_min as a int, or 0. if we couldn't parse it.
        /// </summary>
        public int XenCenterMin
        {
            get { return GetSVAsInt("xencenter_min"); }
        }

        /// <summary>
        /// The xencenter_max as a int, or 0 if we couldn't parse it.
        /// </summary>
        public int XenCenterMax
        {
            get { return GetSVAsInt("xencenter_max"); }
        }

        /// <summary>
        /// The amount of memory free on the host. For George and earlier hosts, we use to use
        /// the obvious Host_metrics.memory_free. Since Midnight Ride, however, we use
        /// the same calculation as xapi, adding the used memory and the virtualisation overheads
        /// on each of the VMs. This is a more conservative estimate (i.e., it reports less memory
        /// free), but it's the one we need to make the memory go down to zero when ballooning
        /// takes place.
        /// </summary>
        public long memory_free_calc
        {
            get
            {
                Host_metrics host_metrics = Connection.Resolve(this.metrics);
                if (host_metrics == null)
                    return 0;

                long used = memory_overhead;
                foreach (VM vm in Connection.ResolveAll(resident_VMs))
                {
                    used += vm.memory_overhead;
                    VM_metrics vm_metrics = vm.Connection.Resolve(vm.metrics);
                    if (vm_metrics != null)
                        used += vm_metrics.memory_actual;
                }

                // This hack is needed because of bug CA-32509. xapi uses a deliberately generous
                // estimate of VM.memory_overhead: but the low-level squeezer code doesn't (and can't)
                // know about the same calculation, and so uses some of this memory_overhead for the
                // VM's memory_actual. This causes up to 1MB of double-counting per VM.
                return ((host_metrics.memory_total > used) ? (host_metrics.memory_total - used) : 0);
            }
        }

        /// <summary>
        /// The total of all the dynamic_minimum memories of all resident VMs other than the control domain.
        /// For non-ballonable VMs, we use the static_maximum instead, because the dynamic_minimum has no effect.
        /// </summary>
        public long tot_dyn_min
        {
            get
            {
                long ans = 0;
                foreach (VM vm in Connection.ResolveAll(resident_VMs))
                {
                    if (!vm.is_control_domain)
                        ans += vm.has_ballooning ? vm.memory_dynamic_min : vm.memory_static_max;
                }
                return ans;
           }
        }

        /// <summary>
        /// The total of all the dynamic_maximum memories of all resident VMs other than the control domain.
        /// For non-ballonable VMs, we use the static_maximum instead, because the dynamic_maximum has no effect.
        /// </summary>
        public long tot_dyn_max
        {
            get
            {
                long ans = 0;
                foreach (VM vm in Connection.ResolveAll(resident_VMs))
                {
                    if (!vm.is_control_domain)
                        ans += vm.has_ballooning ? vm.memory_dynamic_max : vm.memory_static_max;
                }
                return ans;
            }
        }

        /// <summary>
        /// The amount of available memory on the host. This is not the same as the amount of free memory, because
        /// it includes the memory that could be freed by reducing balloonable VMs to their dynamic_minimum memory.
        /// </summary>
        public long memory_available_calc
        {
            get
            {
                Host_metrics host_metrics = Connection.Resolve(this.metrics);
                if (host_metrics == null)
                    return 0;

                long avail = host_metrics.memory_total - tot_dyn_min - xen_memory_calc;
                if (avail < 0)
                    avail = 0;   // I don't think this can happen, but I'm nervous about CA-32509: play it safe
                return avail;
            }
        }

        /// <summary>
        /// The amount of memory used by Xen, including the control domain plus host and VM overheads.
        /// Used to calculate this as total - free - tot_vm_mem, but that caused xen_mem to jump around
        /// during VM startup/shutdown because some changes happen before others.
        /// </summary>
        public long xen_memory_calc
        {
            get
            {
                long xen_mem = memory_overhead;
                foreach (VM vm in Connection.ResolveAll(resident_VMs))
                {
                    xen_mem += vm.memory_overhead;
                    if (vm.is_control_domain)
                    {
                        VM_metrics vmMetrics = vm.Connection.Resolve(vm.metrics);
                        if (vmMetrics != null)
                            xen_mem += vmMetrics.memory_actual;
                    }
                }
                return xen_mem;
            }
        }

        /// <summary>
        /// Friendly string showing memory usage on the host
        /// </summary>
        public string HostMemoryString
        {
            get
            {
                Host_metrics m = Connection.Resolve(metrics);
                if (m == null)
                    return Messages.GENERAL_UNKNOWN;

                long ServerMBAvail = memory_available_calc;
                long ServerMBTotal = m.memory_total;

                return string.Format(Messages.GENERAL_MEMORY_SERVER_FREE,
                    Util.MemorySizeStringSuitableUnits(ServerMBAvail, true),
                    Util.MemorySizeStringSuitableUnits(ServerMBTotal, true));
            }
        }

        /// <summary>
        /// A friendly string for the XenMemory on this host
        /// </summary>
        public string XenMemoryString
        {
            get
            {
                if (Connection.Resolve(metrics) == null)
                    return Messages.GENERAL_UNKNOWN;

                return Util.MemorySizeStringSuitableUnits(xen_memory_calc, true);
            }
        }

        /// <summary>
        /// A friendly string of the resident VM's memory usage, with each entry separated by a line break
        /// </summary>
        public string ResidentVMMemoryUsageString
        {
            get
            {
                Host_metrics m = Connection.Resolve(metrics);

                if (m == null)
                    return Messages.GENERAL_UNKNOWN;
                else
                {
                    List<string> lines = new List<string>();

                    foreach (VM vm in Connection.ResolveAll(resident_VMs))
                    {
                        if (vm.is_control_domain)
                            continue;

                        VM_metrics VMMetrics = Connection.Resolve(vm.metrics);
                        if (VMMetrics == null)
                            continue;

                        string message = string.Format(Messages.GENERAL_MEMORY_VM_USED, vm.Name,
                                Util.MemorySizeStringSuitableUnits(VMMetrics.memory_actual, true));

                        lines.Add(message);
                    }

                    return string.Join("\n", lines.ToArray());
                }
            }
        }

        /// <summary>
        /// Wait about two minutes for all the PBDs on this host to become plugged:
        /// if they do not, try and plug them. (Refs: CA-41219, CA-41305, CA-66496).
        /// </summary>
        public void CheckAndPlugPBDs()
        {
            bool allPBDsReady = false;
            int timeout = 120;
            log.DebugFormat("Waiting for PBDs on host {0} to become plugged", Name);
            
            do
            {
                if (this.enabled)  // if the Host is not yet enabled, pbd.currently_attached may not be accurate: see CA-66496.
                {
                    allPBDsReady = true;
                    foreach (PBD pbd in Connection.ResolveAll(PBDs))
                    {
                        if (!pbd.currently_attached)
                        {
                            allPBDsReady = false;
                            break;
                        }
                    }
                }

                if (!allPBDsReady)
                {
                    Thread.Sleep(1000);
                    timeout--;
                }
            } while (!allPBDsReady && timeout > 0);

            if (allPBDsReady)
                return;

            foreach (var pbd in Connection.ResolveAll(PBDs))
            {
                if (pbd.currently_attached)
                    continue;

                Session session = Connection.DuplicateSession();

                // If we still havent plugged, then try and plug it - this will probably
                // fail, but at least we'll get a better error message.

                try
                {
                    log.DebugFormat("Plugging PBD {0} on host {1}", pbd.Name, Name);
                    PBD.plug(session, pbd.opaque_ref);
                }
                catch (Exception e)
                {
                    log.Debug(string.Format("Error plugging PBD {0} on host {1}", pbd.Name, Name), e);
                }
            }
        }
        /// <summary>
        /// Whether the host is running the vSwitch network stack
        /// </summary>
        public bool vSwitchNetworkBackend
        {
            get
            {
                return software_version.ContainsKey("network_backend") &&
                       software_version["network_backend"] == "openvswitch";
            }
        }

        /// <summary>
        /// The number of CPU sockets the host has
        /// Return 0 if a problem is found
        /// </summary>
        public virtual int CpuSockets
        {
            get
            {
                const string key = "socket_count";
                const int defaultSockets = 0;

                if (cpu_info == null || !cpu_info.ContainsKey(key))
                    return defaultSockets;

                int sockets;
                bool parsed = int.TryParse(cpu_info[key], out sockets);
                if (!parsed)
                    return defaultSockets;
                
                return sockets;

            }
        }

        /// <summary>
        /// The number of cpus the host has
        /// Return 0 if a problem is found
        /// </summary>
        public int CpuCount
        {
            get
            {
                const string key = "cpu_count";
                const int defaultCpuCount = 0;

                if (cpu_info == null || !cpu_info.ContainsKey(key))
                    return defaultCpuCount;

                int cpuCount;
                bool parsed = int.TryParse(cpu_info[key], out cpuCount);
                if (!parsed)
                    return defaultCpuCount;

                return cpuCount;
            }
        }

        /// <summary>
        /// The number of cores per socket the host has
        /// Return 0 if a problem is found
        /// </summary>
        public int CoresPerSocket
        {
            get
            {
                var sockets = CpuSockets;
                var cpuCount = CpuCount;
                if (sockets > 0 && cpuCount > 0)
                    return (cpuCount/sockets);

                return 0;
            }
        }

        /// <summary>
        /// Is the host allowed to install hotfixes or are they restricted?
        /// </summary>
        public virtual bool CanApplyHotfixes
        {
            get
            {
                if(!Helpers.ClearwaterOrGreater(Connection))
                    return true;
                
                return !Helpers.FeatureForbidden(Connection, RestrictHotfixApply);
            }
        }

        /// <summary>
        /// Grace is either upgrade or regular
        /// </summary>
        public virtual bool InGrace
        {
            get { return license_params.ContainsKey("grace"); }
        }

        internal override string LocationString
        {
            get
            {
                //for standalone hosts we do not show redundant location info
                return Helpers.GetPool(Connection) == null ? string.Empty : base.LocationString;
            }
        }

        public bool EnterpriseFeaturesEnabled
        {
            get
            {
                var hostEdition = GetEdition(edition);
                return EligibleForSupport && (hostEdition == Edition.EnterprisePerSocket || hostEdition == Edition.EnterprisePerUser
                    || hostEdition == Edition.PerSocket);
            }
        }

        public bool DesktopPlusFeaturesEnabled
        {
            get
            {
                return GetEdition(edition) == Edition.DesktopPlus;
            }
        }

        public bool DesktopFeaturesEnabled
        {
            get
            {
                return GetEdition(edition) == Edition.Desktop;
            }
        }

        public bool EligibleForSupport
        {
            get
            {
                return (Helpers.CreedenceOrGreater(this) &&  GetEdition(edition) != Edition.Free);
            }
        }

        #region Supplemental Packs

        // From http://scale.uk.xensource.com/confluence/display/engp/Supplemental+Pack+product+design+notes#SupplementalPackproductdesignnotes-XenAPI:
        // The supplemental packs that are installed on a host are listed in the host's Host.software_version field in the data model.
        // The keys of the entries have the form "<originator>:<name>", the value is "<description>, version <version>", appended by
        // ", build <build>" if the build number is present in the XML file, and further appended by ", homogeneous" if the
        // enforce-homogeneity attribute is present and set to true.
        //
        // Examples:
        // xs:main: Base Pack, version 5.5.900, build 19689c
        // xs:linux: Linux Pack, version 5.5.900, build 19689c, homogeneous

        public class SuppPack
        {
            private string originator, name, description, version, build;
            private bool homogeneous;

            public string Originator { get { return originator; } }
            public string Name { get { return name; } }
            public string Description { get { return description; } }
            public string Version { get { return version; } }
            public string Build { get { return build; } }
            public bool Homogeneous { get { return homogeneous; } }

            public string OriginatorAndName { get { return originator + ":" + name; } }

            private bool parsed = false;
            public bool IsValid { get { return parsed; } }

            public string LongDescription { get { return string.Format(Messages.SUPP_PACK_DESCTIPTION, description, version); } }

            /// <summary>
            /// Try to parse the supp pack information from one key of software_version
            /// </summary>
            public SuppPack(string key, string value)
            {
                // Parse the key
                string[] splitKey = key.Split(':');
                if (splitKey.Length != 2)
                    return;
                originator = splitKey[0];
                name = splitKey[1];

                // Parse the value. The description may contain arbitrary text, so we have to be a bit subtle:
                // we first search from the end to find where the description ends.
                int x = value.LastIndexOf(", version ");
                if (x <= 0)
                    return;

                description = value.Substring(0, x);
                string val = value.Substring(x + 10);

                string[] delims = new string[] {", "};
                string[] splitValue = val.Split(delims, StringSplitOptions.None);
                if (splitValue.Length == 0 || splitValue.Length > 3)
                    return;

                version = splitValue[0];

                if (splitValue.Length >= 2)
                {
                    if (!splitValue[1].StartsWith("build "))
                        return;
                    build = splitValue[1].Substring(6);
                }

                if (splitValue.Length >= 3)
                {
                    if (splitValue[2] != "homogeneous")
                        return;
                    homogeneous = true;
                }
                else
                    homogeneous = false;

                parsed = true;
            }
        }


        /// <summary>
        /// Return a list of the supplemental packs
        /// </summary>
        public List<SuppPack> SuppPacks
        {
            get
            {
                List<SuppPack> packs = new List<SuppPack>();
                if (software_version == null)
                    return packs;
                foreach (string key in software_version.Keys)
                {
                    SuppPack pack = new SuppPack(key, software_version[key]);
                    if (pack.IsValid)
                        packs.Add(pack);
                }
                return packs;
            }
        }

        public bool CanInstallSuppPack
        {
            get
            {
                return Helpers.CreamOrGreater(Connection);
            }
        }
        #endregion

        /// <summary>
        /// The PGPU that is the system display device or null
        /// </summary>
        public PGPU SystemDisplayDevice
        {
            get
            {
                var pGpus = Connection.ResolveAll(PGPUs);
                return pGpus.FirstOrDefault(pGpu => pGpu.is_system_display_device);
            }
        }

        /// <summary>
        /// Is the host allowed to enable/disable integrated GPU passthrough or is the feature unavailable/restricted?
        /// </summary>
        public bool CanEnableDisableIntegratedGpu
        {
            get
            {
                return Helpers.CreamOrGreater(Connection)
                    && Helpers.GpuCapability(Connection)
                    && !Helpers.FeatureForbidden(Connection, RestrictIntegratedGpuPassthrough);
            }
        }

        #region IEquatable<Host> Members

        /// <summary>
        /// Indicates whether the current object is equal to the specified object. This calls the implementation from XenObject.
        /// This implementation is required for ToStringWrapper.
        /// </summary>
        public bool Equals(Host other)
        {
            return base.Equals(other);
        }

        #endregion
    }
}
