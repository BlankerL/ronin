﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.Configuration {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    internal sealed partial class SRLab : global::System.Configuration.ApplicationSettingsBase {
        
        private static SRLab defaultInstance = ((SRLab)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new SRLab())));
        
        public static SRLab Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Smds\\config")]
        public string Configlocation {
            get {
                return ((string)(this["Configlocation"]));
            }
            set {
                this["Configlocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ronin-mc-client-allfeeds.xml")]
        public string ConfigFile {
            get {
                return ((string)(this["ConfigFile"]));
            }
            set {
                this["ConfigFile"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int Depth {
            get {
                return ((int)(this["Depth"]));
            }
            set {
                this["Depth"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MDRCClientSessionMgr")]
        public string SMType {
            get {
                return ((string)(this["SMType"]));
            }
            set {
                this["SMType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CTA,NASDAQ,CME,CME-CBOT,CME-MGEX,CME-NYMEX,ICE,OPRA")]
        public string SMNames {
            get {
                return ((string)(this["SMNames"]));
            }
            set {
                this["SMNames"] = value;
            }
        }
    }
}
