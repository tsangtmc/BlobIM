using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace BIM_Settings
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            FillFormFromConfig();
            FillFormFromWorkerConfig();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Cancel_Click(object sender, EventArgs e)
        {
            Settings.ActiveForm.Close();
        }

        private void Settings_Save_Click(object sender, EventArgs e)
        {
            FormToConfig();
            WorkerFormToConfig();
            Settings.ActiveForm.Close();
        }

        void Checked_HighPerformance(object sender, EventArgs e)
        {
            if (CheckBox_HighPerformance.Checked == true)
            {
                TextBox_Snapshot_MaxDownloadSize.Text = "0";
            }      
        }
        void TextChange_MaxDownloadSize(object sender, EventArgs e)
        {
            try {
                if ((Convert.ToInt64(TextBox_Snapshot_MaxDownloadSize.Text)) == 0)
                {
                    CheckBox_HighPerformance.Checked = true;
                }
                else
                {
                    CheckBox_HighPerformance.Checked = false; 
                }
            }
            catch (Exception ex) 
            { 
                //MessageBox.Show(ex.ToString()); 
            }
            
        }
        void LabelChange_EncryptKey(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox_Encrypt_BlobKey.Checked == false)
                {
                    Label_EncryptKey.Text = "[🚫 !Warning - NOT Protected! ☹]";
                    Label_EncryptKey.Font = new Font(Label_EncryptKey.Font.Name, 9, FontStyle.Bold);
                    Label_EncryptKey.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Label_EncryptKey.Text = "[👌 Currently Protected ☺] -> Click Save!";
                    Label_EncryptKey.Font = new Font(Label_EncryptKey.Font.Name, 9, FontStyle.Regular);
                    Label_EncryptKey.ForeColor = System.Drawing.Color.DarkGreen;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString()); 
            }

        }
        void LabelChange_EncryptEmailPassword(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox_Encrypt_EmailPassword.Checked == false)
                {
                    Label_EncryptEmailPassword.Text = "[🚫 !Warning - NOT Protected! ☹]";
                    Label_EncryptEmailPassword.Font = new Font(Label_EncryptEmailPassword.Font.Name, 9, FontStyle.Bold);
                    Label_EncryptEmailPassword.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Label_EncryptEmailPassword.Text = "[👌 Currently Protected ☺] -> Click Save!";
                    Label_EncryptEmailPassword.Font = new Font(Label_EncryptEmailPassword.Font.Name, 9, FontStyle.Regular);
                    Label_EncryptEmailPassword.ForeColor = System.Drawing.Color.DarkGreen;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString()); 
            }

        }
        void FillFormFromConfig()
        {
            try
            {
                string line;

                if ((File.Exists("./Settings.Config")))
                {
                    using (System.IO.StreamReader file = new System.IO.StreamReader(@"./Settings.Config"))
                    {
                        bool done = false;
                        while (((line = file.ReadLine()) != null) && (done == false))
                        {
                            if (((GetSettingName(line)).ToLower()).Equals("DownloadPath".ToLower()))
                            {
                                Set_TextBox(line, TextBox_Snapshot_TempFiles); 
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("MaxDownloadSize".ToLower()))
                            {
                                Set_TextBox(line, TextBox_Snapshot_MaxDownloadSize);
                                if ((Convert.ToInt64(TextBox_Snapshot_MaxDownloadSize.Text)) == 0)
                                {
                                    CheckBox_HighPerformance.Checked = true;
                                }
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SnapShotFileName_Baseline".ToLower()))
                            {
                                Set_TextBox(line, TextBox_SnapshotFilename_Baseline); 
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SnapShotFileName_Previous".ToLower()))
                            {
                                Set_TextBox(line, TextBox_SnapshotFilename_Previous); 
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SnapShotFileName_Current".ToLower()))
                            {
                                Set_TextBox(line, TextBox_SnapshotFilename_Current);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SnapShotFileName_FileAccess".ToLower()))
                            {
                                Set_TextBox(line, TextBox_SnapshotFilename_Permissions);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("DetectionPeriod_EveryNumberof_Hours".ToLower()))
                            {
                                Set_TextBox(line, TextBox_Snapshot_ScanEveryHour);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("DetectionPeriod_EveryNumberof_Minutes".ToLower()))
                            {
                                Set_TextBox(line, TextBox_Snapshot_ScanEveryMinute);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("EventLog_FileName".ToLower()))
                            {
                                Set_TextBox(line, TextBox_EventLog_Filename);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("EventLog_SaveEvents".ToLower()))
                            {
                                CheckBox_EventLog_EnableLocal.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("EventLog_MaxSize".ToLower()))
                            {
                                Set_TextBox(line, TextBox_EventLog_MaxSize);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("EventLog_WriteTo_WindowsApplicationLog".ToLower()))
                            {
                                CheckBox_EventLog_WindowsAppLog.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("EventLog_ShowTaskBarMessage".ToLower()))
                            {
                                CheckBox_ShowTaskBar_Events.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Report_FileName_html".ToLower()))
                            {
                                Set_TextBox(line, TextBox_EventLog_HTMLFilename);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SendReportAs_HTML".ToLower()))
                            {
                                CheckBox_EventLog_EnableHTML.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Report_FileName_csv".ToLower()))
                            {
                                Set_TextBox(line, TextBox_EventLog_CSVFilename);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SendReportAs_CSV".ToLower()))
                            {
                                CheckBox_EventLog_EnableCSV.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SaveBackupOfSnapshotsOnEventFound".ToLower()))
                            {
                                CheckBox_SaveBackup.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("EmailBackupOfSnapshotsOnEventFound".ToLower()))
                            {
                                CheckBox_EmailBackup.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("ErrorLog_Path".ToLower()))
                            {
                                Set_TextBox(line, TextBox_ErrorLog_Filename);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("ErrorLog_WriteTo_LocalLog".ToLower()))
                            {
                                CheckBox_ErrorLog_Local.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("ErrorLog_WriteTo_WindowsApplicationLog".ToLower()))
                            {
                                CheckBox_ErrorLog_WindowsAppLog.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("ErrorLog_SendEmail_PerError".ToLower()))
                            {
                                CheckBox_ErrorLog_EmailPerError.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("ErrorLog_ShowTaskBarMessage".ToLower()))
                            {
                                CheckBox_ShowTaskBar_Errors.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour".ToLower()))
                            {
                                Set_TextBox(line, TextBox_Heartbeat_Hours);
                                if ((Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour == 0) && (Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes == 0))
                                {
                                    CheckBox_Heartbeat_Enable.Checked = false;
                                }
                                else
                                {
                                    CheckBox_Heartbeat_Enable.Checked = true;
                                }
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes".ToLower()))
                            {
                                Set_TextBox(line, TextBox_Heartbeat_Minutes);
                                if ((Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour == 0) && (Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes == 0))
                                {
                                    CheckBox_Heartbeat_Enable.Checked = false;
                                }
                                else
                                {
                                    CheckBox_Heartbeat_Enable.Checked = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Alerting.ErrorLogging.WriteTo_Log("Failed UpdateFromConfig", "Settings.Config could not be found");
                }
            }
            catch (Exception e)
            {

                Alerting.ErrorLogging.WriteTo_Log("Failed UpdateFromConfig", e.ToString());
            }
        }

        void FillFormFromWorkerConfig()
        {
            try
            {
                string line;
                if ((File.Exists("./Settings.Worker.Config")))
                {
                    using (System.IO.StreamReader file = new System.IO.StreamReader(@"./Settings.Worker.Config"))
                    {
                        bool done = false;
                        while (((line = file.ReadLine()) != null) && (done == false))
                        {
                            if (((GetSettingName(line)).ToLower()).Equals("BlobStorage_Account_Name".ToLower()))
                            {
                                Set_TextBox(line, TextBox_AccountName);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("BlobStorage_Account_Key".ToLower()))
                            {
                                string Storage_key = ParseSettingContent(line);
                                if (Storage_key.Contains("[Required To Be Changed]"))
                                {
                                    TextBox_AccountKey.Text = ParseSettingContent(line);
                                    TextBox_AccountKey.BackColor = Color.Red;
                                }
                                else
                                {
                                    TextBox_AccountKey.PasswordChar = '*';
                                    TextBox_AccountKey.Text = ParseSettingContent(line);
                                }
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("BlobStorage_Account_Key_Encrypted".ToLower()))
                            {
                                CheckBox_Encrypt_BlobKey.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                                Config.Settings.BlobStorage_Account_Key_Encrypted_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));

                                if (CheckBox_Encrypt_BlobKey.Checked == false)
                                {
                                    Label_EncryptKey.Text = "[🚫 !Warning - NOT Protected! ☹]";
                                    Label_EncryptKey.Font = new Font(Label_EncryptKey.Font.Name, 9, FontStyle.Bold);
                                    Label_EncryptKey.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    Label_EncryptKey.Text = "[👌 Currently Protected ☺]";
                                    Label_EncryptKey.Font = new Font(Label_EncryptKey.Font.Name, 9, FontStyle.Regular);
                                    Label_EncryptKey.ForeColor = System.Drawing.Color.DarkGreen;
                                }
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("BlobStorage_Account_Environment".ToLower()))
                            {
                                Set_TextBox(line, TextBox_AccountEnvironment);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_SMTPServer_Generic".ToLower()))
                            {
                                Set_TextBox(line, TextBox_SMTPServer);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_SMTPServer_Port".ToLower()))
                            {
                                Set_TextBox(line, TextBox_SMTPServerPort);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_Account".ToLower()))
                            {
                                Set_TextBox(line, TextBox_SMTPAccount);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_Password".ToLower()))
                            {
                                string email_password = ParseSettingContent(line);
                                if (email_password.Contains("[Required To Be Changed]"))
                                {
                                    TextBox_SMTPPassword.Text = ParseSettingContent(line);
                                    TextBox_SMTPPassword.BackColor = Color.Red;
                                }
                                else
                                {
                                    TextBox_SMTPPassword.PasswordChar = '*';
                                    TextBox_SMTPPassword.Text = ParseSettingContent(line);
                                }
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_Password_Encrypted".ToLower()))
                            {
                                CheckBox_Encrypt_EmailPassword.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                                Config.Settings.Email_Password_Encrypted_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));

                                if (CheckBox_Encrypt_EmailPassword.Checked == false)
                                {
                                    Label_EncryptEmailPassword.Text = "[🚫 !Warning - NOT Protected! ☹]";
                                    Label_EncryptEmailPassword.Font = new Font(Label_EncryptEmailPassword.Font.Name, 9, FontStyle.Bold);
                                    Label_EncryptEmailPassword.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    Label_EncryptEmailPassword.Text = "[👌 Currently Protected ☺]";
                                    Label_EncryptEmailPassword.Font = new Font(Label_EncryptEmailPassword.Font.Name, 9, FontStyle.Regular);
                                    Label_EncryptEmailPassword.ForeColor = System.Drawing.Color.DarkGreen;
                                }
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_SMTPServer_WindowsCredentials".ToLower()))
                            {
                                Set_TextBox(line, TextBox_SMTPServer_Windows);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_SendUsing_Generic".ToLower()))
                            {
                                CheckBox_EmailAlerting.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_SendUsing_WindowsCredentials".ToLower()))
                            {
                                CheckBox_EmailAlertingWindows.Checked = Convert.ToBoolean((ParseSettingContent(line)).ToLower());
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_Sender".ToLower()))
                            {
                                Set_TextBox(line, TextBox_EmailFrom);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_Recipient".ToLower()))
                            {
                                Set_TextBox(line, TextBox_EmailTo);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_Subject_Alerts".ToLower()))
                            {
                                Set_TextBox(line, TextBox_EmailSubject_Alert);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_Subject_HeartBeat".ToLower()))
                            {
                                Set_TextBox(line, TextBox_EmailSubject_Heartbeat);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_Subject_Errors".ToLower()))
                            {
                                Set_TextBox(line, TextBox_EmailSubject_Error);
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_Subject_Reporting".ToLower()))
                            {
                                Set_TextBox(line, TextBox_EmailSubject_Report); // Not yet implemented
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Email_Subject_Backups".ToLower()))
                            {
                                Set_TextBox(line, TextBox_EmailSubject_Backups); 
                            }

                        }
                    }
                }
                else
                {
                    Alerting.ErrorLogging.WriteTo_Log("Failed UpdateFromConfig", "Settings.Config could not be found");
                }
            }
            catch (Exception e)
            {

                Alerting.ErrorLogging.WriteTo_Log("Failed UpdateFromConfig", e.ToString());
            }
        }



        void FormToConfig()
        {
            try
            {
                if ((File.Exists("./Settings.Config")))
                { File.Delete("./Settings.Config"); }

                if (CheckBox_Heartbeat_Enable.Checked == false)
                {
                    TextBox_Heartbeat_Hours.Text = "0";
                    TextBox_Heartbeat_Minutes.Text = "0";
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./Settings.Config"))
                {
                    file.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><!-- GUI Settings Generated -->");
                    file.WriteLine("");
                    file.WriteLine("<!-- Note that settings can be modified real time and will take effect on the next scan weather manual or scheduled -->");
                    file.WriteLine("");
                    file.WriteLine("<!-- Manual ShutDown -->");
                    file.WriteLine("<setting name=\"ShutDownBIM\">False</setting><!-- This is a manual override setting for turning off BIM. When set to true, on the next scanning interval the BIM engine will exit instead. -->");
                    file.WriteLine("");
                    file.WriteLine("<!-- Detection Settings -->");
                    file.WriteLine("<setting name=\"DownloadPath\">" + TextBox_Snapshot_TempFiles.Text + "</setting><!-- Path of where to allow the tool to store temp files -->");
                    file.WriteLine("<setting name=\"MaxDownloadSize\">" + TextBox_Snapshot_MaxDownloadSize .Text+ "</setting><!-- Maximum size a file can be to be downloaded for detection purposes, 3000000 = 3mb (keep in mind transaction costs of download files) -->");
                    file.WriteLine("<setting name=\"SnapShotFileName_Baseline\">" + TextBox_SnapshotFilename_Baseline.Text + "</setting><!-- This can be ignored unless you have a real need to not having a file created with this name. This will be used as a configuration file for specifiying what blobs and containers should be monitored. The state of blob storage baseline is saved as \"snapshots\", specify the file name for that here -->");
                    file.WriteLine("<setting name=\"SnapShotFileName_Previous\">" + TextBox_SnapshotFilename_Previous.Text+ "</setting><!-- This can be ignored unless you have a real need to not having a temp file created with this name. The state of blob storage from a previous check is stored as \"snapshots\", specify the file name for that here -->");
                    file.WriteLine("<setting name=\"SnapShotFileName_Current\">" + TextBox_SnapshotFilename_Current.Text + "</setting><!-- This can be ignored unless you have a real need to not having a temp file created with this name. The state of blob storage during every check is saved as \"snapshots\", specify the file name for that here -->");
                    file.WriteLine("<setting name=\"SnapShotFileName_FileAccess\">" + TextBox_SnapshotFilename_Permissions.Text + "</setting><!-- This can be ignored unless you have a real need to not having a file created with this name. The state of blob storage identifing file permissions saved as \"snapshot\", specify the file name for that here -->");
                    file.WriteLine("<setting name=\"DetectionPeriod_EveryNumberof_Hours\">" +TextBox_Snapshot_ScanEveryHour.Text+ "</setting><!-- (Hours and minutes can be combine for the same settings) specify periodically how many hours to do a check at, zero with effectively disable this setting -->");
                    file.WriteLine("<setting name=\"DetectionPeriod_EveryNumberof_Minutes\">"+TextBox_Snapshot_ScanEveryMinute.Text+"</setting><!-- (Hours and minutes can be combine for the same settings) specify periodically how many minutes to do a check at, zero with effectively disable this setting -->");
                    file.WriteLine("");
                    file.WriteLine("<!-- Results\\Event Logging Settings -->");
                    file.WriteLine("<setting name=\"EventLog_FileName\">"+TextBox_EventLog_Filename.Text+"</setting><!-- FileName of the log of Detected Events -->");
                    file.WriteLine("<setting name=\"EventLog_SaveEvents\">"+ CheckBox_EventLog_EnableLocal.Checked +"</setting><!-- Enable or Disable saving detected events to log -->");
                    file.WriteLine("<setting name=\"EventLog_MaxSize\">"+TextBox_EventLog_MaxSize.Text+"</setting><!-- The Maximum size in MB a log file can be before it is rolled over -->");
                    file.WriteLine("<setting name=\"EventLog_WriteTo_WindowsApplicationLog\">"+CheckBox_EventLog_WindowsAppLog.Checked+"</setting><!-- Enable or Disable recording Detected Events in the Windows Application Log -->");
                    file.WriteLine("<setting name=\"EventLog_ShowTaskBarMessage\">"+CheckBox_ShowTaskBar_Events.Checked+"</setting><!-- Enable or Disable taskbar notifications -->");
                    file.WriteLine("<setting name=\"Report_FileName_html\">"+TextBox_EventLog_HTMLFilename.Text+"</setting><!-- File name of the Detected Events Report in HTML format, this is only a temporary file which is deleted after sending-->");
                    file.WriteLine("<setting name=\"SendReportAs_HTML\">"+CheckBox_EventLog_EnableHTML.Checked+"</setting><!-- Enable or Disable sending reports in HTML format -->");
                    file.WriteLine("<setting name=\"Report_FileName_csv\">"+TextBox_EventLog_CSVFilename.Text+"</setting><!-- File name of the Detected Events Report in CSV format, this is only a temporary file which is delted after sending-->");
                    file.WriteLine("<setting name=\"SendReportAs_CSV\">"+CheckBox_EventLog_EnableCSV.Checked+"</setting><!-- Enable or Disable sending reports in HTML format -->");
                    file.WriteLine("<setting name=\"SaveBackupOfSnapshotsOnEventFound\">"+CheckBox_SaveBackup.Checked+"</setting><!-- Enable or Disable saving the \"snapshot\" as a backup if a Event is Detected -->");
                    file.WriteLine("<setting name=\"EmailBackupOfSnapshotsOnEventFound\">"+CheckBox_EmailBackup.Checked+"</setting><!-- Enable or Disable Emailing a copy of the \"snapshot\" if a Event is Detected -->");
                    file.WriteLine("");
                    file.WriteLine("<!-- Error Logging Settings -->");
                    file.WriteLine("<setting name=\"ErrorLog_Path\">"+TextBox_ErrorLog_Filename.Text+"</setting><!-- File name and path of were to save error log files -->");
                    file.WriteLine("<setting name=\"ErrorLog_WriteTo_LocalLog\">"+CheckBox_ErrorLog_Local.Checked+"</setting><!-- Enable or Disable weather errors should be saved to log file -->");
                    file.WriteLine("<setting name=\"ErrorLog_WriteTo_WindowsApplicationLog\">"+CheckBox_ErrorLog_WindowsAppLog.Checked+"</setting><!-- Enable or Disable if errors should be written to windows Application Log -->");
                    file.WriteLine("<setting name=\"ErrorLog_SendEmail_PerError\">"+CheckBox_ErrorLog_EmailPerError.Checked+"</setting><!-- Enable or Disable if emails should be sent when a error occurs -->");
                    file.WriteLine("<setting name=\"ErrorLog_ShowTaskBarMessage\">"+CheckBox_ShowTaskBar_Errors.Checked+"</setting><!-- Enable or Disable taskbar notifications for errors -->");
                    file.WriteLine("");
                    file.WriteLine("<!-- HealthMonitoring/Uptime Settings -->");
                    file.WriteLine("<setting name=\"HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour\">"+TextBox_Heartbeat_Hours.Text+"</setting><!-- (Hours and minutes can be combine for the same settings) specify periodically how many hours to send a health status email at, zero with effectively disable this setting -->");
                    file.WriteLine("<setting name=\"HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes\">" + TextBox_Heartbeat_Minutes.Text + "</setting><!-- (Hours and minutes can be combine for the same settings) specify periodically how many minutes to send a health status email at, zero with effectively disable this setting -->");
                }
            }
            catch (Exception e)
            {

                Alerting.ErrorLogging.WriteTo_Log("Failed FormToConfig", e.ToString());
            }
        }

        void WorkerFormToConfig()
        {
            try
            {
                if ((File.Exists("./Settings.Worker.Config")))
                { File.Delete("./Settings.Worker.Config"); }

                //first check the encrypted settigns
                if ((CheckBox_Encrypt_EmailPassword.Checked == true)&&(Config.Settings.Email_Password_Encrypted == false))
                {
                    //encrypt the password with DPAPI before writing to file
                    Config.Settings.Email_Password_Set(Config.DPAPI.Encrypt(TextBox_SMTPPassword.Text));
                }
                else
                {
                    Config.Settings.Email_Password_Set(TextBox_SMTPPassword.Text);
                }
                if ((CheckBox_Encrypt_BlobKey.Checked == true) &&(Config.Settings.BlobStorage_Account_Key_Encrypted == false))
                {
                    Config.Settings.BlobStorage_Account_Key_Set(Config.DPAPI.Encrypt(TextBox_AccountKey.Text));
                }
                else
                {
                    Config.Settings.BlobStorage_Account_Key_Set(TextBox_AccountKey.Text);
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./Settings.Worker.Config"))
                {
                    file.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><!-- GUI Settings Generated -->");
                    file.WriteLine("<!-- BlobStorage Credentials -->");
                    file.WriteLine("<setting name=\"BlobStorage_Account_Name\">"+TextBox_AccountName.Text+"</setting><!-- BlobStorage Account to be Monitored -->");
                    file.WriteLine("<setting name=\"BlobStorage_Account_Key\">" + Config.Settings.BlobStorage_Account_Key + "</setting><!-- Key for the BlobStorage Account to be monitored, if DPAI Encrypted must be base64 encoded and make sure BlobStorage_Account_Key_Encrypted is set to true, if NOT Encrypted make sure BlobStorage_Account_Key_Encrypted is set to false -->");
                    file.WriteLine("<setting name=\"BlobStorage_Account_Key_Encrypted\">" + CheckBox_Encrypt_BlobKey.Checked + "</setting><!-- If Account Key in this setting file is Encrypted with DPAPI, if set to False then BIM will try to use the key as \"clear text\" (without decrypting it) -->");
                    file.WriteLine("<setting name=\"BlobStorage_Account_Environment\">" + TextBox_AccountEnvironment.Text + "</setting><!-- Set the Blob Storage Endpoint environment to connect to -->");
                    file.WriteLine("");
                    file.WriteLine("<!-- Email Alert Settings -->");
                    file.WriteLine("<setting name=\"Email_SMTPServer_Generic\">"+TextBox_SMTPServer.Text+"</setting><!-- The SMTP email server to send out email alerts -->");
                    file.WriteLine("<setting name=\"Email_SMTPServer_Port\">"+TextBox_SMTPServerPort.Text+"</setting><!-- Port of SMTP Email Server -->");
                    file.WriteLine("<setting name=\"Email_Account\">"+TextBox_SMTPAccount.Text+"</setting><!-- Email Account to login to SMTP server -->");
                    file.WriteLine("<setting name=\"Email_Password\">" + Config.Settings.Email_Password + "</setting><!-- Password for Email Account to login to SMTP Server, if DPAI Encrypted must be base64 encoded and make sure Email_Password_Encrypted is set to true, if NOT Encrypted make sure Email_Password_Encrypted is set to false -->");
                    file.WriteLine("<setting name=\"Email_Password_Encrypted\">" + CheckBox_Encrypt_EmailPassword.Checked + "</setting><!-- If Email Password in this setting file is Encrypted with DPAPI, if set to False then BIM will try to use the password as \"clear text\" (without decrypting it) -->");
                    file.WriteLine("<setting name=\"Email_SMTPServer_WindowsCredentials\">"+TextBox_SMTPServer_Windows.Text+"</setting><!-- If Windows authentication is enabled, SMTP server to use with windows based Authentication -->");
                    file.WriteLine("<setting name=\"Email_SendUsing_Generic\">"+CheckBox_EmailAlerting.Checked+"</setting><!-- Enable or Disable sending email with SMTP and regular authentication -->");
                    file.WriteLine("<setting name=\"Email_SendUsing_WindowsCredentials\">"+CheckBox_EmailAlertingWindows.Checked+"</setting><!-- Enable or Disable sending email with SMTP using windows based authentication -->");
                    file.WriteLine("<setting name=\"Email_Sender\">"+TextBox_EmailFrom.Text+"</setting><!-- The sender of who email alerts will appear they are from -->");
                    file.WriteLine("<setting name=\"Email_Recipient\">"+TextBox_EmailTo.Text+"</setting><!-- Who to send emails to. To add multiple separate each email with ';' -->");
                    file.WriteLine("<setting name=\"Email_Subject_Alerts\">"+TextBox_EmailSubject_Alert.Text+"</setting><!-- Specify the subject of email Detection based Alerts -->");
                    file.WriteLine("<setting name=\"Email_Subject_HeartBeat\">"+TextBox_EmailSubject_Heartbeat.Text+"</setting><!-- Specify the subject of email Detection based Alerts -->");
                    file.WriteLine("<setting name=\"Email_Subject_Errors\">"+TextBox_EmailSubject_Error.Text+"</setting><!-- Specify the subject of email Error based alerts -->");
                    file.WriteLine("<setting name=\"Email_Subject_Reporting\">"+TextBox_EmailSubject_Report.Text+"</setting><!-- Specify the subject of email Report based alerts -->");
                    file.WriteLine("<setting name=\"Email_Subject_Backups\">" + TextBox_EmailSubject_Backups .Text+ "</setting><!-- Specify the subject of email Backup file based alerts -->");
                }

            }
            catch (Exception e)
            {

                Alerting.ErrorLogging.WriteTo_Log("Failed UpdateFromConfig", e.ToString());
            }
        }

        public void Set_TextBox(string line, System.Windows.Forms.TextBox Text_Box)
        {
            string parameter = ParseSettingContent(line);
            if (parameter.Contains("[Required To Be Changed]"))
            {
                Text_Box.Text = ParseSettingContent(line);
                Text_Box.BackColor = Color.Red;
            }
            else if (parameter.Equals(null))
            {
                Text_Box.Text = ParseSettingContent(line);
                Text_Box.BackColor = Color.Red;
            }
            else if (parameter.Equals(""))
            {
                Text_Box.Text = "[Required To Be Changed]";
                Text_Box.BackColor = Color.Red;
            }
            else
            {
                Text_Box.Text = ParseSettingContent(line);
            }
        }

        private static string GetSettingName(string line)
        {
            try
            {
                if (line.Contains("<setting name="))
                {
                    int startpos = line.IndexOf("=\"");
                    startpos = startpos + 2;
                    string settingname = line.Substring(startpos);
                    int namelength = settingname.IndexOf(">");
                    settingname = settingname.Substring(0, namelength);
                    int endpos = settingname.IndexOf("\"");
                    settingname = settingname.Substring(0, endpos);
                    return settingname;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed GetContainerName", e.ToString());
                return "N/A";
            }
        }

        /// <summary>
        /// Parses out content from a xml element that is contained on one line, e.g: &ltMonitorThisFile>True&lt/MonitorThisFile>
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static string ParseSettingContent(string line)
        {   //<MonitorThisFile>True</MonitorThisFile>
            try
            {
                string content = line.Substring(0, (line.IndexOf("</")));
                content = content.Substring((content.IndexOf(">")) + 1);
                return content;
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed ParseSettingContent", e.ToString());
                return "N/A";
            }
        }


    }
}
