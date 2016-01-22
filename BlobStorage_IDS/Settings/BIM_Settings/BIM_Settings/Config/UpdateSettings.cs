using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIM_Settings.Config
{
    class UpdateSettings
    {
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
                            if (((GetSettingName(line)).ToLower()).Equals("DownloadPath".ToLower()))
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
    }
}
