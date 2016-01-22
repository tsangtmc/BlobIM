using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobIDS_Worker.CommandLine
{
    class CommandLineInput
    {
        public static void commandline_input(string[] args)
        {
            //
            // Handle commandline parameters
            //
            try
            {
                for (int x = 0; x < args.Length; x++)
                {
                    if (args[x].CompareTo("/sendemailalert:") == 0)
                    {
                        //string body
                        if (x + 1 < args.Length)
                        {
                            string emailbody = args[x + 1];
                            Alerting.Email.SendAlert_Generic_Alert(emailbody);
                            
                        }
                    }
                    if (args[x].CompareTo("/sendemailerror:") == 0)
                    {
                        //string body
                        if (x + 1 < args.Length)
                        {
                            string emailbody = args[x + 1];
                            Alerting.Email.SendAlert_Generic_Error(emailbody);
                        }
                    }
                    if (args[x].CompareTo("/sendemailheartbeat:") == 0)
                    {
                        //string body
                        if (x + 1 < args.Length)
                        {
                            string emailbody = args[x + 1];
                            Alerting.Email.SendAlert_Generic_HeartBeat(emailbody);
                        }
                    }
                    if (args[x].CompareTo("/snapshotbaseline:") == 0)
                    {
                        Snapshot.Generate.ConfigFile_Snapshot(Config.Settings.BlobStorage_Account_Environment, Config.Settings.BlobStorage_Account_Name, Config.Settings.BlobStorage_Account_Key, Config.Settings.SnapShotFileName_Baseline, true, false);
                    }
                    if (args[x].CompareTo("/compareshapshots:") == 0)
                    {
                        Snapshot.Compare.ConfigFile_Snapshot();
                    }
                    if (args[x].CompareTo("/checkpermissions:") == 0)
                    {
                        BlobStorage.CheckFileAccess.FileAccess_Snapshot();
                    }
                    if (args[x].StartsWith("/"))
                    {
                        if (!((args[x].Equals("/sendemailalert:")) || (args[x].Equals("/sendemailerror:")) || (args[x].Equals("/snapshotbaseline:")) ||
                            (args[x].Equals("/compareshapshots:")) || (args[x].Equals("/checkpermissions:")) | (args[x].Equals("/sendemailheartbeat:"))))
                        {
                            string argx = (args[x].ToString());
                            Alerting.ErrorLogging.WriteTo_Log("Failed invoking the worker process", "[UNRECOGNIZED INPUT PARAMETER] " + argx);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed invoking the worker process", e.ToString());
            }
        }
    }
}
