using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace BlobIDS.CommandLine
{
    class NewBaseline
    {
        public static void Generate()
        {
            if (!(File.Exists(Config.Settings.SnapShotFileName_Baseline)))
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;
                Console.WriteLine("     Version " + version);
                CommandLine.CommandLineMessages.PrintTitle("                          [B]lob ");
                Console.Write("         _.-----._        "); CommandLine.CommandLineMessages.PrintTitle("[I]ntegrity ");
                Console.Write("       .'.-'''''-.'._     "); CommandLine.CommandLineMessages.PrintTitle("[M]onitor ");
                Console.Write("      //`         `\\\\\\    "); CommandLine.CommandLineMessages.PrintTitle("");
                Console.WriteLine("     ;; '           ;;'.__.===============, ");
                Console.WriteLine("     ||             ||  __    B I M        ) ");
                Console.WriteLine("     ;;             ;;.'  '===============' ");
                Console.WriteLine("      \\           ///     Written By: [Developer name now allowed]");
                Console.WriteLine("       ':.._____..:'~ ");
                Console.WriteLine("         `'-----'` ");
                Console.WriteLine("");
                Console.WriteLine("*****Starting Up - Please Wait*****");
                Console.WriteLine("--Baseline Snapshot not found - Creating a new Baseline");
                Console.WriteLine("   This may take some time, please wait...");

                try
                {
                    Config.Settings._ReadWriteLock_Snapshot.EnterWriteLock();
                    CommandLine.ExecuteWorker.Command("/snapshotbaseline:");
                }
                finally
                {
                    Config.Settings._ReadWriteLock_Snapshot.ExitWriteLock();
                }
            }
        }
    }
}
