using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace BlobIDS.GUI
{
    class TaskBar
    {
        public static void ShowTaskBarMessage_Error(string message)
        {
            try
            {
                Config.Settings.notifyIcon1.ShowBalloonTip(5000, "BlobIM - An Error has Occured", message, ToolTipIcon.Error);
            }
            catch
            {

            }
        }
        public static void ShowTaskBarMessage_Alert(string message)
        {
            try
            {
                Config.Settings.notifyIcon1.ShowBalloonTip(5000, "BlobIM", message, ToolTipIcon.Warning);
            }
            catch
            {

            }
        }

    }
}
