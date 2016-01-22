using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace BlobIDS.GUI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void HTML_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_Do_readme_html);
            worker.RunWorkerAsync();
        }

        private void PDF_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_Do_readme_pdf);
            worker.RunWorkerAsync();
        }

        private void Doc_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_Do_readme_docx);
            worker.RunWorkerAsync();
        }

        private void RawText_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_Do_readme_txt);
            worker.RunWorkerAsync();
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

        void worker_Do_readme_html(object sender, DoWorkEventArgs e)
        {
            if (File.Exists("ReadMe_files.zip"))
            {
                try
                {
                    File.Delete("ReadMe_files.zip");
                }
                catch
                {
                    Alerting.ErrorLogging.WriteTo_Log("Could Not Open ReadMe", "ReadMe_files.zip - Please close any readme files or resources currently open and ensure BIM has permissions to read and delete from the working directory");
                }
            }
            if (File.Exists("Readme_txt.txt"))
            {
                try
                {
                    File.Delete("Readme_txt.txt");
                }
                catch
                {
                    Alerting.ErrorLogging.WriteTo_Log("Could Not Open ReadMe", "Readme_txt.txt - Please close any readme files or resources currently open and ensure BIM has permissions to read and delete from the working directory");
                }
            }
            if (File.Exists("ReadMe.html"))
            {
                try
                {
                    File.Delete("ReadMe.html");
                }
                catch
                {
                    Alerting.ErrorLogging.WriteTo_Log("Could Not Open ReadMe", "ReadMe.html - Please close any readme files or resources currently open and ensure BIM has permissions to read and delete from the working directory");
                }
            }
            if (File.Exists("zip.exe"))
            {
                try
                {
                    File.Delete("zip.exe");
                }
                catch
                {
                    Alerting.ErrorLogging.WriteTo_Log("Could Not Open ReadMe", "zip.exe - Please close any readme files or resources currently open and ensure BIM has permissions to read and delete from the working directory");
                }
            }
            if (Directory.Exists("ReadMe_files"))
            {
                try
                {
                    DeleteDirectory("ReadMe_files");
                }
                catch
                {
                    Alerting.ErrorLogging.WriteTo_Log("Could Not Open ReadMe", "ReadMe_files Directory - Please close any readme files or resources currently open and ensure BIM has permissions to read and delete from the working directory");
                }
            }
            Config.Resources.WriteResourceToFile("BlobIDS.Resources.ReadMe_files.zip", "ReadMe_files.zip");
            Config.Resources.WriteResourceToFile("BlobIDS.Resources.Readme_txt.txt", "Readme_txt.txt");
            Config.Resources.WriteResourceToFile("BlobIDS.Resources.ReadMe.html", "ReadMe.html");
            Config.Resources.WriteResourceToFile("BlobIDS.Resources.zip.exe", "zip.exe");
            if (File.Exists("zip.exe"))
            {
                try
                {
                    string path = Directory.GetCurrentDirectory();
                    Process.Start(path + "\\zip.exe", "/unzip \"" + path + "\\ReadMe_files.zip\" /newfolder \"" + path + "\\ReadMe_files\"");
                    Process.Start(path + "\\ReadMe.html");
                }
                catch
                {
                    MessageBox.Show("Could not open PDF ReadMe");
                    string path = Directory.GetCurrentDirectory();
                    Process.Start(path + "\\Readme_txt.txt");
                }

            }
        }

        void worker_Do_readme_pdf(object sender, DoWorkEventArgs e)
        {
            if (File.Exists("Readme_txt.txt"))
            {
                try
                {
                    File.Delete("Readme_txt.txt");
                }
                catch
                {
                    Alerting.ErrorLogging.WriteTo_Log("Could Not Open ReadMe", "Readme_txt.txt - Please close any readme files or resources currently open and ensure BIM has permissions to read and delete from the working directory");
                }
            }
            if (File.Exists("ReadMe.pdf"))
            {
                try
                {
                    File.Delete("ReadMe.pdf");
                }
                catch
                {
                    Alerting.ErrorLogging.WriteTo_Log("Could Not Open ReadMe", "ReadMe.pdf - Please close any readme files or resources currently open and ensure BIM has permissions to read and delete from the working directory");
                }
            }
            Config.Resources.WriteResourceToFile("BlobIDS.Resources.ReadMe_pdf.pdf", "ReadMe.pdf");
            if (File.Exists("ReadMe.pdf"))
            {
                try
                {
                    string path = Directory.GetCurrentDirectory();
                    Process.Start(path + "\\ReadMe.pdf");
                }
                catch
                {
                    MessageBox.Show("Could not open PDF ReadMe");
                    string path = Directory.GetCurrentDirectory();
                    Process.Start(path + "\\Readme_txt.txt");
                }

            }
        }

        void worker_Do_readme_docx(object sender, DoWorkEventArgs e)
        {
            if (File.Exists("Readme_txt.txt"))
            {
                try
                {
                    File.Delete("Readme_txt.txt");
                }
                catch
                {
                    Alerting.ErrorLogging.WriteTo_Log("Could Not Open ReadMe", "Readme_txt.txt - Please close any readme files or resources currently open and ensure BIM has permissions to read and delete from the working directory");
                }
            }
            if (File.Exists("ReadMe.docx"))
            {
                try
                {
                    File.Delete("ReadMe.docx");
                }
                catch
                {
                    Alerting.ErrorLogging.WriteTo_Log("Could Not Open ReadMe", "ReadMe.docx - Please close any readme files or resources currently open and ensure BIM has permissions to read and delete from the working directory");
                }
            }

            Config.Resources.WriteResourceToFile("BlobIDS.Resources.ReadMe_docx.docx", "ReadMe.docx");
            if (File.Exists("ReadMe.docx"))
            {
                try
                {
                    string path = Directory.GetCurrentDirectory();
                    Process.Start(path + "\\ReadMe.docx");
                }
                catch
                {
                    MessageBox.Show("Could not open Word Document ReadMe");
                    string path = Directory.GetCurrentDirectory();
                    Process.Start(path + "\\Readme_txt.txt");
                }

            }
        }

        void worker_Do_readme_txt(object sender, DoWorkEventArgs e)
        {
            if (File.Exists("Readme_txt.txt"))
            {
                try
                {
                    File.Delete("Readme_txt.txt");
                }
                catch
                {
                    Alerting.ErrorLogging.WriteTo_Log("Could Not Open ReadMe", "Readme_txt.txt - Please close any readme files or resources currently open and ensure BIM has permissions to read and delete from the working directory");
                }
            }
            Config.Resources.WriteResourceToFile("BlobIDS.Resources.Readme_txt.txt", "Readme_txt.txt");
            if (File.Exists("Readme_txt.txt"))
            {
                try
                {
                    string path = Directory.GetCurrentDirectory();
                    Process.Start(path + "\\Readme_txt.txt"); ;
                }
                catch
                {
                    MessageBox.Show("Could not open Text ReadMe");
                }

            }
        }

    }
}
