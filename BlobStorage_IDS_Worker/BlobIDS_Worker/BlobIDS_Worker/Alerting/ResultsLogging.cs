using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BlobIDS_Worker.Alerting
{
    class ResultsLogging
    {
        /// <summary>
        /// Will automatically do error logging based on current config file settings.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public static void WriteTo_TaskBar_WinEventLog(string title, string description)
        {
            if (Config.Settings.EventLog_WriteTo_WindowsApplicationLog == true)
            {
                WriteTo_WindowsApplicaitonEventLog(title, description);
            }
        }
        /// <summary>
        /// Write to the application log in windows event logs
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        private static void WriteTo_WindowsApplicaitonEventLog(string title, string description)
        {
            try
            {
                DateTime now = DateTime.Now;
                System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();

                // Set the source name for writing log entries.
                eventLog.Source = "BlobIM";

                // Create an event ID to add to the event log
                int eventID = 101;

                // Write an entry to the event log.
                eventLog.WriteEntry(title + " - " + now + " \r\n" + description,
                                    System.Diagnostics.EventLogEntryType.Warning,
                                    eventID);

                // Close the Event Log
                eventLog.Close();
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed To Write to EventLog", e.ToString());
            }
        }

        /// <summary>
        /// Send email alerts per event
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public static void WriteTo_EmailResultsAlert(string title, string description)
        {
            try
            {
                if (Config.Settings.Email_SendUsing_Generic == true)
                {
                    try
                    {
                        DateTime now = DateTime.Now;
                        Email.SendAlert_Generic_Alert(title + " - " + now + " \r\n" + description);
                    }
                    catch
                    {

                    }
                }
                if (Config.Settings.Email_SendUsing_WindowsCredentials == true)
                {
                    try
                    {
                        DateTime now = DateTime.Now;
                        Email.SendAlert_UsingWindowsCredentials(Config.Settings.Email_Subject_Alerts, title + " - " + now + " \r\n" + description);
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// make a backup file of the latest snapshot for records if any changes were found
        /// </summary>
        /// <param name="BackupCurrentSnapshotA"></param>
        /// <param name="BackupCurrentSnapshotB"></param>
        public static void BackupSnapshot(bool BackupCurrentSnapshotA, bool BackupCurrentSnapshotB)
        {
            try
            {
                Guid g;
                g = Guid.NewGuid();
                if (Config.Settings.SaveBackupOfSnapshotsOnEventFound == true)
                {
                    if ((BackupCurrentSnapshotA == true) || (BackupCurrentSnapshotB == true))
                    {
                        File.Copy(Config.Settings.SnapShotFileName_Current, Config.Settings.SnapShotFileName_Current + "." + DateTime.Now.ToString("yyyyMMdd") + "." + g + ".Backup");
                    } 
                }
                if (Config.Settings.EmailBackupOfSnapshotsOnEventFound == true)
                {
                    if ((BackupCurrentSnapshotA == true) || (BackupCurrentSnapshotB == true))
                    {
                        if (Config.Settings.Email_SendUsing_Generic == true)
                        {
                            Email.SendEmail_Generic(Config.Settings.Email_Subject_Backups, "This is a backup file of the latest snapshot of your blob storage.", true,
                               Config.Settings.SnapShotFileName_Current);
                        }
                        if (Config.Settings.Email_SendUsing_WindowsCredentials == true)
                        {
                            Email.SendEmail_Generic_UsingWindowsCredentials(Config.Settings.Email_Subject_Backups, "This is a backup file of the latest snapshot of your blob storage.", true,
                               Config.Settings.SnapShotFileName_Current);
                        }
                    }
                }
                File.Delete(Config.Settings.SnapShotFileName_Current);
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed BackupSnapshot", e.ToString());
            }
        }


        /// <summary>
        /// Print to the log for events
        /// </summary>
        /// <param name="toprint"></param>
        public static void PrintToReport_Log(string toprint)
        {
            try
            {

                if(CheckFileSizeLimit_Generic(Config.Settings.EventLog_FileName, Config.Settings.EventLog_MaxSize))
                {
                    Guid g;
                    g = Guid.NewGuid();
                    File.Copy(Config.Settings.EventLog_FileName, DateTime.Now.ToString("yyyyMMdd") + "." + g + "." + Config.Settings.EventLog_FileName);
                    File.Delete(Config.Settings.EventLog_FileName);

                }
                using (StreamWriter sw = File.AppendText(Config.Settings.EventLog_FileName))
                {
                    sw.WriteLine(toprint);
                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// <para> Returns true if file is larger then indicated size in mb</para> 
        /// <para> Returns false by default if it fails</para>
        /// </summary>
        public static bool CheckFileSizeLimit_Generic(string file, int size)
        {
            bool NeedToSplit = false;
            try
            {
                if(File.Exists(file))
                {
                    FileInfo checkfile = new FileInfo(file);
                    ulong filelength = (ulong)checkfile.Length;
                    int filelength_mb = Convert.ToInt32(filelength / 1048576);
                    //int filelength_mb = Convert.ToInt32(filelength / 1024);
                    if (filelength_mb >= size)
                    {
                        NeedToSplit = true;
                    }
                }
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed CheckFileSizeLimit_Generic", e.ToString());
            }
            return NeedToSplit;
            //1000 seq, 1 sequence is about 1kb so 1000kb = 1mb
            //1,048,576 bytes
        }
    }
}
