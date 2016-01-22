using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BlobIDS_Worker.Alerting
{
    class ErrorLogging
    {
        /// <summary>
        /// Will automatically do error logging based on current config file settings.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public static void WriteTo_Log(string title, string description)
        {
            if (Config.Settings.ErrorLog_ShowTaskBarMessage == true)
            {
                GUI.TaskBar.ShowTaskBarMessage_Error(title + "\r\n" + description);
            }
            if (Config.Settings.ErrorLog_WriteTo_LocalLog == true)
            {
                WriteTo_ErrorLog(title, description);
            }
            if(Config.Settings.ErrorLog_WriteTo_WindowsApplicationLog == true)
            {
                WriteTo_WindowsApplicaitonEventLog(title, description);
            }
            if(Config.Settings.ErrorLog_SendEmail_PerError == true)
            {
                WriteTo_EmailErrorAlert(title, description);
            }
        }
        /// <summary>
        /// write to the basic local log file
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public static void WriteTo_ErrorLog(string title, string description)
        {
            try
            {
                
                using (StreamWriter sw = File.AppendText(Config.Settings.ErrorLog_Path))
                {
                    DateTime now = DateTime.Now;
                    title = title.Replace("\r", " ");
                    title = title.Replace("\n", " ");
                    sw.Write(now + " - [" + title + "]     ");

                    description = description.Replace("\r", " ");
                    description = description.Replace("\n", " ");
                    sw.WriteLine(description);
                }	
            }
            catch
            {

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
                int eventID = 111;

                // Write an entry to the event log.
                eventLog.WriteEntry(title + " - " + now + " \r\n" + description,
                                    System.Diagnostics.EventLogEntryType.Error,
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
        /// Send email alerts per error
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        private static void WriteTo_EmailErrorAlert(string title, string description)
        {
            try
            {
                if(Config.Settings.Email_SendUsing_Generic == true)
                {
                    try
                    {
                        DateTime now = DateTime.Now;
                        Email.SendAlert_Generic_Error(title + " - " + now + " \r\n" + description);
                    }
                    catch
                    {

                    }
                }
                if(Config.Settings.Email_SendUsing_WindowsCredentials == true)
                {
                    try
                    {
                        DateTime now = DateTime.Now;
                        Email.SendAlert_UsingWindowsCredentials(Config.Settings.Email_Subject_Errors, title + " - " + now + " \r\n" + description);
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
    }
}
