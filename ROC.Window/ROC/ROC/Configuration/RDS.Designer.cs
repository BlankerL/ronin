﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ROC.Configuration {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
    internal sealed partial class RDS : global::System.Configuration.ApplicationSettingsBase {
        
        private static RDS defaultInstance = ((RDS)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new RDS())));
        
        public static RDS Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost/RDS_DEV/RDS.asmx")]
        public string WebServiceLocation {
            get {
                return ((string)(this["WebServiceLocation"]));
            }
            set {
                this["WebServiceLocation"] = value;
            }
        }
    }
}
