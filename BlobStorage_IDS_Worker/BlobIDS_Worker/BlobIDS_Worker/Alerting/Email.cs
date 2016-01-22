using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;
//using System.Net.Mime;

namespace BlobIDS_Worker.Alerting
{
    class Email
    {
        public static void SendAlert_Generic_Error(string body)
        {
            try
            {
                string subject = Config.Settings.Email_Subject_Errors;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Config.Settings.Email_SMTPServer_Generic);

                mail.From = new MailAddress(Config.Settings.Email_Sender);
                if ((CountStringOccurrences(Config.Settings.Email_Recipient,";"))>0)
                {
                    string s = Config.Settings.Email_Recipient;
                    s = s.Replace(" ", "");
	                string[] words = s.Split(';');
                    foreach (string word in words)
                    {
                        mail.To.Add(word);
                    }
                }
                else
                {
                    mail.To.Add(Config.Settings.Email_Recipient);
                }
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = Config.Settings.Email_SMTPServer_Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Config.Settings.Email_Account, Config.Settings.Email_Password);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                mail.Dispose();
            }
            catch (Exception ex)
            {
                Alerting.ErrorLogging.WriteTo_ErrorLog("Error Failed  SendAlert_Generic_Error", ex.ToString());
                Application.Exit();
                Environment.Exit(0);
            }
        }
        public static void SendAlert_Generic_Alert(string body)
        {
            try
            {
               
                string subject = Config.Settings.Email_Subject_Alerts;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Config.Settings.Email_SMTPServer_Generic);
                mail.From = new MailAddress(Config.Settings.Email_Sender);
                if ((CountStringOccurrences(Config.Settings.Email_Recipient, ";")) > 0)
                {
                    string s = Config.Settings.Email_Recipient;
                    s = s.Replace(" ", "");
                    string[] words = s.Split(';');
                    foreach (string word in words)
                    {
                        mail.To.Add(word);
                    }
                }
                else
                {
                    mail.To.Add(Config.Settings.Email_Recipient);
                }
                mail.Subject = subject;
                
                if (Config.Settings.SendReportAs_HTML == true)
                {
                        mail.IsBodyHtml = true;
                }
                /*
                if (Config.Settings.SendReportAs_CSV == true)
                {
                    if (File.Exists(Config.Settings.Report_FileName_csv))
                    {
                        mail.Attachments.Add(new Attachment(Config.Settings.Report_FileName_csv));
                        Config.Settings.Email_Attachment_Filename_Set(Config.Settings.Report_FileName_csv);
                        // Set the method that is called back when the send operation ends.
                        SmtpServer.SendCompleted += new SendCompletedEventHandler(DeleteOldFile);
                    }
                }
                 * */

                mail.Body = body;
                SmtpServer.Port = Config.Settings.Email_SMTPServer_Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Config.Settings.Email_Account, Config.Settings.Email_Password);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                mail.Dispose();
            }
            catch (Exception ex)
            {
                Alerting.ErrorLogging.WriteTo_Log("Error Failed  SendAlert_Generic", ex.ToString());
                Application.Exit();
                Environment.Exit(0);
            }
        }

        public static void SendAlert_Generic_HeartBeat(string body)
        {
            try
            {

                string subject = Config.Settings.Email_Subject_HeartBeat;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Config.Settings.Email_SMTPServer_Generic);
                mail.From = new MailAddress(Config.Settings.Email_Sender);
                if ((CountStringOccurrences(Config.Settings.Email_Recipient, ";")) > 0)
                {
                    string s = Config.Settings.Email_Recipient;
                    s = s.Replace(" ", "");
                    string[] words = s.Split(';');
                    foreach (string word in words)
                    {
                        mail.To.Add(word);
                    }
                }
                else
                {
                    mail.To.Add(Config.Settings.Email_Recipient);
                }
                mail.Subject = subject;

                if (Config.Settings.SendReportAs_HTML == true)
                {
                    mail.IsBodyHtml = true;
                }

                mail.Body = body;
                SmtpServer.Port = Config.Settings.Email_SMTPServer_Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Config.Settings.Email_Account, Config.Settings.Email_Password);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                mail.Dispose();
            }
            catch (Exception ex)
            {
                Alerting.ErrorLogging.WriteTo_Log("Error Failed SendAlert_Generic", ex.ToString());
                Application.Exit();
                Environment.Exit(0);
            }
        }
        private static int CountStringOccurrences(string text, string pattern)
        {
            try
            {
                // Loop through all instances of the string 'text'.
                int count = 0;
                int i = 0;
                while ((i = text.IndexOf(pattern, i)) != -1)
                {
                    i += pattern.Length;
                    count++;
                }
                return count;
            }
            catch (Exception ex)
            {
                Alerting.ErrorLogging.WriteTo_Log("CountStringOccurrences", ex.ToString());
                return -1;
            }
        }
        public static void SendEmail_Generic(string subject, string body, bool AddAttachment, string AttachmentFilePath)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Config.Settings.Email_SMTPServer_Generic);
                mail.From = new MailAddress(Config.Settings.Email_Sender);
                if ((CountStringOccurrences(Config.Settings.Email_Recipient, ";")) > 0)
                {
                    string s = Config.Settings.Email_Recipient;
                    s = s.Replace(" ", "");
                    string[] words = s.Split(';');
                    foreach (string word in words)
                    {
                        mail.To.Add(word);
                    }
                }
                else
                {
                    mail.To.Add(Config.Settings.Email_Recipient);
                }
                mail.Subject = subject;
                mail.Body = body;
                if (AddAttachment == true)
                {
                    mail.Attachments.Add(new Attachment(AttachmentFilePath));
                    Config.Settings.Email_Attachment_Filename_Set(AttachmentFilePath);
                    // Set the method that is called back when the send operation ends.
                    SmtpServer.SendCompleted += new SendCompletedEventHandler(DeleteOldFile);
                }

                SmtpServer.Port = Config.Settings.Email_SMTPServer_Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Config.Settings.Email_Account, Config.Settings.Email_Password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                mail.Dispose();
            }
            catch (Exception ex)
            {
                Alerting.ErrorLogging.WriteTo_Log("Error Failed  SendEmail_Generic", ex.ToString());
                Application.Exit();
                Environment.Exit(0);
            }
        }
        public static void SendEmail_Generic_UsingWindowsCredentials(string Subject, string Body, bool AddAttachment, string AttachmentFilePath)
        {
            try
            {
                string SMTP = Config.Settings.Email_SMTPServer_WindowsCredentials;
                MailMessage msg = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Config.Settings.Email_SMTPServer_Generic);
                msg.From = new MailAddress(Config.Settings.Email_Sender);
                if ((CountStringOccurrences(Config.Settings.Email_Recipient, ";")) > 0)
                {
                    string s = Config.Settings.Email_Recipient;
                    s = s.Replace(" ", "");
                    string[] words = s.Split(';');
                    foreach (string word in words)
                    {
                        msg.To.Add(word);
                    }
                }
                else
                {
                    msg.To.Add(Config.Settings.Email_Recipient);
                }
                msg.Subject = Subject;
                msg.IsBodyHtml = true;
                msg.Body = Body;
                if (AddAttachment == true)
                {
                    msg.Attachments.Add(new Attachment(AttachmentFilePath));
                    Config.Settings.Email_Attachment_Filename_Set(AttachmentFilePath);
                    // Set the method that is called back when the send operation ends.
                    SmtpServer.SendCompleted += new SendCompletedEventHandler(DeleteOldFile);
                }

                SmtpClient smtpclient = new SmtpClient(SMTP, Config.Settings.Email_SMTPServer_Port);
                smtpclient.EnableSsl = true;
                smtpclient.UseDefaultCredentials = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpclient.Send(msg);
                msg.Dispose();
            }
            catch (Exception ex)
            {
                Alerting.ErrorLogging.WriteTo_Log("Error Failed SendEmail_Generic_UsingWindowsCredentials", ex.ToString());
                Application.Exit();
                Environment.Exit(0);
            }
        }
        public static void SendAlert_UsingWindowsCredentials(string Subject, string Body)
        {
            try
            {
                string SMTP = Config.Settings.Email_SMTPServer_WindowsCredentials;
                MailMessage msg = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Config.Settings.Email_SMTPServer_Generic);
                msg.From = new MailAddress(Config.Settings.Email_Sender);
                if ((CountStringOccurrences(Config.Settings.Email_Recipient, ";")) > 0)
                {
                    string s = Config.Settings.Email_Recipient;
                    s = s.Replace(" ", "");
                    string[] words = s.Split(';');
                    foreach (string word in words)
                    {
                        msg.To.Add(word);
                    }
                }
                else
                {
                    msg.To.Add(Config.Settings.Email_Recipient);
                }
                msg.Subject = Subject;
                if (Config.Settings.SendReportAs_HTML == true)
                {
                    msg.IsBodyHtml = true;
                }
                msg.Body = Body;
                if (Config.Settings.SendReportAs_CSV == true)
                {
                    msg.Attachments.Add(new Attachment(Config.Settings.Report_FileName_csv));
                }

                SmtpClient smtpclient = new SmtpClient(SMTP, Config.Settings.Email_SMTPServer_Port);
                smtpclient.EnableSsl = true;
                smtpclient.UseDefaultCredentials = true;
                msg.IsBodyHtml = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpclient.Send(msg);
                msg.Dispose();
            }
            catch (Exception ex)
            {
                Alerting.ErrorLogging.WriteTo_Log("Error Failed SendAlert_UsingWindowsCredentials", ex.ToString());
                Application.Exit();
                Environment.Exit(0);
            }
        }

        public static void DeleteOldFile(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                //Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                //Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                //Console.WriteLine("Message sent.");
            }


            if(File.Exists(Config.Settings.Email_Attachment_Filename))
            {
                File.Delete(Config.Settings.Email_Attachment_Filename);
                Config.Settings.Email_Attachment_Filename_Set("");
            }
        }
    }
}
