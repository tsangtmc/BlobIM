using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace BIM_Settings
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.Tab_WorkerSettings = new System.Windows.Forms.TabControl();
            this.Tab_WorkerConfig = new System.Windows.Forms.TabPage();
            this.CheckBox_Encrypt_EmailPassword = new System.Windows.Forms.CheckBox();
            this.CheckBox_Encrypt_BlobKey = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_EmailSubject_Report = new System.Windows.Forms.TextBox();
            this.Label_BackupsEmailSubject = new System.Windows.Forms.Label();
            this.TextBox_EmailSubject_Backups = new System.Windows.Forms.TextBox();
            this.Label_ErrorEmailSubject = new System.Windows.Forms.Label();
            this.TextBox_EmailSubject_Error = new System.Windows.Forms.TextBox();
            this.Label_EmailFrom = new System.Windows.Forms.Label();
            this.TextBox_EmailFrom = new System.Windows.Forms.TextBox();
            this.Label_HearbeatEmailSubject = new System.Windows.Forms.Label();
            this.TextBox_EmailSubject_Heartbeat = new System.Windows.Forms.TextBox();
            this.Label_EmailTo = new System.Windows.Forms.Label();
            this.TextBox_EmailTo = new System.Windows.Forms.TextBox();
            this.Label_AlertEmailSubject = new System.Windows.Forms.Label();
            this.TextBox_EmailSubject_Alert = new System.Windows.Forms.TextBox();
            this.CheckBox_EmailAlertingWindows = new System.Windows.Forms.CheckBox();
            this.CheckBox_EmailAlerting = new System.Windows.Forms.CheckBox();
            this.Label_SMTPServer_windowsauth = new System.Windows.Forms.Label();
            this.TextBox_SMTPServer_Windows = new System.Windows.Forms.TextBox();
            this.Label_EmailPassword = new System.Windows.Forms.Label();
            this.TextBox_SMTPPassword = new System.Windows.Forms.TextBox();
            this.Label_EmailAccount = new System.Windows.Forms.Label();
            this.TextBox_SMTPAccount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Label_SMTPPort = new System.Windows.Forms.Label();
            this.TextBox_SMTPServerPort = new System.Windows.Forms.TextBox();
            this.Label_SMTPServer = new System.Windows.Forms.Label();
            this.Label_AccountKey = new System.Windows.Forms.Label();
            this.Label_AccountEnvironment = new System.Windows.Forms.Label();
            this.Label_AccountName = new System.Windows.Forms.Label();
            this.TextBox_SMTPServer = new System.Windows.Forms.TextBox();
            this.TextBox_AccountEnvironment = new System.Windows.Forms.TextBox();
            this.TextBox_AccountName = new System.Windows.Forms.TextBox();
            this.TextBox_AccountKey = new System.Windows.Forms.TextBox();
            this.Tab_SettingsConfig = new System.Windows.Forms.TabPage();
            this.CheckBox_HighPerformance = new System.Windows.Forms.CheckBox();
            this.Label_HeartbeatEveryMinutes = new System.Windows.Forms.Label();
            this.TextBox_Heartbeat_Minutes = new System.Windows.Forms.TextBox();
            this.CheckBox_Heartbeat_Enable = new System.Windows.Forms.CheckBox();
            this.Label_HeartbeatEveryHours = new System.Windows.Forms.Label();
            this.TextBox_Heartbeat_Hours = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.CheckBox_ShowTaskBar_Errors = new System.Windows.Forms.CheckBox();
            this.CheckBox_ErrorLog_WindowsAppLog = new System.Windows.Forms.CheckBox();
            this.CheckBox_ErrorLog_EmailPerError = new System.Windows.Forms.CheckBox();
            this.CheckBox_ErrorLog_Local = new System.Windows.Forms.CheckBox();
            this.Label_ErrorLogFilename = new System.Windows.Forms.Label();
            this.TextBox_ErrorLog_Filename = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.CheckBox_EventLog_WindowsAppLog = new System.Windows.Forms.CheckBox();
            this.CheckBox_ShowTaskBar_Events = new System.Windows.Forms.CheckBox();
            this.CheckBox_EmailBackup = new System.Windows.Forms.CheckBox();
            this.CheckBox_SaveBackup = new System.Windows.Forms.CheckBox();
            this.Label_LocalEventLogMaxSize = new System.Windows.Forms.Label();
            this.TextBox_EventLog_MaxSize = new System.Windows.Forms.TextBox();
            this.CheckBox_EventLog_EnableLocal = new System.Windows.Forms.CheckBox();
            this.CheckBox_EventLog_EnableCSV = new System.Windows.Forms.CheckBox();
            this.CheckBox_EventLog_EnableHTML = new System.Windows.Forms.CheckBox();
            this.Label_CSVReportFilename = new System.Windows.Forms.Label();
            this.TextBox_EventLog_CSVFilename = new System.Windows.Forms.TextBox();
            this.Label_TempFilesLocaiton = new System.Windows.Forms.Label();
            this.Label_SnapshotPermissions = new System.Windows.Forms.Label();
            this.TextBox_Snapshot_TempFiles = new System.Windows.Forms.TextBox();
            this.TextBox_SnapshotFilename_Permissions = new System.Windows.Forms.TextBox();
            this.Label_DetectEveryMinutes = new System.Windows.Forms.Label();
            this.Label_SnapshotCurrent = new System.Windows.Forms.Label();
            this.TextBox_Snapshot_ScanEveryMinute = new System.Windows.Forms.TextBox();
            this.TextBox_SnapshotFilename_Current = new System.Windows.Forms.TextBox();
            this.Label_DetectEveryHours = new System.Windows.Forms.Label();
            this.Label_SnapshotPrevious = new System.Windows.Forms.Label();
            this.TextBox_Snapshot_ScanEveryHour = new System.Windows.Forms.TextBox();
            this.TextBox_SnapshotFilename_Previous = new System.Windows.Forms.TextBox();
            this.Label_HTMLReportFilename = new System.Windows.Forms.Label();
            this.TextBox_EventLog_HTMLFilename = new System.Windows.Forms.TextBox();
            this.Label_LocalEventLog = new System.Windows.Forms.Label();
            this.TextBox_EventLog_Filename = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.Label_MaxDownloadSize = new System.Windows.Forms.Label();
            this.Label_SnapshotBaseline = new System.Windows.Forms.Label();
            this.TextBox_Snapshot_MaxDownloadSize = new System.Windows.Forms.TextBox();
            this.TextBox_SnapshotFilename_Baseline = new System.Windows.Forms.TextBox();
            this.Settings_Save = new System.Windows.Forms.Button();
            this.Settings_Cancel = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.LabelToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Label_EncryptKey = new System.Windows.Forms.Label();
            this.Label_EncryptEmailPassword = new System.Windows.Forms.Label();
            this.Tab_WorkerSettings.SuspendLayout();
            this.Tab_WorkerConfig.SuspendLayout();
            this.Tab_SettingsConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tab_WorkerSettings
            // 
            this.Tab_WorkerSettings.Controls.Add(this.Tab_WorkerConfig);
            this.Tab_WorkerSettings.Controls.Add(this.Tab_SettingsConfig);
            this.Tab_WorkerSettings.Location = new System.Drawing.Point(3, 50);
            this.Tab_WorkerSettings.Name = "Tab_WorkerSettings";
            this.Tab_WorkerSettings.SelectedIndex = 0;
            this.Tab_WorkerSettings.Size = new System.Drawing.Size(831, 522);
            this.Tab_WorkerSettings.TabIndex = 9;
            // 
            // Tab_WorkerConfig
            // 
            this.Tab_WorkerConfig.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Tab_WorkerConfig.Controls.Add(this.Label_EncryptEmailPassword);
            this.Tab_WorkerConfig.Controls.Add(this.Label_EncryptKey);
            this.Tab_WorkerConfig.Controls.Add(this.CheckBox_Encrypt_EmailPassword);
            this.Tab_WorkerConfig.Controls.Add(this.CheckBox_Encrypt_BlobKey);
            this.Tab_WorkerConfig.Controls.Add(this.label1);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_EmailSubject_Report);
            this.Tab_WorkerConfig.Controls.Add(this.Label_BackupsEmailSubject);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_EmailSubject_Backups);
            this.Tab_WorkerConfig.Controls.Add(this.Label_ErrorEmailSubject);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_EmailSubject_Error);
            this.Tab_WorkerConfig.Controls.Add(this.Label_EmailFrom);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_EmailFrom);
            this.Tab_WorkerConfig.Controls.Add(this.Label_HearbeatEmailSubject);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_EmailSubject_Heartbeat);
            this.Tab_WorkerConfig.Controls.Add(this.Label_EmailTo);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_EmailTo);
            this.Tab_WorkerConfig.Controls.Add(this.Label_AlertEmailSubject);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_EmailSubject_Alert);
            this.Tab_WorkerConfig.Controls.Add(this.CheckBox_EmailAlertingWindows);
            this.Tab_WorkerConfig.Controls.Add(this.CheckBox_EmailAlerting);
            this.Tab_WorkerConfig.Controls.Add(this.Label_SMTPServer_windowsauth);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_SMTPServer_Windows);
            this.Tab_WorkerConfig.Controls.Add(this.Label_EmailPassword);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_SMTPPassword);
            this.Tab_WorkerConfig.Controls.Add(this.Label_EmailAccount);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_SMTPAccount);
            this.Tab_WorkerConfig.Controls.Add(this.label4);
            this.Tab_WorkerConfig.Controls.Add(this.label3);
            this.Tab_WorkerConfig.Controls.Add(this.Label_SMTPPort);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_SMTPServerPort);
            this.Tab_WorkerConfig.Controls.Add(this.Label_SMTPServer);
            this.Tab_WorkerConfig.Controls.Add(this.Label_AccountKey);
            this.Tab_WorkerConfig.Controls.Add(this.Label_AccountEnvironment);
            this.Tab_WorkerConfig.Controls.Add(this.Label_AccountName);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_SMTPServer);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_AccountEnvironment);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_AccountName);
            this.Tab_WorkerConfig.Controls.Add(this.TextBox_AccountKey);
            this.Tab_WorkerConfig.Location = new System.Drawing.Point(4, 22);
            this.Tab_WorkerConfig.Name = "Tab_WorkerConfig";
            this.Tab_WorkerConfig.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_WorkerConfig.Size = new System.Drawing.Size(823, 496);
            this.Tab_WorkerConfig.TabIndex = 0;
            this.Tab_WorkerConfig.Text = "Settings.Worker.Config";
            // 
            // CheckBox_Encrypt_EmailPassword
            // 
            this.CheckBox_Encrypt_EmailPassword.AutoSize = true;
            this.CheckBox_Encrypt_EmailPassword.Location = new System.Drawing.Point(567, 362);
            this.CheckBox_Encrypt_EmailPassword.Name = "CheckBox_Encrypt_EmailPassword";
            this.CheckBox_Encrypt_EmailPassword.Size = new System.Drawing.Size(182, 17);
            this.CheckBox_Encrypt_EmailPassword.TabIndex = 54;
            this.CheckBox_Encrypt_EmailPassword.Text = "(Protect) Encrypt Email Password";
            this.LabelToolTip.SetToolTip(this.CheckBox_Encrypt_EmailPassword, resources.GetString("CheckBox_Encrypt_EmailPassword.ToolTip"));
            this.CheckBox_Encrypt_EmailPassword.UseVisualStyleBackColor = true;
            this.CheckBox_Encrypt_EmailPassword.CheckedChanged += new System.EventHandler(this.LabelChange_EncryptEmailPassword);
            // 
            // CheckBox_Encrypt_BlobKey
            // 
            this.CheckBox_Encrypt_BlobKey.AutoSize = true;
            this.CheckBox_Encrypt_BlobKey.Location = new System.Drawing.Point(156, 86);
            this.CheckBox_Encrypt_BlobKey.Name = "CheckBox_Encrypt_BlobKey";
            this.CheckBox_Encrypt_BlobKey.Size = new System.Drawing.Size(169, 17);
            this.CheckBox_Encrypt_BlobKey.TabIndex = 53;
            this.CheckBox_Encrypt_BlobKey.Text = "(Protect) Encrypt Account Key";
            this.LabelToolTip.SetToolTip(this.CheckBox_Encrypt_BlobKey, resources.GetString("CheckBox_Encrypt_BlobKey.ToolTip"));
            this.CheckBox_Encrypt_BlobKey.UseVisualStyleBackColor = true;
            this.CheckBox_Encrypt_BlobKey.CheckedChanged += new System.EventHandler(this.LabelChange_EncryptKey);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Reports Message Subject:";
            this.LabelToolTip.SetToolTip(this.label1, "The subject of the email sent containing the Events Report.");
            // 
            // TextBox_EmailSubject_Report
            // 
            this.TextBox_EmailSubject_Report.Location = new System.Drawing.Point(156, 185);
            this.TextBox_EmailSubject_Report.Name = "TextBox_EmailSubject_Report";
            this.TextBox_EmailSubject_Report.Size = new System.Drawing.Size(281, 20);
            this.TextBox_EmailSubject_Report.TabIndex = 51;
            // 
            // Label_BackupsEmailSubject
            // 
            this.Label_BackupsEmailSubject.AutoSize = true;
            this.Label_BackupsEmailSubject.Location = new System.Drawing.Point(13, 240);
            this.Label_BackupsEmailSubject.Name = "Label_BackupsEmailSubject";
            this.Label_BackupsEmailSubject.Size = new System.Drawing.Size(137, 13);
            this.Label_BackupsEmailSubject.TabIndex = 50;
            this.Label_BackupsEmailSubject.Text = "Backups Message Subject:";
            this.LabelToolTip.SetToolTip(this.Label_BackupsEmailSubject, "The subject of the email sent containing the backup snapshot.");
            // 
            // TextBox_EmailSubject_Backups
            // 
            this.TextBox_EmailSubject_Backups.Location = new System.Drawing.Point(156, 237);
            this.TextBox_EmailSubject_Backups.Name = "TextBox_EmailSubject_Backups";
            this.TextBox_EmailSubject_Backups.Size = new System.Drawing.Size(281, 20);
            this.TextBox_EmailSubject_Backups.TabIndex = 49;
            // 
            // Label_ErrorEmailSubject
            // 
            this.Label_ErrorEmailSubject.AutoSize = true;
            this.Label_ErrorEmailSubject.Location = new System.Drawing.Point(33, 214);
            this.Label_ErrorEmailSubject.Name = "Label_ErrorEmailSubject";
            this.Label_ErrorEmailSubject.Size = new System.Drawing.Size(117, 13);
            this.Label_ErrorEmailSubject.TabIndex = 46;
            this.Label_ErrorEmailSubject.Text = "Error Message Subject:";
            this.LabelToolTip.SetToolTip(this.Label_ErrorEmailSubject, "The subject of the email sent containing a error message.");
            // 
            // TextBox_EmailSubject_Error
            // 
            this.TextBox_EmailSubject_Error.Location = new System.Drawing.Point(156, 211);
            this.TextBox_EmailSubject_Error.Name = "TextBox_EmailSubject_Error";
            this.TextBox_EmailSubject_Error.Size = new System.Drawing.Size(281, 20);
            this.TextBox_EmailSubject_Error.TabIndex = 45;
            // 
            // Label_EmailFrom
            // 
            this.Label_EmailFrom.AutoSize = true;
            this.Label_EmailFrom.Location = new System.Drawing.Point(485, 162);
            this.Label_EmailFrom.Name = "Label_EmailFrom";
            this.Label_EmailFrom.Size = new System.Drawing.Size(76, 13);
            this.Label_EmailFrom.TabIndex = 44;
            this.Label_EmailFrom.Text = "(From) Sender:";
            this.LabelToolTip.SetToolTip(this.Label_EmailFrom, "The sender of who email alerts will appear they are from");
            // 
            // TextBox_EmailFrom
            // 
            this.TextBox_EmailFrom.Location = new System.Drawing.Point(567, 159);
            this.TextBox_EmailFrom.Name = "TextBox_EmailFrom";
            this.TextBox_EmailFrom.Size = new System.Drawing.Size(250, 20);
            this.TextBox_EmailFrom.TabIndex = 43;
            // 
            // Label_HearbeatEmailSubject
            // 
            this.Label_HearbeatEmailSubject.AutoSize = true;
            this.Label_HearbeatEmailSubject.Location = new System.Drawing.Point(8, 162);
            this.Label_HearbeatEmailSubject.Name = "Label_HearbeatEmailSubject";
            this.Label_HearbeatEmailSubject.Size = new System.Drawing.Size(142, 13);
            this.Label_HearbeatEmailSubject.TabIndex = 42;
            this.Label_HearbeatEmailSubject.Text = "Heartbeat Message Subject:";
            this.LabelToolTip.SetToolTip(this.Label_HearbeatEmailSubject, "The subject of the email sent containing a health monitoring status update.");
            // 
            // TextBox_EmailSubject_Heartbeat
            // 
            this.TextBox_EmailSubject_Heartbeat.Location = new System.Drawing.Point(156, 159);
            this.TextBox_EmailSubject_Heartbeat.Name = "TextBox_EmailSubject_Heartbeat";
            this.TextBox_EmailSubject_Heartbeat.Size = new System.Drawing.Size(281, 20);
            this.TextBox_EmailSubject_Heartbeat.TabIndex = 41;
            // 
            // Label_EmailTo
            // 
            this.Label_EmailTo.AutoSize = true;
            this.Label_EmailTo.Location = new System.Drawing.Point(484, 136);
            this.Label_EmailTo.Name = "Label_EmailTo";
            this.Label_EmailTo.Size = new System.Drawing.Size(77, 13);
            this.Label_EmailTo.TabIndex = 40;
            this.Label_EmailTo.Text = "(To) Recipient:";
            this.LabelToolTip.SetToolTip(this.Label_EmailTo, "Who to send all email messages to.\r\n Multiple recipients can be specified with a " +
        "semicolon:\r\nE.g: \"test@test.com; test2@test.com; test3@test.com");
            // 
            // TextBox_EmailTo
            // 
            this.TextBox_EmailTo.Location = new System.Drawing.Point(567, 133);
            this.TextBox_EmailTo.Name = "TextBox_EmailTo";
            this.TextBox_EmailTo.Size = new System.Drawing.Size(250, 20);
            this.TextBox_EmailTo.TabIndex = 39;
            // 
            // Label_AlertEmailSubject
            // 
            this.Label_AlertEmailSubject.AutoSize = true;
            this.Label_AlertEmailSubject.Location = new System.Drawing.Point(34, 136);
            this.Label_AlertEmailSubject.Name = "Label_AlertEmailSubject";
            this.Label_AlertEmailSubject.Size = new System.Drawing.Size(116, 13);
            this.Label_AlertEmailSubject.TabIndex = 38;
            this.Label_AlertEmailSubject.Text = "Alert Message Subject:";
            this.LabelToolTip.SetToolTip(this.Label_AlertEmailSubject, "The subject of the email sent containing a Event messages such as a change in a b" +
        "lob was detected.");
            this.Label_AlertEmailSubject.Click += new System.EventHandler(this.label11_Click);
            // 
            // TextBox_EmailSubject_Alert
            // 
            this.TextBox_EmailSubject_Alert.Location = new System.Drawing.Point(156, 133);
            this.TextBox_EmailSubject_Alert.Name = "TextBox_EmailSubject_Alert";
            this.TextBox_EmailSubject_Alert.Size = new System.Drawing.Size(281, 20);
            this.TextBox_EmailSubject_Alert.TabIndex = 37;
            // 
            // CheckBox_EmailAlertingWindows
            // 
            this.CheckBox_EmailAlertingWindows.AutoSize = true;
            this.CheckBox_EmailAlertingWindows.Enabled = false;
            this.CheckBox_EmailAlertingWindows.Location = new System.Drawing.Point(16, 389);
            this.CheckBox_EmailAlertingWindows.Name = "CheckBox_EmailAlertingWindows";
            this.CheckBox_EmailAlertingWindows.Size = new System.Drawing.Size(309, 17);
            this.CheckBox_EmailAlertingWindows.TabIndex = 36;
            this.CheckBox_EmailAlertingWindows.Text = "Enable Email Alerting (using Windows Profile Authentication)";
            this.LabelToolTip.SetToolTip(this.CheckBox_EmailAlertingWindows, "Enable or Disable if Email based alerts should be sent using Windows Profile base" +
        "d authentication.");
            this.CheckBox_EmailAlertingWindows.UseVisualStyleBackColor = true;
            // 
            // CheckBox_EmailAlerting
            // 
            this.CheckBox_EmailAlerting.AutoSize = true;
            this.CheckBox_EmailAlerting.Location = new System.Drawing.Point(18, 284);
            this.CheckBox_EmailAlerting.Name = "CheckBox_EmailAlerting";
            this.CheckBox_EmailAlerting.Size = new System.Drawing.Size(125, 17);
            this.CheckBox_EmailAlerting.TabIndex = 35;
            this.CheckBox_EmailAlerting.Text = "Enable Email Alerting";
            this.LabelToolTip.SetToolTip(this.CheckBox_EmailAlerting, "Enable or Disable if Email based alerts should be sent when a event is detected s" +
        "uch as a change in a blob.");
            this.CheckBox_EmailAlerting.UseVisualStyleBackColor = true;
            // 
            // Label_SMTPServer_windowsauth
            // 
            this.Label_SMTPServer_windowsauth.AutoSize = true;
            this.Label_SMTPServer_windowsauth.Enabled = false;
            this.Label_SMTPServer_windowsauth.Location = new System.Drawing.Point(3, 419);
            this.Label_SMTPServer_windowsauth.Name = "Label_SMTPServer_windowsauth";
            this.Label_SMTPServer_windowsauth.Size = new System.Drawing.Size(152, 13);
            this.Label_SMTPServer_windowsauth.TabIndex = 28;
            this.Label_SMTPServer_windowsauth.Text = "(Windows Auth) SMTP Server:";
            this.LabelToolTip.SetToolTip(this.Label_SMTPServer_windowsauth, "The SMTP Server to use for windows profile based authentication.");
            // 
            // TextBox_SMTPServer_Windows
            // 
            this.TextBox_SMTPServer_Windows.Enabled = false;
            this.TextBox_SMTPServer_Windows.Location = new System.Drawing.Point(156, 416);
            this.TextBox_SMTPServer_Windows.Name = "TextBox_SMTPServer_Windows";
            this.TextBox_SMTPServer_Windows.Size = new System.Drawing.Size(281, 20);
            this.TextBox_SMTPServer_Windows.TabIndex = 27;
            // 
            // Label_EmailPassword
            // 
            this.Label_EmailPassword.AutoSize = true;
            this.Label_EmailPassword.Location = new System.Drawing.Point(477, 338);
            this.Label_EmailPassword.Name = "Label_EmailPassword";
            this.Label_EmailPassword.Size = new System.Drawing.Size(84, 13);
            this.Label_EmailPassword.TabIndex = 26;
            this.Label_EmailPassword.Text = "Email Password:";
            this.LabelToolTip.SetToolTip(this.Label_EmailPassword, "The SMTP Server to use for windows profile based authentication.");
            // 
            // TextBox_SMTPPassword
            // 
            this.TextBox_SMTPPassword.Location = new System.Drawing.Point(567, 335);
            this.TextBox_SMTPPassword.Name = "TextBox_SMTPPassword";
            this.TextBox_SMTPPassword.Size = new System.Drawing.Size(250, 20);
            this.TextBox_SMTPPassword.TabIndex = 25;
            // 
            // Label_EmailAccount
            // 
            this.Label_EmailAccount.AutoSize = true;
            this.Label_EmailAccount.Location = new System.Drawing.Point(72, 338);
            this.Label_EmailAccount.Name = "Label_EmailAccount";
            this.Label_EmailAccount.Size = new System.Drawing.Size(78, 13);
            this.Label_EmailAccount.TabIndex = 24;
            this.Label_EmailAccount.Text = "Email Account:";
            this.LabelToolTip.SetToolTip(this.Label_EmailAccount, "The SMTP Account to authenticate with. \r\n E.g: test@outlook.com");
            // 
            // TextBox_SMTPAccount
            // 
            this.TextBox_SMTPAccount.Location = new System.Drawing.Point(156, 335);
            this.TextBox_SMTPAccount.Name = "TextBox_SMTPAccount";
            this.TextBox_SMTPAccount.Size = new System.Drawing.Size(281, 20);
            this.TextBox_SMTPAccount.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "- Blob Storage Settings -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "- Email Alert Settings -";
            // 
            // Label_SMTPPort
            // 
            this.Label_SMTPPort.AutoSize = true;
            this.Label_SMTPPort.Location = new System.Drawing.Point(499, 312);
            this.Label_SMTPPort.Name = "Label_SMTPPort";
            this.Label_SMTPPort.Size = new System.Drawing.Size(62, 13);
            this.Label_SMTPPort.TabIndex = 20;
            this.Label_SMTPPort.Text = "SMTP Port:";
            this.LabelToolTip.SetToolTip(this.Label_SMTPPort, "Network port to access SMTP over");
            // 
            // TextBox_SMTPServerPort
            // 
            this.TextBox_SMTPServerPort.Location = new System.Drawing.Point(567, 309);
            this.TextBox_SMTPServerPort.Name = "TextBox_SMTPServerPort";
            this.TextBox_SMTPServerPort.Size = new System.Drawing.Size(57, 20);
            this.TextBox_SMTPServerPort.TabIndex = 19;
            // 
            // Label_SMTPServer
            // 
            this.Label_SMTPServer.AutoSize = true;
            this.Label_SMTPServer.Location = new System.Drawing.Point(76, 312);
            this.Label_SMTPServer.Name = "Label_SMTPServer";
            this.Label_SMTPServer.Size = new System.Drawing.Size(74, 13);
            this.Label_SMTPServer.TabIndex = 18;
            this.Label_SMTPServer.Text = "SMTP Server:";
            this.LabelToolTip.SetToolTip(this.Label_SMTPServer, "The SMTP Serer to be used to send out various email messages");
            // 
            // Label_AccountKey
            // 
            this.Label_AccountKey.AutoSize = true;
            this.Label_AccountKey.Location = new System.Drawing.Point(15, 62);
            this.Label_AccountKey.Name = "Label_AccountKey";
            this.Label_AccountKey.Size = new System.Drawing.Size(135, 13);
            this.Label_AccountKey.TabIndex = 17;
            this.Label_AccountKey.Text = "Blob Storage Account Key:";
            this.LabelToolTip.SetToolTip(this.Label_AccountKey, "Enter the Key to access blob storage.");
            // 
            // Label_AccountEnvironment
            // 
            this.Label_AccountEnvironment.AutoSize = true;
            this.Label_AccountEnvironment.Location = new System.Drawing.Point(437, 34);
            this.Label_AccountEnvironment.Name = "Label_AccountEnvironment";
            this.Label_AccountEnvironment.Size = new System.Drawing.Size(124, 13);
            this.Label_AccountEnvironment.TabIndex = 16;
            this.Label_AccountEnvironment.Text = "Blob Store Environment: ";
            this.LabelToolTip.SetToolTip(this.Label_AccountEnvironment, "Specify the environment to connect to.\r\n E.g: \"blob.core.windows.net\"\r\n \"blob.cor" +
        "e.test.net\"\r\n\"etc\"");
            // 
            // Label_AccountName
            // 
            this.Label_AccountName.AutoSize = true;
            this.Label_AccountName.Location = new System.Drawing.Point(5, 34);
            this.Label_AccountName.Name = "Label_AccountName";
            this.Label_AccountName.Size = new System.Drawing.Size(145, 13);
            this.Label_AccountName.TabIndex = 15;
            this.Label_AccountName.Text = "Blob Storage Account Name:";
            this.LabelToolTip.SetToolTip(this.Label_AccountName, "Specify the blob storage account name.");
            // 
            // TextBox_SMTPServer
            // 
            this.TextBox_SMTPServer.Location = new System.Drawing.Point(156, 309);
            this.TextBox_SMTPServer.Name = "TextBox_SMTPServer";
            this.TextBox_SMTPServer.Size = new System.Drawing.Size(281, 20);
            this.TextBox_SMTPServer.TabIndex = 12;
            // 
            // TextBox_AccountEnvironment
            // 
            this.TextBox_AccountEnvironment.Location = new System.Drawing.Point(567, 31);
            this.TextBox_AccountEnvironment.Name = "TextBox_AccountEnvironment";
            this.TextBox_AccountEnvironment.Size = new System.Drawing.Size(250, 20);
            this.TextBox_AccountEnvironment.TabIndex = 11;
            // 
            // TextBox_AccountName
            // 
            this.TextBox_AccountName.Location = new System.Drawing.Point(156, 31);
            this.TextBox_AccountName.Name = "TextBox_AccountName";
            this.TextBox_AccountName.Size = new System.Drawing.Size(256, 20);
            this.TextBox_AccountName.TabIndex = 10;
            // 
            // TextBox_AccountKey
            // 
            this.TextBox_AccountKey.Location = new System.Drawing.Point(156, 59);
            this.TextBox_AccountKey.Name = "TextBox_AccountKey";
            this.TextBox_AccountKey.Size = new System.Drawing.Size(661, 20);
            this.TextBox_AccountKey.TabIndex = 9;
            // 
            // Tab_SettingsConfig
            // 
            this.Tab_SettingsConfig.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_HighPerformance);
            this.Tab_SettingsConfig.Controls.Add(this.Label_HeartbeatEveryMinutes);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_Heartbeat_Minutes);
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_Heartbeat_Enable);
            this.Tab_SettingsConfig.Controls.Add(this.Label_HeartbeatEveryHours);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_Heartbeat_Hours);
            this.Tab_SettingsConfig.Controls.Add(this.label20);
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_ShowTaskBar_Errors);
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_ErrorLog_WindowsAppLog);
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_ErrorLog_EmailPerError);
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_ErrorLog_Local);
            this.Tab_SettingsConfig.Controls.Add(this.Label_ErrorLogFilename);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_ErrorLog_Filename);
            this.Tab_SettingsConfig.Controls.Add(this.label25);
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_EventLog_WindowsAppLog);
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_ShowTaskBar_Events);
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_EmailBackup);
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_SaveBackup);
            this.Tab_SettingsConfig.Controls.Add(this.Label_LocalEventLogMaxSize);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_EventLog_MaxSize);
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_EventLog_EnableLocal);
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_EventLog_EnableCSV);
            this.Tab_SettingsConfig.Controls.Add(this.CheckBox_EventLog_EnableHTML);
            this.Tab_SettingsConfig.Controls.Add(this.Label_CSVReportFilename);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_EventLog_CSVFilename);
            this.Tab_SettingsConfig.Controls.Add(this.Label_TempFilesLocaiton);
            this.Tab_SettingsConfig.Controls.Add(this.Label_SnapshotPermissions);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_Snapshot_TempFiles);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_SnapshotFilename_Permissions);
            this.Tab_SettingsConfig.Controls.Add(this.Label_DetectEveryMinutes);
            this.Tab_SettingsConfig.Controls.Add(this.Label_SnapshotCurrent);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_Snapshot_ScanEveryMinute);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_SnapshotFilename_Current);
            this.Tab_SettingsConfig.Controls.Add(this.Label_DetectEveryHours);
            this.Tab_SettingsConfig.Controls.Add(this.Label_SnapshotPrevious);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_Snapshot_ScanEveryHour);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_SnapshotFilename_Previous);
            this.Tab_SettingsConfig.Controls.Add(this.Label_HTMLReportFilename);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_EventLog_HTMLFilename);
            this.Tab_SettingsConfig.Controls.Add(this.Label_LocalEventLog);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_EventLog_Filename);
            this.Tab_SettingsConfig.Controls.Add(this.label23);
            this.Tab_SettingsConfig.Controls.Add(this.label24);
            this.Tab_SettingsConfig.Controls.Add(this.Label_MaxDownloadSize);
            this.Tab_SettingsConfig.Controls.Add(this.Label_SnapshotBaseline);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_Snapshot_MaxDownloadSize);
            this.Tab_SettingsConfig.Controls.Add(this.TextBox_SnapshotFilename_Baseline);
            this.Tab_SettingsConfig.Location = new System.Drawing.Point(4, 22);
            this.Tab_SettingsConfig.Name = "Tab_SettingsConfig";
            this.Tab_SettingsConfig.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_SettingsConfig.Size = new System.Drawing.Size(823, 496);
            this.Tab_SettingsConfig.TabIndex = 1;
            this.Tab_SettingsConfig.Text = "Settings.Config";
            // 
            // CheckBox_HighPerformance
            // 
            this.CheckBox_HighPerformance.AutoSize = true;
            this.CheckBox_HighPerformance.Location = new System.Drawing.Point(638, 6);
            this.CheckBox_HighPerformance.Name = "CheckBox_HighPerformance";
            this.CheckBox_HighPerformance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckBox_HighPerformance.Size = new System.Drawing.Size(111, 17);
            this.CheckBox_HighPerformance.TabIndex = 129;
            this.CheckBox_HighPerformance.Text = "High Performance";
            this.LabelToolTip.SetToolTip(this.CheckBox_HighPerformance, resources.GetString("CheckBox_HighPerformance.ToolTip"));
            this.CheckBox_HighPerformance.UseVisualStyleBackColor = true;
            this.CheckBox_HighPerformance.CheckedChanged += new System.EventHandler(this.Checked_HighPerformance);
            // 
            // Label_HeartbeatEveryMinutes
            // 
            this.Label_HeartbeatEveryMinutes.AutoSize = true;
            this.Label_HeartbeatEveryMinutes.Location = new System.Drawing.Point(12, 470);
            this.Label_HeartbeatEveryMinutes.Name = "Label_HeartbeatEveryMinutes";
            this.Label_HeartbeatEveryMinutes.Size = new System.Drawing.Size(289, 13);
            this.Label_HeartbeatEveryMinutes.TabIndex = 128;
            this.Label_HeartbeatEveryMinutes.Text = "Send Email Heartbeat/Uptime Message Every # of Minutes:";
            this.LabelToolTip.SetToolTip(this.Label_HeartbeatEveryMinutes, "The frequency of how often scans of blob storage should be performed.\r\n E.g: ever" +
        "y \'x\' minutes \r\n Minutes can be added with the hours setting.\r\nE.g: Scan every \'" +
        "2\' hours and \'5\' minutes");
            // 
            // TextBox_Heartbeat_Minutes
            // 
            this.TextBox_Heartbeat_Minutes.Location = new System.Drawing.Point(307, 468);
            this.TextBox_Heartbeat_Minutes.Name = "TextBox_Heartbeat_Minutes";
            this.TextBox_Heartbeat_Minutes.Size = new System.Drawing.Size(35, 20);
            this.TextBox_Heartbeat_Minutes.TabIndex = 127;
            // 
            // CheckBox_Heartbeat_Enable
            // 
            this.CheckBox_Heartbeat_Enable.AutoSize = true;
            this.CheckBox_Heartbeat_Enable.Location = new System.Drawing.Point(391, 443);
            this.CheckBox_Heartbeat_Enable.Name = "CheckBox_Heartbeat_Enable";
            this.CheckBox_Heartbeat_Enable.Size = new System.Drawing.Size(197, 17);
            this.CheckBox_Heartbeat_Enable.TabIndex = 126;
            this.CheckBox_Heartbeat_Enable.Text = "Enable Heartbeat/Health Monitoring";
            this.LabelToolTip.SetToolTip(this.CheckBox_Heartbeat_Enable, "CheckBox_Heartbeat_Enable.ToolTip");
            this.CheckBox_Heartbeat_Enable.UseVisualStyleBackColor = true;
            // 
            // Label_HeartbeatEveryHours
            // 
            this.Label_HeartbeatEveryHours.AutoSize = true;
            this.Label_HeartbeatEveryHours.Location = new System.Drawing.Point(21, 444);
            this.Label_HeartbeatEveryHours.Name = "Label_HeartbeatEveryHours";
            this.Label_HeartbeatEveryHours.Size = new System.Drawing.Size(280, 13);
            this.Label_HeartbeatEveryHours.TabIndex = 125;
            this.Label_HeartbeatEveryHours.Text = "Send Email Heartbeat/Uptime Message Every # of Hours:";
            this.LabelToolTip.SetToolTip(this.Label_HeartbeatEveryHours, "The frequency of how often heartbeats should be sent.\r\n E.g: every \'x\' hours \r\n M" +
        "inutes can be added with the hours setting.\r\nE.g: Scan every \'2\' hours and \'5\' m" +
        "inutes");
            // 
            // TextBox_Heartbeat_Hours
            // 
            this.TextBox_Heartbeat_Hours.Location = new System.Drawing.Point(307, 442);
            this.TextBox_Heartbeat_Hours.Name = "TextBox_Heartbeat_Hours";
            this.TextBox_Heartbeat_Hours.Size = new System.Drawing.Size(35, 20);
            this.TextBox_Heartbeat_Hours.TabIndex = 124;
            this.LabelToolTip.SetToolTip(this.TextBox_Heartbeat_Hours, "The frequency of how often heartbeats should be sent.\r\n E.g: every \'x\' minutes \r\n" +
        " Minutes can be added with the hours setting.\r\nE.g: Scan every \'2\' hours and \'5\'" +
        " minutes");
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.SteelBlue;
            this.label20.Location = new System.Drawing.Point(6, 415);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(235, 13);
            this.label20.TabIndex = 123;
            this.label20.Text = "- (Heartbeat) Heath Monitoring/Uptime Settings -";
            // 
            // CheckBox_ShowTaskBar_Errors
            // 
            this.CheckBox_ShowTaskBar_Errors.AutoSize = true;
            this.CheckBox_ShowTaskBar_Errors.Location = new System.Drawing.Point(391, 372);
            this.CheckBox_ShowTaskBar_Errors.Name = "CheckBox_ShowTaskBar_Errors";
            this.CheckBox_ShowTaskBar_Errors.Size = new System.Drawing.Size(215, 17);
            this.CheckBox_ShowTaskBar_Errors.TabIndex = 122;
            this.CheckBox_ShowTaskBar_Errors.Text = "Show Taskbar Error Occured Messages";
            this.LabelToolTip.SetToolTip(this.CheckBox_ShowTaskBar_Errors, "Enable or Disable if Error alerts should appear using notification in the windows" +
        " task bar.");
            this.CheckBox_ShowTaskBar_Errors.UseVisualStyleBackColor = true;
            // 
            // CheckBox_ErrorLog_WindowsAppLog
            // 
            this.CheckBox_ErrorLog_WindowsAppLog.AutoSize = true;
            this.CheckBox_ErrorLog_WindowsAppLog.Location = new System.Drawing.Point(391, 395);
            this.CheckBox_ErrorLog_WindowsAppLog.Name = "CheckBox_ErrorLog_WindowsAppLog";
            this.CheckBox_ErrorLog_WindowsAppLog.Size = new System.Drawing.Size(209, 17);
            this.CheckBox_ErrorLog_WindowsAppLog.TabIndex = 120;
            this.CheckBox_ErrorLog_WindowsAppLog.Text = "Log Errors to Windows Application Log";
            this.LabelToolTip.SetToolTip(this.CheckBox_ErrorLog_WindowsAppLog, "Enable or Disable if Errors occuring in BIM should be logged to the windows appli" +
        "cation log.");
            this.CheckBox_ErrorLog_WindowsAppLog.UseVisualStyleBackColor = true;
            // 
            // CheckBox_ErrorLog_EmailPerError
            // 
            this.CheckBox_ErrorLog_EmailPerError.AutoSize = true;
            this.CheckBox_ErrorLog_EmailPerError.Location = new System.Drawing.Point(145, 372);
            this.CheckBox_ErrorLog_EmailPerError.Name = "CheckBox_ErrorLog_EmailPerError";
            this.CheckBox_ErrorLog_EmailPerError.Size = new System.Drawing.Size(166, 17);
            this.CheckBox_ErrorLog_EmailPerError.TabIndex = 119;
            this.CheckBox_ErrorLog_EmailPerError.Text = "Email Error Message Per Error";
            this.LabelToolTip.SetToolTip(this.CheckBox_ErrorLog_EmailPerError, "Enable or Disable if an email should be sent for every error which occurs in BIM");
            this.CheckBox_ErrorLog_EmailPerError.UseVisualStyleBackColor = true;
            // 
            // CheckBox_ErrorLog_Local
            // 
            this.CheckBox_ErrorLog_Local.AutoSize = true;
            this.CheckBox_ErrorLog_Local.Location = new System.Drawing.Point(597, 339);
            this.CheckBox_ErrorLog_Local.Name = "CheckBox_ErrorLog_Local";
            this.CheckBox_ErrorLog_Local.Size = new System.Drawing.Size(185, 17);
            this.CheckBox_ErrorLog_Local.TabIndex = 118;
            this.CheckBox_ErrorLog_Local.Text = "Enable Error Logging to Local File";
            this.LabelToolTip.SetToolTip(this.CheckBox_ErrorLog_Local, "Enable or Disable if Error should be logged to a local error log file.");
            this.CheckBox_ErrorLog_Local.UseVisualStyleBackColor = true;
            // 
            // Label_ErrorLogFilename
            // 
            this.Label_ErrorLogFilename.AutoSize = true;
            this.Label_ErrorLogFilename.Location = new System.Drawing.Point(12, 339);
            this.Label_ErrorLogFilename.Name = "Label_ErrorLogFilename";
            this.Label_ErrorLogFilename.Size = new System.Drawing.Size(127, 13);
            this.Label_ErrorLogFilename.TabIndex = 115;
            this.Label_ErrorLogFilename.Text = "Local Error Log Filename:";
            this.LabelToolTip.SetToolTip(this.Label_ErrorLogFilename, "Specify the filename and path of the error log.");
            // 
            // TextBox_ErrorLog_Filename
            // 
            this.TextBox_ErrorLog_Filename.Location = new System.Drawing.Point(145, 337);
            this.TextBox_ErrorLog_Filename.Name = "TextBox_ErrorLog_Filename";
            this.TextBox_ErrorLog_Filename.Size = new System.Drawing.Size(431, 20);
            this.TextBox_ErrorLog_Filename.TabIndex = 114;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.SteelBlue;
            this.label25.Location = new System.Drawing.Point(6, 310);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(123, 13);
            this.label25.TabIndex = 111;
            this.label25.Text = "- Error Logging Settings -";
            // 
            // CheckBox_EventLog_WindowsAppLog
            // 
            this.CheckBox_EventLog_WindowsAppLog.AutoSize = true;
            this.CheckBox_EventLog_WindowsAppLog.Location = new System.Drawing.Point(391, 284);
            this.CheckBox_EventLog_WindowsAppLog.Name = "CheckBox_EventLog_WindowsAppLog";
            this.CheckBox_EventLog_WindowsAppLog.Size = new System.Drawing.Size(262, 17);
            this.CheckBox_EventLog_WindowsAppLog.TabIndex = 110;
            this.CheckBox_EventLog_WindowsAppLog.Text = "Log Detected Events to Windows Application Log";
            this.LabelToolTip.SetToolTip(this.CheckBox_EventLog_WindowsAppLog, "Enable or Disable if Detected Events, such as a change in a blob, should be logge" +
        "d to the windows application log.");
            this.CheckBox_EventLog_WindowsAppLog.UseVisualStyleBackColor = true;
            // 
            // CheckBox_ShowTaskBar_Events
            // 
            this.CheckBox_ShowTaskBar_Events.AutoSize = true;
            this.CheckBox_ShowTaskBar_Events.Location = new System.Drawing.Point(391, 261);
            this.CheckBox_ShowTaskBar_Events.Name = "CheckBox_ShowTaskBar_Events";
            this.CheckBox_ShowTaskBar_Events.Size = new System.Drawing.Size(224, 17);
            this.CheckBox_ShowTaskBar_Events.TabIndex = 109;
            this.CheckBox_ShowTaskBar_Events.Text = "Show Taskbar Event Detected Messages";
            this.LabelToolTip.SetToolTip(this.CheckBox_ShowTaskBar_Events, "Enable or Disable if Detected Events, such as a change in a blob, should appear u" +
        "sing notification in the windows task bar.");
            this.CheckBox_ShowTaskBar_Events.UseVisualStyleBackColor = true;
            // 
            // CheckBox_EmailBackup
            // 
            this.CheckBox_EmailBackup.AutoSize = true;
            this.CheckBox_EmailBackup.Location = new System.Drawing.Point(145, 284);
            this.CheckBox_EmailBackup.Name = "CheckBox_EmailBackup";
            this.CheckBox_EmailBackup.Size = new System.Drawing.Size(235, 17);
            this.CheckBox_EmailBackup.TabIndex = 108;
            this.CheckBox_EmailBackup.Text = "Email Backup of Snapshots on Event Found";
            this.LabelToolTip.SetToolTip(this.CheckBox_EmailBackup, "Enable or Disable if during detection of a event, a backup of the current snapsho" +
        "t should be sent via email.");
            this.CheckBox_EmailBackup.UseVisualStyleBackColor = true;
            // 
            // CheckBox_SaveBackup
            // 
            this.CheckBox_SaveBackup.AutoSize = true;
            this.CheckBox_SaveBackup.Location = new System.Drawing.Point(145, 261);
            this.CheckBox_SaveBackup.Name = "CheckBox_SaveBackup";
            this.CheckBox_SaveBackup.Size = new System.Drawing.Size(235, 17);
            this.CheckBox_SaveBackup.TabIndex = 107;
            this.CheckBox_SaveBackup.Text = "Save Backup of Snapshots on Event Found";
            this.LabelToolTip.SetToolTip(this.CheckBox_SaveBackup, "Enable or Disable if during detection of a event, a backup of the current snapsho" +
        "t should be saved locally.");
            this.CheckBox_SaveBackup.UseVisualStyleBackColor = true;
            // 
            // Label_LocalEventLogMaxSize
            // 
            this.Label_LocalEventLogMaxSize.AutoSize = true;
            this.Label_LocalEventLogMaxSize.Location = new System.Drawing.Point(362, 177);
            this.Label_LocalEventLogMaxSize.Name = "Label_LocalEventLogMaxSize";
            this.Label_LocalEventLogMaxSize.Size = new System.Drawing.Size(156, 13);
            this.Label_LocalEventLogMaxSize.TabIndex = 106;
            this.Label_LocalEventLogMaxSize.Text = "Local Event Log MaxSize (MB):";
            this.LabelToolTip.SetToolTip(this.Label_LocalEventLogMaxSize, "Specify the max size a event log can be, in MB, before it is rolled and a new log" +
        " file is started.");
            // 
            // TextBox_EventLog_MaxSize
            // 
            this.TextBox_EventLog_MaxSize.Location = new System.Drawing.Point(524, 174);
            this.TextBox_EventLog_MaxSize.Name = "TextBox_EventLog_MaxSize";
            this.TextBox_EventLog_MaxSize.Size = new System.Drawing.Size(52, 20);
            this.TextBox_EventLog_MaxSize.TabIndex = 105;
            // 
            // CheckBox_EventLog_EnableLocal
            // 
            this.CheckBox_EventLog_EnableLocal.AutoSize = true;
            this.CheckBox_EventLog_EnableLocal.Location = new System.Drawing.Point(597, 176);
            this.CheckBox_EventLog_EnableLocal.Name = "CheckBox_EventLog_EnableLocal";
            this.CheckBox_EventLog_EnableLocal.Size = new System.Drawing.Size(191, 17);
            this.CheckBox_EventLog_EnableLocal.TabIndex = 104;
            this.CheckBox_EventLog_EnableLocal.Text = "Enable Event Logging to Local File";
            this.LabelToolTip.SetToolTip(this.CheckBox_EventLog_EnableLocal, "Enable or Disable if during detection of a event, such as a change in a blob, eve" +
        "nts should be logged locally to a log file");
            this.CheckBox_EventLog_EnableLocal.UseVisualStyleBackColor = true;
            // 
            // CheckBox_EventLog_EnableCSV
            // 
            this.CheckBox_EventLog_EnableCSV.AutoSize = true;
            this.CheckBox_EventLog_EnableCSV.Location = new System.Drawing.Point(597, 228);
            this.CheckBox_EventLog_EnableCSV.Name = "CheckBox_EventLog_EnableCSV";
            this.CheckBox_EventLog_EnableCSV.Size = new System.Drawing.Size(210, 17);
            this.CheckBox_EventLog_EnableCSV.TabIndex = 102;
            this.CheckBox_EventLog_EnableCSV.Text = "Enable Emailing Event Reports as CSV";
            this.LabelToolTip.SetToolTip(this.CheckBox_EventLog_EnableCSV, "Enable or Disable if during detection of a event, a report of changes in CSV form" +
        "at should be sent via email.");
            this.CheckBox_EventLog_EnableCSV.UseVisualStyleBackColor = true;
            // 
            // CheckBox_EventLog_EnableHTML
            // 
            this.CheckBox_EventLog_EnableHTML.AutoSize = true;
            this.CheckBox_EventLog_EnableHTML.Location = new System.Drawing.Point(597, 202);
            this.CheckBox_EventLog_EnableHTML.Name = "CheckBox_EventLog_EnableHTML";
            this.CheckBox_EventLog_EnableHTML.Size = new System.Drawing.Size(216, 17);
            this.CheckBox_EventLog_EnableHTML.TabIndex = 101;
            this.CheckBox_EventLog_EnableHTML.Text = "Enable Emailing Event Reports in HTML";
            this.LabelToolTip.SetToolTip(this.CheckBox_EventLog_EnableHTML, "Enable or Disable if during detection of a event, a report of changes in HTML for" +
        "mat should be sent via email.");
            this.CheckBox_EventLog_EnableHTML.UseVisualStyleBackColor = true;
            // 
            // Label_CSVReportFilename
            // 
            this.Label_CSVReportFilename.AutoSize = true;
            this.Label_CSVReportFilename.Location = new System.Drawing.Point(28, 229);
            this.Label_CSVReportFilename.Name = "Label_CSVReportFilename";
            this.Label_CSVReportFilename.Size = new System.Drawing.Size(111, 13);
            this.Label_CSVReportFilename.TabIndex = 96;
            this.Label_CSVReportFilename.Text = "CSV Report Filename:";
            this.LabelToolTip.SetToolTip(this.Label_CSVReportFilename, "Filename and Path of the CSV report to be generated.");
            // 
            // TextBox_EventLog_CSVFilename
            // 
            this.TextBox_EventLog_CSVFilename.Location = new System.Drawing.Point(145, 226);
            this.TextBox_EventLog_CSVFilename.Name = "TextBox_EventLog_CSVFilename";
            this.TextBox_EventLog_CSVFilename.Size = new System.Drawing.Size(431, 20);
            this.TextBox_EventLog_CSVFilename.TabIndex = 95;
            // 
            // Label_TempFilesLocaiton
            // 
            this.Label_TempFilesLocaiton.AutoSize = true;
            this.Label_TempFilesLocaiton.Location = new System.Drawing.Point(468, 108);
            this.Label_TempFilesLocaiton.Name = "Label_TempFilesLocaiton";
            this.Label_TempFilesLocaiton.Size = new System.Drawing.Size(123, 13);
            this.Label_TempFilesLocaiton.TabIndex = 94;
            this.Label_TempFilesLocaiton.Text = "Location for Temp Files: ";
            this.LabelToolTip.SetToolTip(this.Label_TempFilesLocaiton, "Specify a Folder where it is accepatble for BIM to store temporary files while op" +
        "erating.");
            // 
            // Label_SnapshotPermissions
            // 
            this.Label_SnapshotPermissions.AutoSize = true;
            this.Label_SnapshotPermissions.Location = new System.Drawing.Point(3, 108);
            this.Label_SnapshotPermissions.Name = "Label_SnapshotPermissions";
            this.Label_SnapshotPermissions.Size = new System.Drawing.Size(158, 13);
            this.Label_SnapshotPermissions.TabIndex = 93;
            this.Label_SnapshotPermissions.Text = "Permissions Snapshot Filename:";
            this.LabelToolTip.SetToolTip(this.Label_SnapshotPermissions, "Specify a Filename of the snapshot to be used to analyzed blob access permissions" +
        ".");
            // 
            // TextBox_Snapshot_TempFiles
            // 
            this.TextBox_Snapshot_TempFiles.Location = new System.Drawing.Point(597, 105);
            this.TextBox_Snapshot_TempFiles.Name = "TextBox_Snapshot_TempFiles";
            this.TextBox_Snapshot_TempFiles.Size = new System.Drawing.Size(208, 20);
            this.TextBox_Snapshot_TempFiles.TabIndex = 92;
            // 
            // TextBox_SnapshotFilename_Permissions
            // 
            this.TextBox_SnapshotFilename_Permissions.Location = new System.Drawing.Point(167, 105);
            this.TextBox_SnapshotFilename_Permissions.Name = "TextBox_SnapshotFilename_Permissions";
            this.TextBox_SnapshotFilename_Permissions.Size = new System.Drawing.Size(275, 20);
            this.TextBox_SnapshotFilename_Permissions.TabIndex = 91;
            // 
            // Label_DetectEveryMinutes
            // 
            this.Label_DetectEveryMinutes.AutoSize = true;
            this.Label_DetectEveryMinutes.Location = new System.Drawing.Point(599, 82);
            this.Label_DetectEveryMinutes.Name = "Label_DetectEveryMinutes";
            this.Label_DetectEveryMinutes.Size = new System.Drawing.Size(130, 13);
            this.Label_DetectEveryMinutes.TabIndex = 90;
            this.Label_DetectEveryMinutes.Text = "Scan Every # of Minutes: ";
            this.LabelToolTip.SetToolTip(this.Label_DetectEveryMinutes, "The frequency of how often scans of blob storage should be performed.\r\n E.g: ever" +
        "y \'x\' minutes \r\n Minutes can be added with the hours setting.\r\nE.g: Scan every \'" +
        "2\' hours and \'5\' minutes");
            // 
            // Label_SnapshotCurrent
            // 
            this.Label_SnapshotCurrent.AutoSize = true;
            this.Label_SnapshotCurrent.Location = new System.Drawing.Point(25, 82);
            this.Label_SnapshotCurrent.Name = "Label_SnapshotCurrent";
            this.Label_SnapshotCurrent.Size = new System.Drawing.Size(137, 13);
            this.Label_SnapshotCurrent.TabIndex = 89;
            this.Label_SnapshotCurrent.Text = "Current Snapshot Filename:";
            this.LabelToolTip.SetToolTip(this.Label_SnapshotCurrent, "Specify a Filename of the current snapshot to be generated when checking if the s" +
        "tate of the blob storage has changed.");
            // 
            // TextBox_Snapshot_ScanEveryMinute
            // 
            this.TextBox_Snapshot_ScanEveryMinute.Location = new System.Drawing.Point(735, 79);
            this.TextBox_Snapshot_ScanEveryMinute.Name = "TextBox_Snapshot_ScanEveryMinute";
            this.TextBox_Snapshot_ScanEveryMinute.Size = new System.Drawing.Size(70, 20);
            this.TextBox_Snapshot_ScanEveryMinute.TabIndex = 88;
            // 
            // TextBox_SnapshotFilename_Current
            // 
            this.TextBox_SnapshotFilename_Current.Location = new System.Drawing.Point(167, 79);
            this.TextBox_SnapshotFilename_Current.Name = "TextBox_SnapshotFilename_Current";
            this.TextBox_SnapshotFilename_Current.Size = new System.Drawing.Size(275, 20);
            this.TextBox_SnapshotFilename_Current.TabIndex = 87;
            // 
            // Label_DetectEveryHours
            // 
            this.Label_DetectEveryHours.AutoSize = true;
            this.Label_DetectEveryHours.Location = new System.Drawing.Point(608, 56);
            this.Label_DetectEveryHours.Name = "Label_DetectEveryHours";
            this.Label_DetectEveryHours.Size = new System.Drawing.Size(121, 13);
            this.Label_DetectEveryHours.TabIndex = 86;
            this.Label_DetectEveryHours.Text = "Scan Every # of Hours: ";
            this.LabelToolTip.SetToolTip(this.Label_DetectEveryHours, "The frequency of how often scans of blob storage should be performed.\r\n E.g: ever" +
        "y \'x\' hours \r\n Minutes can be added with the hours setting.\r\nE.g: Scan every \'2\'" +
        " hours and \'5\' minutes");
            // 
            // Label_SnapshotPrevious
            // 
            this.Label_SnapshotPrevious.AutoSize = true;
            this.Label_SnapshotPrevious.Location = new System.Drawing.Point(18, 56);
            this.Label_SnapshotPrevious.Name = "Label_SnapshotPrevious";
            this.Label_SnapshotPrevious.Size = new System.Drawing.Size(144, 13);
            this.Label_SnapshotPrevious.TabIndex = 85;
            this.Label_SnapshotPrevious.Text = "Previous Snapshot Filename:";
            this.LabelToolTip.SetToolTip(this.Label_SnapshotPrevious, "Specify a Filename of the previous snapshot to be generated when checking if the " +
        "state of the blob storage has changed.");
            // 
            // TextBox_Snapshot_ScanEveryHour
            // 
            this.TextBox_Snapshot_ScanEveryHour.Location = new System.Drawing.Point(735, 53);
            this.TextBox_Snapshot_ScanEveryHour.Name = "TextBox_Snapshot_ScanEveryHour";
            this.TextBox_Snapshot_ScanEveryHour.Size = new System.Drawing.Size(70, 20);
            this.TextBox_Snapshot_ScanEveryHour.TabIndex = 84;
            // 
            // TextBox_SnapshotFilename_Previous
            // 
            this.TextBox_SnapshotFilename_Previous.Location = new System.Drawing.Point(167, 53);
            this.TextBox_SnapshotFilename_Previous.Name = "TextBox_SnapshotFilename_Previous";
            this.TextBox_SnapshotFilename_Previous.Size = new System.Drawing.Size(275, 20);
            this.TextBox_SnapshotFilename_Previous.TabIndex = 83;
            // 
            // Label_HTMLReportFilename
            // 
            this.Label_HTMLReportFilename.AutoSize = true;
            this.Label_HTMLReportFilename.Location = new System.Drawing.Point(19, 203);
            this.Label_HTMLReportFilename.Name = "Label_HTMLReportFilename";
            this.Label_HTMLReportFilename.Size = new System.Drawing.Size(120, 13);
            this.Label_HTMLReportFilename.TabIndex = 76;
            this.Label_HTMLReportFilename.Text = "HTML Report Filename:";
            this.LabelToolTip.SetToolTip(this.Label_HTMLReportFilename, "Specify a Filename of the Detected Events report to be generated in HTML format.");
            // 
            // TextBox_EventLog_HTMLFilename
            // 
            this.TextBox_EventLog_HTMLFilename.Location = new System.Drawing.Point(145, 200);
            this.TextBox_EventLog_HTMLFilename.Name = "TextBox_EventLog_HTMLFilename";
            this.TextBox_EventLog_HTMLFilename.Size = new System.Drawing.Size(431, 20);
            this.TextBox_EventLog_HTMLFilename.TabIndex = 75;
            // 
            // Label_LocalEventLog
            // 
            this.Label_LocalEventLog.AutoSize = true;
            this.Label_LocalEventLog.Location = new System.Drawing.Point(6, 177);
            this.Label_LocalEventLog.Name = "Label_LocalEventLog";
            this.Label_LocalEventLog.Size = new System.Drawing.Size(133, 13);
            this.Label_LocalEventLog.TabIndex = 72;
            this.Label_LocalEventLog.Text = "Local Event Log Filename:";
            this.LabelToolTip.SetToolTip(this.Label_LocalEventLog, "Specify a Filename of the Detected Events Log to be generated locally.");
            // 
            // TextBox_EventLog_Filename
            // 
            this.TextBox_EventLog_Filename.Location = new System.Drawing.Point(145, 174);
            this.TextBox_EventLog_Filename.Name = "TextBox_EventLog_Filename";
            this.TextBox_EventLog_Filename.Size = new System.Drawing.Size(207, 20);
            this.TextBox_EventLog_Filename.TabIndex = 71;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.SteelBlue;
            this.label23.Location = new System.Drawing.Point(6, 3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(106, 13);
            this.label23.TabIndex = 62;
            this.label23.Text = "- Detection Settings -";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.SteelBlue;
            this.label24.Location = new System.Drawing.Point(6, 148);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(169, 13);
            this.label24.TabIndex = 61;
            this.label24.Text = "- Results\\Event Logging Settings -";
            // 
            // Label_MaxDownloadSize
            // 
            this.Label_MaxDownloadSize.AutoSize = true;
            this.Label_MaxDownloadSize.Location = new System.Drawing.Point(588, 30);
            this.Label_MaxDownloadSize.Name = "Label_MaxDownloadSize";
            this.Label_MaxDownloadSize.Size = new System.Drawing.Size(141, 13);
            this.Label_MaxDownloadSize.TabIndex = 56;
            this.Label_MaxDownloadSize.Text = "Max Download Size (bytes): ";
            this.LabelToolTip.SetToolTip(this.Label_MaxDownloadSize, "Maximum size a file can be to be downloaded for detection purposes,\r\n 3000000 = 3" +
        "mb \r\n (keep in mind transaction costs of download files");
            // 
            // Label_SnapshotBaseline
            // 
            this.Label_SnapshotBaseline.AutoSize = true;
            this.Label_SnapshotBaseline.Location = new System.Drawing.Point(18, 30);
            this.Label_SnapshotBaseline.Name = "Label_SnapshotBaseline";
            this.Label_SnapshotBaseline.Size = new System.Drawing.Size(143, 13);
            this.Label_SnapshotBaseline.TabIndex = 55;
            this.Label_SnapshotBaseline.Text = "Baseline Snapshot Filename:";
            this.LabelToolTip.SetToolTip(this.Label_SnapshotBaseline, resources.GetString("Label_SnapshotBaseline.ToolTip"));
            // 
            // TextBox_Snapshot_MaxDownloadSize
            // 
            this.TextBox_Snapshot_MaxDownloadSize.Location = new System.Drawing.Point(735, 27);
            this.TextBox_Snapshot_MaxDownloadSize.Name = "TextBox_Snapshot_MaxDownloadSize";
            this.TextBox_Snapshot_MaxDownloadSize.Size = new System.Drawing.Size(70, 20);
            this.TextBox_Snapshot_MaxDownloadSize.TabIndex = 53;
            this.TextBox_Snapshot_MaxDownloadSize.TextChanged += new System.EventHandler(this.TextChange_MaxDownloadSize);
            // 
            // TextBox_SnapshotFilename_Baseline
            // 
            this.TextBox_SnapshotFilename_Baseline.Location = new System.Drawing.Point(167, 27);
            this.TextBox_SnapshotFilename_Baseline.Name = "TextBox_SnapshotFilename_Baseline";
            this.TextBox_SnapshotFilename_Baseline.Size = new System.Drawing.Size(275, 20);
            this.TextBox_SnapshotFilename_Baseline.TabIndex = 52;
            // 
            // Settings_Save
            // 
            this.Settings_Save.Location = new System.Drawing.Point(658, 21);
            this.Settings_Save.Name = "Settings_Save";
            this.Settings_Save.Size = new System.Drawing.Size(75, 23);
            this.Settings_Save.TabIndex = 10;
            this.Settings_Save.Text = "Save";
            this.Settings_Save.UseVisualStyleBackColor = true;
            this.Settings_Save.Click += new System.EventHandler(this.Settings_Save_Click);
            // 
            // Settings_Cancel
            // 
            this.Settings_Cancel.Location = new System.Drawing.Point(739, 21);
            this.Settings_Cancel.Name = "Settings_Cancel";
            this.Settings_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Settings_Cancel.TabIndex = 11;
            this.Settings_Cancel.Text = "Cancel";
            this.Settings_Cancel.UseVisualStyleBackColor = true;
            this.Settings_Cancel.Click += new System.EventHandler(this.Settings_Cancel_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(174, 9);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(203, 13);
            this.label26.TabIndex = 12;
            this.label26.Text = "1) Please review the settings in both tabs.";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(174, 26);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(185, 13);
            this.label33.TabIndex = 13;
            this.label33.Text = "2) All feilds in Red MUST be filled out.";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(393, 9);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(179, 13);
            this.label35.TabIndex = 14;
            this.label35.Text = "3) Hover over labels for more details.";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(393, 26);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(238, 13);
            this.label36.TabIndex = 15;
            this.label36.Text = "4) Be sure to \"Save\" your settings when finished.";
            // 
            // LabelToolTip
            // 
            this.LabelToolTip.AutoPopDelay = 30000;
            this.LabelToolTip.InitialDelay = 500;
            this.LabelToolTip.IsBalloon = true;
            this.LabelToolTip.ReshowDelay = 100;
            this.LabelToolTip.ShowAlways = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "By [Author_Name_Removed]";
            // 
            // Label_EncryptKey
            // 
            this.Label_EncryptKey.AutoSize = true;
            this.Label_EncryptKey.Location = new System.Drawing.Point(321, 86);
            this.Label_EncryptKey.Name = "Label_EncryptKey";
            this.Label_EncryptKey.Size = new System.Drawing.Size(132, 13);
            this.Label_EncryptKey.TabIndex = 55;
            this.Label_EncryptKey.Text = "[🚫 !Warning - NOT Protected! ☹]";
            this.Label_EncryptKey.Font = new Font(this.Label_EncryptKey.Font.Name, 9, FontStyle.Bold);
            this.Label_EncryptKey.ForeColor = System.Drawing.Color.Red;
            // 
            // Label_EncryptEmailPassword
            // 
            this.Label_EncryptEmailPassword.AutoSize = true;
            this.Label_EncryptEmailPassword.Location = new System.Drawing.Point(584, 378);
            this.Label_EncryptEmailPassword.Name = "Label_EncryptEmailPassword";
            this.Label_EncryptEmailPassword.Size = new System.Drawing.Size(132, 13);
            this.Label_EncryptEmailPassword.TabIndex = 56;
            this.Label_EncryptEmailPassword.Text = "[🚫 !Warning - NOT Protected! ☹]";
            this.Label_EncryptEmailPassword.Font = new Font(this.Label_EncryptEmailPassword.Font.Name, 9, FontStyle.Bold);
            this.Label_EncryptEmailPassword.ForeColor = System.Drawing.Color.Red;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(836, 570);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.Settings_Cancel);
            this.Controls.Add(this.Settings_Save);
            this.Controls.Add(this.Tab_WorkerSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.Tab_WorkerSettings.ResumeLayout(false);
            this.Tab_WorkerConfig.ResumeLayout(false);
            this.Tab_WorkerConfig.PerformLayout();
            this.Tab_SettingsConfig.ResumeLayout(false);
            this.Tab_SettingsConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Tab_WorkerSettings;
        private System.Windows.Forms.TabPage Tab_WorkerConfig;
        private System.Windows.Forms.Label Label_AccountKey;
        private System.Windows.Forms.Label Label_AccountEnvironment;
        private System.Windows.Forms.Label Label_AccountName;
        private System.Windows.Forms.TextBox TextBox_SMTPServer;
        private System.Windows.Forms.TextBox TextBox_AccountEnvironment;
        private System.Windows.Forms.TextBox TextBox_AccountName;
        private System.Windows.Forms.TextBox TextBox_AccountKey;
        private System.Windows.Forms.TabPage Tab_SettingsConfig;
        private System.Windows.Forms.Label Label_BackupsEmailSubject;
        private System.Windows.Forms.TextBox TextBox_EmailSubject_Backups;
        private System.Windows.Forms.Label Label_ErrorEmailSubject;
        private System.Windows.Forms.TextBox TextBox_EmailSubject_Error;
        private System.Windows.Forms.Label Label_EmailFrom;
        private System.Windows.Forms.TextBox TextBox_EmailFrom;
        private System.Windows.Forms.Label Label_HearbeatEmailSubject;
        private System.Windows.Forms.TextBox TextBox_EmailSubject_Heartbeat;
        private System.Windows.Forms.Label Label_EmailTo;
        private System.Windows.Forms.TextBox TextBox_EmailTo;
        private System.Windows.Forms.Label Label_AlertEmailSubject;
        private System.Windows.Forms.TextBox TextBox_EmailSubject_Alert;
        private System.Windows.Forms.CheckBox CheckBox_EmailAlertingWindows;
        private System.Windows.Forms.CheckBox CheckBox_EmailAlerting;
        private System.Windows.Forms.Label Label_SMTPServer_windowsauth;
        private System.Windows.Forms.TextBox TextBox_SMTPServer_Windows;
        private System.Windows.Forms.Label Label_EmailPassword;
        private System.Windows.Forms.TextBox TextBox_SMTPPassword;
        private System.Windows.Forms.Label Label_EmailAccount;
        private System.Windows.Forms.TextBox TextBox_SMTPAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Label_SMTPPort;
        private System.Windows.Forms.TextBox TextBox_SMTPServerPort;
        private System.Windows.Forms.Label Label_SMTPServer;
        private System.Windows.Forms.Label Label_HeartbeatEveryMinutes;
        private System.Windows.Forms.TextBox TextBox_Heartbeat_Minutes;
        private System.Windows.Forms.CheckBox CheckBox_Heartbeat_Enable;
        private System.Windows.Forms.Label Label_HeartbeatEveryHours;
        private System.Windows.Forms.TextBox TextBox_Heartbeat_Hours;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox CheckBox_ShowTaskBar_Errors;
        private System.Windows.Forms.CheckBox CheckBox_ErrorLog_WindowsAppLog;
        private System.Windows.Forms.CheckBox CheckBox_ErrorLog_EmailPerError;
        private System.Windows.Forms.CheckBox CheckBox_ErrorLog_Local;
        private System.Windows.Forms.Label Label_ErrorLogFilename;
        private System.Windows.Forms.TextBox TextBox_ErrorLog_Filename;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox CheckBox_EventLog_WindowsAppLog;
        private System.Windows.Forms.CheckBox CheckBox_ShowTaskBar_Events;
        private System.Windows.Forms.CheckBox CheckBox_EmailBackup;
        private System.Windows.Forms.CheckBox CheckBox_SaveBackup;
        private System.Windows.Forms.Label Label_LocalEventLogMaxSize;
        private System.Windows.Forms.TextBox TextBox_EventLog_MaxSize;
        private System.Windows.Forms.CheckBox CheckBox_EventLog_EnableLocal;
        private System.Windows.Forms.CheckBox CheckBox_EventLog_EnableCSV;
        private System.Windows.Forms.CheckBox CheckBox_EventLog_EnableHTML;
        private System.Windows.Forms.Label Label_CSVReportFilename;
        private System.Windows.Forms.TextBox TextBox_EventLog_CSVFilename;
        private System.Windows.Forms.Label Label_TempFilesLocaiton;
        private System.Windows.Forms.Label Label_SnapshotPermissions;
        private System.Windows.Forms.TextBox TextBox_Snapshot_TempFiles;
        private System.Windows.Forms.TextBox TextBox_SnapshotFilename_Permissions;
        private System.Windows.Forms.Label Label_DetectEveryMinutes;
        private System.Windows.Forms.Label Label_SnapshotCurrent;
        private System.Windows.Forms.TextBox TextBox_Snapshot_ScanEveryMinute;
        private System.Windows.Forms.TextBox TextBox_SnapshotFilename_Current;
        private System.Windows.Forms.Label Label_DetectEveryHours;
        private System.Windows.Forms.Label Label_SnapshotPrevious;
        private System.Windows.Forms.TextBox TextBox_Snapshot_ScanEveryHour;
        private System.Windows.Forms.TextBox TextBox_SnapshotFilename_Previous;
        private System.Windows.Forms.Label Label_HTMLReportFilename;
        private System.Windows.Forms.TextBox TextBox_EventLog_HTMLFilename;
        private System.Windows.Forms.Label Label_LocalEventLog;
        private System.Windows.Forms.TextBox TextBox_EventLog_Filename;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label Label_MaxDownloadSize;
        private System.Windows.Forms.Label Label_SnapshotBaseline;
        private System.Windows.Forms.TextBox TextBox_Snapshot_MaxDownloadSize;
        private System.Windows.Forms.TextBox TextBox_SnapshotFilename_Baseline;
        private System.Windows.Forms.Button Settings_Save;
        private System.Windows.Forms.Button Settings_Cancel;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ToolTip LabelToolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_EmailSubject_Report;
        private System.Windows.Forms.CheckBox CheckBox_Encrypt_BlobKey;
        private System.Windows.Forms.CheckBox CheckBox_Encrypt_EmailPassword;
        private System.Windows.Forms.CheckBox CheckBox_HighPerformance;
        private System.Windows.Forms.Label Label_EncryptEmailPassword;
        private System.Windows.Forms.Label Label_EncryptKey;
        private System.Windows.Forms.Label label2;

    }
}