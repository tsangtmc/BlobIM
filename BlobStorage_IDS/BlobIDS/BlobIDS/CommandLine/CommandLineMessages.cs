using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobIDS.CommandLine
{
    class CommandLineMessages
    {

        public static void PrintTitle(string titletext)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(titletext);
            Console.ResetColor();
        }
        public static void PrintSettingError(string label, string errormessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(label);
            System.Threading.Thread.Sleep(500);
            Console.ResetColor();
            Console.WriteLine(errormessage);
        }
        public static void PrintSettingDefault(string label, string Defaultmessage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(label);
            System.Threading.Thread.Sleep(1000);
            Console.ResetColor();
            Console.WriteLine(Defaultmessage);
        }
        public static void PrintSettingCustom(string label, string CustomMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(label);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(CustomMessage);
            Console.ResetColor();
        }
        public static void PrintSettingCustom_SameLine(string label, string CustomMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(label);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(CustomMessage);
            Console.ResetColor();
        }
        public static void PrintStatusMessage(string label, string CustomMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(label);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(CustomMessage);
            Console.ResetColor();
        }

    }
}
