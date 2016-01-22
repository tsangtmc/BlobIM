using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;

namespace BlobIDS.Config
{
    class UpdateSettings
    {
        public static void CheckForSettings()
        {
            try
            {
                if ((!File.Exists("./Settings.Config")))
                {
                    Config.Resources.WriteResourceToFile("BlobIDS.Resources.Settings.Config.Default", "./Settings.Config");
                }
                if ((!File.Exists("./Settings.Worker.Config")))
                {
                    Config.Resources.WriteResourceToFile("BlobIDS.Resources.Settings.Worker.Config.Default", "./Settings.Worker.Config");
                }
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed CheckForSetting", e.ToString());
            }
        }

        public static void CheckIfUnConfigured()
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
                            if (line.Contains("[Required To Be Changed]"))
                            {
                                done = true;
                                var worker = new BackgroundWorker();
                                worker.DoWork += new DoWorkEventHandler(worker_Do_config);
                                worker.RunWorkerAsync();
                            }
                        }
                    }
                }
                else
                {
                    Alerting.ErrorLogging.WriteTo_Log("Failed CheckIfUnConfigured", "Settings.Config could not be found");
                }
            }
            catch (Exception e)
            {

                Alerting.ErrorLogging.WriteTo_Log("Failed CheckIfUnConfigured", e.ToString());
            }
        }

        static void worker_Do_config(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (File.Exists("./BIM_Settings.exe"))
                {
                    Process.Start(Directory.GetCurrentDirectory() + "/BIM_Settings.exe");
                }
                else
                {
                    Config.Resources.WriteResourceToFile("BlobIDS.Resources.BIM_Settings.exe", "BIM_Settings.exe");
                    Process.Start("./BIM_Settings.exe");
                }
            }
            catch (Exception x)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed Opening Settings", "\r\n" + x.ToString());
            }
        }
        public static void UpdateFromConfig()
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
                            if (((GetSettingName(line)).ToLower()).Equals("ShutDownBIM".ToLower()))
                            {
                                try
                                {
                                    if (Convert.ToBoolean(ParseSettingContent(line)) == true)
                                    {
                                        Alerting.ErrorLogging.WriteTo_Log("Manual ShutDown Detected", "\"ShutDownBIM\" was set to True in Settings.Config");
                                        Application.Exit();
                                    }
                                }
                                catch
                                {
                                    Alerting.ErrorLogging.WriteTo_Log("Failed To Exit", "Most likely the setting for \"ShutDownBIM\" was not True or False, but something else");
                                }
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("DownloadPath".ToLower()))
                            {
                                Config.Settings.DownloadPath_Set(ParseSettingContent(line));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("MaxDownloadSize".ToLower()))
                            {
                                Config.Settings.MaxDownloadSize_Set(Convert.ToInt64(ParseSettingContent(line)));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SnapShotFileName_Baseline".ToLower()))
                            {
                                Config.Settings.SnapShotFileName_Baseline_Set(ParseSettingContent(line));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SnapShotFileName_Previous".ToLower()))
                            {
                                Config.Settings.SnapShotFileName_Previous_Set(ParseSettingContent(line));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SnapShotFileName_Current".ToLower()))
                            {
                                Config.Settings.SnapShotFileName_Current_Set(ParseSettingContent(line));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SnapShotFileName_FileAccess".ToLower()))
                            {
                                Config.Settings.SnapShotFileName_FileAccess_Set(ParseSettingContent(line));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("DetectionPeriod_EveryNumberof_Hours".ToLower()))
                            {
                                Config.Settings.DetectionPeriod_EveryNumberof_Hours_Set(Convert.ToInt32(ParseSettingContent(line)));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("DetectionPeriod_EveryNumberof_Minutes".ToLower()))
                            {
                                Config.Settings.DetectionPeriod_EveryNumberof_Minutes_Set(Convert.ToInt32(ParseSettingContent(line)));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("EventLog_FileName".ToLower()))
                            {
                                Config.Settings.EventLog_FileName_Set(ParseSettingContent(line));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("EventLog_SaveEvents".ToLower()))
                            {
                                Config.Settings.EventLog_SaveEvents_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("EventLog_MaxSize".ToLower()))
                            {
                                Config.Settings.EventLog_MaxSize_Set(Convert.ToInt32(ParseSettingContent(line)));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("EventLog_WriteTo_WindowsApplicationLog".ToLower()))
                            {
                                Config.Settings.EventLog_WriteTo_WindowsApplicationLog_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));


                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("EventLog_ShowTaskBarMessage".ToLower()))
                            {
                                Config.Settings.EventLog_ShowTaskBarMessage_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Report_FileName_html".ToLower()))
                            {
                                Config.Settings.Report_FileName_html_Set(ParseSettingContent(line));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SendReportAs_HTML".ToLower()))
                            {
                                Config.Settings.SendReportAs_HTML_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("Report_FileName_csv".ToLower()))
                            {
                                Config.Settings.Report_FileName_csv_Set(ParseSettingContent(line));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SendReportAs_CSV".ToLower()))
                            {
                                Config.Settings.SendReportAs_CSV_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("SaveBackupOfSnapshotsOnEventFound".ToLower()))
                            {
                                Config.Settings.SaveBackupOfSnapshotsOnEventFound_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("EmailBackupOfSnapshotsOnEventFound".ToLower()))
                            {
                                Config.Settings.EmailBackupOfSnapshotsOnEventFound_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("ErrorLog_Path".ToLower()))
                            {
                                Config.Settings.ErrorLog_Path_Set(ParseSettingContent(line));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("ErrorLog_WriteTo_LocalLog".ToLower()))
                            {
                                Config.Settings.ErrorLog_WriteTo_LocalLog_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("ErrorLog_WriteTo_WindowsApplicationLog".ToLower()))
                            {
                                Config.Settings.ErrorLog_WriteTo_WindowsApplicationLog_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));


                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("ErrorLog_SendEmail_PerError".ToLower()))
                            {
                                Config.Settings.ErrorLog_SendEmail_PerError_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("ErrorLog_ShowTaskBarMessage".ToLower()))
                            {
                                Config.Settings.ErrorLog_ShowTaskBarMessage_Set(Convert.ToBoolean((ParseSettingContent(line)).ToLower()));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour".ToLower()))
                            {
                                Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour_Set(Convert.ToInt32(ParseSettingContent(line)));
                            }
                            else if (((GetSettingName(line)).ToLower()).Equals("HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes".ToLower()))
                            {
                                Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes_Set(Convert.ToInt32(ParseSettingContent(line)));
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

        /// <summary>
        /// Parses out the container name from xml snapshot file, must specifically be in this format "&lt;Container Name="devicereadings"&gt;"
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
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

        public static int GetNthIndex(string s, char t, int n)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static void SetWindowsEventLog_UAC()
        {
            if ((Config.Settings.EventLog_WriteTo_WindowsApplicationLog == true) || (Config.Settings.ErrorLog_WriteTo_WindowsApplicationLog == true))
            {
                // check first if its possible to write to even log without being admin
                try
                {
                    DateTime now = DateTime.Now;
                    System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();

                    // Set the source name for writing log entries.
                    eventLog.Source = "BlobIM";

                    // Create an event ID to add to the event log
                    int eventID = 111;

                    // Write an entry to the event log.
                    eventLog.WriteEntry("Permission Check" + " - " + now + " \r\n This entry is created when BIM is started to verify if it has permissions to write to windows event log.",
                                        System.Diagnostics.EventLogEntryType.Information,
                                        eventID);

                    // Close the Event Log
                    eventLog.Close();
                }
                catch (Exception e)
                {
                    System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent());
                    bool administrativeMode = principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);

                    if (!administrativeMode)
                    {
                        MessageBox.Show("Administrative Permissions Required \n You have selected in the BIM Configuration to have BIM Log Events to the Windows Event Log. \n It does not appear it is possible with the current user, BIM will now request Administrative Permissions to do so. ");
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.Verb = "runas";
                        startInfo.FileName = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                        try
                        {
                            System.Diagnostics.Process.Start(startInfo);
                            Application.Exit();
                            Environment.Exit(0);
                        }
                        catch (Exception ex)
                        {
                            Alerting.ErrorLogging.WriteTo_Log("Failed Running as Administrator", ex.ToString());
                            return;
                        }
                        return;
                    }
                    else
                    {
                        System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
                        // Check if the event source exists. If not create it.
                        if (!System.Diagnostics.EventLog.SourceExists("BlobIM"))
                        {
                            System.Diagnostics.EventLog.CreateEventSource("BlobIM", "Application");
                        }
                    }
                }

            }
        }
    }
}
