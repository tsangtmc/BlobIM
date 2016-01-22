using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace BlobIDS.CommandLine
{
    class Usage
    {
        public static void print()
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
            Console.WriteLine("     ||             ||  __    B.IM        ) ");
            Console.WriteLine("     ;;             ;;.'  '===============' ");
            Console.WriteLine("      \\           ///     Written By: [Developer Name Not Allowed]");
            Console.WriteLine("       ':.._____..:'~ ");
            Console.WriteLine("         `'-----'` ");

            Console.WriteLine("[Usage]");
            CommandLine.CommandLineMessages.PrintSettingCustom(" ----------------------------------------------- ", "");
            CommandLine.CommandLineMessages.PrintSettingCustom_SameLine("|","");
            CommandLine.CommandLineMessages.PrintSettingCustom_SameLine(" Example Usage: ", "BlobIM.exe /checkpermissions:");
            CommandLine.CommandLineMessages.PrintSettingCustom(" |", "");
            CommandLine.CommandLineMessages.PrintSettingCustom(" ----------------------------------------------- ", "");
            CommandLine.CommandLineMessages.PrintStatusMessage("\"/help:\"", " Prints Usage of BIM");
            CommandLine.CommandLineMessages.PrintStatusMessage("\"/silent:\"", " Start BIM without the GUI Interface (BIM will auto scan on schedule)");
            CommandLine.CommandLineMessages.PrintStatusMessage("\"/snapshotbaseline:\"", " Create a new \"Snapshot Baseline\"");
            CommandLine.CommandLineMessages.PrintStatusMessage("\"/compareshapshots:\"", " Compare the previous \"Snapshot\" against what's in blob");
            CommandLine.CommandLineMessages.PrintStatusMessage("\"/checkpermissions:\"", " Check the access permissions of blob in blob storage");
            CommandLine.CommandLineMessages.PrintStatusMessage(" ", " ");
            CommandLine.CommandLineMessages.PrintSettingCustom_SameLine("For Detailed Information Please See: ", "Readme_txt.txt Or ReadMe.html");
            Config.Resources.WriteResourceToFile("BlobIDS.Resources.ReadMe_files.zip", "ReadMe_files.zip");
            Config.Resources.WriteResourceToFile("BlobIDS.Resources.Readme_txt.txt", "Readme_txt.txt");
            Config.Resources.WriteResourceToFile("BlobIDS.Resources.ReadMe.html", "ReadMe.html");
            Config.Resources.WriteResourceToFile("BlobIDS.Resources.zip.exe", "zip.exe");
            string path = Directory.GetCurrentDirectory();
            if ((File.Exists("zip.exe"))&&(!(Directory.Exists(path + "\\ReadMe_files"))))
            {
                try
                {
                    
                    Process.Start(path + "\\zip.exe", "/unzip \"" + path + "\\ReadMe_files.zip\" /newfolder \"" + path + "\\ReadMe_files\"");
                }
                catch
                {
                    Process.Start(path + "\\ReadMe.txt");
                }
            }
            CommandLine.CommandLineMessages.PrintStatusMessage(" ", " ");
        }
    }
}
