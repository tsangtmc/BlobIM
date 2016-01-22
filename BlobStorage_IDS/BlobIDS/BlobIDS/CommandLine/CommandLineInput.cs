using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace BlobIDS.CommandLine
{
    class CommandLineInput
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [STAThread]
        public static void commandline_input(string[] args)
        {
            //
            // Handle commandline parameters
            //
            try
            {
                bool ShowGUI = true;
                bool IsHelp = false;
                string arguments = "";
                for (int x = 0; x < args.Length; x++)
                {
                    if ((args[x].CompareTo("/help:") == 0) ||
                        (args[x].CompareTo("/help") == 0) ||
                        (args[x].CompareTo("\\help") == 0) ||
                        (args[x].CompareTo("-help") == 0) ||
                        (args[x].CompareTo("/h:") == 0) ||
                        (args[x].CompareTo("-h") == 0))
                    {
                        ShowGUI = false;
                        IsHelp = true;
                        CommandLine.Usage.print();
                    }
                    if ((args[x].CompareTo("/silent:") == 0) ||
                        (args[x].CompareTo("/silent") == 0) ||
                        (args[x].CompareTo("\\silent") == 0) ||
                        (args[x].CompareTo("-silent") == 0))
                    {
                        ShowGUI = false;

                        NewBaseline.Generate();

                        BackgroundWorker FIMThread = new BackgroundWorker();
                        FIMThread.DoWork += new DoWorkEventHandler(delegate(object o, DoWorkEventArgs f)
                        {
                            Detection.BlobStorage_FIM.Start();
                        });
                        FIMThread.RunWorkerAsync();

                        BackgroundWorker healthmonitorThread = new BackgroundWorker();
                        healthmonitorThread.DoWork += new DoWorkEventHandler(delegate(object o, DoWorkEventArgs e)
                        {
                            HealthMonitor.HeartBeat.Start();
                        });
                        healthmonitorThread.RunWorkerAsync();
                    }
                    if ((args[x].CompareTo("/snapshotbaseline:") == 0) ||
                        (args[x].CompareTo("/snapshotbaseline") == 0) ||
                        (args[x].CompareTo("\\snapshotbaseline") == 0) ||
                        (args[x].CompareTo("-snapshotbaseline") == 0))
                    {
                        ShowGUI = false;
                        arguments = arguments + " /snapshotbaseline:";
                    }
                    if ((args[x].CompareTo("/compareshapshots:") == 0)||
                        (args[x].CompareTo("/compareshapshots") == 0)||
                        (args[x].CompareTo("\\compareshapshots") == 0) ||
                        (args[x].CompareTo("-compareshapshots") == 0))
                    {
                        ShowGUI = false;
                        arguments = arguments + " /compareshapshots:";
                    }
                    if ((args[x].CompareTo("/checkpermissions:") == 0)||
                        (args[x].CompareTo("/checkpermissions") == 0)||
                        (args[x].CompareTo("\\checkpermissions") == 0) ||
                        (args[x].CompareTo("-checkpermissions") == 0))
                    {
                        ShowGUI = false;
                        arguments = arguments + " /checkpermissions:";
                    }
                    if ((args[x].CompareTo("/quit:") == 0)||
                        (args[x].CompareTo("/quit") == 0)||
                        (args[x].CompareTo("\\quit") == 0) ||
                        (args[x].CompareTo("-quit") == 0))
                    {
                        ShowGUI = false;
                        Application.Exit();
                    }
                    if ((args[x].CompareTo("/exit:") == 0)||
                        (args[x].CompareTo("/exit") == 0)||
                        (args[x].CompareTo("\\exit") == 0) ||
                        (args[x].CompareTo("-exit") == 0))
                    {
                        ShowGUI = false;
                        Application.Exit();
                    }
                    if (args[x].StartsWith("/"))
                    {
                        if (!(((args[x].Equals("/silent:")) || (args[x].Equals("/silent")) || (args[x].Equals("\\silent")) || (args[x].Equals("-silent"))) ||
                            ((args[x].Equals("/snapshotbaseline:")) || (args[x].Equals("/snapshotbaseline")) || (args[x].Equals("\\snapshotbaseline")) || (args[x].Equals("-snapshotbaseline"))) ||
                            ((args[x].Equals("/compareshapshots:")) || (args[x].Equals("/compareshapshots")) || (args[x].Equals("\\compareshapshots")) || (args[x].Equals("-compareshapshots"))) ||
                            ((args[x].Equals("/checkpermissions:")) || (args[x].Equals("/checkpermissions")) || (args[x].Equals("\\checkpermissions")) || (args[x].Equals("-checkpermissions"))) ||
                            ((args[x].Equals("/help:")) || (args[x].Equals("/help")) || (args[x].Equals("\\help")) || (args[x].Equals("-help"))) ||
                            ((args[x].Equals("/quit:")) || (args[x].Equals("/quit")) || (args[x].Equals("\\quit")) || (args[x].Equals("-quit"))) ||
                            ((args[x].Equals("/exit:")) || (args[x].Equals("/exit")) || (args[x].Equals("\\exit")) || (args[x].Equals("-exit")))
                            ))
                        {
                            string argx = (args[x].ToString());
                            Alerting.ErrorLogging.WriteTo_Log("Failed invoking the worker process", "[UNRECOGNIZED INPUT PARAMETER] " + argx);
                            ShowGUI = false;
                            IsHelp = true;
                            CommandLineMessages.PrintSettingError("-------------------------------------------------------------------", " ");
                            CommandLineMessages.PrintSettingError("Input Error: ", "The Flag \"" + args[x] + "\" was not recognized");
                            CommandLineMessages.PrintSettingError("-------------------------------------------------------------------", " ");
                            CommandLine.Usage.print();
                            CommandLineMessages.PrintSettingError(" ", " ");
                        }
                    }
                }
                if (ShowGUI == true)
                {
                    NewBaseline.Generate();

                    Config.UpdateSettings.CheckIfUnConfigured();

                    BackgroundWorker FIMThread = new BackgroundWorker();
                    FIMThread.DoWork += new DoWorkEventHandler(delegate(object o, DoWorkEventArgs f)
                    {
                        Detection.BlobStorage_FIM.Start();
                    });
                    FIMThread.RunWorkerAsync(); 

                    BackgroundWorker healthmonitorThread = new BackgroundWorker();
                    healthmonitorThread.DoWork += new DoWorkEventHandler(delegate(object o, DoWorkEventArgs e)
                    {
                        HealthMonitor.HeartBeat.Start();
                    });
                    healthmonitorThread.RunWorkerAsync();

                    try
                    {
                        IntPtr h = Process.GetCurrentProcess().MainWindowHandle;
                        ShowWindow(h, 0);
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new GUI.Form1("fr-FR"));
                    }
                    catch
                    {

                    }

                }
                else
                {
                    if(IsHelp == false)
                    {
                        NewBaseline.Generate();
                        ExecuteWorker.Command(arguments);
                    }  
                }
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed invoking the worker process", e.ToString());
            }
        }

    }
}
