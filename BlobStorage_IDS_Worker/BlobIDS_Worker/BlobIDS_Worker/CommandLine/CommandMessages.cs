using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobIDS_Worker.CommandLine
{
    class CommandMessages
    {

        public static void PrintSettingError(string label, string errormessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(label);
            System.Threading.Thread.Sleep(1000);
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
            System.Threading.Thread.Sleep(1000);
            Console.ResetColor();
            Console.WriteLine(CustomMessage);
        }
        private static void PrintStatusMessage(string label, string CustomMessage)
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
