﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CardlinkReportsFtpUpload.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.2.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/In/TMS_Export_Files/")]
        public string FtpPathToUpload {
            get {
                return ((string)(this["FtpPathToUpload"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192.168.111.11")]
        public string FtpAddress {
            get {
                return ((string)(this["FtpAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mellon")]
        public string FtpUser {
            get {
                return ((string)(this["FtpUser"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("#M3ll0n#")]
        public string FtpPassword {
            get {
                return ((string)(this["FtpPassword"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\IngProvLogs\\")]
        public string PathToSaveCsv {
            get {
                return ((string)(this["PathToSaveCsv"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("v.charalambidis@mellongroup.com ")]
        public string EmailTo {
            get {
                return ((string)(this["EmailTo"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CardLink Ftp Upload reports")]
        public string EmailSubject {
            get {
                return ((string)(this["EmailSubject"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string EmailBody {
            get {
                return ((string)(this["EmailBody"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("smtp.office365.com")]
        public string SmtpHostIp {
            get {
                return ((string)(this["SmtpHostIp"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("do-not-reply@mellongroup.com")]
        public string EmailFrom {
            get {
                return ((string)(this["EmailFrom"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("587")]
        public int SmtpPort {
            get {
                return ((int)(this["SmtpPort"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("do-not-reply@mellongroup.com")]
        public string NetworkCredentialUserName {
            get {
                return ((string)(this["NetworkCredentialUserName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("P@55w0rd!!")]
        public string NetworkCredentialPassword {
            get {
                return ((string)(this["NetworkCredentialPassword"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://9d26bd6bcf484bc4895ea2615fcc2233@o347434.ingest.sentry.io/5980834")]
        public string SentryDSN {
            get {
                return ((string)(this["SentryDSN"]));
            }
            set {
                this["SentryDSN"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SentryDebug {
            get {
                return ((bool)(this["SentryDebug"]));
            }
            set {
                this["SentryDebug"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public double SentryTracesSampleRate {
            get {
                return ((double)(this["SentryTracesSampleRate"]));
            }
            set {
                this["SentryTracesSampleRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\a.gkliatis\\source\\repos\\CardlinkReportsUpload\\AutoReport\\AutoCardLinkRep" +
            "ortApplication\\bin\\Release\\AutoCardlinkReportApplication")]
        public string AutoReportGenerator {
            get {
                return ((string)(this["AutoReportGenerator"]));
            }
            set {
                this["AutoReportGenerator"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\a.gkliatis\\source\\repos\\CardlinkReportsUpload\\LogReport\\CardLinkLogRepor" +
            "t\\bin\\Release\\CardLinkLogReport")]
        public string TerminalLogReport {
            get {
                return ((string)(this["TerminalLogReport"]));
            }
            set {
                this["TerminalLogReport"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ConnectionString {
            get {
                return ((string)(this["ConnectionString"]));
            }
            set {
                this["ConnectionString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string StartHourReport {
            get {
                return ((string)(this["StartHourReport"]));
            }
            set {
                this["StartHourReport"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string PathToSaveStatsLoggingCsv {
            get {
                return ((string)(this["PathToSaveStatsLoggingCsv"]));
            }
            set {
                this["PathToSaveStatsLoggingCsv"] = value;
            }
        }
    }
}