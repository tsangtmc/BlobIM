using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace BlobIDS
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Config.Settings.Init();
            Config.Resources.ExtractAllResources();

            Config.UpdateSettings.CheckForSettings();
            Config.UpdateSettings.UpdateFromConfig();

            

            if (args.Length < 1)
            {
                Config.UpdateSettings.SetWindowsEventLog_UAC();
            }
            if ((Config.Settings.EventLog_WriteTo_WindowsApplicationLog == true) && (args.Length < 1))
            {
                HealthMonitor.HeartBeat.WriteTo_WindowsApplicaitonEventLog("BlobIM Started", "BlobIM has been restarted or started for the first time");
            }
            CommandLine.CommandLineInput.commandline_input(args);

            
        }
    }
}
