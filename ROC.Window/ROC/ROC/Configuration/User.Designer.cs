﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ROC.Configuration {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    internal sealed partial class User : global::System.Configuration.ApplicationSettingsBase {
        
        private static User defaultInstance = ((User)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new User())));
        
        public static User Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("23:55:00")]
        public string StopTime {
            get {
                return ((string)(this["StopTime"]));
            }
            set {
                this["StopTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseStopTime {
            get {
                return ((bool)(this["UseStopTime"]));
            }
            set {
                this["UseStopTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseLogRetensionLimit {
            get {
                return ((bool)(this["UseLogRetensionLimit"]));
            }
            set {
                this["UseLogRetensionLimit"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public int LogRetensionDays {
            get {
                return ((int)(this["LogRetensionDays"]));
            }
            set {
                this["LogRetensionDays"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("50")]
        public int UIUpdateRate {
            get {
                return ((int)(this["UIUpdateRate"]));
            }
            set {
                this["UIUpdateRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("500")]
        public int NotificationDuration {
            get {
                return ((int)(this["NotificationDuration"]));
            }
            set {
                this["NotificationDuration"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ROC DEV")]
        public string InstanceName {
            get {
                return ((string)(this["InstanceName"]));
            }
            set {
                this["InstanceName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30000")]
        public int TPOSUpdateRate {
            get {
                return ((int)(this["TPOSUpdateRate"]));
            }
            set {
                this["TPOSUpdateRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("50")]
        public long LogFileSizeLimit {
            get {
                return ((long)(this["LogFileSizeLimit"]));
            }
            set {
                this["LogFileSizeLimit"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseUIUpdateRate {
            get {
                return ((bool)(this["UseUIUpdateRate"]));
            }
            set {
                this["UseUIUpdateRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UpdateBatchTicketStatus {
            get {
                return ((bool)(this["UpdateBatchTicketStatus"]));
            }
            set {
                this["UpdateBatchTicketStatus"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int DesktopHeight {
            get {
                return ((int)(this["DesktopHeight"]));
            }
            set {
                this["DesktopHeight"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int DesktopWidth {
            get {
                return ((int)(this["DesktopWidth"]));
            }
            set {
                this["DesktopWidth"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseMarketData {
            get {
                return ((bool)(this["UseMarketData"]));
            }
            set {
                this["UseMarketData"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseTPOS {
            get {
                return ((bool)(this["UseTPOS"]));
            }
            set {
                this["UseTPOS"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseROMDatabase {
            get {
                return ((bool)(this["UseROMDatabase"]));
            }
            set {
                this["UseROMDatabase"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ShowOnlySelectedExchange {
            get {
                return ((bool)(this["ShowOnlySelectedExchange"]));
            }
            set {
                this["ShowOnlySelectedExchange"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool PlayAllStatusSound {
            get {
                return ((bool)(this["PlayAllStatusSound"]));
            }
            set {
                this["PlayAllStatusSound"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LastUserName {
            get {
                return ((string)(this["LastUserName"]));
            }
            set {
                this["LastUserName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ConfirmOnCancellAll {
            get {
                return ((bool)(this["ConfirmOnCancellAll"]));
            }
            set {
                this["ConfirmOnCancellAll"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LastCSVFile {
            get {
                return ((string)(this["LastCSVFile"]));
            }
            set {
                this["LastCSVFile"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int CSVThreadPriority {
            get {
                return ((int)(this["CSVThreadPriority"]));
            }
            set {
                this["CSVThreadPriority"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int MDThreadPriority {
            get {
                return ((int)(this["MDThreadPriority"]));
            }
            set {
                this["MDThreadPriority"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UseStockAutoCancel {
            get {
                return ((bool)(this["UseStockAutoCancel"]));
            }
            set {
                this["UseStockAutoCancel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15:00:00")]
        public string StockAutoCancelTime {
            get {
                return ((string)(this["StockAutoCancelTime"]));
            }
            set {
                this["StockAutoCancelTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OrderAutoFocusLast {
            get {
                return ((bool)(this["OrderAutoFocusLast"]));
            }
            set {
                this["OrderAutoFocusLast"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int OrderAvgPriceResolution {
            get {
                return ((int)(this["OrderAvgPriceResolution"]));
            }
            set {
                this["OrderAvgPriceResolution"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ShowInternalStatus {
            get {
                return ((bool)(this["ShowInternalStatus"]));
            }
            set {
                this["ShowInternalStatus"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DelayUIProcess {
            get {
                return ((bool)(this["DelayUIProcess"]));
            }
            set {
                this["DelayUIProcess"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15:30:00")]
        public string FutureAutoCancelTime {
            get {
                return ((string)(this["FutureAutoCancelTime"]));
            }
            set {
                this["FutureAutoCancelTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UseFutureAutoCancel {
            get {
                return ((bool)(this["UseFutureAutoCancel"]));
            }
            set {
                this["UseFutureAutoCancel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15:00:00")]
        public string OptionAutoCancelTime {
            get {
                return ((string)(this["OptionAutoCancelTime"]));
            }
            set {
                this["OptionAutoCancelTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SkipGTCandGTDonAuto {
            get {
                return ((bool)(this["SkipGTCandGTDonAuto"]));
            }
            set {
                this["SkipGTCandGTDonAuto"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UseOptionAutoCancel {
            get {
                return ((bool)(this["UseOptionAutoCancel"]));
            }
            set {
                this["UseOptionAutoCancel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool DoNotLoadOPRAParticipant {
            get {
                return ((bool)(this["DoNotLoadOPRAParticipant"]));
            }
            set {
                this["DoNotLoadOPRAParticipant"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoFocusOnControls {
            get {
                return ((bool)(this["AutoFocusOnControls"]));
            }
            set {
                this["AutoFocusOnControls"] = value;
            }
        }
    }
}
