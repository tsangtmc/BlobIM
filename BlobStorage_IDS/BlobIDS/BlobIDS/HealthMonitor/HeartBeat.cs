using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;

namespace BlobIDS.HealthMonitor
{
    class HeartBeat
    {
        public static void Start()
        {
            try
            {
                if ((Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour > 0) || (Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes > 0))
                {
                    long olderrorlogsize = 0;
                    long oldeventlogsize = 0;
                    DateTime now = DateTime.Now;
                    CommandLine.ExecuteWorker.Command("/sendemailheartbeat: \"RESTARTED: BlobIM has been started as of " + now + "\"");

                    while (true)
                    {
                        Config.UpdateSettings.UpdateFromConfig();

                        int interval = (Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour * 60) + Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes;

                        //BackgroundWorker b = o as BackgroundWorker;

                        // do some simple processing for 10 seconds
                        for (int i = 1; i <= interval; i++)
                        {
                            Thread.Sleep(60000);
                        }
                        try
                        {
                            if (Config.Settings.HealthMonitoring_Enabled == true)
                            {
                                DateTime time = DateTime.Now;             // Use current time.
                                CommandLine.ExecuteWorker.Command("/sendemailheartbeat: \"BlobIM is Alive. \r\n Time: " + time + "\"");
                            }
                            if ((Config.Settings.ErrorLog_WriteTo_LocalLog == true) && (File.Exists(Config.Settings.ErrorLog_Path)))
                            {
                                FileInfo f = new FileInfo(Config.Settings.ErrorLog_Path);
                                long errorloglength = f.Length;
                                if (errorloglength > olderrorlogsize)
                                {
                                    GUI.TaskBar.ShowTaskBarMessage_Error("New Errors in Error log \r\n " + Config.Settings.ErrorLog_Path);
                                }
                                olderrorlogsize = errorloglength;
                            }
                            if ((Config.Settings.EventLog_SaveEvents == true) && (File.Exists(Config.Settings.EventLog_FileName)))
                            {
                                FileInfo g = new FileInfo(Config.Settings.EventLog_FileName);
                                long eventloglength = g.Length;
                                if ((eventloglength != oldeventlogsize))
                                {
                                    GUI.TaskBar.ShowTaskBarMessage_Alert("New Events Detected! \r\n " + Config.Settings.EventLog_FileName);
                                }
                                oldeventlogsize = eventloglength;
                            }
                        }
                        catch (Exception e)
                        {
                            Alerting.ErrorLogging.WriteTo_Log("Failed HeartBeat", e.ToString());
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed HeatBeart.Start()", e.ToString());
            }

        }

        /// <summary>
        /// Write to the application log in windows event logs
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public static void WriteTo_WindowsApplicaitonEventLog(string title, string description)
        {
            try
            {
                DateTime now = DateTime.Now;
                System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();

                // Set the source name for writing log entries.
                eventLog.Source = "BlobIM";

                // Create an event ID to add to the event log
                int eventID = 011;

                // Write an entry to the event log.
                eventLog.WriteEntry(title + " - " + now + " \r\n" + description,
                                    System.Diagnostics.EventLogEntryType.Information,
                                    eventID);

                // Close the Event Log
                eventLog.Close();
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed To Write to EventLog", e.ToString());
            }
        }
    }
}
