using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace BlobIDS_Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.Settings.Init();
            Config.Resources.ExtractAllResources();

            Config.UpdateSettings.CheckForSettings();
            Config.UpdateSettings.UpdateFromConfig();
            Config.UpdateSettings.UpdateFromWorkerConfig();
            
            CommandLine.CommandLineInput.commandline_input(args);

        }
    }
}
