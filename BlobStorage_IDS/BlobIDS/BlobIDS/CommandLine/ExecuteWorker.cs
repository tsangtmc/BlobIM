using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobIDS.CommandLine
{
    class ExecuteWorker
    {
        public static void Command(string arguments)
        {
            try
            {
                if(!(File.Exists("BlobIM_Worker.exe")))
                {
                    Config.Resources.WriteResourceToFile("BlobIDS.Resources.BlobIM_Worker.exe", "BlobIM_Worker.exe");
                }
                Process worker = new Process();
                worker.StartInfo.FileName = "BlobIM_Worker.exe";
                worker.StartInfo.Arguments = arguments;
                worker.Start();
                worker.WaitForExit();
            }
            catch(Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed ExecuteWorker.Command", e.ToString());
            }
        }
    }
}
