using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BlobIDS_Worker.Config
{
    public class Settings
    {
        public static void Init() 
        {
        //Detection Settings
        DownloadPath = "./"; //Path of where to allow the tool to store temp files
        MaxDownloadSize = 0; // in bytes is 3000000 = 3mb of the max file size of a blob a STRONG file check will be made of
        SnapShotFileName_Baseline = "./BIM_Baseline.Snapshot";
        SnapShotFileName_Previous = "./BIM_Previous.Snapshot";
        SnapShotFileName_Current = "./BIM_Current.Snapshot";
        SnapShotFileName_FileAccess = "./BIM_FileAccess.Snapshot";
        DetectionPeriod_EveryNumberof_Hours = 0; //specify periodically how many hours to send a report 
        DetectionPeriod_EveryNumberof_Minutes = 0; //specify periodically how many hours to send a report 

        //TaskBar Icon, share it so error messages and such can reach it
        NotifyIcon notifyIcon1;

        //BlobStorage Credentials
        BlobStorage_Account_Name = "";
        BlobStorage_Account_Key = "";
        BlobStorage_Account_Key_Encrypted = false;
        BlobStorage_Account_Environment = "blob.core.windows.net";
       // public static SecureString BlobStorage_Account = new SecureString();
       // public static SecureString BlobStorage_Key = new SecureString();

        //Email Alerting settings
        Email_SMTPServer_Generic = "";
        Email_SMTPServer_Port = 0;
        Email_Account = "";
        Email_Password = "";
        Email_Password_Encrypted = false;
       // public static SecureString Email_AccountName_Generic = new SecureString();
       // public static SecureString Email_AccountPassword_Generic = new SecureString();
        Email_SMTPServer_WindowsCredentials = "";
        Email_SendUsing_Generic = true;
        Email_SendUsing_WindowsCredentials = false;
        Email_Sender = "";
        Email_Recipient = ""; //to add multiple speperate with ';'
        Email_Subject_Alerts = "";
        Email_Subject_HeartBeat = "";
        Email_Subject_Errors = "";
        Email_Subject_Reporting = "";
        Email_Subject_Backups = "";
        Email_Attachment_Filename = "";

        // Results\Event Logging
        EventLog_FileName = "";
        EventLog_SaveEvents = true;
        EventLog_MaxSize = 100; // in mb
        EventLog_WriteTo_WindowsApplicationLog = false;
        EventLog_ShowTaskBarMessage = true; //if messages will popup on the task bar when a event is detected
        Report_FileName_html = "";
        SendReportAs_HTML = true;
        Report_FileName_csv = ".";
        SendReportAs_CSV = true;
        SaveBackupOfSnapshotsOnEventFound = true; // this will cause the current snapshot to be saved as a backup file if anything is found
        EmailBackupOfSnapshotsOnEventFound = true; // this will cause the current snapshot to be saved as a backup file if anything is found

        //ErrorLogging
        ErrorLog_Path = "";
        ErrorLog_WriteTo_LocalLog = false;
        ErrorLog_WriteTo_WindowsApplicationLog = false;
        ErrorLog_SendEmail_PerError = false;
        ErrorLog_ShowTaskBarMessage = true; //if messages will popup on the task bar when a error occurs

        //IDS Health Monitoring
        HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour = 0; //zero will not send any, specify periodically how many hours to send a report 
        HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes = 0; //zero will not send any, specify periodically how many hours to send a report 

        }

        public static ReaderWriterLockSlim _ReadWriteLock_ConfigFile = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim _ReadWriteLock_WorkerConfigFile = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim _ReadWriteLock_Snapshot = new ReaderWriterLockSlim();

        //Detection Settings
        public static string DownloadPath { get; private set; } //Path of where to allow the tool to store temp files
        public static void DownloadPath_Set(string newstr) { DownloadPath = newstr; }
        public static long MaxDownloadSize { get; private set; } // in bytes is 3000000 = 3mb of the max file size of a blob a STRONG file check will be made of
        public static void MaxDownloadSize_Set(long newlong) { MaxDownloadSize = newlong; }
        public static string SnapShotFileName_Baseline { get; private set; }
        public static void SnapShotFileName_Baseline_Set(string newstr) { SnapShotFileName_Baseline = newstr; }
        public static string SnapShotFileName_Previous { get; private set; }
        public static void SnapShotFileName_Previous_Set(string newstr) { SnapShotFileName_Previous = newstr; }
        public static string SnapShotFileName_Current{ get; private set; }
        public static void SnapShotFileName_Current_Set(string newstr) { SnapShotFileName_Current = newstr; }
        public static string SnapShotFileName_FileAccess { get; private set; }
        public static void SnapShotFileName_FileAccess_Set(string newstr) { SnapShotFileName_FileAccess = newstr; }
        public static int DetectionPeriod_EveryNumberof_Hours { get; private set; } //specify periodically how many hours to send a report 
        public static void DetectionPeriod_EveryNumberof_Hours_Set(int newint) { DetectionPeriod_EveryNumberof_Hours = newint; }
        public static int DetectionPeriod_EveryNumberof_Minutes { get; private set; } //specify periodically how many hours to send a report 
        public static void DetectionPeriod_EveryNumberof_Minutes_Set (int newint) { DetectionPeriod_EveryNumberof_Hours = newint; }

        //TaskBar Icon, share it so error messages and such can reach it
        public static NotifyIcon notifyIcon1 { get; private set; }
        public static void notifyIcon1_Set(NotifyIcon newicon) { notifyIcon1 = newicon; }

        //BlobStorage Credentials
        public static string BlobStorage_Account_Name { get; private set; }
        public static void BlobStorage_Account_Name_Set(string newstr) { BlobStorage_Account_Name = newstr; }
        public static string BlobStorage_Account_Key { get; private set; }
        public static void BlobStorage_Account_Key_Set(string newstr) { BlobStorage_Account_Key = newstr; }
        public static bool BlobStorage_Account_Key_Encrypted { get; private set; }
        public static void BlobStorage_Account_Key_Encrypted_Set(bool newbool) { BlobStorage_Account_Key_Encrypted = newbool; }
        public static string BlobStorage_Account_Environment { get; private set; }
        public static void BlobStorage_Account_Environment_Set(string newstr) { BlobStorage_Account_Environment = newstr; }

        //Email Alerting settings
        public static string Email_SMTPServer_Generic { get; private set; }
        public static void Email_SMTPServer_Generic_Set (string newstr) { Email_SMTPServer_Generic = newstr; }
        public static int Email_SMTPServer_Port { get; private set; }
        public static void Email_SMTPServer_Port_Set(int newint) { Email_SMTPServer_Port = newint; }
        public static string Email_Account { get; private set; }
        public static void Email_Account_Set(string newstr) { Email_Account = newstr; }
        public static string Email_Password { get; private set; }
        public static void Email_Password_Set(string newstr) { Email_Password = newstr; }
        public static bool Email_Password_Encrypted { get; private set; }
        public static void Email_Password_Encrypted_Set(bool newbool) { Email_Password_Encrypted = newbool; }
        public static string Email_SMTPServer_WindowsCredentials { get; private set; }
        public static void Email_SMTPServer_WindowsCredentials_Set(string newstr) { Email_SMTPServer_WindowsCredentials = newstr; }
        public static bool Email_SendUsing_Generic { get; private set; }
        public static void Email_SendUsing_Generic_Set(bool newbool) { Email_SendUsing_Generic = newbool; }
        public static bool Email_SendUsing_WindowsCredentials { get; private set; }
        public static void Email_SendUsing_WindowsCredentials_Set(bool newbool) { Email_SendUsing_WindowsCredentials = newbool; }
        public static string Email_Sender { get; private set; }
        public static void Email_Sender_Set(string newstr) { Email_Sender = newstr; }
        public static string Email_Recipient { get; private set; } //to add multiple speperate with ';'
        public static void Email_Recipient_Set(string newstr) { Email_Recipient = newstr; }
        public static string Email_Subject_HeartBeat { get; private set; }
        public static void Email_Subject_HeartBeat_Set(string newstr) { Email_Subject_HeartBeat = newstr; }
        public static string Email_Subject_Alerts { get; private set; }
        public static void Email_Subject_Alerts_Set(string newstr) { Email_Subject_Alerts = newstr; }
        public static string Email_Subject_Errors { get; private set; }
        public static void Email_Subject_Errors_Set(string newstr) { Email_Subject_Errors = newstr; }
        public static string Email_Subject_Reporting { get; private set; }
        public static void Email_Subject_Reporting_Set(string newstr) { Email_Subject_Reporting = newstr; }
        public static string Email_Subject_Backups { get; private set; }
        public static void Email_Subject_Backups_Set(string newstr) { Email_Subject_Backups = newstr; }
        public static string Email_Attachment_Filename { get; private set; }
        public static void Email_Attachment_Filename_Set(string newstr) { Email_Attachment_Filename = newstr; } 

        // Results\Event Logging
        public static string EventLog_FileName { get; private set; }
        public static void EventLog_FileName_Set(string newstr) { EventLog_FileName = newstr; } 
        public static bool EventLog_SaveEvents { get; private set; }
        public static void EventLog_SaveEvents_Set(bool newbool) { EventLog_SaveEvents = newbool; }
        public static int EventLog_MaxSize { get; private set; } // in mb
        public static void EventLog_MaxSize_Set(int newint) { EventLog_MaxSize = newint; }
        public static bool EventLog_WriteTo_WindowsApplicationLog { get; private set; }
        public static void EventLog_WriteTo_WindowsApplicationLog_Set(bool newbool) { EventLog_WriteTo_WindowsApplicationLog = newbool; }
        public static bool EventLog_ShowTaskBarMessage { get; private set; } //if messages will popup on the task bar when a event is detected
        public static void EventLog_ShowTaskBarMessage_Set(bool newbool) { EventLog_ShowTaskBarMessage = newbool; }
        public static string Report_FileName_html { get; private set; }
        public static void Report_FileName_html_Set(string newstr) { Report_FileName_html = newstr; }
        public static bool SendReportAs_HTML { get; private set; }
        public static void SendReportAs_HTML_Set(bool newbool) { SendReportAs_HTML = newbool; }
        public static string Report_FileName_csv { get; private set; }
        public static void Report_FileName_csv_Set(string newstr) { Report_FileName_csv = newstr; }
        public static bool SendReportAs_CSV { get; private set; }
        public static void SendReportAs_CSV_Set(bool newbool) { SendReportAs_CSV = newbool; }
        public static bool SaveBackupOfSnapshotsOnEventFound { get; private set; } // this will cause the current snapshot to be saved as a backup file if anything is found
        public static void SaveBackupOfSnapshotsOnEventFound_Set(bool newbool) { SaveBackupOfSnapshotsOnEventFound = newbool; }
        public static bool EmailBackupOfSnapshotsOnEventFound { get; private set; } // this will cause the current snapshot to be saved as a backup file if anything is found
        public static void EmailBackupOfSnapshotsOnEventFound_Set(bool newbool) { EmailBackupOfSnapshotsOnEventFound = newbool; }


        //ErrorLogging
        public static string ErrorLog_Path { get; private set; }
        public static void ErrorLog_Path_Set(string newstr) { ErrorLog_Path = newstr; }
        public static bool ErrorLog_WriteTo_LocalLog { get; private set; }
        public static void ErrorLog_WriteTo_LocalLog_Set(bool newbool) { ErrorLog_WriteTo_LocalLog = newbool; }
        public static bool ErrorLog_WriteTo_WindowsApplicationLog { get; private set; }
        public static void ErrorLog_WriteTo_WindowsApplicationLog_Set(bool newbool) { ErrorLog_WriteTo_WindowsApplicationLog = newbool; }
        public static bool ErrorLog_SendEmail_PerError { get; private set; }
        public static void ErrorLog_SendEmail_PerError_Set(bool newbool) { ErrorLog_SendEmail_PerError = newbool; }
        public static bool ErrorLog_ShowTaskBarMessage { get; private set; } //if messages will popup on the task bar when a error occurs
        public static void ErrorLog_ShowTaskBarMessage_Set(bool newbool) { ErrorLog_ShowTaskBarMessage = newbool; }

        //IDS Health Monitoring
        public static int HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour { get; private set; } //zero will not send any, specify periodically how many hours to send a report 
        public static void HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour_Set(int newint) { HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour = newint; }
        public static int HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes { get; private set; } //zero will not send any, specify periodically how many hours to send a report 
        public static void HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes_Set(int newint) { HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes = newint; }
    }

}
