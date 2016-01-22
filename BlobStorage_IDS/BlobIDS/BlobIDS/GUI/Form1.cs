using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace BlobIDS.GUI
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem IconmenuItem1;
        private System.Windows.Forms.MenuItem IconmenuItem2;
        private System.Windows.Forms.MenuItem IconmenuItem3;
        private int progress = 0;

        public Form1(string language)
        {
            try
            {
                InitializeComponent();

                this.components = new System.ComponentModel.Container();
                this.contextMenu1 = new System.Windows.Forms.ContextMenu();
                this.IconmenuItem1 = new System.Windows.Forms.MenuItem();
                this.IconmenuItem2 = new System.Windows.Forms.MenuItem();
                this.IconmenuItem3 = new System.Windows.Forms.MenuItem();
                // Initialize contextMenu1 
                this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.IconmenuItem1 });
                this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.IconmenuItem2 });
                this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.IconmenuItem3 });

                // Initialize menuItem1 
                this.IconmenuItem1.Index = 0;
                this.IconmenuItem1.Text = "Hide Interface";
                this.IconmenuItem1.Click += new System.EventHandler(this.IconmenuItem1_Click);


                this.IconmenuItem2.Index = 1;
                this.IconmenuItem2.Text = "Show Interface";
                this.IconmenuItem2.Click += new System.EventHandler(this.IconmenuItem2_Click);

                this.IconmenuItem3.Index = 2;
                this.IconmenuItem3.Text = "E&xit BlobIM";
                this.IconmenuItem3.Click += new System.EventHandler(this.IconmenuItem3_Click);

                // Create the NotifyIcon. 
                Config.Settings.notifyIcon1_Set(new NotifyIcon(this.components));
                Config.Settings.notifyIcon1.Icon = new Icon("./logo.ico");
                Config.Settings.notifyIcon1.ContextMenu = this.contextMenu1;
                Config.Settings.notifyIcon1.Text = "BlobIM";
                Config.Settings.notifyIcon1.Visible = true;
                Config.Settings.notifyIcon1.ShowBalloonTip(5000, "BlobIM", "BlobIM is running!", ToolTipIcon.Info);

                // Handle the DoubleClick event to activate the form.
                Config.Settings.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void notifyIcon1_DoubleClick(object Sender, EventArgs e)
        {
            // Show the form when the user double clicks on the notify icon. 

            // Set the WindowState to normal if the form is minimized. 
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form. 
            this.Activate();
            this.Show();
        }

        private void IconmenuItem1_Click(object Sender, EventArgs e)
        {
            // hide interface
            this.Hide();
        }
        private void IconmenuItem2_Click(object Sender, EventArgs e)
        {
            // show interface
            this.Show();
        }
        private void IconmenuItem3_Click(object Sender, EventArgs e)
        {
            //turn off B.IDS
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //new baseline snapshot
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_Do_snapshotbaseline);
            worker.RunWorkerAsync();
        }

        void worker_Do_snapshotbaseline(object sender, DoWorkEventArgs e)
        {
            SetTextBox("Please Wait");
            SetTextBox("Creating Baseline Snapshot.");
            if (!(File.Exists(Config.Settings.SnapShotFileName_Baseline)))
            {
                try
                {
                    Config.Settings._ReadWriteLock_Snapshot.EnterWriteLock();
                    CommandLine.ExecuteWorker.Command(" /snapshotbaseline:");
                    System.Threading.Thread.Sleep(1500);
                    if (!(File.Exists(Config.Settings.SnapShotFileName_Baseline)))
                    {
                        Alerting.ErrorLogging.WriteTo_Log("Failed Creating New Baseline", "Verify Settings in Config are Correct. New baseline snapshot file was not created - A1");
                        SetTextBox("ERROR Occured!\r\nVerify Settings in Config are Correct.\r\nPlease Check " + Config.Settings.ErrorLog_Path + " \r\n_____________________________");
                    }
                    else
                    {
                        SetTextBox("Finshed \r\n_____________________________");
                    }
                }
                finally
                {
                    Config.Settings._ReadWriteLock_Snapshot.ExitWriteLock();
                }
                
            }
            else
            {
                try
                {
                    Config.Settings._ReadWriteLock_Snapshot.EnterWriteLock();
                    FileInfo f = new FileInfo(Config.Settings.SnapShotFileName_Baseline);
                    var datelastmodifiedbefore = f.LastWriteTime;
                    CommandLine.ExecuteWorker.Command(" /snapshotbaseline:");
                    System.Threading.Thread.Sleep(1500);
                    f.Refresh();
                    var datelastmodifiedafter = f.LastWriteTime;

                    if (!(datelastmodifiedafter > datelastmodifiedbefore))
                    {
                        Alerting.ErrorLogging.WriteTo_Log("Failed Creating New Baseline", "Verify Settings in Config are Correct. New baseline snapshot file was not created - A2");
                        SetTextBox("ERROR Occured!\r\nVerify Settings in Config are Correct.\r\nPlease Check " + Config.Settings.ErrorLog_Path + " \r\n_____________________________");
                    }
                    else
                    {
                        SetTextBox("Finshed \r\n_____________________________");
                    }
                }
                finally
                {
                    Config.Settings._ReadWriteLock_Snapshot.ExitWriteLock();
                }
            }          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_Do_compareshapshots);
            worker.RunWorkerAsync();
        }
        void worker_Do_compareshapshots(object sender, DoWorkEventArgs e)
        {
            SetTextBox("Please Wait");
            SetTextBox("Comparing Snapshots");
            SetTextBox("Note: If this is the first time using BIM it may take longer for the inital run.");
            if (!(File.Exists(Config.Settings.SnapShotFileName_Baseline)))
            {
                try
                {
                    Config.Settings._ReadWriteLock_Snapshot.EnterWriteLock();
                    CommandLine.ExecuteWorker.Command(" /snapshotbaseline:");
                }
                finally
                {
                    Config.Settings._ReadWriteLock_Snapshot.ExitWriteLock();
                }
            }
            if ((!(File.Exists(Config.Settings.SnapShotFileName_Previous))) && (File.Exists(Config.Settings.SnapShotFileName_Baseline)))
            {
                File.Copy(Config.Settings.SnapShotFileName_Baseline, Config.Settings.SnapShotFileName_Previous);
            }
            if (!(File.Exists(Config.Settings.SnapShotFileName_Current)))
            {
                if (!(File.Exists(Config.Settings.SnapShotFileName_Previous)))
                {
                    using (File.Create(Config.Settings.SnapShotFileName_Previous)) { };
                }
                FileInfo f = new FileInfo(Config.Settings.SnapShotFileName_Previous);
                var datelastmodifiedbefore = f.LastWriteTime;

                try
                {
                    Config.Settings._ReadWriteLock_Snapshot.EnterWriteLock();
                    CommandLine.ExecuteWorker.Command(" /compareshapshots:");
                }
                finally
                {
                    Config.Settings._ReadWriteLock_Snapshot.ExitWriteLock();
                }
                System.Threading.Thread.Sleep(1000);
                if (!(File.Exists(Config.Settings.SnapShotFileName_Current)))
                {
                    f.Refresh();
                    var datelastmodifiedafter = f.LastWriteTime;
                    if (!(datelastmodifiedafter > datelastmodifiedbefore))
                    {
                        Alerting.ErrorLogging.WriteTo_Log("Failed Doing FIM Check", "Verify Settings in Config are Correct. Could Not Compare Snapshots - Current snapshot could not be moved to previous - B1");
                        SetTextBox("ERROR Occured!\r\nVerify Settings in Config are Correct.\r\nPlease Check " + Config.Settings.ErrorLog_Path + " \r\n_____________________________");
                    }
                    else
                    {
                        SetTextBox("Finshed \r\n_____________________________");
                    }
                }
                else
                {
                    SetTextBox("Finshed \r\n_____________________________");
                }
            }
            else
            {
                FileInfo f = new FileInfo(Config.Settings.SnapShotFileName_Current);
                var datelastmodifiedbefore = f.LastWriteTime;

                if (!(File.Exists(Config.Settings.SnapShotFileName_Previous)))
                {
                    using (File.Create(Config.Settings.SnapShotFileName_Previous)) { };
                }

                FileInfo g = new FileInfo(Config.Settings.SnapShotFileName_Previous);
                var datelastmodifiedbefore2 = g.LastWriteTime;
                try
                {
                    Config.Settings._ReadWriteLock_Snapshot.EnterWriteLock();
                    CommandLine.ExecuteWorker.Command(" /compareshapshots:");
                }
                finally
                {
                    Config.Settings._ReadWriteLock_Snapshot.ExitWriteLock();
                }
                System.Threading.Thread.Sleep(1000);
                var datelastmodifiedafter = f.LastWriteTime;

                if (!(File.Exists(Config.Settings.SnapShotFileName_Current)))
                {
                    g.Refresh();
                    var datelastmodifiedafter2 = g.LastWriteTime;
                    if (!(datelastmodifiedafter2 > datelastmodifiedbefore2))
                    {
                        Alerting.ErrorLogging.WriteTo_Log("Failed Doing FIM Check", "Verify Settings in Config are Correct. Could Not Compare Snapshots - Current snapshot could not be moved to previous - B2");
                        SetTextBox("ERROR Occured!\r\nVerify Settings in Config are Correct.\r\nPlease Check " + Config.Settings.ErrorLog_Path + " \r\n_____________________________");
                    }
                    else
                    {
                        SetTextBox("Finshed \r\n_____________________________");
                    }
                }
                else
                {
                    if (!(datelastmodifiedafter > datelastmodifiedbefore))
                    {
                        Alerting.ErrorLogging.WriteTo_Log("Failed Doing FIM Check", "Verify Settings in Config are Correct. Could Not Compare Snapshots - Could not get a new current snapshot - B3");
                        SetTextBox("ERROR Occured!\r\nVerify Settings in Config are Correct.\r\nPlease Check " + Config.Settings.ErrorLog_Path + " \r\n_____________________________");
                    }
                    else
                    {
                        SetTextBox("Finshed \r\n_____________________________");
                    }
                }
            }           
        }


        private void button3_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_Do_checkpermissions);
            worker.RunWorkerAsync();

            //the command will generate a snapshot, need to do somethethign with it afterwards still.
            //Do STUFF HERE
        }
        void worker_Do_checkpermissions(object sender, DoWorkEventArgs e)
        {
            SetTextBox("Please Wait");
            SetTextBox("Checking for Blobs with Anonymous Access..");

            if (!(File.Exists("BlobPermissionsReport.csv")))
            {
                CommandLine.ExecuteWorker.Command(" /checkpermissions:");
                int found = Alerting.GeneratePermissionsReport.ToCSV(Config.Settings.SnapShotFileName_FileAccess);

                System.Threading.Thread.Sleep(1000);
                if (!(File.Exists("BlobPermissionsReport.csv")))
                {
                    Alerting.ErrorLogging.WriteTo_Log("Failed Checking Permissions", "Verify Settings in Config are Correct. Permissions report was not generated - C1");
                    SetTextBox("ERROR Occured!\r\nVerify Settings in Config are Correct.\r\nPlease Check " + Config.Settings.ErrorLog_Path + " \r\n_____________________________");
                }
                else
                {
                    SetTextBox("Blobs with Anonymous Access = " + found);
                    SetTextBox("Results saved to \r\n\"" + Directory.GetCurrentDirectory() + "\\BlobPermissionsReport.csv\"");
                    SetTextBox("Finshed \r\n_____________________________");
                    Process.Start(Directory.GetCurrentDirectory() + "\\BlobPermissionsReport.csv");
                }
            }
            else
            {
                FileInfo f = new FileInfo("BlobPermissionsReport.csv");
                var datelastmodifiedbefore = f.LastWriteTime;

                CommandLine.ExecuteWorker.Command(" /checkpermissions:");
                int found = Alerting.GeneratePermissionsReport.ToCSV(Config.Settings.SnapShotFileName_FileAccess);

                System.Threading.Thread.Sleep(1000);
                f.Refresh();
                var datelastmodifiedafter = f.LastWriteTime;

                if (!(File.Exists("BlobPermissionsReport.csv")))
                {
                    Alerting.ErrorLogging.WriteTo_Log("Failed Checking Permissions", "Verify Settings in Config are Correct. Permissions report was not generated - C2");
                    SetTextBox("ERROR Occured!\r\nVerify Settings in Config are Correct.\r\nPlease Check " + Config.Settings.ErrorLog_Path + " \r\n_____________________________");
                }
                else
                {
                    if (!(datelastmodifiedafter > datelastmodifiedbefore))
                    {
                        Alerting.ErrorLogging.WriteTo_Log("Failed Checking Permissions", "Verify Settings in Config are Correct.Permissions report was not generated - C3");
                        SetTextBox("ERROR Occured!\r\nVerify Settings in Config are Correct.\r\nPlease Check " + Config.Settings.ErrorLog_Path + " \r\n_____________________________");
                    }
                    else
                    {
                        SetTextBox("Blobs with Anonymous Access = " + found);
                        SetTextBox("Results saved to \r\n\"" + Directory.GetCurrentDirectory() + "\\BlobPermissionsReport.csv\"");
                        SetTextBox("Finshed \r\n_____________________________");
                        Process.Start(Directory.GetCurrentDirectory() + "\\BlobPermissionsReport.csv");
                    }
                }
            } 
        }


        private void button4_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_Do_config);
            worker.RunWorkerAsync();

        }
        void worker_Do_config(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (File.Exists("./BIM_Settings.exe"))
                {
                    Process.Start(Directory.GetCurrentDirectory()+"/BIM_Settings.exe");
                }
                else
                {
                    Config.Resources.WriteResourceToFile("BlobIDS.Resources.BIM_Settings.exe", "BIM_Settings.exe");
                    Process.Start("./BIM_Settings.exe");
                }
            }
            catch (Exception x)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed Opening Settings", "\r\n" + x.ToString());
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            //hide gui
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //turn off B.IDS
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Readme
            int xPosition = this.Location.X;
            int yPosition = this.Location.Y;
            Form3 form_readme = new Form3();
            form_readme.StartPosition = FormStartPosition.Manual;
            form_readme.Location = new Point(xPosition, yPosition);
            form_readme.Show();

        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        private void SetTextBox(string text)
        {
            if (!IsHandleCreated)
            {
                textBox1.CreateControl();
            }
            Action action2 = () => textBox1.AppendText(text + "\r\n\r\n");
            textBox1.Invoke(action2);

        }
        private void ResetTextBox(string text)
        {
            if (!IsHandleCreated)
            {
                textBox1.CreateControl();
            }
            Action action = () => textBox1.Text = "";
            textBox1.Invoke(action);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(Config.Settings.EnableFIM == true)
            {
                Config.Settings.EnableFIM_Set(false);
                SetTextBox("File Integrity Monitoring has been Paused");
                SetTextBox("Finsihed \r\n_____________________________");
                button8.Text = "Unpause BIM";
                pictureBox1.Image = global::BlobIDS.Properties.Resources.Wrong;
                label9.Text = "BIM is Paused";
            }
            else
            {
                Config.Settings.EnableFIM_Set(true);
                SetTextBox("File Integrity Monitoring has been Unpaused");
                SetTextBox("Finsihed \r\n_____________________________");
                button8.Text = "Pause BIM";
                pictureBox1.Image = global::BlobIDS.Properties.Resources.Check;
                label9.Text = "BIM is Running";
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_Do_baselineconfig);
            worker.RunWorkerAsync();
        }
        void worker_Do_baselineconfig(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (File.Exists(Config.Settings.SnapShotFileName_Baseline))
                {
                    Process.Start("notepad.exe", Config.Settings.SnapShotFileName_Baseline);
                }
                else
                {
                    var worker = new BackgroundWorker();
                    worker.DoWork += new DoWorkEventHandler(worker_Do_snapshotbaseline);
                    worker.RunWorkerAsync();
                    Process.Start("notepad.exe", Config.Settings.SnapShotFileName_Baseline);
                }
            }
            catch
            {

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Config.Settings.HealthMonitoring_Enabled == true)
            {
                Config.Settings.HealthMonitoring_Enabled_Set(false);
                SetTextBox("Heartbeat Alerts have been Paused");
                SetTextBox("Finsihed \r\n_____________________________");
                button9.Text = "Unpause HeartBeat";
                pictureBox12.Image = global::BlobIDS.Properties.Resources.heart_off;
                label13.Text = "Heartbeat is Paused";
            }
            else
            {
                Config.Settings.HealthMonitoring_Enabled_Set(true);
                SetTextBox("HeartBeat Alerts have been Unpaused");
                SetTextBox("Finsihed \r\n_____________________________");
                button9.Text = "Pause HeartBeat";
                pictureBox12.Image = global::BlobIDS.Properties.Resources.heart_on;
                label13.Text = "Heartbeat is Running";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int xPosition = this.Location.X;
            int yPosition = this.Location.Y;
            Form2 form = new Form2();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(xPosition, yPosition);
            form.Show();
        }

        private void Label_Copyright_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(""+
                                "-------------------------- START OF LICENSE --------------------------\r\n" +
                                "\r\n" +
                                "Blob Integrity Monitor\r\n" +
                                "\r\n" +
                                "Copyright (c) Microsoft Corporation\r\n" +
                                "\r\n" +
                                "All rights reserved. \r\n" +
                                "\r\n" +
                                "MIT License\r\n" +
                                "\r\n" +
                                "Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the \"Software\"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:\r\n" +
                                "\r\n" +
                                "The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.\r\n" +
                                "\r\n" +
                                "THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.\r\n" +
                                "\r\n" +
                                "-------------------------- END OF LICENSE --------------------------\r\n" +
                                "");
        }

    }

}
