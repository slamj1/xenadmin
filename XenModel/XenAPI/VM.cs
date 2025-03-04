/*
 * Copyright (c) Citrix Systems, Inc.
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 
 *   1) Redistributions of source code must retain the above copyright
 *      notice, this list of conditions and the following disclaimer.
 * 
 *   2) Redistributions in binary form must reproduce the above
 *      copyright notice, this list of conditions and the following
 *      disclaimer in the documentation and/or other materials
 *      provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
 * FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
 * COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
 * STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
 * OF THE POSSIBILITY OF SUCH DAMAGE.
 */


using System;
using System.Collections;
using System.Collections.Generic;

using CookComputing.XmlRpc;


namespace XenAPI
{
    /// <summary>
    /// A virtual machine (or 'guest').
    /// First published in XenServer 4.0.
    /// </summary>
    public partial class VM : XenObject<VM>
    {
        public VM()
        {
        }

        public VM(string uuid,
            List<vm_operations> allowed_operations,
            Dictionary<string, vm_operations> current_operations,
            vm_power_state power_state,
            string name_label,
            string name_description,
            long user_version,
            bool is_a_template,
            XenRef<VDI> suspend_VDI,
            XenRef<Host> resident_on,
            XenRef<Host> affinity,
            long memory_overhead,
            long memory_target,
            long memory_static_max,
            long memory_dynamic_max,
            long memory_dynamic_min,
            long memory_static_min,
            Dictionary<string, string> VCPUs_params,
            long VCPUs_max,
            long VCPUs_at_startup,
            on_normal_exit actions_after_shutdown,
            on_normal_exit actions_after_reboot,
            on_crash_behaviour actions_after_crash,
            List<XenRef<Console>> consoles,
            List<XenRef<VIF>> VIFs,
            List<XenRef<VBD>> VBDs,
            List<XenRef<Crashdump>> crash_dumps,
            List<XenRef<VTPM>> VTPMs,
            string PV_bootloader,
            string PV_kernel,
            string PV_ramdisk,
            string PV_args,
            string PV_bootloader_args,
            string PV_legacy_args,
            string HVM_boot_policy,
            Dictionary<string, string> HVM_boot_params,
            double HVM_shadow_multiplier,
            Dictionary<string, string> platform,
            string PCI_bus,
            Dictionary<string, string> other_config,
            long domid,
            string domarch,
            Dictionary<string, string> last_boot_CPU_flags,
            bool is_control_domain,
            XenRef<VM_metrics> metrics,
            XenRef<VM_guest_metrics> guest_metrics,
            string last_booted_record,
            string recommendations,
            Dictionary<string, string> xenstore_data,
            bool ha_always_run,
            string ha_restart_priority,
            bool is_a_snapshot,
            XenRef<VM> snapshot_of,
            List<XenRef<VM>> snapshots,
            DateTime snapshot_time,
            string transportable_snapshot_id,
            Dictionary<string, XenRef<Blob>> blobs,
            string[] tags,
            Dictionary<vm_operations, string> blocked_operations,
            Dictionary<string, string> snapshot_info,
            string snapshot_metadata,
            XenRef<VM> parent,
            List<XenRef<VM>> children,
            Dictionary<string, string> bios_strings,
            XenRef<VMPP> protection_policy,
            bool is_snapshot_from_vmpp,
            XenRef<VM_appliance> appliance,
            long start_delay,
            long shutdown_delay,
            long order,
            List<XenRef<VGPU>> VGPUs,
            List<XenRef<PCI>> attached_PCIs,
            XenRef<SR> suspend_SR,
            long version,
            string generation_id,
            long hardware_platform_version,
            bool auto_update_drivers,
            bool has_vendor_device)
        {
            this.uuid = uuid;
            this.allowed_operations = allowed_operations;
            this.current_operations = current_operations;
            this.power_state = power_state;
            this.name_label = name_label;
            this.name_description = name_description;
            this.user_version = user_version;
            this.is_a_template = is_a_template;
            this.suspend_VDI = suspend_VDI;
            this.resident_on = resident_on;
            this.affinity = affinity;
            this.memory_overhead = memory_overhead;
            this.memory_target = memory_target;
            this.memory_static_max = memory_static_max;
            this.memory_dynamic_max = memory_dynamic_max;
            this.memory_dynamic_min = memory_dynamic_min;
            this.memory_static_min = memory_static_min;
            this.VCPUs_params = VCPUs_params;
            this.VCPUs_max = VCPUs_max;
            this.VCPUs_at_startup = VCPUs_at_startup;
            this.actions_after_shutdown = actions_after_shutdown;
            this.actions_after_reboot = actions_after_reboot;
            this.actions_after_crash = actions_after_crash;
            this.consoles = consoles;
            this.VIFs = VIFs;
            this.VBDs = VBDs;
            this.crash_dumps = crash_dumps;
            this.VTPMs = VTPMs;
            this.PV_bootloader = PV_bootloader;
            this.PV_kernel = PV_kernel;
            this.PV_ramdisk = PV_ramdisk;
            this.PV_args = PV_args;
            this.PV_bootloader_args = PV_bootloader_args;
            this.PV_legacy_args = PV_legacy_args;
            this.HVM_boot_policy = HVM_boot_policy;
            this.HVM_boot_params = HVM_boot_params;
            this.HVM_shadow_multiplier = HVM_shadow_multiplier;
            this.platform = platform;
            this.PCI_bus = PCI_bus;
            this.other_config = other_config;
            this.domid = domid;
            this.domarch = domarch;
            this.last_boot_CPU_flags = last_boot_CPU_flags;
            this.is_control_domain = is_control_domain;
            this.metrics = metrics;
            this.guest_metrics = guest_metrics;
            this.last_booted_record = last_booted_record;
            this.recommendations = recommendations;
            this.xenstore_data = xenstore_data;
            this.ha_always_run = ha_always_run;
            this.ha_restart_priority = ha_restart_priority;
            this.is_a_snapshot = is_a_snapshot;
            this.snapshot_of = snapshot_of;
            this.snapshots = snapshots;
            this.snapshot_time = snapshot_time;
            this.transportable_snapshot_id = transportable_snapshot_id;
            this.blobs = blobs;
            this.tags = tags;
            this.blocked_operations = blocked_operations;
            this.snapshot_info = snapshot_info;
            this.snapshot_metadata = snapshot_metadata;
            this.parent = parent;
            this.children = children;
            this.bios_strings = bios_strings;
            this.protection_policy = protection_policy;
            this.is_snapshot_from_vmpp = is_snapshot_from_vmpp;
            this.appliance = appliance;
            this.start_delay = start_delay;
            this.shutdown_delay = shutdown_delay;
            this.order = order;
            this.VGPUs = VGPUs;
            this.attached_PCIs = attached_PCIs;
            this.suspend_SR = suspend_SR;
            this.version = version;
            this.generation_id = generation_id;
            this.hardware_platform_version = hardware_platform_version;
            this.auto_update_drivers = auto_update_drivers;
            this.has_vendor_device = has_vendor_device;
        }

        /// <summary>
        /// Creates a new VM from a Proxy_VM.
        /// </summary>
        /// <param name="proxy"></param>
        public VM(Proxy_VM proxy)
        {
            this.UpdateFromProxy(proxy);
        }

        public override void UpdateFrom(VM update)
        {
            uuid = update.uuid;
            allowed_operations = update.allowed_operations;
            current_operations = update.current_operations;
            power_state = update.power_state;
            name_label = update.name_label;
            name_description = update.name_description;
            user_version = update.user_version;
            is_a_template = update.is_a_template;
            suspend_VDI = update.suspend_VDI;
            resident_on = update.resident_on;
            affinity = update.affinity;
            memory_overhead = update.memory_overhead;
            memory_target = update.memory_target;
            memory_static_max = update.memory_static_max;
            memory_dynamic_max = update.memory_dynamic_max;
            memory_dynamic_min = update.memory_dynamic_min;
            memory_static_min = update.memory_static_min;
            VCPUs_params = update.VCPUs_params;
            VCPUs_max = update.VCPUs_max;
            VCPUs_at_startup = update.VCPUs_at_startup;
            actions_after_shutdown = update.actions_after_shutdown;
            actions_after_reboot = update.actions_after_reboot;
            actions_after_crash = update.actions_after_crash;
            consoles = update.consoles;
            VIFs = update.VIFs;
            VBDs = update.VBDs;
            crash_dumps = update.crash_dumps;
            VTPMs = update.VTPMs;
            PV_bootloader = update.PV_bootloader;
            PV_kernel = update.PV_kernel;
            PV_ramdisk = update.PV_ramdisk;
            PV_args = update.PV_args;
            PV_bootloader_args = update.PV_bootloader_args;
            PV_legacy_args = update.PV_legacy_args;
            HVM_boot_policy = update.HVM_boot_policy;
            HVM_boot_params = update.HVM_boot_params;
            HVM_shadow_multiplier = update.HVM_shadow_multiplier;
            platform = update.platform;
            PCI_bus = update.PCI_bus;
            other_config = update.other_config;
            domid = update.domid;
            domarch = update.domarch;
            last_boot_CPU_flags = update.last_boot_CPU_flags;
            is_control_domain = update.is_control_domain;
            metrics = update.metrics;
            guest_metrics = update.guest_metrics;
            last_booted_record = update.last_booted_record;
            recommendations = update.recommendations;
            xenstore_data = update.xenstore_data;
            ha_always_run = update.ha_always_run;
            ha_restart_priority = update.ha_restart_priority;
            is_a_snapshot = update.is_a_snapshot;
            snapshot_of = update.snapshot_of;
            snapshots = update.snapshots;
            snapshot_time = update.snapshot_time;
            transportable_snapshot_id = update.transportable_snapshot_id;
            blobs = update.blobs;
            tags = update.tags;
            blocked_operations = update.blocked_operations;
            snapshot_info = update.snapshot_info;
            snapshot_metadata = update.snapshot_metadata;
            parent = update.parent;
            children = update.children;
            bios_strings = update.bios_strings;
            protection_policy = update.protection_policy;
            is_snapshot_from_vmpp = update.is_snapshot_from_vmpp;
            appliance = update.appliance;
            start_delay = update.start_delay;
            shutdown_delay = update.shutdown_delay;
            order = update.order;
            VGPUs = update.VGPUs;
            attached_PCIs = update.attached_PCIs;
            suspend_SR = update.suspend_SR;
            version = update.version;
            generation_id = update.generation_id;
            hardware_platform_version = update.hardware_platform_version;
            auto_update_drivers = update.auto_update_drivers;
            has_vendor_device = update.has_vendor_device;
        }

        internal void UpdateFromProxy(Proxy_VM proxy)
        {
            uuid = proxy.uuid == null ? null : (string)proxy.uuid;
            allowed_operations = proxy.allowed_operations == null ? null : Helper.StringArrayToEnumList<vm_operations>(proxy.allowed_operations);
            current_operations = proxy.current_operations == null ? null : Maps.convert_from_proxy_string_vm_operations(proxy.current_operations);
            power_state = proxy.power_state == null ? (vm_power_state) 0 : (vm_power_state)Helper.EnumParseDefault(typeof(vm_power_state), (string)proxy.power_state);
            name_label = proxy.name_label == null ? null : (string)proxy.name_label;
            name_description = proxy.name_description == null ? null : (string)proxy.name_description;
            user_version = proxy.user_version == null ? 0 : long.Parse((string)proxy.user_version);
            is_a_template = (bool)proxy.is_a_template;
            suspend_VDI = proxy.suspend_VDI == null ? null : XenRef<VDI>.Create(proxy.suspend_VDI);
            resident_on = proxy.resident_on == null ? null : XenRef<Host>.Create(proxy.resident_on);
            affinity = proxy.affinity == null ? null : XenRef<Host>.Create(proxy.affinity);
            memory_overhead = proxy.memory_overhead == null ? 0 : long.Parse((string)proxy.memory_overhead);
            memory_target = proxy.memory_target == null ? 0 : long.Parse((string)proxy.memory_target);
            memory_static_max = proxy.memory_static_max == null ? 0 : long.Parse((string)proxy.memory_static_max);
            memory_dynamic_max = proxy.memory_dynamic_max == null ? 0 : long.Parse((string)proxy.memory_dynamic_max);
            memory_dynamic_min = proxy.memory_dynamic_min == null ? 0 : long.Parse((string)proxy.memory_dynamic_min);
            memory_static_min = proxy.memory_static_min == null ? 0 : long.Parse((string)proxy.memory_static_min);
            VCPUs_params = proxy.VCPUs_params == null ? null : Maps.convert_from_proxy_string_string(proxy.VCPUs_params);
            VCPUs_max = proxy.VCPUs_max == null ? 0 : long.Parse((string)proxy.VCPUs_max);
            VCPUs_at_startup = proxy.VCPUs_at_startup == null ? 0 : long.Parse((string)proxy.VCPUs_at_startup);
            actions_after_shutdown = proxy.actions_after_shutdown == null ? (on_normal_exit) 0 : (on_normal_exit)Helper.EnumParseDefault(typeof(on_normal_exit), (string)proxy.actions_after_shutdown);
            actions_after_reboot = proxy.actions_after_reboot == null ? (on_normal_exit) 0 : (on_normal_exit)Helper.EnumParseDefault(typeof(on_normal_exit), (string)proxy.actions_after_reboot);
            actions_after_crash = proxy.actions_after_crash == null ? (on_crash_behaviour) 0 : (on_crash_behaviour)Helper.EnumParseDefault(typeof(on_crash_behaviour), (string)proxy.actions_after_crash);
            consoles = proxy.consoles == null ? null : XenRef<Console>.Create(proxy.consoles);
            VIFs = proxy.VIFs == null ? null : XenRef<VIF>.Create(proxy.VIFs);
            VBDs = proxy.VBDs == null ? null : XenRef<VBD>.Create(proxy.VBDs);
            crash_dumps = proxy.crash_dumps == null ? null : XenRef<Crashdump>.Create(proxy.crash_dumps);
            VTPMs = proxy.VTPMs == null ? null : XenRef<VTPM>.Create(proxy.VTPMs);
            PV_bootloader = proxy.PV_bootloader == null ? null : (string)proxy.PV_bootloader;
            PV_kernel = proxy.PV_kernel == null ? null : (string)proxy.PV_kernel;
            PV_ramdisk = proxy.PV_ramdisk == null ? null : (string)proxy.PV_ramdisk;
            PV_args = proxy.PV_args == null ? null : (string)proxy.PV_args;
            PV_bootloader_args = proxy.PV_bootloader_args == null ? null : (string)proxy.PV_bootloader_args;
            PV_legacy_args = proxy.PV_legacy_args == null ? null : (string)proxy.PV_legacy_args;
            HVM_boot_policy = proxy.HVM_boot_policy == null ? null : (string)proxy.HVM_boot_policy;
            HVM_boot_params = proxy.HVM_boot_params == null ? null : Maps.convert_from_proxy_string_string(proxy.HVM_boot_params);
            HVM_shadow_multiplier = Convert.ToDouble(proxy.HVM_shadow_multiplier);
            platform = proxy.platform == null ? null : Maps.convert_from_proxy_string_string(proxy.platform);
            PCI_bus = proxy.PCI_bus == null ? null : (string)proxy.PCI_bus;
            other_config = proxy.other_config == null ? null : Maps.convert_from_proxy_string_string(proxy.other_config);
            domid = proxy.domid == null ? 0 : long.Parse((string)proxy.domid);
            domarch = proxy.domarch == null ? null : (string)proxy.domarch;
            last_boot_CPU_flags = proxy.last_boot_CPU_flags == null ? null : Maps.convert_from_proxy_string_string(proxy.last_boot_CPU_flags);
            is_control_domain = (bool)proxy.is_control_domain;
            metrics = proxy.metrics == null ? null : XenRef<VM_metrics>.Create(proxy.metrics);
            guest_metrics = proxy.guest_metrics == null ? null : XenRef<VM_guest_metrics>.Create(proxy.guest_metrics);
            last_booted_record = proxy.last_booted_record == null ? null : (string)proxy.last_booted_record;
            recommendations = proxy.recommendations == null ? null : (string)proxy.recommendations;
            xenstore_data = proxy.xenstore_data == null ? null : Maps.convert_from_proxy_string_string(proxy.xenstore_data);
            ha_always_run = (bool)proxy.ha_always_run;
            ha_restart_priority = proxy.ha_restart_priority == null ? null : (string)proxy.ha_restart_priority;
            is_a_snapshot = (bool)proxy.is_a_snapshot;
            snapshot_of = proxy.snapshot_of == null ? null : XenRef<VM>.Create(proxy.snapshot_of);
            snapshots = proxy.snapshots == null ? null : XenRef<VM>.Create(proxy.snapshots);
            snapshot_time = proxy.snapshot_time;
            transportable_snapshot_id = proxy.transportable_snapshot_id == null ? null : (string)proxy.transportable_snapshot_id;
            blobs = proxy.blobs == null ? null : Maps.convert_from_proxy_string_XenRefBlob(proxy.blobs);
            tags = proxy.tags == null ? new string[] {} : (string [])proxy.tags;
            blocked_operations = proxy.blocked_operations == null ? null : Maps.convert_from_proxy_vm_operations_string(proxy.blocked_operations);
            snapshot_info = proxy.snapshot_info == null ? null : Maps.convert_from_proxy_string_string(proxy.snapshot_info);
            snapshot_metadata = proxy.snapshot_metadata == null ? null : (string)proxy.snapshot_metadata;
            parent = proxy.parent == null ? null : XenRef<VM>.Create(proxy.parent);
            children = proxy.children == null ? null : XenRef<VM>.Create(proxy.children);
            bios_strings = proxy.bios_strings == null ? null : Maps.convert_from_proxy_string_string(proxy.bios_strings);
            protection_policy = proxy.protection_policy == null ? null : XenRef<VMPP>.Create(proxy.protection_policy);
            is_snapshot_from_vmpp = (bool)proxy.is_snapshot_from_vmpp;
            appliance = proxy.appliance == null ? null : XenRef<VM_appliance>.Create(proxy.appliance);
            start_delay = proxy.start_delay == null ? 0 : long.Parse((string)proxy.start_delay);
            shutdown_delay = proxy.shutdown_delay == null ? 0 : long.Parse((string)proxy.shutdown_delay);
            order = proxy.order == null ? 0 : long.Parse((string)proxy.order);
            VGPUs = proxy.VGPUs == null ? null : XenRef<VGPU>.Create(proxy.VGPUs);
            attached_PCIs = proxy.attached_PCIs == null ? null : XenRef<PCI>.Create(proxy.attached_PCIs);
            suspend_SR = proxy.suspend_SR == null ? null : XenRef<SR>.Create(proxy.suspend_SR);
            version = proxy.version == null ? 0 : long.Parse((string)proxy.version);
            generation_id = proxy.generation_id == null ? null : (string)proxy.generation_id;
            hardware_platform_version = proxy.hardware_platform_version == null ? 0 : long.Parse((string)proxy.hardware_platform_version);
            auto_update_drivers = (bool)proxy.auto_update_drivers;
            has_vendor_device = (bool)proxy.has_vendor_device;
        }

        public Proxy_VM ToProxy()
        {
            Proxy_VM result_ = new Proxy_VM();
            result_.uuid = (uuid != null) ? uuid : "";
            result_.allowed_operations = (allowed_operations != null) ? Helper.ObjectListToStringArray(allowed_operations) : new string[] {};
            result_.current_operations = Maps.convert_to_proxy_string_vm_operations(current_operations);
            result_.power_state = vm_power_state_helper.ToString(power_state);
            result_.name_label = (name_label != null) ? name_label : "";
            result_.name_description = (name_description != null) ? name_description : "";
            result_.user_version = user_version.ToString();
            result_.is_a_template = is_a_template;
            result_.suspend_VDI = (suspend_VDI != null) ? suspend_VDI : "";
            result_.resident_on = (resident_on != null) ? resident_on : "";
            result_.affinity = (affinity != null) ? affinity : "";
            result_.memory_overhead = memory_overhead.ToString();
            result_.memory_target = memory_target.ToString();
            result_.memory_static_max = memory_static_max.ToString();
            result_.memory_dynamic_max = memory_dynamic_max.ToString();
            result_.memory_dynamic_min = memory_dynamic_min.ToString();
            result_.memory_static_min = memory_static_min.ToString();
            result_.VCPUs_params = Maps.convert_to_proxy_string_string(VCPUs_params);
            result_.VCPUs_max = VCPUs_max.ToString();
            result_.VCPUs_at_startup = VCPUs_at_startup.ToString();
            result_.actions_after_shutdown = on_normal_exit_helper.ToString(actions_after_shutdown);
            result_.actions_after_reboot = on_normal_exit_helper.ToString(actions_after_reboot);
            result_.actions_after_crash = on_crash_behaviour_helper.ToString(actions_after_crash);
            result_.consoles = (consoles != null) ? Helper.RefListToStringArray(consoles) : new string[] {};
            result_.VIFs = (VIFs != null) ? Helper.RefListToStringArray(VIFs) : new string[] {};
            result_.VBDs = (VBDs != null) ? Helper.RefListToStringArray(VBDs) : new string[] {};
            result_.crash_dumps = (crash_dumps != null) ? Helper.RefListToStringArray(crash_dumps) : new string[] {};
            result_.VTPMs = (VTPMs != null) ? Helper.RefListToStringArray(VTPMs) : new string[] {};
            result_.PV_bootloader = (PV_bootloader != null) ? PV_bootloader : "";
            result_.PV_kernel = (PV_kernel != null) ? PV_kernel : "";
            result_.PV_ramdisk = (PV_ramdisk != null) ? PV_ramdisk : "";
            result_.PV_args = (PV_args != null) ? PV_args : "";
            result_.PV_bootloader_args = (PV_bootloader_args != null) ? PV_bootloader_args : "";
            result_.PV_legacy_args = (PV_legacy_args != null) ? PV_legacy_args : "";
            result_.HVM_boot_policy = (HVM_boot_policy != null) ? HVM_boot_policy : "";
            result_.HVM_boot_params = Maps.convert_to_proxy_string_string(HVM_boot_params);
            result_.HVM_shadow_multiplier = HVM_shadow_multiplier;
            result_.platform = Maps.convert_to_proxy_string_string(platform);
            result_.PCI_bus = (PCI_bus != null) ? PCI_bus : "";
            result_.other_config = Maps.convert_to_proxy_string_string(other_config);
            result_.domid = domid.ToString();
            result_.domarch = (domarch != null) ? domarch : "";
            result_.last_boot_CPU_flags = Maps.convert_to_proxy_string_string(last_boot_CPU_flags);
            result_.is_control_domain = is_control_domain;
            result_.metrics = (metrics != null) ? metrics : "";
            result_.guest_metrics = (guest_metrics != null) ? guest_metrics : "";
            result_.last_booted_record = (last_booted_record != null) ? last_booted_record : "";
            result_.recommendations = (recommendations != null) ? recommendations : "";
            result_.xenstore_data = Maps.convert_to_proxy_string_string(xenstore_data);
            result_.ha_always_run = ha_always_run;
            result_.ha_restart_priority = (ha_restart_priority != null) ? ha_restart_priority : "";
            result_.is_a_snapshot = is_a_snapshot;
            result_.snapshot_of = (snapshot_of != null) ? snapshot_of : "";
            result_.snapshots = (snapshots != null) ? Helper.RefListToStringArray(snapshots) : new string[] {};
            result_.snapshot_time = snapshot_time;
            result_.transportable_snapshot_id = (transportable_snapshot_id != null) ? transportable_snapshot_id : "";
            result_.blobs = Maps.convert_to_proxy_string_XenRefBlob(blobs);
            result_.tags = tags;
            result_.blocked_operations = Maps.convert_to_proxy_vm_operations_string(blocked_operations);
            result_.snapshot_info = Maps.convert_to_proxy_string_string(snapshot_info);
            result_.snapshot_metadata = (snapshot_metadata != null) ? snapshot_metadata : "";
            result_.parent = (parent != null) ? parent : "";
            result_.children = (children != null) ? Helper.RefListToStringArray(children) : new string[] {};
            result_.bios_strings = Maps.convert_to_proxy_string_string(bios_strings);
            result_.protection_policy = (protection_policy != null) ? protection_policy : "";
            result_.is_snapshot_from_vmpp = is_snapshot_from_vmpp;
            result_.appliance = (appliance != null) ? appliance : "";
            result_.start_delay = start_delay.ToString();
            result_.shutdown_delay = shutdown_delay.ToString();
            result_.order = order.ToString();
            result_.VGPUs = (VGPUs != null) ? Helper.RefListToStringArray(VGPUs) : new string[] {};
            result_.attached_PCIs = (attached_PCIs != null) ? Helper.RefListToStringArray(attached_PCIs) : new string[] {};
            result_.suspend_SR = (suspend_SR != null) ? suspend_SR : "";
            result_.version = version.ToString();
            result_.generation_id = (generation_id != null) ? generation_id : "";
            result_.hardware_platform_version = hardware_platform_version.ToString();
            result_.auto_update_drivers = auto_update_drivers;
            result_.has_vendor_device = has_vendor_device;
            return result_;
        }

        /// <summary>
        /// Creates a new VM from a Hashtable.
        /// </summary>
        /// <param name="table"></param>
        public VM(Hashtable table)
        {
            uuid = Marshalling.ParseString(table, "uuid");
            allowed_operations = Helper.StringArrayToEnumList<vm_operations>(Marshalling.ParseStringArray(table, "allowed_operations"));
            current_operations = Maps.convert_from_proxy_string_vm_operations(Marshalling.ParseHashTable(table, "current_operations"));
            power_state = (vm_power_state)Helper.EnumParseDefault(typeof(vm_power_state), Marshalling.ParseString(table, "power_state"));
            name_label = Marshalling.ParseString(table, "name_label");
            name_description = Marshalling.ParseString(table, "name_description");
            user_version = Marshalling.ParseLong(table, "user_version");
            is_a_template = Marshalling.ParseBool(table, "is_a_template");
            suspend_VDI = Marshalling.ParseRef<VDI>(table, "suspend_VDI");
            resident_on = Marshalling.ParseRef<Host>(table, "resident_on");
            affinity = Marshalling.ParseRef<Host>(table, "affinity");
            memory_overhead = Marshalling.ParseLong(table, "memory_overhead");
            memory_target = Marshalling.ParseLong(table, "memory_target");
            memory_static_max = Marshalling.ParseLong(table, "memory_static_max");
            memory_dynamic_max = Marshalling.ParseLong(table, "memory_dynamic_max");
            memory_dynamic_min = Marshalling.ParseLong(table, "memory_dynamic_min");
            memory_static_min = Marshalling.ParseLong(table, "memory_static_min");
            VCPUs_params = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "VCPUs_params"));
            VCPUs_max = Marshalling.ParseLong(table, "VCPUs_max");
            VCPUs_at_startup = Marshalling.ParseLong(table, "VCPUs_at_startup");
            actions_after_shutdown = (on_normal_exit)Helper.EnumParseDefault(typeof(on_normal_exit), Marshalling.ParseString(table, "actions_after_shutdown"));
            actions_after_reboot = (on_normal_exit)Helper.EnumParseDefault(typeof(on_normal_exit), Marshalling.ParseString(table, "actions_after_reboot"));
            actions_after_crash = (on_crash_behaviour)Helper.EnumParseDefault(typeof(on_crash_behaviour), Marshalling.ParseString(table, "actions_after_crash"));
            consoles = Marshalling.ParseSetRef<Console>(table, "consoles");
            VIFs = Marshalling.ParseSetRef<VIF>(table, "VIFs");
            VBDs = Marshalling.ParseSetRef<VBD>(table, "VBDs");
            crash_dumps = Marshalling.ParseSetRef<Crashdump>(table, "crash_dumps");
            VTPMs = Marshalling.ParseSetRef<VTPM>(table, "VTPMs");
            PV_bootloader = Marshalling.ParseString(table, "PV_bootloader");
            PV_kernel = Marshalling.ParseString(table, "PV_kernel");
            PV_ramdisk = Marshalling.ParseString(table, "PV_ramdisk");
            PV_args = Marshalling.ParseString(table, "PV_args");
            PV_bootloader_args = Marshalling.ParseString(table, "PV_bootloader_args");
            PV_legacy_args = Marshalling.ParseString(table, "PV_legacy_args");
            HVM_boot_policy = Marshalling.ParseString(table, "HVM_boot_policy");
            HVM_boot_params = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "HVM_boot_params"));
            HVM_shadow_multiplier = Marshalling.ParseDouble(table, "HVM_shadow_multiplier");
            platform = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "platform"));
            PCI_bus = Marshalling.ParseString(table, "PCI_bus");
            other_config = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "other_config"));
            domid = Marshalling.ParseLong(table, "domid");
            domarch = Marshalling.ParseString(table, "domarch");
            last_boot_CPU_flags = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "last_boot_CPU_flags"));
            is_control_domain = Marshalling.ParseBool(table, "is_control_domain");
            metrics = Marshalling.ParseRef<VM_metrics>(table, "metrics");
            guest_metrics = Marshalling.ParseRef<VM_guest_metrics>(table, "guest_metrics");
            last_booted_record = Marshalling.ParseString(table, "last_booted_record");
            recommendations = Marshalling.ParseString(table, "recommendations");
            xenstore_data = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "xenstore_data"));
            ha_always_run = Marshalling.ParseBool(table, "ha_always_run");
            ha_restart_priority = Marshalling.ParseString(table, "ha_restart_priority");
            is_a_snapshot = Marshalling.ParseBool(table, "is_a_snapshot");
            snapshot_of = Marshalling.ParseRef<VM>(table, "snapshot_of");
            snapshots = Marshalling.ParseSetRef<VM>(table, "snapshots");
            snapshot_time = Marshalling.ParseDateTime(table, "snapshot_time");
            transportable_snapshot_id = Marshalling.ParseString(table, "transportable_snapshot_id");
            blobs = Maps.convert_from_proxy_string_XenRefBlob(Marshalling.ParseHashTable(table, "blobs"));
            tags = Marshalling.ParseStringArray(table, "tags");
            blocked_operations = Maps.convert_from_proxy_vm_operations_string(Marshalling.ParseHashTable(table, "blocked_operations"));
            snapshot_info = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "snapshot_info"));
            snapshot_metadata = Marshalling.ParseString(table, "snapshot_metadata");
            parent = Marshalling.ParseRef<VM>(table, "parent");
            children = Marshalling.ParseSetRef<VM>(table, "children");
            bios_strings = Maps.convert_from_proxy_string_string(Marshalling.ParseHashTable(table, "bios_strings"));
            protection_policy = Marshalling.ParseRef<VMPP>(table, "protection_policy");
            is_snapshot_from_vmpp = Marshalling.ParseBool(table, "is_snapshot_from_vmpp");
            appliance = Marshalling.ParseRef<VM_appliance>(table, "appliance");
            start_delay = Marshalling.ParseLong(table, "start_delay");
            shutdown_delay = Marshalling.ParseLong(table, "shutdown_delay");
            order = Marshalling.ParseLong(table, "order");
            VGPUs = Marshalling.ParseSetRef<VGPU>(table, "VGPUs");
            attached_PCIs = Marshalling.ParseSetRef<PCI>(table, "attached_PCIs");
            suspend_SR = Marshalling.ParseRef<SR>(table, "suspend_SR");
            version = Marshalling.ParseLong(table, "version");
            generation_id = Marshalling.ParseString(table, "generation_id");
            hardware_platform_version = Marshalling.ParseLong(table, "hardware_platform_version");
            auto_update_drivers = Marshalling.ParseBool(table, "auto_update_drivers");
            has_vendor_device = Marshalling.ParseBool(table, "has_vendor_device");
        }

        public bool DeepEquals(VM other, bool ignoreCurrentOperations)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            if (!ignoreCurrentOperations && !Helper.AreEqual2(this.current_operations, other.current_operations))
                return false;

            return Helper.AreEqual2(this._uuid, other._uuid) &&
                Helper.AreEqual2(this._allowed_operations, other._allowed_operations) &&
                Helper.AreEqual2(this._power_state, other._power_state) &&
                Helper.AreEqual2(this._name_label, other._name_label) &&
                Helper.AreEqual2(this._name_description, other._name_description) &&
                Helper.AreEqual2(this._user_version, other._user_version) &&
                Helper.AreEqual2(this._is_a_template, other._is_a_template) &&
                Helper.AreEqual2(this._suspend_VDI, other._suspend_VDI) &&
                Helper.AreEqual2(this._resident_on, other._resident_on) &&
                Helper.AreEqual2(this._affinity, other._affinity) &&
                Helper.AreEqual2(this._memory_overhead, other._memory_overhead) &&
                Helper.AreEqual2(this._memory_target, other._memory_target) &&
                Helper.AreEqual2(this._memory_static_max, other._memory_static_max) &&
                Helper.AreEqual2(this._memory_dynamic_max, other._memory_dynamic_max) &&
                Helper.AreEqual2(this._memory_dynamic_min, other._memory_dynamic_min) &&
                Helper.AreEqual2(this._memory_static_min, other._memory_static_min) &&
                Helper.AreEqual2(this._VCPUs_params, other._VCPUs_params) &&
                Helper.AreEqual2(this._VCPUs_max, other._VCPUs_max) &&
                Helper.AreEqual2(this._VCPUs_at_startup, other._VCPUs_at_startup) &&
                Helper.AreEqual2(this._actions_after_shutdown, other._actions_after_shutdown) &&
                Helper.AreEqual2(this._actions_after_reboot, other._actions_after_reboot) &&
                Helper.AreEqual2(this._actions_after_crash, other._actions_after_crash) &&
                Helper.AreEqual2(this._consoles, other._consoles) &&
                Helper.AreEqual2(this._VIFs, other._VIFs) &&
                Helper.AreEqual2(this._VBDs, other._VBDs) &&
                Helper.AreEqual2(this._crash_dumps, other._crash_dumps) &&
                Helper.AreEqual2(this._VTPMs, other._VTPMs) &&
                Helper.AreEqual2(this._PV_bootloader, other._PV_bootloader) &&
                Helper.AreEqual2(this._PV_kernel, other._PV_kernel) &&
                Helper.AreEqual2(this._PV_ramdisk, other._PV_ramdisk) &&
                Helper.AreEqual2(this._PV_args, other._PV_args) &&
                Helper.AreEqual2(this._PV_bootloader_args, other._PV_bootloader_args) &&
                Helper.AreEqual2(this._PV_legacy_args, other._PV_legacy_args) &&
                Helper.AreEqual2(this._HVM_boot_policy, other._HVM_boot_policy) &&
                Helper.AreEqual2(this._HVM_boot_params, other._HVM_boot_params) &&
                Helper.AreEqual2(this._HVM_shadow_multiplier, other._HVM_shadow_multiplier) &&
                Helper.AreEqual2(this._platform, other._platform) &&
                Helper.AreEqual2(this._PCI_bus, other._PCI_bus) &&
                Helper.AreEqual2(this._other_config, other._other_config) &&
                Helper.AreEqual2(this._domid, other._domid) &&
                Helper.AreEqual2(this._domarch, other._domarch) &&
                Helper.AreEqual2(this._last_boot_CPU_flags, other._last_boot_CPU_flags) &&
                Helper.AreEqual2(this._is_control_domain, other._is_control_domain) &&
                Helper.AreEqual2(this._metrics, other._metrics) &&
                Helper.AreEqual2(this._guest_metrics, other._guest_metrics) &&
                Helper.AreEqual2(this._last_booted_record, other._last_booted_record) &&
                Helper.AreEqual2(this._recommendations, other._recommendations) &&
                Helper.AreEqual2(this._xenstore_data, other._xenstore_data) &&
                Helper.AreEqual2(this._ha_always_run, other._ha_always_run) &&
                Helper.AreEqual2(this._ha_restart_priority, other._ha_restart_priority) &&
                Helper.AreEqual2(this._is_a_snapshot, other._is_a_snapshot) &&
                Helper.AreEqual2(this._snapshot_of, other._snapshot_of) &&
                Helper.AreEqual2(this._snapshots, other._snapshots) &&
                Helper.AreEqual2(this._snapshot_time, other._snapshot_time) &&
                Helper.AreEqual2(this._transportable_snapshot_id, other._transportable_snapshot_id) &&
                Helper.AreEqual2(this._blobs, other._blobs) &&
                Helper.AreEqual2(this._tags, other._tags) &&
                Helper.AreEqual2(this._blocked_operations, other._blocked_operations) &&
                Helper.AreEqual2(this._snapshot_info, other._snapshot_info) &&
                Helper.AreEqual2(this._snapshot_metadata, other._snapshot_metadata) &&
                Helper.AreEqual2(this._parent, other._parent) &&
                Helper.AreEqual2(this._children, other._children) &&
                Helper.AreEqual2(this._bios_strings, other._bios_strings) &&
                Helper.AreEqual2(this._protection_policy, other._protection_policy) &&
                Helper.AreEqual2(this._is_snapshot_from_vmpp, other._is_snapshot_from_vmpp) &&
                Helper.AreEqual2(this._appliance, other._appliance) &&
                Helper.AreEqual2(this._start_delay, other._start_delay) &&
                Helper.AreEqual2(this._shutdown_delay, other._shutdown_delay) &&
                Helper.AreEqual2(this._order, other._order) &&
                Helper.AreEqual2(this._VGPUs, other._VGPUs) &&
                Helper.AreEqual2(this._attached_PCIs, other._attached_PCIs) &&
                Helper.AreEqual2(this._suspend_SR, other._suspend_SR) &&
                Helper.AreEqual2(this._version, other._version) &&
                Helper.AreEqual2(this._generation_id, other._generation_id) &&
                Helper.AreEqual2(this._hardware_platform_version, other._hardware_platform_version) &&
                Helper.AreEqual2(this._auto_update_drivers, other._auto_update_drivers) &&
                Helper.AreEqual2(this._has_vendor_device, other._has_vendor_device);
        }

        public override string SaveChanges(Session session, string opaqueRef, VM server)
        {
            if (opaqueRef == null)
            {
                Proxy_VM p = this.ToProxy();
                return session.proxy.vm_create(session.uuid, p).parse();
            }
            else
            {
                if (!Helper.AreEqual2(_name_label, server._name_label))
                {
                    VM.set_name_label(session, opaqueRef, _name_label);
                }
                if (!Helper.AreEqual2(_name_description, server._name_description))
                {
                    VM.set_name_description(session, opaqueRef, _name_description);
                }
                if (!Helper.AreEqual2(_user_version, server._user_version))
                {
                    VM.set_user_version(session, opaqueRef, _user_version);
                }
                if (!Helper.AreEqual2(_is_a_template, server._is_a_template))
                {
                    VM.set_is_a_template(session, opaqueRef, _is_a_template);
                }
                if (!Helper.AreEqual2(_affinity, server._affinity))
                {
                    VM.set_affinity(session, opaqueRef, _affinity);
                }
                if (!Helper.AreEqual2(_VCPUs_params, server._VCPUs_params))
                {
                    VM.set_VCPUs_params(session, opaqueRef, _VCPUs_params);
                }
                if (!Helper.AreEqual2(_actions_after_shutdown, server._actions_after_shutdown))
                {
                    VM.set_actions_after_shutdown(session, opaqueRef, _actions_after_shutdown);
                }
                if (!Helper.AreEqual2(_actions_after_reboot, server._actions_after_reboot))
                {
                    VM.set_actions_after_reboot(session, opaqueRef, _actions_after_reboot);
                }
                if (!Helper.AreEqual2(_actions_after_crash, server._actions_after_crash))
                {
                    VM.set_actions_after_crash(session, opaqueRef, _actions_after_crash);
                }
                if (!Helper.AreEqual2(_PV_bootloader, server._PV_bootloader))
                {
                    VM.set_PV_bootloader(session, opaqueRef, _PV_bootloader);
                }
                if (!Helper.AreEqual2(_PV_kernel, server._PV_kernel))
                {
                    VM.set_PV_kernel(session, opaqueRef, _PV_kernel);
                }
                if (!Helper.AreEqual2(_PV_ramdisk, server._PV_ramdisk))
                {
                    VM.set_PV_ramdisk(session, opaqueRef, _PV_ramdisk);
                }
                if (!Helper.AreEqual2(_PV_args, server._PV_args))
                {
                    VM.set_PV_args(session, opaqueRef, _PV_args);
                }
                if (!Helper.AreEqual2(_PV_bootloader_args, server._PV_bootloader_args))
                {
                    VM.set_PV_bootloader_args(session, opaqueRef, _PV_bootloader_args);
                }
                if (!Helper.AreEqual2(_PV_legacy_args, server._PV_legacy_args))
                {
                    VM.set_PV_legacy_args(session, opaqueRef, _PV_legacy_args);
                }
                if (!Helper.AreEqual2(_HVM_boot_policy, server._HVM_boot_policy))
                {
                    VM.set_HVM_boot_policy(session, opaqueRef, _HVM_boot_policy);
                }
                if (!Helper.AreEqual2(_HVM_boot_params, server._HVM_boot_params))
                {
                    VM.set_HVM_boot_params(session, opaqueRef, _HVM_boot_params);
                }
                if (!Helper.AreEqual2(_platform, server._platform))
                {
                    VM.set_platform(session, opaqueRef, _platform);
                }
                if (!Helper.AreEqual2(_PCI_bus, server._PCI_bus))
                {
                    VM.set_PCI_bus(session, opaqueRef, _PCI_bus);
                }
                if (!Helper.AreEqual2(_other_config, server._other_config))
                {
                    VM.set_other_config(session, opaqueRef, _other_config);
                }
                if (!Helper.AreEqual2(_recommendations, server._recommendations))
                {
                    VM.set_recommendations(session, opaqueRef, _recommendations);
                }
                if (!Helper.AreEqual2(_xenstore_data, server._xenstore_data))
                {
                    VM.set_xenstore_data(session, opaqueRef, _xenstore_data);
                }
                if (!Helper.AreEqual2(_tags, server._tags))
                {
                    VM.set_tags(session, opaqueRef, _tags);
                }
                if (!Helper.AreEqual2(_blocked_operations, server._blocked_operations))
                {
                    VM.set_blocked_operations(session, opaqueRef, _blocked_operations);
                }
                if (!Helper.AreEqual2(_suspend_SR, server._suspend_SR))
                {
                    VM.set_suspend_SR(session, opaqueRef, _suspend_SR);
                }
                if (!Helper.AreEqual2(_hardware_platform_version, server._hardware_platform_version))
                {
                    VM.set_hardware_platform_version(session, opaqueRef, _hardware_platform_version);
                }
                if (!Helper.AreEqual2(_has_vendor_device, server._has_vendor_device))
                {
                    VM.set_has_vendor_device(session, opaqueRef, _has_vendor_device);
                }
                if (!Helper.AreEqual2(_memory_static_max, server._memory_static_max))
                {
                    VM.set_memory_static_max(session, opaqueRef, _memory_static_max);
                }
                if (!Helper.AreEqual2(_memory_dynamic_max, server._memory_dynamic_max))
                {
                    VM.set_memory_dynamic_max(session, opaqueRef, _memory_dynamic_max);
                }
                if (!Helper.AreEqual2(_memory_dynamic_min, server._memory_dynamic_min))
                {
                    VM.set_memory_dynamic_min(session, opaqueRef, _memory_dynamic_min);
                }
                if (!Helper.AreEqual2(_memory_static_min, server._memory_static_min))
                {
                    VM.set_memory_static_min(session, opaqueRef, _memory_static_min);
                }
                if (!Helper.AreEqual2(_VCPUs_max, server._VCPUs_max))
                {
                    VM.set_VCPUs_max(session, opaqueRef, _VCPUs_max);
                }
                if (!Helper.AreEqual2(_VCPUs_at_startup, server._VCPUs_at_startup))
                {
                    VM.set_VCPUs_at_startup(session, opaqueRef, _VCPUs_at_startup);
                }
                if (!Helper.AreEqual2(_HVM_shadow_multiplier, server._HVM_shadow_multiplier))
                {
                    VM.set_HVM_shadow_multiplier(session, opaqueRef, _HVM_shadow_multiplier);
                }
                if (!Helper.AreEqual2(_ha_always_run, server._ha_always_run))
                {
                    VM.set_ha_always_run(session, opaqueRef, _ha_always_run);
                }
                if (!Helper.AreEqual2(_ha_restart_priority, server._ha_restart_priority))
                {
                    VM.set_ha_restart_priority(session, opaqueRef, _ha_restart_priority);
                }
                if (!Helper.AreEqual2(_protection_policy, server._protection_policy))
                {
                    VM.set_protection_policy(session, opaqueRef, _protection_policy);
                }
                if (!Helper.AreEqual2(_appliance, server._appliance))
                {
                    VM.set_appliance(session, opaqueRef, _appliance);
                }
                if (!Helper.AreEqual2(_start_delay, server._start_delay))
                {
                    VM.set_start_delay(session, opaqueRef, _start_delay);
                }
                if (!Helper.AreEqual2(_shutdown_delay, server._shutdown_delay))
                {
                    VM.set_shutdown_delay(session, opaqueRef, _shutdown_delay);
                }
                if (!Helper.AreEqual2(_order, server._order))
                {
                    VM.set_order(session, opaqueRef, _order);
                }
                if (!Helper.AreEqual2(_auto_update_drivers, server._auto_update_drivers))
                {
                    VM.set_auto_update_drivers(session, opaqueRef, _auto_update_drivers);
                }

                return null;
            }
        }
        /// <summary>
        /// Get a record containing the current state of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static VM get_record(Session session, string _vm)
        {
            return new VM((Proxy_VM)session.proxy.vm_get_record(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get a reference to the VM instance with the specified UUID.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_uuid">UUID of object to return</param>
        public static XenRef<VM> get_by_uuid(Session session, string _uuid)
        {
            return XenRef<VM>.Create(session.proxy.vm_get_by_uuid(session.uuid, (_uuid != null) ? _uuid : "").parse());
        }

        /// <summary>
        /// Create a new VM instance, and return its handle.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_record">All constructor arguments</param>
        public static XenRef<VM> create(Session session, VM _record)
        {
            return XenRef<VM>.Create(session.proxy.vm_create(session.uuid, _record.ToProxy()).parse());
        }

        /// <summary>
        /// Create a new VM instance, and return its handle.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_record">All constructor arguments</param>
        public static XenRef<Task> async_create(Session session, VM _record)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_create(session.uuid, _record.ToProxy()).parse());
        }

        /// <summary>
        /// Destroy the specified VM.  The VM is completely removed from the system.  This function can only be called when the VM is in the Halted State.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void destroy(Session session, string _vm)
        {
            session.proxy.vm_destroy(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Destroy the specified VM.  The VM is completely removed from the system.  This function can only be called when the VM is in the Halted State.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_destroy(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_destroy(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get all the VM instances with the given label.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_label">label of object to return</param>
        public static List<XenRef<VM>> get_by_name_label(Session session, string _label)
        {
            return XenRef<VM>.Create(session.proxy.vm_get_by_name_label(session.uuid, (_label != null) ? _label : "").parse());
        }

        /// <summary>
        /// Get the uuid field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_uuid(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_uuid(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the allowed_operations field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static List<vm_operations> get_allowed_operations(Session session, string _vm)
        {
            return Helper.StringArrayToEnumList<vm_operations>(session.proxy.vm_get_allowed_operations(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the current_operations field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<string, vm_operations> get_current_operations(Session session, string _vm)
        {
            return Maps.convert_from_proxy_string_vm_operations(session.proxy.vm_get_current_operations(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the power_state field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static vm_power_state get_power_state(Session session, string _vm)
        {
            return (vm_power_state)Helper.EnumParseDefault(typeof(vm_power_state), (string)session.proxy.vm_get_power_state(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the name/label field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_name_label(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_name_label(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the name/description field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_name_description(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_name_description(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the user_version field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_user_version(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_user_version(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the is_a_template field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static bool get_is_a_template(Session session, string _vm)
        {
            return (bool)session.proxy.vm_get_is_a_template(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the suspend_VDI field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<VDI> get_suspend_VDI(Session session, string _vm)
        {
            return XenRef<VDI>.Create(session.proxy.vm_get_suspend_vdi(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the resident_on field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Host> get_resident_on(Session session, string _vm)
        {
            return XenRef<Host>.Create(session.proxy.vm_get_resident_on(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the affinity field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Host> get_affinity(Session session, string _vm)
        {
            return XenRef<Host>.Create(session.proxy.vm_get_affinity(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the memory/overhead field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_memory_overhead(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_memory_overhead(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the memory/target field of the given VM.
        /// First published in XenServer 4.0.
        /// Deprecated since XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        [Deprecated("XenServer 5.6")]
        public static long get_memory_target(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_memory_target(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the memory/static_max field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_memory_static_max(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_memory_static_max(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the memory/dynamic_max field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_memory_dynamic_max(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_memory_dynamic_max(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the memory/dynamic_min field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_memory_dynamic_min(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_memory_dynamic_min(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the memory/static_min field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_memory_static_min(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_memory_static_min(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the VCPUs/params field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<string, string> get_VCPUs_params(Session session, string _vm)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vm_get_vcpus_params(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the VCPUs/max field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_VCPUs_max(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_vcpus_max(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the VCPUs/at_startup field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_VCPUs_at_startup(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_vcpus_at_startup(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the actions/after_shutdown field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static on_normal_exit get_actions_after_shutdown(Session session, string _vm)
        {
            return (on_normal_exit)Helper.EnumParseDefault(typeof(on_normal_exit), (string)session.proxy.vm_get_actions_after_shutdown(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the actions/after_reboot field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static on_normal_exit get_actions_after_reboot(Session session, string _vm)
        {
            return (on_normal_exit)Helper.EnumParseDefault(typeof(on_normal_exit), (string)session.proxy.vm_get_actions_after_reboot(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the actions/after_crash field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static on_crash_behaviour get_actions_after_crash(Session session, string _vm)
        {
            return (on_crash_behaviour)Helper.EnumParseDefault(typeof(on_crash_behaviour), (string)session.proxy.vm_get_actions_after_crash(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the consoles field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static List<XenRef<Console>> get_consoles(Session session, string _vm)
        {
            return XenRef<Console>.Create(session.proxy.vm_get_consoles(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the VIFs field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static List<XenRef<VIF>> get_VIFs(Session session, string _vm)
        {
            return XenRef<VIF>.Create(session.proxy.vm_get_vifs(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the VBDs field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static List<XenRef<VBD>> get_VBDs(Session session, string _vm)
        {
            return XenRef<VBD>.Create(session.proxy.vm_get_vbds(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the crash_dumps field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static List<XenRef<Crashdump>> get_crash_dumps(Session session, string _vm)
        {
            return XenRef<Crashdump>.Create(session.proxy.vm_get_crash_dumps(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the VTPMs field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static List<XenRef<VTPM>> get_VTPMs(Session session, string _vm)
        {
            return XenRef<VTPM>.Create(session.proxy.vm_get_vtpms(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the PV/bootloader field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_PV_bootloader(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_pv_bootloader(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the PV/kernel field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_PV_kernel(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_pv_kernel(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the PV/ramdisk field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_PV_ramdisk(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_pv_ramdisk(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the PV/args field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_PV_args(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_pv_args(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the PV/bootloader_args field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_PV_bootloader_args(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_pv_bootloader_args(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the PV/legacy_args field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_PV_legacy_args(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_pv_legacy_args(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the HVM/boot_policy field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_HVM_boot_policy(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_hvm_boot_policy(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the HVM/boot_params field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<string, string> get_HVM_boot_params(Session session, string _vm)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vm_get_hvm_boot_params(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the HVM/shadow_multiplier field of the given VM.
        /// First published in XenServer 4.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static double get_HVM_shadow_multiplier(Session session, string _vm)
        {
            return Convert.ToDouble(session.proxy.vm_get_hvm_shadow_multiplier(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the platform field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<string, string> get_platform(Session session, string _vm)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vm_get_platform(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the PCI_bus field of the given VM.
        /// First published in XenServer 4.0.
        /// Deprecated since XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        [Deprecated("XenServer 6.0")]
        public static string get_PCI_bus(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_pci_bus(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the other_config field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<string, string> get_other_config(Session session, string _vm)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vm_get_other_config(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the domid field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_domid(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_domid(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the domarch field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_domarch(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_domarch(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the last_boot_CPU_flags field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<string, string> get_last_boot_CPU_flags(Session session, string _vm)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vm_get_last_boot_cpu_flags(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the is_control_domain field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static bool get_is_control_domain(Session session, string _vm)
        {
            return (bool)session.proxy.vm_get_is_control_domain(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the metrics field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<VM_metrics> get_metrics(Session session, string _vm)
        {
            return XenRef<VM_metrics>.Create(session.proxy.vm_get_metrics(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the guest_metrics field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<VM_guest_metrics> get_guest_metrics(Session session, string _vm)
        {
            return XenRef<VM_guest_metrics>.Create(session.proxy.vm_get_guest_metrics(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the last_booted_record field of the given VM.
        /// First published in XenServer 4.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_last_booted_record(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_last_booted_record(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the recommendations field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_recommendations(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_recommendations(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the xenstore_data field of the given VM.
        /// First published in XenServer 4.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<string, string> get_xenstore_data(Session session, string _vm)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vm_get_xenstore_data(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the ha_always_run field of the given VM.
        /// First published in XenServer 5.0.
        /// Deprecated since XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        [Deprecated("XenServer 6.0")]
        public static bool get_ha_always_run(Session session, string _vm)
        {
            return (bool)session.proxy.vm_get_ha_always_run(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the ha_restart_priority field of the given VM.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_ha_restart_priority(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_ha_restart_priority(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the is_a_snapshot field of the given VM.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static bool get_is_a_snapshot(Session session, string _vm)
        {
            return (bool)session.proxy.vm_get_is_a_snapshot(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the snapshot_of field of the given VM.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<VM> get_snapshot_of(Session session, string _vm)
        {
            return XenRef<VM>.Create(session.proxy.vm_get_snapshot_of(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the snapshots field of the given VM.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static List<XenRef<VM>> get_snapshots(Session session, string _vm)
        {
            return XenRef<VM>.Create(session.proxy.vm_get_snapshots(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the snapshot_time field of the given VM.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static DateTime get_snapshot_time(Session session, string _vm)
        {
            return session.proxy.vm_get_snapshot_time(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the transportable_snapshot_id field of the given VM.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_transportable_snapshot_id(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_transportable_snapshot_id(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the blobs field of the given VM.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<string, XenRef<Blob>> get_blobs(Session session, string _vm)
        {
            return Maps.convert_from_proxy_string_XenRefBlob(session.proxy.vm_get_blobs(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the tags field of the given VM.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string[] get_tags(Session session, string _vm)
        {
            return (string [])session.proxy.vm_get_tags(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the blocked_operations field of the given VM.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<vm_operations, string> get_blocked_operations(Session session, string _vm)
        {
            return Maps.convert_from_proxy_vm_operations_string(session.proxy.vm_get_blocked_operations(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the snapshot_info field of the given VM.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<string, string> get_snapshot_info(Session session, string _vm)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vm_get_snapshot_info(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the snapshot_metadata field of the given VM.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_snapshot_metadata(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_snapshot_metadata(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the parent field of the given VM.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<VM> get_parent(Session session, string _vm)
        {
            return XenRef<VM>.Create(session.proxy.vm_get_parent(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the children field of the given VM.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static List<XenRef<VM>> get_children(Session session, string _vm)
        {
            return XenRef<VM>.Create(session.proxy.vm_get_children(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the bios_strings field of the given VM.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<string, string> get_bios_strings(Session session, string _vm)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vm_get_bios_strings(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the protection_policy field of the given VM.
        /// First published in XenServer 5.6 FP1.
        /// Deprecated since XenServer 6.2.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        [Deprecated("XenServer 6.2")]
        public static XenRef<VMPP> get_protection_policy(Session session, string _vm)
        {
            return XenRef<VMPP>.Create(session.proxy.vm_get_protection_policy(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the is_snapshot_from_vmpp field of the given VM.
        /// First published in XenServer 5.6 FP1.
        /// Deprecated since XenServer 6.2.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        [Deprecated("XenServer 6.2")]
        public static bool get_is_snapshot_from_vmpp(Session session, string _vm)
        {
            return (bool)session.proxy.vm_get_is_snapshot_from_vmpp(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the appliance field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<VM_appliance> get_appliance(Session session, string _vm)
        {
            return XenRef<VM_appliance>.Create(session.proxy.vm_get_appliance(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the start_delay field of the given VM.
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_start_delay(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_start_delay(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the shutdown_delay field of the given VM.
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_shutdown_delay(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_shutdown_delay(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the order field of the given VM.
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_order(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_order(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the VGPUs field of the given VM.
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static List<XenRef<VGPU>> get_VGPUs(Session session, string _vm)
        {
            return XenRef<VGPU>.Create(session.proxy.vm_get_vgpus(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the attached_PCIs field of the given VM.
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static List<XenRef<PCI>> get_attached_PCIs(Session session, string _vm)
        {
            return XenRef<PCI>.Create(session.proxy.vm_get_attached_pcis(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the suspend_SR field of the given VM.
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<SR> get_suspend_SR(Session session, string _vm)
        {
            return XenRef<SR>.Create(session.proxy.vm_get_suspend_sr(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the version field of the given VM.
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_version(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_version(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the generation_id field of the given VM.
        /// First published in XenServer 6.2.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string get_generation_id(Session session, string _vm)
        {
            return (string)session.proxy.vm_get_generation_id(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the hardware_platform_version field of the given VM.
        /// First published in XenServer 6.5 SP1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long get_hardware_platform_version(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_get_hardware_platform_version(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Get the auto_update_drivers field of the given VM.
        /// Experimental. First published in XenServer Dundee.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static bool get_auto_update_drivers(Session session, string _vm)
        {
            return (bool)session.proxy.vm_get_auto_update_drivers(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Get the has_vendor_device field of the given VM.
        /// Experimental. First published in XenServer Dundee.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static bool get_has_vendor_device(Session session, string _vm)
        {
            return (bool)session.proxy.vm_get_has_vendor_device(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Set the name/label field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_label">New value to set</param>
        public static void set_name_label(Session session, string _vm, string _label)
        {
            session.proxy.vm_set_name_label(session.uuid, (_vm != null) ? _vm : "", (_label != null) ? _label : "").parse();
        }

        /// <summary>
        /// Set the name/description field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_description">New value to set</param>
        public static void set_name_description(Session session, string _vm, string _description)
        {
            session.proxy.vm_set_name_description(session.uuid, (_vm != null) ? _vm : "", (_description != null) ? _description : "").parse();
        }

        /// <summary>
        /// Set the user_version field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_user_version">New value to set</param>
        public static void set_user_version(Session session, string _vm, long _user_version)
        {
            session.proxy.vm_set_user_version(session.uuid, (_vm != null) ? _vm : "", _user_version.ToString()).parse();
        }

        /// <summary>
        /// Set the is_a_template field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_is_a_template">New value to set</param>
        public static void set_is_a_template(Session session, string _vm, bool _is_a_template)
        {
            session.proxy.vm_set_is_a_template(session.uuid, (_vm != null) ? _vm : "", _is_a_template).parse();
        }

        /// <summary>
        /// Set the affinity field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_affinity">New value to set</param>
        public static void set_affinity(Session session, string _vm, string _affinity)
        {
            session.proxy.vm_set_affinity(session.uuid, (_vm != null) ? _vm : "", (_affinity != null) ? _affinity : "").parse();
        }

        /// <summary>
        /// Set the VCPUs/params field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_params">New value to set</param>
        public static void set_VCPUs_params(Session session, string _vm, Dictionary<string, string> _params)
        {
            session.proxy.vm_set_vcpus_params(session.uuid, (_vm != null) ? _vm : "", Maps.convert_to_proxy_string_string(_params)).parse();
        }

        /// <summary>
        /// Add the given key-value pair to the VCPUs/params field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">Key to add</param>
        /// <param name="_value">Value to add</param>
        public static void add_to_VCPUs_params(Session session, string _vm, string _key, string _value)
        {
            session.proxy.vm_add_to_vcpus_params(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Remove the given key and its corresponding value from the VCPUs/params field of the given VM.  If the key is not in that Map, then do nothing.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">Key to remove</param>
        public static void remove_from_VCPUs_params(Session session, string _vm, string _key)
        {
            session.proxy.vm_remove_from_vcpus_params(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "").parse();
        }

        /// <summary>
        /// Set the actions/after_shutdown field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_after_shutdown">New value to set</param>
        public static void set_actions_after_shutdown(Session session, string _vm, on_normal_exit _after_shutdown)
        {
            session.proxy.vm_set_actions_after_shutdown(session.uuid, (_vm != null) ? _vm : "", on_normal_exit_helper.ToString(_after_shutdown)).parse();
        }

        /// <summary>
        /// Set the actions/after_reboot field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_after_reboot">New value to set</param>
        public static void set_actions_after_reboot(Session session, string _vm, on_normal_exit _after_reboot)
        {
            session.proxy.vm_set_actions_after_reboot(session.uuid, (_vm != null) ? _vm : "", on_normal_exit_helper.ToString(_after_reboot)).parse();
        }

        /// <summary>
        /// Set the actions/after_crash field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_after_crash">New value to set</param>
        public static void set_actions_after_crash(Session session, string _vm, on_crash_behaviour _after_crash)
        {
            session.proxy.vm_set_actions_after_crash(session.uuid, (_vm != null) ? _vm : "", on_crash_behaviour_helper.ToString(_after_crash)).parse();
        }

        /// <summary>
        /// Set the PV/bootloader field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_bootloader">New value to set</param>
        public static void set_PV_bootloader(Session session, string _vm, string _bootloader)
        {
            session.proxy.vm_set_pv_bootloader(session.uuid, (_vm != null) ? _vm : "", (_bootloader != null) ? _bootloader : "").parse();
        }

        /// <summary>
        /// Set the PV/kernel field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_kernel">New value to set</param>
        public static void set_PV_kernel(Session session, string _vm, string _kernel)
        {
            session.proxy.vm_set_pv_kernel(session.uuid, (_vm != null) ? _vm : "", (_kernel != null) ? _kernel : "").parse();
        }

        /// <summary>
        /// Set the PV/ramdisk field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_ramdisk">New value to set</param>
        public static void set_PV_ramdisk(Session session, string _vm, string _ramdisk)
        {
            session.proxy.vm_set_pv_ramdisk(session.uuid, (_vm != null) ? _vm : "", (_ramdisk != null) ? _ramdisk : "").parse();
        }

        /// <summary>
        /// Set the PV/args field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_args">New value to set</param>
        public static void set_PV_args(Session session, string _vm, string _args)
        {
            session.proxy.vm_set_pv_args(session.uuid, (_vm != null) ? _vm : "", (_args != null) ? _args : "").parse();
        }

        /// <summary>
        /// Set the PV/bootloader_args field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_bootloader_args">New value to set</param>
        public static void set_PV_bootloader_args(Session session, string _vm, string _bootloader_args)
        {
            session.proxy.vm_set_pv_bootloader_args(session.uuid, (_vm != null) ? _vm : "", (_bootloader_args != null) ? _bootloader_args : "").parse();
        }

        /// <summary>
        /// Set the PV/legacy_args field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_legacy_args">New value to set</param>
        public static void set_PV_legacy_args(Session session, string _vm, string _legacy_args)
        {
            session.proxy.vm_set_pv_legacy_args(session.uuid, (_vm != null) ? _vm : "", (_legacy_args != null) ? _legacy_args : "").parse();
        }

        /// <summary>
        /// Set the HVM/boot_policy field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_boot_policy">New value to set</param>
        public static void set_HVM_boot_policy(Session session, string _vm, string _boot_policy)
        {
            session.proxy.vm_set_hvm_boot_policy(session.uuid, (_vm != null) ? _vm : "", (_boot_policy != null) ? _boot_policy : "").parse();
        }

        /// <summary>
        /// Set the HVM/boot_params field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_boot_params">New value to set</param>
        public static void set_HVM_boot_params(Session session, string _vm, Dictionary<string, string> _boot_params)
        {
            session.proxy.vm_set_hvm_boot_params(session.uuid, (_vm != null) ? _vm : "", Maps.convert_to_proxy_string_string(_boot_params)).parse();
        }

        /// <summary>
        /// Add the given key-value pair to the HVM/boot_params field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">Key to add</param>
        /// <param name="_value">Value to add</param>
        public static void add_to_HVM_boot_params(Session session, string _vm, string _key, string _value)
        {
            session.proxy.vm_add_to_hvm_boot_params(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Remove the given key and its corresponding value from the HVM/boot_params field of the given VM.  If the key is not in that Map, then do nothing.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">Key to remove</param>
        public static void remove_from_HVM_boot_params(Session session, string _vm, string _key)
        {
            session.proxy.vm_remove_from_hvm_boot_params(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "").parse();
        }

        /// <summary>
        /// Set the platform field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_platform">New value to set</param>
        public static void set_platform(Session session, string _vm, Dictionary<string, string> _platform)
        {
            session.proxy.vm_set_platform(session.uuid, (_vm != null) ? _vm : "", Maps.convert_to_proxy_string_string(_platform)).parse();
        }

        /// <summary>
        /// Add the given key-value pair to the platform field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">Key to add</param>
        /// <param name="_value">Value to add</param>
        public static void add_to_platform(Session session, string _vm, string _key, string _value)
        {
            session.proxy.vm_add_to_platform(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Remove the given key and its corresponding value from the platform field of the given VM.  If the key is not in that Map, then do nothing.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">Key to remove</param>
        public static void remove_from_platform(Session session, string _vm, string _key)
        {
            session.proxy.vm_remove_from_platform(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "").parse();
        }

        /// <summary>
        /// Set the PCI_bus field of the given VM.
        /// First published in XenServer 4.0.
        /// Deprecated since XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_pci_bus">New value to set</param>
        [Deprecated("XenServer 6.0")]
        public static void set_PCI_bus(Session session, string _vm, string _pci_bus)
        {
            session.proxy.vm_set_pci_bus(session.uuid, (_vm != null) ? _vm : "", (_pci_bus != null) ? _pci_bus : "").parse();
        }

        /// <summary>
        /// Set the other_config field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_other_config">New value to set</param>
        public static void set_other_config(Session session, string _vm, Dictionary<string, string> _other_config)
        {
            session.proxy.vm_set_other_config(session.uuid, (_vm != null) ? _vm : "", Maps.convert_to_proxy_string_string(_other_config)).parse();
        }

        /// <summary>
        /// Add the given key-value pair to the other_config field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">Key to add</param>
        /// <param name="_value">Value to add</param>
        public static void add_to_other_config(Session session, string _vm, string _key, string _value)
        {
            session.proxy.vm_add_to_other_config(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Remove the given key and its corresponding value from the other_config field of the given VM.  If the key is not in that Map, then do nothing.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">Key to remove</param>
        public static void remove_from_other_config(Session session, string _vm, string _key)
        {
            session.proxy.vm_remove_from_other_config(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "").parse();
        }

        /// <summary>
        /// Set the recommendations field of the given VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_recommendations">New value to set</param>
        public static void set_recommendations(Session session, string _vm, string _recommendations)
        {
            session.proxy.vm_set_recommendations(session.uuid, (_vm != null) ? _vm : "", (_recommendations != null) ? _recommendations : "").parse();
        }

        /// <summary>
        /// Set the xenstore_data field of the given VM.
        /// First published in XenServer 4.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_xenstore_data">New value to set</param>
        public static void set_xenstore_data(Session session, string _vm, Dictionary<string, string> _xenstore_data)
        {
            session.proxy.vm_set_xenstore_data(session.uuid, (_vm != null) ? _vm : "", Maps.convert_to_proxy_string_string(_xenstore_data)).parse();
        }

        /// <summary>
        /// Add the given key-value pair to the xenstore_data field of the given VM.
        /// First published in XenServer 4.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">Key to add</param>
        /// <param name="_value">Value to add</param>
        public static void add_to_xenstore_data(Session session, string _vm, string _key, string _value)
        {
            session.proxy.vm_add_to_xenstore_data(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Remove the given key and its corresponding value from the xenstore_data field of the given VM.  If the key is not in that Map, then do nothing.
        /// First published in XenServer 4.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">Key to remove</param>
        public static void remove_from_xenstore_data(Session session, string _vm, string _key)
        {
            session.proxy.vm_remove_from_xenstore_data(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "").parse();
        }

        /// <summary>
        /// Set the tags field of the given VM.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_tags">New value to set</param>
        public static void set_tags(Session session, string _vm, string[] _tags)
        {
            session.proxy.vm_set_tags(session.uuid, (_vm != null) ? _vm : "", _tags).parse();
        }

        /// <summary>
        /// Add the given value to the tags field of the given VM.  If the value is already in that Set, then do nothing.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">New value to add</param>
        public static void add_tags(Session session, string _vm, string _value)
        {
            session.proxy.vm_add_tags(session.uuid, (_vm != null) ? _vm : "", (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Remove the given value from the tags field of the given VM.  If the value is not in that Set, then do nothing.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">Value to remove</param>
        public static void remove_tags(Session session, string _vm, string _value)
        {
            session.proxy.vm_remove_tags(session.uuid, (_vm != null) ? _vm : "", (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Set the blocked_operations field of the given VM.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_blocked_operations">New value to set</param>
        public static void set_blocked_operations(Session session, string _vm, Dictionary<vm_operations, string> _blocked_operations)
        {
            session.proxy.vm_set_blocked_operations(session.uuid, (_vm != null) ? _vm : "", Maps.convert_to_proxy_vm_operations_string(_blocked_operations)).parse();
        }

        /// <summary>
        /// Add the given key-value pair to the blocked_operations field of the given VM.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">Key to add</param>
        /// <param name="_value">Value to add</param>
        public static void add_to_blocked_operations(Session session, string _vm, vm_operations _key, string _value)
        {
            session.proxy.vm_add_to_blocked_operations(session.uuid, (_vm != null) ? _vm : "", vm_operations_helper.ToString(_key), (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Remove the given key and its corresponding value from the blocked_operations field of the given VM.  If the key is not in that Map, then do nothing.
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">Key to remove</param>
        public static void remove_from_blocked_operations(Session session, string _vm, vm_operations _key)
        {
            session.proxy.vm_remove_from_blocked_operations(session.uuid, (_vm != null) ? _vm : "", vm_operations_helper.ToString(_key)).parse();
        }

        /// <summary>
        /// Set the suspend_SR field of the given VM.
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_suspend_sr">New value to set</param>
        public static void set_suspend_SR(Session session, string _vm, string _suspend_sr)
        {
            session.proxy.vm_set_suspend_sr(session.uuid, (_vm != null) ? _vm : "", (_suspend_sr != null) ? _suspend_sr : "").parse();
        }

        /// <summary>
        /// Set the hardware_platform_version field of the given VM.
        /// First published in XenServer 6.5 SP1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_hardware_platform_version">New value to set</param>
        public static void set_hardware_platform_version(Session session, string _vm, long _hardware_platform_version)
        {
            session.proxy.vm_set_hardware_platform_version(session.uuid, (_vm != null) ? _vm : "", _hardware_platform_version.ToString()).parse();
        }

        /// <summary>
        /// Set the has_vendor_device field of the given VM.
        /// Experimental. First published in XenServer Dundee.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_has_vendor_device">New value to set</param>
        public static void set_has_vendor_device(Session session, string _vm, bool _has_vendor_device)
        {
            session.proxy.vm_set_has_vendor_device(session.uuid, (_vm != null) ? _vm : "", _has_vendor_device).parse();
        }

        /// <summary>
        /// Snapshots the specified VM, making a new VM. Snapshot automatically exploits the capabilities of the underlying storage repository in which the VM's disk images are stored (e.g. Copy on Write).
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_new_name">The name of the snapshotted VM</param>
        public static XenRef<VM> snapshot(Session session, string _vm, string _new_name)
        {
            return XenRef<VM>.Create(session.proxy.vm_snapshot(session.uuid, (_vm != null) ? _vm : "", (_new_name != null) ? _new_name : "").parse());
        }

        /// <summary>
        /// Snapshots the specified VM, making a new VM. Snapshot automatically exploits the capabilities of the underlying storage repository in which the VM's disk images are stored (e.g. Copy on Write).
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_new_name">The name of the snapshotted VM</param>
        public static XenRef<Task> async_snapshot(Session session, string _vm, string _new_name)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_snapshot(session.uuid, (_vm != null) ? _vm : "", (_new_name != null) ? _new_name : "").parse());
        }

        /// <summary>
        /// Snapshots the specified VM with quiesce, making a new VM. Snapshot automatically exploits the capabilities of the underlying storage repository in which the VM's disk images are stored (e.g. Copy on Write).
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_new_name">The name of the snapshotted VM</param>
        public static XenRef<VM> snapshot_with_quiesce(Session session, string _vm, string _new_name)
        {
            return XenRef<VM>.Create(session.proxy.vm_snapshot_with_quiesce(session.uuid, (_vm != null) ? _vm : "", (_new_name != null) ? _new_name : "").parse());
        }

        /// <summary>
        /// Snapshots the specified VM with quiesce, making a new VM. Snapshot automatically exploits the capabilities of the underlying storage repository in which the VM's disk images are stored (e.g. Copy on Write).
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_new_name">The name of the snapshotted VM</param>
        public static XenRef<Task> async_snapshot_with_quiesce(Session session, string _vm, string _new_name)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_snapshot_with_quiesce(session.uuid, (_vm != null) ? _vm : "", (_new_name != null) ? _new_name : "").parse());
        }

        /// <summary>
        /// Clones the specified VM, making a new VM. Clone automatically exploits the capabilities of the underlying storage repository in which the VM's disk images are stored (e.g. Copy on Write).   This function can only be called when the VM is in the Halted State.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_new_name">The name of the cloned VM</param>
        public static XenRef<VM> clone(Session session, string _vm, string _new_name)
        {
            return XenRef<VM>.Create(session.proxy.vm_clone(session.uuid, (_vm != null) ? _vm : "", (_new_name != null) ? _new_name : "").parse());
        }

        /// <summary>
        /// Clones the specified VM, making a new VM. Clone automatically exploits the capabilities of the underlying storage repository in which the VM's disk images are stored (e.g. Copy on Write).   This function can only be called when the VM is in the Halted State.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_new_name">The name of the cloned VM</param>
        public static XenRef<Task> async_clone(Session session, string _vm, string _new_name)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_clone(session.uuid, (_vm != null) ? _vm : "", (_new_name != null) ? _new_name : "").parse());
        }

        /// <summary>
        /// Copied the specified VM, making a new VM. Unlike clone, copy does not exploits the capabilities of the underlying storage repository in which the VM's disk images are stored. Instead, copy guarantees that the disk images of the newly created VM will be 'full disks' - i.e. not part of a CoW chain.  This function can only be called when the VM is in the Halted State.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_new_name">The name of the copied VM</param>
        /// <param name="_sr">An SR to copy all the VM's disks into (if an invalid reference then it uses the existing SRs)</param>
        public static XenRef<VM> copy(Session session, string _vm, string _new_name, string _sr)
        {
            return XenRef<VM>.Create(session.proxy.vm_copy(session.uuid, (_vm != null) ? _vm : "", (_new_name != null) ? _new_name : "", (_sr != null) ? _sr : "").parse());
        }

        /// <summary>
        /// Copied the specified VM, making a new VM. Unlike clone, copy does not exploits the capabilities of the underlying storage repository in which the VM's disk images are stored. Instead, copy guarantees that the disk images of the newly created VM will be 'full disks' - i.e. not part of a CoW chain.  This function can only be called when the VM is in the Halted State.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_new_name">The name of the copied VM</param>
        /// <param name="_sr">An SR to copy all the VM's disks into (if an invalid reference then it uses the existing SRs)</param>
        public static XenRef<Task> async_copy(Session session, string _vm, string _new_name, string _sr)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_copy(session.uuid, (_vm != null) ? _vm : "", (_new_name != null) ? _new_name : "", (_sr != null) ? _sr : "").parse());
        }

        /// <summary>
        /// Reverts the specified VM to a previous state.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given snapshotted state</param>
        public static void revert(Session session, string _vm)
        {
            session.proxy.vm_revert(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Reverts the specified VM to a previous state.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given snapshotted state</param>
        public static XenRef<Task> async_revert(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_revert(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Checkpoints the specified VM, making a new VM. Checkpoint automatically exploits the capabilities of the underlying storage repository in which the VM's disk images are stored (e.g. Copy on Write) and saves the memory image as well.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_new_name">The name of the checkpointed VM</param>
        public static XenRef<VM> checkpoint(Session session, string _vm, string _new_name)
        {
            return XenRef<VM>.Create(session.proxy.vm_checkpoint(session.uuid, (_vm != null) ? _vm : "", (_new_name != null) ? _new_name : "").parse());
        }

        /// <summary>
        /// Checkpoints the specified VM, making a new VM. Checkpoint automatically exploits the capabilities of the underlying storage repository in which the VM's disk images are stored (e.g. Copy on Write) and saves the memory image as well.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_new_name">The name of the checkpointed VM</param>
        public static XenRef<Task> async_checkpoint(Session session, string _vm, string _new_name)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_checkpoint(session.uuid, (_vm != null) ? _vm : "", (_new_name != null) ? _new_name : "").parse());
        }

        /// <summary>
        /// Inspects the disk configuration contained within the VM's other_config, creates VDIs and VBDs and then executes any applicable post-install script.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void provision(Session session, string _vm)
        {
            session.proxy.vm_provision(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Inspects the disk configuration contained within the VM's other_config, creates VDIs and VBDs and then executes any applicable post-install script.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_provision(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_provision(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Start the specified VM.  This function can only be called with the VM is in the Halted State.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_start_paused">Instantiate VM in paused state if set to true.</param>
        /// <param name="_force">Attempt to force the VM to start. If this flag is false then the VM may fail pre-boot safety checks (e.g. if the CPU the VM last booted on looks substantially different to the current one)</param>
        public static void start(Session session, string _vm, bool _start_paused, bool _force)
        {
            session.proxy.vm_start(session.uuid, (_vm != null) ? _vm : "", _start_paused, _force).parse();
        }

        /// <summary>
        /// Start the specified VM.  This function can only be called with the VM is in the Halted State.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_start_paused">Instantiate VM in paused state if set to true.</param>
        /// <param name="_force">Attempt to force the VM to start. If this flag is false then the VM may fail pre-boot safety checks (e.g. if the CPU the VM last booted on looks substantially different to the current one)</param>
        public static XenRef<Task> async_start(Session session, string _vm, bool _start_paused, bool _force)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_start(session.uuid, (_vm != null) ? _vm : "", _start_paused, _force).parse());
        }

        /// <summary>
        /// Start the specified VM on a particular host.  This function can only be called with the VM is in the Halted State.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_host">The Host on which to start the VM</param>
        /// <param name="_start_paused">Instantiate VM in paused state if set to true.</param>
        /// <param name="_force">Attempt to force the VM to start. If this flag is false then the VM may fail pre-boot safety checks (e.g. if the CPU the VM last booted on looks substantially different to the current one)</param>
        public static void start_on(Session session, string _vm, string _host, bool _start_paused, bool _force)
        {
            session.proxy.vm_start_on(session.uuid, (_vm != null) ? _vm : "", (_host != null) ? _host : "", _start_paused, _force).parse();
        }

        /// <summary>
        /// Start the specified VM on a particular host.  This function can only be called with the VM is in the Halted State.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_host">The Host on which to start the VM</param>
        /// <param name="_start_paused">Instantiate VM in paused state if set to true.</param>
        /// <param name="_force">Attempt to force the VM to start. If this flag is false then the VM may fail pre-boot safety checks (e.g. if the CPU the VM last booted on looks substantially different to the current one)</param>
        public static XenRef<Task> async_start_on(Session session, string _vm, string _host, bool _start_paused, bool _force)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_start_on(session.uuid, (_vm != null) ? _vm : "", (_host != null) ? _host : "", _start_paused, _force).parse());
        }

        /// <summary>
        /// Pause the specified VM. This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void pause(Session session, string _vm)
        {
            session.proxy.vm_pause(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Pause the specified VM. This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_pause(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_pause(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Resume the specified VM. This can only be called when the specified VM is in the Paused state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void unpause(Session session, string _vm)
        {
            session.proxy.vm_unpause(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Resume the specified VM. This can only be called when the specified VM is in the Paused state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_unpause(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_unpause(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Attempt to cleanly shutdown the specified VM. (Note: this may not be supported---e.g. if a guest agent is not installed). This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void clean_shutdown(Session session, string _vm)
        {
            session.proxy.vm_clean_shutdown(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Attempt to cleanly shutdown the specified VM. (Note: this may not be supported---e.g. if a guest agent is not installed). This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_clean_shutdown(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_clean_shutdown(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Attempts to first clean shutdown a VM and if it should fail then perform a hard shutdown on it.
        /// First published in XenServer 6.2.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void shutdown(Session session, string _vm)
        {
            session.proxy.vm_shutdown(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Attempts to first clean shutdown a VM and if it should fail then perform a hard shutdown on it.
        /// First published in XenServer 6.2.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_shutdown(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_shutdown(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Attempt to cleanly shutdown the specified VM (Note: this may not be supported---e.g. if a guest agent is not installed). This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void clean_reboot(Session session, string _vm)
        {
            session.proxy.vm_clean_reboot(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Attempt to cleanly shutdown the specified VM (Note: this may not be supported---e.g. if a guest agent is not installed). This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_clean_reboot(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_clean_reboot(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Stop executing the specified VM without attempting a clean shutdown.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void hard_shutdown(Session session, string _vm)
        {
            session.proxy.vm_hard_shutdown(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Stop executing the specified VM without attempting a clean shutdown.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_hard_shutdown(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_hard_shutdown(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Reset the power-state of the VM to halted in the database only. (Used to recover from slave failures in pooling scenarios by resetting the power-states of VMs running on dead slaves to halted.) This is a potentially dangerous operation; use with care.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void power_state_reset(Session session, string _vm)
        {
            session.proxy.vm_power_state_reset(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Reset the power-state of the VM to halted in the database only. (Used to recover from slave failures in pooling scenarios by resetting the power-states of VMs running on dead slaves to halted.) This is a potentially dangerous operation; use with care.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_power_state_reset(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_power_state_reset(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Stop executing the specified VM without attempting a clean shutdown and immediately restart the VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void hard_reboot(Session session, string _vm)
        {
            session.proxy.vm_hard_reboot(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Stop executing the specified VM without attempting a clean shutdown and immediately restart the VM.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_hard_reboot(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_hard_reboot(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Suspend the specified VM to disk.  This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void suspend(Session session, string _vm)
        {
            session.proxy.vm_suspend(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Suspend the specified VM to disk.  This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_suspend(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_suspend(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Awaken the specified VM and resume it.  This can only be called when the specified VM is in the Suspended state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_start_paused">Resume VM in paused state if set to true.</param>
        /// <param name="_force">Attempt to force the VM to resume. If this flag is false then the VM may fail pre-resume safety checks (e.g. if the CPU the VM was running on looks substantially different to the current one)</param>
        public static void resume(Session session, string _vm, bool _start_paused, bool _force)
        {
            session.proxy.vm_resume(session.uuid, (_vm != null) ? _vm : "", _start_paused, _force).parse();
        }

        /// <summary>
        /// Awaken the specified VM and resume it.  This can only be called when the specified VM is in the Suspended state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_start_paused">Resume VM in paused state if set to true.</param>
        /// <param name="_force">Attempt to force the VM to resume. If this flag is false then the VM may fail pre-resume safety checks (e.g. if the CPU the VM was running on looks substantially different to the current one)</param>
        public static XenRef<Task> async_resume(Session session, string _vm, bool _start_paused, bool _force)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_resume(session.uuid, (_vm != null) ? _vm : "", _start_paused, _force).parse());
        }

        /// <summary>
        /// Awaken the specified VM and resume it on a particular Host.  This can only be called when the specified VM is in the Suspended state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_host">The Host on which to resume the VM</param>
        /// <param name="_start_paused">Resume VM in paused state if set to true.</param>
        /// <param name="_force">Attempt to force the VM to resume. If this flag is false then the VM may fail pre-resume safety checks (e.g. if the CPU the VM was running on looks substantially different to the current one)</param>
        public static void resume_on(Session session, string _vm, string _host, bool _start_paused, bool _force)
        {
            session.proxy.vm_resume_on(session.uuid, (_vm != null) ? _vm : "", (_host != null) ? _host : "", _start_paused, _force).parse();
        }

        /// <summary>
        /// Awaken the specified VM and resume it on a particular Host.  This can only be called when the specified VM is in the Suspended state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_host">The Host on which to resume the VM</param>
        /// <param name="_start_paused">Resume VM in paused state if set to true.</param>
        /// <param name="_force">Attempt to force the VM to resume. If this flag is false then the VM may fail pre-resume safety checks (e.g. if the CPU the VM was running on looks substantially different to the current one)</param>
        public static XenRef<Task> async_resume_on(Session session, string _vm, string _host, bool _start_paused, bool _force)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_resume_on(session.uuid, (_vm != null) ? _vm : "", (_host != null) ? _host : "", _start_paused, _force).parse());
        }

        /// <summary>
        /// Migrate a VM to another Host.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_host">The target host</param>
        /// <param name="_options">Extra configuration operations</param>
        public static void pool_migrate(Session session, string _vm, string _host, Dictionary<string, string> _options)
        {
            session.proxy.vm_pool_migrate(session.uuid, (_vm != null) ? _vm : "", (_host != null) ? _host : "", Maps.convert_to_proxy_string_string(_options)).parse();
        }

        /// <summary>
        /// Migrate a VM to another Host.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_host">The target host</param>
        /// <param name="_options">Extra configuration operations</param>
        public static XenRef<Task> async_pool_migrate(Session session, string _vm, string _host, Dictionary<string, string> _options)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_pool_migrate(session.uuid, (_vm != null) ? _vm : "", (_host != null) ? _host : "", Maps.convert_to_proxy_string_string(_options)).parse());
        }

        /// <summary>
        /// Set the number of VCPUs for a running VM
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_nvcpu">The number of VCPUs</param>
        public static void set_VCPUs_number_live(Session session, string _vm, long _nvcpu)
        {
            session.proxy.vm_set_vcpus_number_live(session.uuid, (_vm != null) ? _vm : "", _nvcpu.ToString()).parse();
        }

        /// <summary>
        /// Set the number of VCPUs for a running VM
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_nvcpu">The number of VCPUs</param>
        public static XenRef<Task> async_set_VCPUs_number_live(Session session, string _vm, long _nvcpu)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_set_vcpus_number_live(session.uuid, (_vm != null) ? _vm : "", _nvcpu.ToString()).parse());
        }

        /// <summary>
        /// Add the given key-value pair to VM.VCPUs_params, and apply that value on the running VM
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">The key</param>
        /// <param name="_value">The value</param>
        public static void add_to_VCPUs_params_live(Session session, string _vm, string _key, string _value)
        {
            session.proxy.vm_add_to_vcpus_params_live(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Add the given key-value pair to VM.VCPUs_params, and apply that value on the running VM
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">The key</param>
        /// <param name="_value">The value</param>
        public static XenRef<Task> async_add_to_VCPUs_params_live(Session session, string _vm, string _key, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_add_to_vcpus_params_live(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "", (_value != null) ? _value : "").parse());
        }

        /// <summary>
        /// Set the value of the ha_restart_priority field
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The value</param>
        public static void set_ha_restart_priority(Session session, string _vm, string _value)
        {
            session.proxy.vm_set_ha_restart_priority(session.uuid, (_vm != null) ? _vm : "", (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Set the value of the ha_always_run
        /// First published in XenServer 5.0.
        /// Deprecated since XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The value</param>
        [Deprecated("XenServer 6.0")]
        public static void set_ha_always_run(Session session, string _vm, bool _value)
        {
            session.proxy.vm_set_ha_always_run(session.uuid, (_vm != null) ? _vm : "", _value).parse();
        }

        /// <summary>
        /// Computes the virtualization memory overhead of a VM.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static long compute_memory_overhead(Session session, string _vm)
        {
            return long.Parse((string)session.proxy.vm_compute_memory_overhead(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Computes the virtualization memory overhead of a VM.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_compute_memory_overhead(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_compute_memory_overhead(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Set the value of the memory_dynamic_max field
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The new value of memory_dynamic_max</param>
        public static void set_memory_dynamic_max(Session session, string _vm, long _value)
        {
            session.proxy.vm_set_memory_dynamic_max(session.uuid, (_vm != null) ? _vm : "", _value.ToString()).parse();
        }

        /// <summary>
        /// Set the value of the memory_dynamic_min field
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The new value of memory_dynamic_min</param>
        public static void set_memory_dynamic_min(Session session, string _vm, long _value)
        {
            session.proxy.vm_set_memory_dynamic_min(session.uuid, (_vm != null) ? _vm : "", _value.ToString()).parse();
        }

        /// <summary>
        /// Set the minimum and maximum amounts of physical memory the VM is allowed to use.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_min">The new minimum value</param>
        /// <param name="_max">The new maximum value</param>
        public static void set_memory_dynamic_range(Session session, string _vm, long _min, long _max)
        {
            session.proxy.vm_set_memory_dynamic_range(session.uuid, (_vm != null) ? _vm : "", _min.ToString(), _max.ToString()).parse();
        }

        /// <summary>
        /// Set the minimum and maximum amounts of physical memory the VM is allowed to use.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_min">The new minimum value</param>
        /// <param name="_max">The new maximum value</param>
        public static XenRef<Task> async_set_memory_dynamic_range(Session session, string _vm, long _min, long _max)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_set_memory_dynamic_range(session.uuid, (_vm != null) ? _vm : "", _min.ToString(), _max.ToString()).parse());
        }

        /// <summary>
        /// Set the value of the memory_static_max field
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The new value of memory_static_max</param>
        public static void set_memory_static_max(Session session, string _vm, long _value)
        {
            session.proxy.vm_set_memory_static_max(session.uuid, (_vm != null) ? _vm : "", _value.ToString()).parse();
        }

        /// <summary>
        /// Set the value of the memory_static_min field
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The new value of memory_static_min</param>
        public static void set_memory_static_min(Session session, string _vm, long _value)
        {
            session.proxy.vm_set_memory_static_min(session.uuid, (_vm != null) ? _vm : "", _value.ToString()).parse();
        }

        /// <summary>
        /// Set the static (ie boot-time) range of virtual memory that the VM is allowed to use.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_min">The new minimum value</param>
        /// <param name="_max">The new maximum value</param>
        public static void set_memory_static_range(Session session, string _vm, long _min, long _max)
        {
            session.proxy.vm_set_memory_static_range(session.uuid, (_vm != null) ? _vm : "", _min.ToString(), _max.ToString()).parse();
        }

        /// <summary>
        /// Set the static (ie boot-time) range of virtual memory that the VM is allowed to use.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_min">The new minimum value</param>
        /// <param name="_max">The new maximum value</param>
        public static XenRef<Task> async_set_memory_static_range(Session session, string _vm, long _min, long _max)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_set_memory_static_range(session.uuid, (_vm != null) ? _vm : "", _min.ToString(), _max.ToString()).parse());
        }

        /// <summary>
        /// Set the memory limits of this VM.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_static_min">The new value of memory_static_min.</param>
        /// <param name="_static_max">The new value of memory_static_max.</param>
        /// <param name="_dynamic_min">The new value of memory_dynamic_min.</param>
        /// <param name="_dynamic_max">The new value of memory_dynamic_max.</param>
        public static void set_memory_limits(Session session, string _vm, long _static_min, long _static_max, long _dynamic_min, long _dynamic_max)
        {
            session.proxy.vm_set_memory_limits(session.uuid, (_vm != null) ? _vm : "", _static_min.ToString(), _static_max.ToString(), _dynamic_min.ToString(), _dynamic_max.ToString()).parse();
        }

        /// <summary>
        /// Set the memory limits of this VM.
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_static_min">The new value of memory_static_min.</param>
        /// <param name="_static_max">The new value of memory_static_max.</param>
        /// <param name="_dynamic_min">The new value of memory_dynamic_min.</param>
        /// <param name="_dynamic_max">The new value of memory_dynamic_max.</param>
        public static XenRef<Task> async_set_memory_limits(Session session, string _vm, long _static_min, long _static_max, long _dynamic_min, long _dynamic_max)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_set_memory_limits(session.uuid, (_vm != null) ? _vm : "", _static_min.ToString(), _static_max.ToString(), _dynamic_min.ToString(), _dynamic_max.ToString()).parse());
        }

        /// <summary>
        /// Set the memory target for a running VM
        /// First published in XenServer 4.0.
        /// Deprecated since XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_target">The target in bytes</param>
        [Deprecated("XenServer 5.6")]
        public static void set_memory_target_live(Session session, string _vm, long _target)
        {
            session.proxy.vm_set_memory_target_live(session.uuid, (_vm != null) ? _vm : "", _target.ToString()).parse();
        }

        /// <summary>
        /// Set the memory target for a running VM
        /// First published in XenServer 4.0.
        /// Deprecated since XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_target">The target in bytes</param>
        [Deprecated("XenServer 5.6")]
        public static XenRef<Task> async_set_memory_target_live(Session session, string _vm, long _target)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_set_memory_target_live(session.uuid, (_vm != null) ? _vm : "", _target.ToString()).parse());
        }

        /// <summary>
        /// Wait for a running VM to reach its current memory target
        /// First published in XenServer 5.0.
        /// Deprecated since XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        [Deprecated("XenServer 5.6")]
        public static void wait_memory_target_live(Session session, string _vm)
        {
            session.proxy.vm_wait_memory_target_live(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Wait for a running VM to reach its current memory target
        /// First published in XenServer 5.0.
        /// Deprecated since XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        [Deprecated("XenServer 5.6")]
        public static XenRef<Task> async_wait_memory_target_live(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_wait_memory_target_live(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Return true if the VM is currently 'co-operative' i.e. is expected to reach a balloon target and actually has done
        /// First published in XenServer 5.6.
        /// Deprecated since XenServer 6.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        [Deprecated("XenServer 6.1")]
        public static bool get_cooperative(Session session, string _vm)
        {
            return (bool)session.proxy.vm_get_cooperative(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Return true if the VM is currently 'co-operative' i.e. is expected to reach a balloon target and actually has done
        /// First published in XenServer 5.6.
        /// Deprecated since XenServer 6.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        [Deprecated("XenServer 6.1")]
        public static XenRef<Task> async_get_cooperative(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_get_cooperative(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Set the shadow memory multiplier on a halted VM
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The new shadow memory multiplier to set</param>
        public static void set_HVM_shadow_multiplier(Session session, string _vm, double _value)
        {
            session.proxy.vm_set_hvm_shadow_multiplier(session.uuid, (_vm != null) ? _vm : "", _value).parse();
        }

        /// <summary>
        /// Set the shadow memory multiplier on a running VM
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_multiplier">The new shadow memory multiplier to set</param>
        public static void set_shadow_multiplier_live(Session session, string _vm, double _multiplier)
        {
            session.proxy.vm_set_shadow_multiplier_live(session.uuid, (_vm != null) ? _vm : "", _multiplier).parse();
        }

        /// <summary>
        /// Set the shadow memory multiplier on a running VM
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_multiplier">The new shadow memory multiplier to set</param>
        public static XenRef<Task> async_set_shadow_multiplier_live(Session session, string _vm, double _multiplier)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_set_shadow_multiplier_live(session.uuid, (_vm != null) ? _vm : "", _multiplier).parse());
        }

        /// <summary>
        /// Set the maximum number of VCPUs for a halted VM
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The new maximum number of VCPUs</param>
        public static void set_VCPUs_max(Session session, string _vm, long _value)
        {
            session.proxy.vm_set_vcpus_max(session.uuid, (_vm != null) ? _vm : "", _value.ToString()).parse();
        }

        /// <summary>
        /// Set the number of startup VCPUs for a halted VM
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The new maximum number of VCPUs</param>
        public static void set_VCPUs_at_startup(Session session, string _vm, long _value)
        {
            session.proxy.vm_set_vcpus_at_startup(session.uuid, (_vm != null) ? _vm : "", _value.ToString()).parse();
        }

        /// <summary>
        /// Send the given key as a sysrq to this VM.  The key is specified as a single character (a String of length 1).  This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">The key to send</param>
        public static void send_sysrq(Session session, string _vm, string _key)
        {
            session.proxy.vm_send_sysrq(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "").parse();
        }

        /// <summary>
        /// Send the given key as a sysrq to this VM.  The key is specified as a single character (a String of length 1).  This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_key">The key to send</param>
        public static XenRef<Task> async_send_sysrq(Session session, string _vm, string _key)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_send_sysrq(session.uuid, (_vm != null) ? _vm : "", (_key != null) ? _key : "").parse());
        }

        /// <summary>
        /// Send the named trigger to this VM.  This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_trigger">The trigger to send</param>
        public static void send_trigger(Session session, string _vm, string _trigger)
        {
            session.proxy.vm_send_trigger(session.uuid, (_vm != null) ? _vm : "", (_trigger != null) ? _trigger : "").parse();
        }

        /// <summary>
        /// Send the named trigger to this VM.  This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_trigger">The trigger to send</param>
        public static XenRef<Task> async_send_trigger(Session session, string _vm, string _trigger)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_send_trigger(session.uuid, (_vm != null) ? _vm : "", (_trigger != null) ? _trigger : "").parse());
        }

        /// <summary>
        /// Returns the maximum amount of guest memory which will fit, together with overheads, in the supplied amount of physical memory. If 'exact' is true then an exact calculation is performed using the VM's current settings. If 'exact' is false then a more conservative approximation is used
        /// First published in XenServer 4.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_total">Total amount of physical RAM to fit within</param>
        /// <param name="_approximate">If false the limit is calculated with the guest's current exact configuration. Otherwise a more approximate calculation is performed</param>
        public static long maximise_memory(Session session, string _vm, long _total, bool _approximate)
        {
            return long.Parse((string)session.proxy.vm_maximise_memory(session.uuid, (_vm != null) ? _vm : "", _total.ToString(), _approximate).parse());
        }

        /// <summary>
        /// Returns the maximum amount of guest memory which will fit, together with overheads, in the supplied amount of physical memory. If 'exact' is true then an exact calculation is performed using the VM's current settings. If 'exact' is false then a more conservative approximation is used
        /// First published in XenServer 4.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_total">Total amount of physical RAM to fit within</param>
        /// <param name="_approximate">If false the limit is calculated with the guest's current exact configuration. Otherwise a more approximate calculation is performed</param>
        public static XenRef<Task> async_maximise_memory(Session session, string _vm, long _total, bool _approximate)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_maximise_memory(session.uuid, (_vm != null) ? _vm : "", _total.ToString(), _approximate).parse());
        }

        /// <summary>
        /// Migrate the VM to another host.  This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 6.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_dest">The result of a Host.migrate_receive call.</param>
        /// <param name="_live">Live migration</param>
        /// <param name="_vdi_map">Map of source VDI to destination SR</param>
        /// <param name="_vif_map">Map of source VIF to destination network</param>
        /// <param name="_options">Other parameters</param>
        public static XenRef<VM> migrate_send(Session session, string _vm, Dictionary<string, string> _dest, bool _live, Dictionary<XenRef<VDI>, XenRef<SR>> _vdi_map, Dictionary<XenRef<VIF>, XenRef<Network>> _vif_map, Dictionary<string, string> _options)
        {
            return XenRef<VM>.Create(session.proxy.vm_migrate_send(session.uuid, (_vm != null) ? _vm : "", Maps.convert_to_proxy_string_string(_dest), _live, Maps.convert_to_proxy_XenRefVDI_XenRefSR(_vdi_map), Maps.convert_to_proxy_XenRefVIF_XenRefNetwork(_vif_map), Maps.convert_to_proxy_string_string(_options)).parse());
        }

        /// <summary>
        /// Migrate the VM to another host.  This can only be called when the specified VM is in the Running state.
        /// First published in XenServer 6.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_dest">The result of a Host.migrate_receive call.</param>
        /// <param name="_live">Live migration</param>
        /// <param name="_vdi_map">Map of source VDI to destination SR</param>
        /// <param name="_vif_map">Map of source VIF to destination network</param>
        /// <param name="_options">Other parameters</param>
        public static XenRef<Task> async_migrate_send(Session session, string _vm, Dictionary<string, string> _dest, bool _live, Dictionary<XenRef<VDI>, XenRef<SR>> _vdi_map, Dictionary<XenRef<VIF>, XenRef<Network>> _vif_map, Dictionary<string, string> _options)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_migrate_send(session.uuid, (_vm != null) ? _vm : "", Maps.convert_to_proxy_string_string(_dest), _live, Maps.convert_to_proxy_XenRefVDI_XenRefSR(_vdi_map), Maps.convert_to_proxy_XenRefVIF_XenRefNetwork(_vif_map), Maps.convert_to_proxy_string_string(_options)).parse());
        }

        /// <summary>
        /// Assert whether a VM can be migrated to the specified destination.
        /// First published in XenServer 6.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_dest">The result of a VM.migrate_receive call.</param>
        /// <param name="_live">Live migration</param>
        /// <param name="_vdi_map">Map of source VDI to destination SR</param>
        /// <param name="_vif_map">Map of source VIF to destination network</param>
        /// <param name="_options">Other parameters</param>
        public static void assert_can_migrate(Session session, string _vm, Dictionary<string, string> _dest, bool _live, Dictionary<XenRef<VDI>, XenRef<SR>> _vdi_map, Dictionary<XenRef<VIF>, XenRef<Network>> _vif_map, Dictionary<string, string> _options)
        {
            session.proxy.vm_assert_can_migrate(session.uuid, (_vm != null) ? _vm : "", Maps.convert_to_proxy_string_string(_dest), _live, Maps.convert_to_proxy_XenRefVDI_XenRefSR(_vdi_map), Maps.convert_to_proxy_XenRefVIF_XenRefNetwork(_vif_map), Maps.convert_to_proxy_string_string(_options)).parse();
        }

        /// <summary>
        /// Assert whether a VM can be migrated to the specified destination.
        /// First published in XenServer 6.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_dest">The result of a VM.migrate_receive call.</param>
        /// <param name="_live">Live migration</param>
        /// <param name="_vdi_map">Map of source VDI to destination SR</param>
        /// <param name="_vif_map">Map of source VIF to destination network</param>
        /// <param name="_options">Other parameters</param>
        public static XenRef<Task> async_assert_can_migrate(Session session, string _vm, Dictionary<string, string> _dest, bool _live, Dictionary<XenRef<VDI>, XenRef<SR>> _vdi_map, Dictionary<XenRef<VIF>, XenRef<Network>> _vif_map, Dictionary<string, string> _options)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_assert_can_migrate(session.uuid, (_vm != null) ? _vm : "", Maps.convert_to_proxy_string_string(_dest), _live, Maps.convert_to_proxy_XenRefVDI_XenRefSR(_vdi_map), Maps.convert_to_proxy_XenRefVIF_XenRefNetwork(_vif_map), Maps.convert_to_proxy_string_string(_options)).parse());
        }

        /// <summary>
        /// Returns a record describing the VM's dynamic state, initialised when the VM boots and updated to reflect runtime configuration changes e.g. CPU hotplug
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static VM get_boot_record(Session session, string _vm)
        {
            return new VM((Proxy_VM)session.proxy.vm_get_boot_record(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// 
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static List<Data_source> get_data_sources(Session session, string _vm)
        {
            return Helper.Proxy_Data_sourceArrayToData_sourceList(session.proxy.vm_get_data_sources(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Start recording the specified data source
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_data_source">The data source to record</param>
        public static void record_data_source(Session session, string _vm, string _data_source)
        {
            session.proxy.vm_record_data_source(session.uuid, (_vm != null) ? _vm : "", (_data_source != null) ? _data_source : "").parse();
        }

        /// <summary>
        /// Query the latest value of the specified data source
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_data_source">The data source to query</param>
        public static double query_data_source(Session session, string _vm, string _data_source)
        {
            return Convert.ToDouble(session.proxy.vm_query_data_source(session.uuid, (_vm != null) ? _vm : "", (_data_source != null) ? _data_source : "").parse());
        }

        /// <summary>
        /// Forget the recorded statistics related to the specified data source
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_data_source">The data source whose archives are to be forgotten</param>
        public static void forget_data_source_archives(Session session, string _vm, string _data_source)
        {
            session.proxy.vm_forget_data_source_archives(session.uuid, (_vm != null) ? _vm : "", (_data_source != null) ? _data_source : "").parse();
        }

        /// <summary>
        /// Check to see whether this operation is acceptable in the current state of the system, raising an error if the operation is invalid for some reason
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_op">proposed operation</param>
        public static void assert_operation_valid(Session session, string _vm, vm_operations _op)
        {
            session.proxy.vm_assert_operation_valid(session.uuid, (_vm != null) ? _vm : "", vm_operations_helper.ToString(_op)).parse();
        }

        /// <summary>
        /// Check to see whether this operation is acceptable in the current state of the system, raising an error if the operation is invalid for some reason
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_op">proposed operation</param>
        public static XenRef<Task> async_assert_operation_valid(Session session, string _vm, vm_operations _op)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_assert_operation_valid(session.uuid, (_vm != null) ? _vm : "", vm_operations_helper.ToString(_op)).parse());
        }

        /// <summary>
        /// Recomputes the list of acceptable operations
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void update_allowed_operations(Session session, string _vm)
        {
            session.proxy.vm_update_allowed_operations(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Recomputes the list of acceptable operations
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_update_allowed_operations(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_update_allowed_operations(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Returns a list of the allowed values that a VBD device field can take
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string[] get_allowed_VBD_devices(Session session, string _vm)
        {
            return (string [])session.proxy.vm_get_allowed_vbd_devices(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Returns a list of the allowed values that a VIF device field can take
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static string[] get_allowed_VIF_devices(Session session, string _vm)
        {
            return (string [])session.proxy.vm_get_allowed_vif_devices(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Return the list of hosts on which this VM may run.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static List<XenRef<Host>> get_possible_hosts(Session session, string _vm)
        {
            return XenRef<Host>.Create(session.proxy.vm_get_possible_hosts(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Return the list of hosts on which this VM may run.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_get_possible_hosts(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_get_possible_hosts(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Returns an error if the VM could not boot on this host for some reason
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_host">The host</param>
        public static void assert_can_boot_here(Session session, string _vm, string _host)
        {
            session.proxy.vm_assert_can_boot_here(session.uuid, (_vm != null) ? _vm : "", (_host != null) ? _host : "").parse();
        }

        /// <summary>
        /// Returns an error if the VM could not boot on this host for some reason
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_host">The host</param>
        public static XenRef<Task> async_assert_can_boot_here(Session session, string _vm, string _host)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_assert_can_boot_here(session.uuid, (_vm != null) ? _vm : "", (_host != null) ? _host : "").parse());
        }

        /// <summary>
        /// Create a placeholder for a named binary blob of data that is associated with this VM
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_name">The name associated with the blob</param>
        /// <param name="_mime_type">The mime type for the data. Empty string translates to application/octet-stream</param>
        public static XenRef<Blob> create_new_blob(Session session, string _vm, string _name, string _mime_type)
        {
            return XenRef<Blob>.Create(session.proxy.vm_create_new_blob(session.uuid, (_vm != null) ? _vm : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "").parse());
        }

        /// <summary>
        /// Create a placeholder for a named binary blob of data that is associated with this VM
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_name">The name associated with the blob</param>
        /// <param name="_mime_type">The mime type for the data. Empty string translates to application/octet-stream</param>
        public static XenRef<Task> async_create_new_blob(Session session, string _vm, string _name, string _mime_type)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_create_new_blob(session.uuid, (_vm != null) ? _vm : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "").parse());
        }

        /// <summary>
        /// Create a placeholder for a named binary blob of data that is associated with this VM
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_name">The name associated with the blob</param>
        /// <param name="_mime_type">The mime type for the data. Empty string translates to application/octet-stream</param>
        /// <param name="_public">True if the blob should be publicly available First published in XenServer 6.1.</param>
        public static XenRef<Blob> create_new_blob(Session session, string _vm, string _name, string _mime_type, bool _public)
        {
            return XenRef<Blob>.Create(session.proxy.vm_create_new_blob(session.uuid, (_vm != null) ? _vm : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "", _public).parse());
        }

        /// <summary>
        /// Create a placeholder for a named binary blob of data that is associated with this VM
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_name">The name associated with the blob</param>
        /// <param name="_mime_type">The mime type for the data. Empty string translates to application/octet-stream</param>
        /// <param name="_public">True if the blob should be publicly available First published in XenServer 6.1.</param>
        public static XenRef<Task> async_create_new_blob(Session session, string _vm, string _name, string _mime_type, bool _public)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_create_new_blob(session.uuid, (_vm != null) ? _vm : "", (_name != null) ? _name : "", (_mime_type != null) ? _mime_type : "", _public).parse());
        }

        /// <summary>
        /// Returns an error if the VM is not considered agile e.g. because it is tied to a resource local to a host
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static void assert_agile(Session session, string _vm)
        {
            session.proxy.vm_assert_agile(session.uuid, (_vm != null) ? _vm : "").parse();
        }

        /// <summary>
        /// Returns an error if the VM is not considered agile e.g. because it is tied to a resource local to a host
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_assert_agile(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_assert_agile(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Returns mapping of hosts to ratings, indicating the suitability of starting the VM at that location according to wlb. Rating is replaced with an error if the VM cannot boot there.
        /// First published in XenServer 5.5.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<XenRef<Host>, string[]> retrieve_wlb_recommendations(Session session, string _vm)
        {
            return Maps.convert_from_proxy_XenRefHost_string_array(session.proxy.vm_retrieve_wlb_recommendations(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Returns mapping of hosts to ratings, indicating the suitability of starting the VM at that location according to wlb. Rating is replaced with an error if the VM cannot boot there.
        /// First published in XenServer 5.5.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_retrieve_wlb_recommendations(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_retrieve_wlb_recommendations(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Copy the BIOS strings from the given host to this VM
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_host">The host to copy the BIOS strings from</param>
        public static void copy_bios_strings(Session session, string _vm, string _host)
        {
            session.proxy.vm_copy_bios_strings(session.uuid, (_vm != null) ? _vm : "", (_host != null) ? _host : "").parse();
        }

        /// <summary>
        /// Copy the BIOS strings from the given host to this VM
        /// First published in XenServer 5.6.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_host">The host to copy the BIOS strings from</param>
        public static XenRef<Task> async_copy_bios_strings(Session session, string _vm, string _host)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_copy_bios_strings(session.uuid, (_vm != null) ? _vm : "", (_host != null) ? _host : "").parse());
        }

        /// <summary>
        /// Set the value of the protection_policy field
        /// First published in XenServer 5.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The value</param>
        public static void set_protection_policy(Session session, string _vm, string _value)
        {
            session.proxy.vm_set_protection_policy(session.uuid, (_vm != null) ? _vm : "", (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Set this VM's start delay in seconds
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">This VM's start delay in seconds</param>
        public static void set_start_delay(Session session, string _vm, long _value)
        {
            session.proxy.vm_set_start_delay(session.uuid, (_vm != null) ? _vm : "", _value.ToString()).parse();
        }

        /// <summary>
        /// Set this VM's start delay in seconds
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">This VM's start delay in seconds</param>
        public static XenRef<Task> async_set_start_delay(Session session, string _vm, long _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_set_start_delay(session.uuid, (_vm != null) ? _vm : "", _value.ToString()).parse());
        }

        /// <summary>
        /// Set this VM's shutdown delay in seconds
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">This VM's shutdown delay in seconds</param>
        public static void set_shutdown_delay(Session session, string _vm, long _value)
        {
            session.proxy.vm_set_shutdown_delay(session.uuid, (_vm != null) ? _vm : "", _value.ToString()).parse();
        }

        /// <summary>
        /// Set this VM's shutdown delay in seconds
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">This VM's shutdown delay in seconds</param>
        public static XenRef<Task> async_set_shutdown_delay(Session session, string _vm, long _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_set_shutdown_delay(session.uuid, (_vm != null) ? _vm : "", _value.ToString()).parse());
        }

        /// <summary>
        /// Set this VM's boot order
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">This VM's boot order</param>
        public static void set_order(Session session, string _vm, long _value)
        {
            session.proxy.vm_set_order(session.uuid, (_vm != null) ? _vm : "", _value.ToString()).parse();
        }

        /// <summary>
        /// Set this VM's boot order
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">This VM's boot order</param>
        public static XenRef<Task> async_set_order(Session session, string _vm, long _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_set_order(session.uuid, (_vm != null) ? _vm : "", _value.ToString()).parse());
        }

        /// <summary>
        /// Set this VM's suspend VDI, which must be indentical to its current one
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The suspend VDI uuid</param>
        public static void set_suspend_VDI(Session session, string _vm, string _value)
        {
            session.proxy.vm_set_suspend_vdi(session.uuid, (_vm != null) ? _vm : "", (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Set this VM's suspend VDI, which must be indentical to its current one
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The suspend VDI uuid</param>
        public static XenRef<Task> async_set_suspend_VDI(Session session, string _vm, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_set_suspend_vdi(session.uuid, (_vm != null) ? _vm : "", (_value != null) ? _value : "").parse());
        }

        /// <summary>
        /// Assert whether all SRs required to recover this VM are available.
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_session_to">The session to which the VM is to be recovered.</param>
        public static void assert_can_be_recovered(Session session, string _vm, string _session_to)
        {
            session.proxy.vm_assert_can_be_recovered(session.uuid, (_vm != null) ? _vm : "", (_session_to != null) ? _session_to : "").parse();
        }

        /// <summary>
        /// Assert whether all SRs required to recover this VM are available.
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_session_to">The session to which the VM is to be recovered.</param>
        public static XenRef<Task> async_assert_can_be_recovered(Session session, string _vm, string _session_to)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_assert_can_be_recovered(session.uuid, (_vm != null) ? _vm : "", (_session_to != null) ? _session_to : "").parse());
        }

        /// <summary>
        /// List all the SR's that are required for the VM to be recovered
        /// First published in XenServer 6.5.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_session_to">The session to which the SRs of the VM have to be recovered.</param>
        public static List<XenRef<SR>> get_SRs_required_for_recovery(Session session, string _vm, string _session_to)
        {
            return XenRef<SR>.Create(session.proxy.vm_get_srs_required_for_recovery(session.uuid, (_vm != null) ? _vm : "", (_session_to != null) ? _session_to : "").parse());
        }

        /// <summary>
        /// List all the SR's that are required for the VM to be recovered
        /// First published in XenServer 6.5.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_session_to">The session to which the SRs of the VM have to be recovered.</param>
        public static XenRef<Task> async_get_SRs_required_for_recovery(Session session, string _vm, string _session_to)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_get_srs_required_for_recovery(session.uuid, (_vm != null) ? _vm : "", (_session_to != null) ? _session_to : "").parse());
        }

        /// <summary>
        /// Recover the VM
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_session_to">The session to which the VM is to be recovered.</param>
        /// <param name="_force">Whether the VM should replace newer versions of itself.</param>
        public static void recover(Session session, string _vm, string _session_to, bool _force)
        {
            session.proxy.vm_recover(session.uuid, (_vm != null) ? _vm : "", (_session_to != null) ? _session_to : "", _force).parse();
        }

        /// <summary>
        /// Recover the VM
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_session_to">The session to which the VM is to be recovered.</param>
        /// <param name="_force">Whether the VM should replace newer versions of itself.</param>
        public static XenRef<Task> async_recover(Session session, string _vm, string _session_to, bool _force)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_recover(session.uuid, (_vm != null) ? _vm : "", (_session_to != null) ? _session_to : "", _force).parse());
        }

        /// <summary>
        /// Import using a conversion service.
        /// First published in XenServer 6.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_type">Type of the conversion</param>
        /// <param name="_username">Admin username on the host</param>
        /// <param name="_password">Password on the host</param>
        /// <param name="_sr">The destination SR</param>
        /// <param name="_remote_config">Remote configuration options</param>
        public static void import_convert(Session session, string _type, string _username, string _password, string _sr, Dictionary<string, string> _remote_config)
        {
            session.proxy.vm_import_convert(session.uuid, (_type != null) ? _type : "", (_username != null) ? _username : "", (_password != null) ? _password : "", (_sr != null) ? _sr : "", Maps.convert_to_proxy_string_string(_remote_config)).parse();
        }

        /// <summary>
        /// Import using a conversion service.
        /// First published in XenServer 6.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_type">Type of the conversion</param>
        /// <param name="_username">Admin username on the host</param>
        /// <param name="_password">Password on the host</param>
        /// <param name="_sr">The destination SR</param>
        /// <param name="_remote_config">Remote configuration options</param>
        public static XenRef<Task> async_import_convert(Session session, string _type, string _username, string _password, string _sr, Dictionary<string, string> _remote_config)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_import_convert(session.uuid, (_type != null) ? _type : "", (_username != null) ? _username : "", (_password != null) ? _password : "", (_sr != null) ? _sr : "", Maps.convert_to_proxy_string_string(_remote_config)).parse());
        }

        /// <summary>
        /// Assign this VM to an appliance.
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The appliance to which this VM should be assigned.</param>
        public static void set_appliance(Session session, string _vm, string _value)
        {
            session.proxy.vm_set_appliance(session.uuid, (_vm != null) ? _vm : "", (_value != null) ? _value : "").parse();
        }

        /// <summary>
        /// Assign this VM to an appliance.
        /// First published in XenServer 6.0.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">The appliance to which this VM should be assigned.</param>
        public static XenRef<Task> async_set_appliance(Session session, string _vm, string _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_set_appliance(session.uuid, (_vm != null) ? _vm : "", (_value != null) ? _value : "").parse());
        }

        /// <summary>
        /// Query the system services advertised by this VM and register them. This can only be applied to a system domain.
        /// First published in XenServer 6.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static Dictionary<string, string> query_services(Session session, string _vm)
        {
            return Maps.convert_from_proxy_string_string(session.proxy.vm_query_services(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Query the system services advertised by this VM and register them. This can only be applied to a system domain.
        /// First published in XenServer 6.1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        public static XenRef<Task> async_query_services(Session session, string _vm)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_query_services(session.uuid, (_vm != null) ? _vm : "").parse());
        }

        /// <summary>
        /// Call a XenAPI plugin on this vm
        /// First published in XenServer 6.5 SP1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_plugin">The name of the plugin</param>
        /// <param name="_fn">The name of the function within the plugin</param>
        /// <param name="_args">Arguments for the function</param>
        public static string call_plugin(Session session, string _vm, string _plugin, string _fn, Dictionary<string, string> _args)
        {
            return (string)session.proxy.vm_call_plugin(session.uuid, (_vm != null) ? _vm : "", (_plugin != null) ? _plugin : "", (_fn != null) ? _fn : "", Maps.convert_to_proxy_string_string(_args)).parse();
        }

        /// <summary>
        /// Call a XenAPI plugin on this vm
        /// First published in XenServer 6.5 SP1.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_plugin">The name of the plugin</param>
        /// <param name="_fn">The name of the function within the plugin</param>
        /// <param name="_args">Arguments for the function</param>
        public static XenRef<Task> async_call_plugin(Session session, string _vm, string _plugin, string _fn, Dictionary<string, string> _args)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_call_plugin(session.uuid, (_vm != null) ? _vm : "", (_plugin != null) ? _plugin : "", (_fn != null) ? _fn : "", Maps.convert_to_proxy_string_string(_args)).parse());
        }

        /// <summary>
        /// Enable or disable PV auto update on Windows vm
        /// First published in XenServer Dundee.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">True if the Windows Update feature is enabled on the VM; false otherwise</param>
        public static void set_auto_update_drivers(Session session, string _vm, bool _value)
        {
            session.proxy.vm_set_auto_update_drivers(session.uuid, (_vm != null) ? _vm : "", _value).parse();
        }

        /// <summary>
        /// Enable or disable PV auto update on Windows vm
        /// First published in XenServer Dundee.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_vm">The opaque_ref of the given vm</param>
        /// <param name="_value">True if the Windows Update feature is enabled on the VM; false otherwise</param>
        public static XenRef<Task> async_set_auto_update_drivers(Session session, string _vm, bool _value)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_set_auto_update_drivers(session.uuid, (_vm != null) ? _vm : "", _value).parse());
        }

        /// <summary>
        /// Import an XVA from a URI
        /// First published in XenServer Dundee.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_url">The URL of the XVA file</param>
        /// <param name="_sr">The destination SR for the disks</param>
        /// <param name="_full_restore">Perform a full restore</param>
        /// <param name="_force">Force the import</param>
        public static List<XenRef<VM>> import(Session session, string _url, string _sr, bool _full_restore, bool _force)
        {
            return XenRef<VM>.Create(session.proxy.vm_import(session.uuid, (_url != null) ? _url : "", (_sr != null) ? _sr : "", _full_restore, _force).parse());
        }

        /// <summary>
        /// Import an XVA from a URI
        /// First published in XenServer Dundee.
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="_url">The URL of the XVA file</param>
        /// <param name="_sr">The destination SR for the disks</param>
        /// <param name="_full_restore">Perform a full restore</param>
        /// <param name="_force">Force the import</param>
        public static XenRef<Task> async_import(Session session, string _url, string _sr, bool _full_restore, bool _force)
        {
            return XenRef<Task>.Create(session.proxy.async_vm_import(session.uuid, (_url != null) ? _url : "", (_sr != null) ? _sr : "", _full_restore, _force).parse());
        }

        /// <summary>
        /// Return a list of all the VMs known to the system.
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        public static List<XenRef<VM>> get_all(Session session)
        {
            return XenRef<VM>.Create(session.proxy.vm_get_all(session.uuid).parse());
        }

        /// <summary>
        /// Get all the VM Records at once, in a single XML RPC call
        /// First published in XenServer 4.0.
        /// </summary>
        /// <param name="session">The session</param>
        public static Dictionary<XenRef<VM>, VM> get_all_records(Session session)
        {
            return XenRef<VM>.Create<Proxy_VM>(session.proxy.vm_get_all_records(session.uuid).parse());
        }

        /// <summary>
        /// Unique identifier/object reference
        /// </summary>
        public virtual string uuid
        {
            get { return _uuid; }
            set
            {
                if (!Helper.AreEqual(value, _uuid))
                {
                    _uuid = value;
                    Changed = true;
                    NotifyPropertyChanged("uuid");
                }
            }
        }
        private string _uuid;

        /// <summary>
        /// list of the operations allowed in this state. This list is advisory only and the server state may have changed by the time this field is read by a client.
        /// </summary>
        public virtual List<vm_operations> allowed_operations
        {
            get { return _allowed_operations; }
            set
            {
                if (!Helper.AreEqual(value, _allowed_operations))
                {
                    _allowed_operations = value;
                    Changed = true;
                    NotifyPropertyChanged("allowed_operations");
                }
            }
        }
        private List<vm_operations> _allowed_operations;

        /// <summary>
        /// links each of the running tasks using this object (by reference) to a current_operation enum which describes the nature of the task.
        /// </summary>
        public virtual Dictionary<string, vm_operations> current_operations
        {
            get { return _current_operations; }
            set
            {
                if (!Helper.AreEqual(value, _current_operations))
                {
                    _current_operations = value;
                    Changed = true;
                    NotifyPropertyChanged("current_operations");
                }
            }
        }
        private Dictionary<string, vm_operations> _current_operations;

        /// <summary>
        /// Current power state of the machine
        /// </summary>
        public virtual vm_power_state power_state
        {
            get { return _power_state; }
            set
            {
                if (!Helper.AreEqual(value, _power_state))
                {
                    _power_state = value;
                    Changed = true;
                    NotifyPropertyChanged("power_state");
                }
            }
        }
        private vm_power_state _power_state;

        /// <summary>
        /// a human-readable name
        /// </summary>
        public virtual string name_label
        {
            get { return _name_label; }
            set
            {
                if (!Helper.AreEqual(value, _name_label))
                {
                    _name_label = value;
                    Changed = true;
                    NotifyPropertyChanged("name_label");
                }
            }
        }
        private string _name_label;

        /// <summary>
        /// a notes field containing human-readable description
        /// </summary>
        public virtual string name_description
        {
            get { return _name_description; }
            set
            {
                if (!Helper.AreEqual(value, _name_description))
                {
                    _name_description = value;
                    Changed = true;
                    NotifyPropertyChanged("name_description");
                }
            }
        }
        private string _name_description;

        /// <summary>
        /// Creators of VMs and templates may store version information here.
        /// </summary>
        public virtual long user_version
        {
            get { return _user_version; }
            set
            {
                if (!Helper.AreEqual(value, _user_version))
                {
                    _user_version = value;
                    Changed = true;
                    NotifyPropertyChanged("user_version");
                }
            }
        }
        private long _user_version;

        /// <summary>
        /// true if this is a template. Template VMs can never be started, they are used only for cloning other VMs
        /// </summary>
        public virtual bool is_a_template
        {
            get { return _is_a_template; }
            set
            {
                if (!Helper.AreEqual(value, _is_a_template))
                {
                    _is_a_template = value;
                    Changed = true;
                    NotifyPropertyChanged("is_a_template");
                }
            }
        }
        private bool _is_a_template;

        /// <summary>
        /// The VDI that a suspend image is stored on. (Only has meaning if VM is currently suspended)
        /// </summary>
        public virtual XenRef<VDI> suspend_VDI
        {
            get { return _suspend_VDI; }
            set
            {
                if (!Helper.AreEqual(value, _suspend_VDI))
                {
                    _suspend_VDI = value;
                    Changed = true;
                    NotifyPropertyChanged("suspend_VDI");
                }
            }
        }
        private XenRef<VDI> _suspend_VDI;

        /// <summary>
        /// the host the VM is currently resident on
        /// </summary>
        public virtual XenRef<Host> resident_on
        {
            get { return _resident_on; }
            set
            {
                if (!Helper.AreEqual(value, _resident_on))
                {
                    _resident_on = value;
                    Changed = true;
                    NotifyPropertyChanged("resident_on");
                }
            }
        }
        private XenRef<Host> _resident_on;

        /// <summary>
        /// a host which the VM has some affinity for (or NULL). This is used as a hint to the start call when it decides where to run the VM. Implementations are free to ignore this field.
        /// </summary>
        public virtual XenRef<Host> affinity
        {
            get { return _affinity; }
            set
            {
                if (!Helper.AreEqual(value, _affinity))
                {
                    _affinity = value;
                    Changed = true;
                    NotifyPropertyChanged("affinity");
                }
            }
        }
        private XenRef<Host> _affinity;

        /// <summary>
        /// Virtualization memory overhead (bytes).
        /// </summary>
        public virtual long memory_overhead
        {
            get { return _memory_overhead; }
            set
            {
                if (!Helper.AreEqual(value, _memory_overhead))
                {
                    _memory_overhead = value;
                    Changed = true;
                    NotifyPropertyChanged("memory_overhead");
                }
            }
        }
        private long _memory_overhead;

        /// <summary>
        /// Dynamically-set memory target (bytes). The value of this field indicates the current target for memory available to this VM.
        /// </summary>
        public virtual long memory_target
        {
            get { return _memory_target; }
            set
            {
                if (!Helper.AreEqual(value, _memory_target))
                {
                    _memory_target = value;
                    Changed = true;
                    NotifyPropertyChanged("memory_target");
                }
            }
        }
        private long _memory_target;

        /// <summary>
        /// Statically-set (i.e. absolute) maximum (bytes). The value of this field at VM start time acts as a hard limit of the amount of memory a guest can use. New values only take effect on reboot.
        /// </summary>
        public virtual long memory_static_max
        {
            get { return _memory_static_max; }
            set
            {
                if (!Helper.AreEqual(value, _memory_static_max))
                {
                    _memory_static_max = value;
                    Changed = true;
                    NotifyPropertyChanged("memory_static_max");
                }
            }
        }
        private long _memory_static_max;

        /// <summary>
        /// Dynamic maximum (bytes)
        /// </summary>
        public virtual long memory_dynamic_max
        {
            get { return _memory_dynamic_max; }
            set
            {
                if (!Helper.AreEqual(value, _memory_dynamic_max))
                {
                    _memory_dynamic_max = value;
                    Changed = true;
                    NotifyPropertyChanged("memory_dynamic_max");
                }
            }
        }
        private long _memory_dynamic_max;

        /// <summary>
        /// Dynamic minimum (bytes)
        /// </summary>
        public virtual long memory_dynamic_min
        {
            get { return _memory_dynamic_min; }
            set
            {
                if (!Helper.AreEqual(value, _memory_dynamic_min))
                {
                    _memory_dynamic_min = value;
                    Changed = true;
                    NotifyPropertyChanged("memory_dynamic_min");
                }
            }
        }
        private long _memory_dynamic_min;

        /// <summary>
        /// Statically-set (i.e. absolute) mininum (bytes). The value of this field indicates the least amount of memory this VM can boot with without crashing.
        /// </summary>
        public virtual long memory_static_min
        {
            get { return _memory_static_min; }
            set
            {
                if (!Helper.AreEqual(value, _memory_static_min))
                {
                    _memory_static_min = value;
                    Changed = true;
                    NotifyPropertyChanged("memory_static_min");
                }
            }
        }
        private long _memory_static_min;

        /// <summary>
        /// configuration parameters for the selected VCPU policy
        /// </summary>
        public virtual Dictionary<string, string> VCPUs_params
        {
            get { return _VCPUs_params; }
            set
            {
                if (!Helper.AreEqual(value, _VCPUs_params))
                {
                    _VCPUs_params = value;
                    Changed = true;
                    NotifyPropertyChanged("VCPUs_params");
                }
            }
        }
        private Dictionary<string, string> _VCPUs_params;

        /// <summary>
        /// Max number of VCPUs
        /// </summary>
        public virtual long VCPUs_max
        {
            get { return _VCPUs_max; }
            set
            {
                if (!Helper.AreEqual(value, _VCPUs_max))
                {
                    _VCPUs_max = value;
                    Changed = true;
                    NotifyPropertyChanged("VCPUs_max");
                }
            }
        }
        private long _VCPUs_max;

        /// <summary>
        /// Boot number of VCPUs
        /// </summary>
        public virtual long VCPUs_at_startup
        {
            get { return _VCPUs_at_startup; }
            set
            {
                if (!Helper.AreEqual(value, _VCPUs_at_startup))
                {
                    _VCPUs_at_startup = value;
                    Changed = true;
                    NotifyPropertyChanged("VCPUs_at_startup");
                }
            }
        }
        private long _VCPUs_at_startup;

        /// <summary>
        /// action to take after the guest has shutdown itself
        /// </summary>
        public virtual on_normal_exit actions_after_shutdown
        {
            get { return _actions_after_shutdown; }
            set
            {
                if (!Helper.AreEqual(value, _actions_after_shutdown))
                {
                    _actions_after_shutdown = value;
                    Changed = true;
                    NotifyPropertyChanged("actions_after_shutdown");
                }
            }
        }
        private on_normal_exit _actions_after_shutdown;

        /// <summary>
        /// action to take after the guest has rebooted itself
        /// </summary>
        public virtual on_normal_exit actions_after_reboot
        {
            get { return _actions_after_reboot; }
            set
            {
                if (!Helper.AreEqual(value, _actions_after_reboot))
                {
                    _actions_after_reboot = value;
                    Changed = true;
                    NotifyPropertyChanged("actions_after_reboot");
                }
            }
        }
        private on_normal_exit _actions_after_reboot;

        /// <summary>
        /// action to take if the guest crashes
        /// </summary>
        public virtual on_crash_behaviour actions_after_crash
        {
            get { return _actions_after_crash; }
            set
            {
                if (!Helper.AreEqual(value, _actions_after_crash))
                {
                    _actions_after_crash = value;
                    Changed = true;
                    NotifyPropertyChanged("actions_after_crash");
                }
            }
        }
        private on_crash_behaviour _actions_after_crash;

        /// <summary>
        /// virtual console devices
        /// </summary>
        public virtual List<XenRef<Console>> consoles
        {
            get { return _consoles; }
            set
            {
                if (!Helper.AreEqual(value, _consoles))
                {
                    _consoles = value;
                    Changed = true;
                    NotifyPropertyChanged("consoles");
                }
            }
        }
        private List<XenRef<Console>> _consoles;

        /// <summary>
        /// virtual network interfaces
        /// </summary>
        public virtual List<XenRef<VIF>> VIFs
        {
            get { return _VIFs; }
            set
            {
                if (!Helper.AreEqual(value, _VIFs))
                {
                    _VIFs = value;
                    Changed = true;
                    NotifyPropertyChanged("VIFs");
                }
            }
        }
        private List<XenRef<VIF>> _VIFs;

        /// <summary>
        /// virtual block devices
        /// </summary>
        public virtual List<XenRef<VBD>> VBDs
        {
            get { return _VBDs; }
            set
            {
                if (!Helper.AreEqual(value, _VBDs))
                {
                    _VBDs = value;
                    Changed = true;
                    NotifyPropertyChanged("VBDs");
                }
            }
        }
        private List<XenRef<VBD>> _VBDs;

        /// <summary>
        /// crash dumps associated with this VM
        /// </summary>
        public virtual List<XenRef<Crashdump>> crash_dumps
        {
            get { return _crash_dumps; }
            set
            {
                if (!Helper.AreEqual(value, _crash_dumps))
                {
                    _crash_dumps = value;
                    Changed = true;
                    NotifyPropertyChanged("crash_dumps");
                }
            }
        }
        private List<XenRef<Crashdump>> _crash_dumps;

        /// <summary>
        /// virtual TPMs
        /// </summary>
        public virtual List<XenRef<VTPM>> VTPMs
        {
            get { return _VTPMs; }
            set
            {
                if (!Helper.AreEqual(value, _VTPMs))
                {
                    _VTPMs = value;
                    Changed = true;
                    NotifyPropertyChanged("VTPMs");
                }
            }
        }
        private List<XenRef<VTPM>> _VTPMs;

        /// <summary>
        /// name of or path to bootloader
        /// </summary>
        public virtual string PV_bootloader
        {
            get { return _PV_bootloader; }
            set
            {
                if (!Helper.AreEqual(value, _PV_bootloader))
                {
                    _PV_bootloader = value;
                    Changed = true;
                    NotifyPropertyChanged("PV_bootloader");
                }
            }
        }
        private string _PV_bootloader;

        /// <summary>
        /// path to the kernel
        /// </summary>
        public virtual string PV_kernel
        {
            get { return _PV_kernel; }
            set
            {
                if (!Helper.AreEqual(value, _PV_kernel))
                {
                    _PV_kernel = value;
                    Changed = true;
                    NotifyPropertyChanged("PV_kernel");
                }
            }
        }
        private string _PV_kernel;

        /// <summary>
        /// path to the initrd
        /// </summary>
        public virtual string PV_ramdisk
        {
            get { return _PV_ramdisk; }
            set
            {
                if (!Helper.AreEqual(value, _PV_ramdisk))
                {
                    _PV_ramdisk = value;
                    Changed = true;
                    NotifyPropertyChanged("PV_ramdisk");
                }
            }
        }
        private string _PV_ramdisk;

        /// <summary>
        /// kernel command-line arguments
        /// </summary>
        public virtual string PV_args
        {
            get { return _PV_args; }
            set
            {
                if (!Helper.AreEqual(value, _PV_args))
                {
                    _PV_args = value;
                    Changed = true;
                    NotifyPropertyChanged("PV_args");
                }
            }
        }
        private string _PV_args;

        /// <summary>
        /// miscellaneous arguments for the bootloader
        /// </summary>
        public virtual string PV_bootloader_args
        {
            get { return _PV_bootloader_args; }
            set
            {
                if (!Helper.AreEqual(value, _PV_bootloader_args))
                {
                    _PV_bootloader_args = value;
                    Changed = true;
                    NotifyPropertyChanged("PV_bootloader_args");
                }
            }
        }
        private string _PV_bootloader_args;

        /// <summary>
        /// to make Zurich guests boot
        /// </summary>
        public virtual string PV_legacy_args
        {
            get { return _PV_legacy_args; }
            set
            {
                if (!Helper.AreEqual(value, _PV_legacy_args))
                {
                    _PV_legacy_args = value;
                    Changed = true;
                    NotifyPropertyChanged("PV_legacy_args");
                }
            }
        }
        private string _PV_legacy_args;

        /// <summary>
        /// HVM boot policy
        /// </summary>
        public virtual string HVM_boot_policy
        {
            get { return _HVM_boot_policy; }
            set
            {
                if (!Helper.AreEqual(value, _HVM_boot_policy))
                {
                    _HVM_boot_policy = value;
                    Changed = true;
                    NotifyPropertyChanged("HVM_boot_policy");
                }
            }
        }
        private string _HVM_boot_policy;

        /// <summary>
        /// HVM boot params
        /// </summary>
        public virtual Dictionary<string, string> HVM_boot_params
        {
            get { return _HVM_boot_params; }
            set
            {
                if (!Helper.AreEqual(value, _HVM_boot_params))
                {
                    _HVM_boot_params = value;
                    Changed = true;
                    NotifyPropertyChanged("HVM_boot_params");
                }
            }
        }
        private Dictionary<string, string> _HVM_boot_params;

        /// <summary>
        /// multiplier applied to the amount of shadow that will be made available to the guest
        /// First published in XenServer 4.1.
        /// </summary>
        public virtual double HVM_shadow_multiplier
        {
            get { return _HVM_shadow_multiplier; }
            set
            {
                if (!Helper.AreEqual(value, _HVM_shadow_multiplier))
                {
                    _HVM_shadow_multiplier = value;
                    Changed = true;
                    NotifyPropertyChanged("HVM_shadow_multiplier");
                }
            }
        }
        private double _HVM_shadow_multiplier;

        /// <summary>
        /// platform-specific configuration
        /// </summary>
        public virtual Dictionary<string, string> platform
        {
            get { return _platform; }
            set
            {
                if (!Helper.AreEqual(value, _platform))
                {
                    _platform = value;
                    Changed = true;
                    NotifyPropertyChanged("platform");
                }
            }
        }
        private Dictionary<string, string> _platform;

        /// <summary>
        /// PCI bus path for pass-through devices
        /// </summary>
        public virtual string PCI_bus
        {
            get { return _PCI_bus; }
            set
            {
                if (!Helper.AreEqual(value, _PCI_bus))
                {
                    _PCI_bus = value;
                    Changed = true;
                    NotifyPropertyChanged("PCI_bus");
                }
            }
        }
        private string _PCI_bus;

        /// <summary>
        /// additional configuration
        /// </summary>
        public virtual Dictionary<string, string> other_config
        {
            get { return _other_config; }
            set
            {
                if (!Helper.AreEqual(value, _other_config))
                {
                    _other_config = value;
                    Changed = true;
                    NotifyPropertyChanged("other_config");
                }
            }
        }
        private Dictionary<string, string> _other_config;

        /// <summary>
        /// domain ID (if available, -1 otherwise)
        /// </summary>
        public virtual long domid
        {
            get { return _domid; }
            set
            {
                if (!Helper.AreEqual(value, _domid))
                {
                    _domid = value;
                    Changed = true;
                    NotifyPropertyChanged("domid");
                }
            }
        }
        private long _domid;

        /// <summary>
        /// Domain architecture (if available, null string otherwise)
        /// </summary>
        public virtual string domarch
        {
            get { return _domarch; }
            set
            {
                if (!Helper.AreEqual(value, _domarch))
                {
                    _domarch = value;
                    Changed = true;
                    NotifyPropertyChanged("domarch");
                }
            }
        }
        private string _domarch;

        /// <summary>
        /// describes the CPU flags on which the VM was last booted
        /// </summary>
        public virtual Dictionary<string, string> last_boot_CPU_flags
        {
            get { return _last_boot_CPU_flags; }
            set
            {
                if (!Helper.AreEqual(value, _last_boot_CPU_flags))
                {
                    _last_boot_CPU_flags = value;
                    Changed = true;
                    NotifyPropertyChanged("last_boot_CPU_flags");
                }
            }
        }
        private Dictionary<string, string> _last_boot_CPU_flags;

        /// <summary>
        /// true if this is a control domain (domain 0 or a driver domain)
        /// </summary>
        public virtual bool is_control_domain
        {
            get { return _is_control_domain; }
            set
            {
                if (!Helper.AreEqual(value, _is_control_domain))
                {
                    _is_control_domain = value;
                    Changed = true;
                    NotifyPropertyChanged("is_control_domain");
                }
            }
        }
        private bool _is_control_domain;

        /// <summary>
        /// metrics associated with this VM
        /// </summary>
        public virtual XenRef<VM_metrics> metrics
        {
            get { return _metrics; }
            set
            {
                if (!Helper.AreEqual(value, _metrics))
                {
                    _metrics = value;
                    Changed = true;
                    NotifyPropertyChanged("metrics");
                }
            }
        }
        private XenRef<VM_metrics> _metrics;

        /// <summary>
        /// metrics associated with the running guest
        /// </summary>
        public virtual XenRef<VM_guest_metrics> guest_metrics
        {
            get { return _guest_metrics; }
            set
            {
                if (!Helper.AreEqual(value, _guest_metrics))
                {
                    _guest_metrics = value;
                    Changed = true;
                    NotifyPropertyChanged("guest_metrics");
                }
            }
        }
        private XenRef<VM_guest_metrics> _guest_metrics;

        /// <summary>
        /// marshalled value containing VM record at time of last boot, updated dynamically to reflect the runtime state of the domain
        /// First published in XenServer 4.1.
        /// </summary>
        public virtual string last_booted_record
        {
            get { return _last_booted_record; }
            set
            {
                if (!Helper.AreEqual(value, _last_booted_record))
                {
                    _last_booted_record = value;
                    Changed = true;
                    NotifyPropertyChanged("last_booted_record");
                }
            }
        }
        private string _last_booted_record;

        /// <summary>
        /// An XML specification of recommended values and ranges for properties of this VM
        /// </summary>
        public virtual string recommendations
        {
            get { return _recommendations; }
            set
            {
                if (!Helper.AreEqual(value, _recommendations))
                {
                    _recommendations = value;
                    Changed = true;
                    NotifyPropertyChanged("recommendations");
                }
            }
        }
        private string _recommendations;

        /// <summary>
        /// data to be inserted into the xenstore tree (/local/domain/<domid>/vm-data) after the VM is created.
        /// First published in XenServer 4.1.
        /// </summary>
        public virtual Dictionary<string, string> xenstore_data
        {
            get { return _xenstore_data; }
            set
            {
                if (!Helper.AreEqual(value, _xenstore_data))
                {
                    _xenstore_data = value;
                    Changed = true;
                    NotifyPropertyChanged("xenstore_data");
                }
            }
        }
        private Dictionary<string, string> _xenstore_data;

        /// <summary>
        /// if true then the system will attempt to keep the VM running as much as possible.
        /// First published in XenServer 5.0.
        /// </summary>
        public virtual bool ha_always_run
        {
            get { return _ha_always_run; }
            set
            {
                if (!Helper.AreEqual(value, _ha_always_run))
                {
                    _ha_always_run = value;
                    Changed = true;
                    NotifyPropertyChanged("ha_always_run");
                }
            }
        }
        private bool _ha_always_run;

        /// <summary>
        /// has possible values: "best-effort" meaning "try to restart this VM if possible but don't consider the Pool to be overcommitted if this is not possible"; "restart" meaning "this VM should be restarted"; "" meaning "do not try to restart this VM"
        /// First published in XenServer 5.0.
        /// </summary>
        public virtual string ha_restart_priority
        {
            get { return _ha_restart_priority; }
            set
            {
                if (!Helper.AreEqual(value, _ha_restart_priority))
                {
                    _ha_restart_priority = value;
                    Changed = true;
                    NotifyPropertyChanged("ha_restart_priority");
                }
            }
        }
        private string _ha_restart_priority;

        /// <summary>
        /// true if this is a snapshot. Snapshotted VMs can never be started, they are used only for cloning other VMs
        /// First published in XenServer 5.0.
        /// </summary>
        public virtual bool is_a_snapshot
        {
            get { return _is_a_snapshot; }
            set
            {
                if (!Helper.AreEqual(value, _is_a_snapshot))
                {
                    _is_a_snapshot = value;
                    Changed = true;
                    NotifyPropertyChanged("is_a_snapshot");
                }
            }
        }
        private bool _is_a_snapshot;

        /// <summary>
        /// Ref pointing to the VM this snapshot is of.
        /// First published in XenServer 5.0.
        /// </summary>
        public virtual XenRef<VM> snapshot_of
        {
            get { return _snapshot_of; }
            set
            {
                if (!Helper.AreEqual(value, _snapshot_of))
                {
                    _snapshot_of = value;
                    Changed = true;
                    NotifyPropertyChanged("snapshot_of");
                }
            }
        }
        private XenRef<VM> _snapshot_of;

        /// <summary>
        /// List pointing to all the VM snapshots.
        /// First published in XenServer 5.0.
        /// </summary>
        public virtual List<XenRef<VM>> snapshots
        {
            get { return _snapshots; }
            set
            {
                if (!Helper.AreEqual(value, _snapshots))
                {
                    _snapshots = value;
                    Changed = true;
                    NotifyPropertyChanged("snapshots");
                }
            }
        }
        private List<XenRef<VM>> _snapshots;

        /// <summary>
        /// Date/time when this snapshot was created.
        /// First published in XenServer 5.0.
        /// </summary>
        public virtual DateTime snapshot_time
        {
            get { return _snapshot_time; }
            set
            {
                if (!Helper.AreEqual(value, _snapshot_time))
                {
                    _snapshot_time = value;
                    Changed = true;
                    NotifyPropertyChanged("snapshot_time");
                }
            }
        }
        private DateTime _snapshot_time;

        /// <summary>
        /// Transportable ID of the snapshot VM
        /// First published in XenServer 5.0.
        /// </summary>
        public virtual string transportable_snapshot_id
        {
            get { return _transportable_snapshot_id; }
            set
            {
                if (!Helper.AreEqual(value, _transportable_snapshot_id))
                {
                    _transportable_snapshot_id = value;
                    Changed = true;
                    NotifyPropertyChanged("transportable_snapshot_id");
                }
            }
        }
        private string _transportable_snapshot_id;

        /// <summary>
        /// Binary blobs associated with this VM
        /// First published in XenServer 5.0.
        /// </summary>
        public virtual Dictionary<string, XenRef<Blob>> blobs
        {
            get { return _blobs; }
            set
            {
                if (!Helper.AreEqual(value, _blobs))
                {
                    _blobs = value;
                    Changed = true;
                    NotifyPropertyChanged("blobs");
                }
            }
        }
        private Dictionary<string, XenRef<Blob>> _blobs;

        /// <summary>
        /// user-specified tags for categorization purposes
        /// First published in XenServer 5.0.
        /// </summary>
        public virtual string[] tags
        {
            get { return _tags; }
            set
            {
                if (!Helper.AreEqual(value, _tags))
                {
                    _tags = value;
                    Changed = true;
                    NotifyPropertyChanged("tags");
                }
            }
        }
        private string[] _tags;

        /// <summary>
        /// List of operations which have been explicitly blocked and an error code
        /// First published in XenServer 5.0.
        /// </summary>
        public virtual Dictionary<vm_operations, string> blocked_operations
        {
            get { return _blocked_operations; }
            set
            {
                if (!Helper.AreEqual(value, _blocked_operations))
                {
                    _blocked_operations = value;
                    Changed = true;
                    NotifyPropertyChanged("blocked_operations");
                }
            }
        }
        private Dictionary<vm_operations, string> _blocked_operations;

        /// <summary>
        /// Human-readable information concerning this snapshot
        /// First published in XenServer 5.6.
        /// </summary>
        public virtual Dictionary<string, string> snapshot_info
        {
            get { return _snapshot_info; }
            set
            {
                if (!Helper.AreEqual(value, _snapshot_info))
                {
                    _snapshot_info = value;
                    Changed = true;
                    NotifyPropertyChanged("snapshot_info");
                }
            }
        }
        private Dictionary<string, string> _snapshot_info;

        /// <summary>
        /// Encoded information about the VM's metadata this is a snapshot of
        /// First published in XenServer 5.6.
        /// </summary>
        public virtual string snapshot_metadata
        {
            get { return _snapshot_metadata; }
            set
            {
                if (!Helper.AreEqual(value, _snapshot_metadata))
                {
                    _snapshot_metadata = value;
                    Changed = true;
                    NotifyPropertyChanged("snapshot_metadata");
                }
            }
        }
        private string _snapshot_metadata;

        /// <summary>
        /// Ref pointing to the parent of this VM
        /// First published in XenServer 5.6.
        /// </summary>
        public virtual XenRef<VM> parent
        {
            get { return _parent; }
            set
            {
                if (!Helper.AreEqual(value, _parent))
                {
                    _parent = value;
                    Changed = true;
                    NotifyPropertyChanged("parent");
                }
            }
        }
        private XenRef<VM> _parent;

        /// <summary>
        /// List pointing to all the children of this VM
        /// First published in XenServer 5.6.
        /// </summary>
        public virtual List<XenRef<VM>> children
        {
            get { return _children; }
            set
            {
                if (!Helper.AreEqual(value, _children))
                {
                    _children = value;
                    Changed = true;
                    NotifyPropertyChanged("children");
                }
            }
        }
        private List<XenRef<VM>> _children;

        /// <summary>
        /// BIOS strings
        /// First published in XenServer 5.6.
        /// </summary>
        public virtual Dictionary<string, string> bios_strings
        {
            get { return _bios_strings; }
            set
            {
                if (!Helper.AreEqual(value, _bios_strings))
                {
                    _bios_strings = value;
                    Changed = true;
                    NotifyPropertyChanged("bios_strings");
                }
            }
        }
        private Dictionary<string, string> _bios_strings;

        /// <summary>
        /// Ref pointing to a protection policy for this VM
        /// First published in XenServer 5.6 FP1.
        /// </summary>
        public virtual XenRef<VMPP> protection_policy
        {
            get { return _protection_policy; }
            set
            {
                if (!Helper.AreEqual(value, _protection_policy))
                {
                    _protection_policy = value;
                    Changed = true;
                    NotifyPropertyChanged("protection_policy");
                }
            }
        }
        private XenRef<VMPP> _protection_policy;

        /// <summary>
        /// true if this snapshot was created by the protection policy
        /// First published in XenServer 5.6 FP1.
        /// </summary>
        public virtual bool is_snapshot_from_vmpp
        {
            get { return _is_snapshot_from_vmpp; }
            set
            {
                if (!Helper.AreEqual(value, _is_snapshot_from_vmpp))
                {
                    _is_snapshot_from_vmpp = value;
                    Changed = true;
                    NotifyPropertyChanged("is_snapshot_from_vmpp");
                }
            }
        }
        private bool _is_snapshot_from_vmpp;

        /// <summary>
        /// the appliance to which this VM belongs
        /// </summary>
        public virtual XenRef<VM_appliance> appliance
        {
            get { return _appliance; }
            set
            {
                if (!Helper.AreEqual(value, _appliance))
                {
                    _appliance = value;
                    Changed = true;
                    NotifyPropertyChanged("appliance");
                }
            }
        }
        private XenRef<VM_appliance> _appliance;

        /// <summary>
        /// The delay to wait before proceeding to the next order in the startup sequence (seconds)
        /// First published in XenServer 6.0.
        /// </summary>
        public virtual long start_delay
        {
            get { return _start_delay; }
            set
            {
                if (!Helper.AreEqual(value, _start_delay))
                {
                    _start_delay = value;
                    Changed = true;
                    NotifyPropertyChanged("start_delay");
                }
            }
        }
        private long _start_delay;

        /// <summary>
        /// The delay to wait before proceeding to the next order in the shutdown sequence (seconds)
        /// First published in XenServer 6.0.
        /// </summary>
        public virtual long shutdown_delay
        {
            get { return _shutdown_delay; }
            set
            {
                if (!Helper.AreEqual(value, _shutdown_delay))
                {
                    _shutdown_delay = value;
                    Changed = true;
                    NotifyPropertyChanged("shutdown_delay");
                }
            }
        }
        private long _shutdown_delay;

        /// <summary>
        /// The point in the startup or shutdown sequence at which this VM will be started
        /// First published in XenServer 6.0.
        /// </summary>
        public virtual long order
        {
            get { return _order; }
            set
            {
                if (!Helper.AreEqual(value, _order))
                {
                    _order = value;
                    Changed = true;
                    NotifyPropertyChanged("order");
                }
            }
        }
        private long _order;

        /// <summary>
        /// Virtual GPUs
        /// First published in XenServer 6.0.
        /// </summary>
        public virtual List<XenRef<VGPU>> VGPUs
        {
            get { return _VGPUs; }
            set
            {
                if (!Helper.AreEqual(value, _VGPUs))
                {
                    _VGPUs = value;
                    Changed = true;
                    NotifyPropertyChanged("VGPUs");
                }
            }
        }
        private List<XenRef<VGPU>> _VGPUs;

        /// <summary>
        /// Currently passed-through PCI devices
        /// First published in XenServer 6.0.
        /// </summary>
        public virtual List<XenRef<PCI>> attached_PCIs
        {
            get { return _attached_PCIs; }
            set
            {
                if (!Helper.AreEqual(value, _attached_PCIs))
                {
                    _attached_PCIs = value;
                    Changed = true;
                    NotifyPropertyChanged("attached_PCIs");
                }
            }
        }
        private List<XenRef<PCI>> _attached_PCIs;

        /// <summary>
        /// The SR on which a suspend image is stored
        /// First published in XenServer 6.0.
        /// </summary>
        public virtual XenRef<SR> suspend_SR
        {
            get { return _suspend_SR; }
            set
            {
                if (!Helper.AreEqual(value, _suspend_SR))
                {
                    _suspend_SR = value;
                    Changed = true;
                    NotifyPropertyChanged("suspend_SR");
                }
            }
        }
        private XenRef<SR> _suspend_SR;

        /// <summary>
        /// The number of times this VM has been recovered
        /// First published in XenServer 6.0.
        /// </summary>
        public virtual long version
        {
            get { return _version; }
            set
            {
                if (!Helper.AreEqual(value, _version))
                {
                    _version = value;
                    Changed = true;
                    NotifyPropertyChanged("version");
                }
            }
        }
        private long _version;

        /// <summary>
        /// Generation ID of the VM
        /// First published in XenServer 6.2.
        /// </summary>
        public virtual string generation_id
        {
            get { return _generation_id; }
            set
            {
                if (!Helper.AreEqual(value, _generation_id))
                {
                    _generation_id = value;
                    Changed = true;
                    NotifyPropertyChanged("generation_id");
                }
            }
        }
        private string _generation_id;

        /// <summary>
        /// The host virtual hardware platform version the VM can run on
        /// First published in XenServer 6.5 SP1.
        /// </summary>
        public virtual long hardware_platform_version
        {
            get { return _hardware_platform_version; }
            set
            {
                if (!Helper.AreEqual(value, _hardware_platform_version))
                {
                    _hardware_platform_version = value;
                    Changed = true;
                    NotifyPropertyChanged("hardware_platform_version");
                }
            }
        }
        private long _hardware_platform_version;

        /// <summary>
        /// Does nothing at present. To be removed before Dundee release, once other code no longer refers to it.
        /// Experimental. First published in XenServer Dundee.
        /// </summary>
        public virtual bool auto_update_drivers
        {
            get { return _auto_update_drivers; }
            set
            {
                if (!Helper.AreEqual(value, _auto_update_drivers))
                {
                    _auto_update_drivers = value;
                    Changed = true;
                    NotifyPropertyChanged("auto_update_drivers");
                }
            }
        }
        private bool _auto_update_drivers;

        /// <summary>
        /// Does nothing at present. Intended to replace auto_update_drivers to control the presence of the C000 PCI device.
        /// Experimental. First published in XenServer Dundee.
        /// </summary>
        public virtual bool has_vendor_device
        {
            get { return _has_vendor_device; }
            set
            {
                if (!Helper.AreEqual(value, _has_vendor_device))
                {
                    _has_vendor_device = value;
                    Changed = true;
                    NotifyPropertyChanged("has_vendor_device");
                }
            }
        }
        private bool _has_vendor_device;
    }
}
