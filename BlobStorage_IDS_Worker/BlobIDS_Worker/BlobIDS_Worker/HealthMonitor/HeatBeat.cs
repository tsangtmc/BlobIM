using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;

namespace BlobIDS_Worker.HealthMonitor
{
    class HeatBeat
    {
        public static void CheckPulse()
        {
            try
            {
                if ((Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour > 0) || (Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes > 0))
                {
                    DateTime now = DateTime.Now;
                    Alerting.Email.SendEmail_Generic("BlobIM HeartBeat - Started", "BlobIM has been started as of " + now, false, "");
                    BackgroundWorker bw = new BackgroundWorker();
                   
                    // this allows our worker to report progress during work
                    bw.WorkerReportsProgress = true;

                    while (true)
                    {                     
                        // what to do in the background thread
                        bw.DoWork += new DoWorkEventHandler(
                        delegate(object o, DoWorkEventArgs args)
                        {
                            int interval = (Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByHour * 60) + Config.Settings.HealthMonitoring_SendEmail_HeartBeatPeriodicallyByMinutes;

                            //BackgroundWorker b = o as BackgroundWorker;

                            // do some simple processing for 10 seconds
                            for (int i = 1; i <= interval; i++)
                            {
                                // report the progress in percent
                                //b.ReportProgress(i * 10);
                                Thread.Sleep(60000);
                            }
                            DateTime now2 = DateTime.Now;
                            Alerting.Email.SendEmail_Generic("BlobIM HeartBeat", "BlobIM is up and running as of " + now2, false, "");
                        });
                    }


                    // what to do when progress changed (update the progress bar for example)
                    bw.ProgressChanged += new ProgressChangedEventHandler(
                    delegate(object o, ProgressChangedEventArgs args)
                    {

                        //label1.Text = string.Format("{0}% Completed", args.ProgressPercentage);
                    });

                    // what to do when worker completes its task (notify the user)
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                    delegate(object o, RunWorkerCompletedEventArgs args)
                    {

                        //label1.Text = "Finished!";
                    });

                    bw.RunWorkerAsync();
                }
            }
            catch(Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed HeatBeat.Start()", e.ToString());
            }

        }
    }
}
