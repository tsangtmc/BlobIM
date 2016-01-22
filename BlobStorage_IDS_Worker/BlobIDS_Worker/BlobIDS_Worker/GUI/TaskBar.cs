using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace BlobIDS_Worker.GUI
{
    class TaskBar
    {
        //private static ContextMenu contextMenu1 = new System.Windows.Forms.ContextMenu();
        //private static NotifyIcon notifyIcon1 = new NotifyIcon();
        public static void ShowIconInTaskBar()
        {
            ContextMenu contextMenu1 = new System.Windows.Forms.ContextMenu();
            MenuItem menuItemQuit = new MenuItem { Index = 0, Text = "Quit" };
            menuItemQuit.Click += MenuItemQuitClick;
            // Add menu items to context menu.
            contextMenu1.MenuItems.AddRange( new[] { menuItemQuit } );

            // Set properties of NotifyIcon component
            Config.Settings.notifyIcon1_Set(new NotifyIcon { Icon = new System.Drawing.Icon("./logo.ico"), Visible = true });
            Config.Settings.notifyIcon1.ShowBalloonTip(5000, "BlobIM", "BlobIM is running!", ToolTipIcon.Info);
            Config.Settings.notifyIcon1.Text = "BlobIM";
            Config.Settings.notifyIcon1.ContextMenu = contextMenu1;
            Config.Settings.notifyIcon1.DoubleClick += ToggleSettingsDialog;
           // notifyIcon1.MouseClick += new System.Windows.Forms.R (notifyIcon1_DoubleClick);
            //MenuItems("").Click += new System.EventHandler(menuItem2_Click); 

        }
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
        private static void MenuItemQuitClick(object sender, System.EventArgs e)
        {
            //MessageBox.Show("Icon Notify Double Clicked");
        }
        private static void ToggleSettingsDialog(object sender, System.EventArgs e)
        {
           // MessageBox.Show("MenuItem2 Clicked");
        }

    }
}
