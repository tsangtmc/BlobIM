using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace BlobIDS.Detection
{
    class BlobStorage_FIM
    {
        public static void Start()
        {
            try
            {
                if ((Config.Settings.DetectionPeriod_EveryNumberof_Hours > 0) || (Config.Settings.DetectionPeriod_EveryNumberof_Minutes > 0))
                {
                    while (true)
                    {
                        Config.UpdateSettings.UpdateFromConfig();
                            int interval = (Config.Settings.DetectionPeriod_EveryNumberof_Hours * 60) + Config.Settings.DetectionPeriod_EveryNumberof_Minutes;
                            for (int i = 1; i <= interval; i++)
                            {
                                Thread.Sleep(60000);
                            }
                            try
                            {
                                if (Config.Settings.EnableFIM == true)
                                {
                                    DateTime now = DateTime.Now;
                                    if (!(File.Exists(Config.Settings.SnapShotFileName_Baseline)))
                                    {
                                        try
                                        {
                                            Config.Settings._ReadWriteLock_Snapshot.EnterWriteLock();
                                            Alerting.ErrorLogging.WriteTo_Log("New Baseline Snapshot Made", "A Baseline snapshot was not present so one was made on " + now);
                                            CommandLine.ExecuteWorker.Command("/snapshotbaseline:");
                                        }
                                        finally
                                        {
                                            Config.Settings._ReadWriteLock_Snapshot.ExitWriteLock();
                                        }
                                    }
                                    // DO WORK
                                    try
                                    {
                                        Config.Settings._ReadWriteLock_Snapshot.EnterWriteLock();
                                        CommandLine.ExecuteWorker.Command("/compareshapshots:");
                                    }
                                    finally
                                    {
                                        Config.Settings._ReadWriteLock_Snapshot.ExitWriteLock();
                                    }
                                }
                            }
                            catch(Exception e)
                            {
                                Alerting.ErrorLogging.WriteTo_Log("Failed To Run Comparison", e.ToString());
                            }
                    }
                }
                else
                {
                    Alerting.ErrorLogging.WriteTo_Log("Config file needs to be set ", "DetectionPeriod_EveryNumberof_Hours and DetectionPeriod_EveryNumberof_Minutes need to be greater than zero");
                }
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed HeatBeat.Start()", e.ToString());
            }
        }
    }
}
