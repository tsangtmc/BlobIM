using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace BlobIDS_Worker.Alerting
{
    class GenerateReport
    {
        public static void GenerateReport_HTML_CompileAndSend()
        {
            if (Config.Settings.SendReportAs_HTML == true)
            {
                GenerateReport_HTML_CloseHeader_Step4();
                GenerateReport_HTML_Finish_Step5();
                File.AppendAllText(Config.Settings.Report_FileName_html, File.ReadAllText(Config.Settings.Report_FileName_html + ".part1"));
                File.Delete(Config.Settings.Report_FileName_html + ".part1");
                File.AppendAllText(Config.Settings.Report_FileName_html, File.ReadAllText(Config.Settings.Report_FileName_html + ".part2"));
                File.Delete(Config.Settings.Report_FileName_html + ".part2");
                File.AppendAllText(Config.Settings.Report_FileName_html, File.ReadAllText(Config.Settings.Report_FileName_html + ".part4"));
                File.Delete(Config.Settings.Report_FileName_html + ".part4"); // four does need to come before 3, made a mistake, but just swapping it hear instead of rewriting all the code
                File.AppendAllText(Config.Settings.Report_FileName_html, File.ReadAllText(Config.Settings.Report_FileName_html + ".part3"));
                File.Delete(Config.Settings.Report_FileName_html + ".part3");
                File.AppendAllText(Config.Settings.Report_FileName_html, File.ReadAllText(Config.Settings.Report_FileName_html + ".part5"));
                File.Delete(Config.Settings.Report_FileName_html + ".part5");

                Alerting.ResultsLogging.WriteTo_EmailResultsAlert("Blob IDS Results", File.ReadAllText(Config.Settings.Report_FileName_html));//this needs to be update to acutally send out the overall report if the setting
                try
                {
                    File.Delete(Config.Settings.Report_FileName_html);
                }
                catch
                {
                    //error
                }
            }
            //now send CSV report
            if (Config.Settings.SendReportAs_CSV == true)
            {

                try
                {
                    Alerting.Email.SendEmail_Generic("Blob IDS Events Detected - CSV Report", "Changes in Blob storage were detected. \r\n Please find attached the CSV Formatted Report.", true, Config.Settings.Report_FileName_csv);
                    File.Delete(Config.Settings.Report_FileName_csv);
                }
                catch
                {
                    //error
                }
            }
        }
        public static void GenerateReport_Header_Step1(string ScanStartTime)
        {
            if(Config.Settings.SendReportAs_HTML == true)
            {
                if (File.Exists(Config.Settings.Report_FileName_html + ".part1"))
                {
                    File.Delete(Config.Settings.Report_FileName_html + ".part1");
                }
                string toprint = "<!DOCTYPE html PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">" +
                                    "<html>" +
                                "<head>" +
                                "<meta content=\"text/html; charset=ISO-8859-1\" http-equiv=\"content-type\">" +
                                  "<title></title>" +
                                "</head>" +
                                "<body>" +
                                "Summary:<br>" +
                                "<table style=\"text-align: left; width: 650px; table-layout: fixed;\" border=\"1\" cellpadding=\"2\" cellspacing=\"2\">" +
                                  "<tbody>" +
                                    "<tr>" +
                                      "<td style=\"width: 250px; word-wrap:break-word;\">Time Scan Started</td>" +
                                      "<td style=\"width: 400px; word-wrap:break-word;\">##summary1##</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                      "<td>Summary of Events</td>" +
                                      "<td style=\"width: 400px; table-layout: fixed;\">";

                toprint = toprint.Replace("##summary1##", ScanStartTime);

                PrintToReport_HTML(toprint, "part1");
            }
            if(Config.Settings.SendReportAs_CSV == true)
            {
                if (File.Exists(Config.Settings.Report_FileName_csv))
                {
                    File.Delete(Config.Settings.Report_FileName_csv);
                }
                PrintToReport_CSV("Time Scan Started,Event,ContainerName,BlobName,DownloadURL,LastModified,Blob Metdata (Size in Bytes)," +
                    "Blob Metdata (MD5),SHA512 Signature,Blob Metdata (ContentType),Anonymous Access Enabled");
            }
        }
        public static void GenerateReport_HTML_AddToSummary_Step2(string BlobName, string AddEventToSummary)
        {
            if (Config.Settings.SendReportAs_HTML == true)
            {
                string toprint = AddEventToSummary;
                PrintToReport_HTML(("<b>●" + XmlConvert.DecodeName(BlobName) + "</b> - " + XmlConvert.DecodeName(toprint) + "<br>"), "part2");
            }
        }
        private static void GenerateReport_HTML_CloseHeader_Step4()
        {
            if (Config.Settings.SendReportAs_HTML == true)
            {
                string toprint = "</td>" +
                                "</tr>" +
                              "</tbody>" +
                            "</table>";

                PrintToReport_HTML(toprint, "part4");
            }
        }
        /// <summary>
        ///<para>This takes a list as input containing the blob data, that list should be in this order:</para>
        ///<para>0) MonitorThisFile</para>
        ///<para>1) DownloadLocation</para>
        ///<para>2) BlobProperty_LastModified</para>
        ///<para>3) BlobProperty_Size</para>
        ///<para>4) BlobProperty_MD5</para>
        ///<para>5) SHA512</para>
        ///<para>6) ContentType</para>
        ///<para>7) AnonymousAccessEnabled</para>
        ///<para>From that data a report is generated</para>
        /// </summary>
        public static void GenerateReport_Item_Step3(string containername_current, string blobname_current, string containername_baseline, string blobname_baseline, 
            string DateOfDetection, string Event, List<string> Parsed_CurrentBlobData, List<string> Parsed_BaselineBlobData, bool FileWasDeleted, bool FileIsNew)
        {
            if (Config.Settings.SendReportAs_HTML == true)
            {
                string CurrentBlobData = "N/A";
                string BaselineBlobData = "N/A";

                if (FileIsNew == true)
                {
                    CurrentBlobData = ("<b>ContainerName: </b>" + XmlConvert.DecodeName(containername_current) + "<br><b>BlobName: </b>" + XmlConvert.DecodeName(blobname_current) +
                        "<br><b>DownloadURL: </b>" +  XmlConvert.DecodeName((Parsed_CurrentBlobData[1])) + "<br><b>LastModified: </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[2])) +
                        "<br><b>Blob Metdata (Size in Bytes): </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[3])) + "<br><b>Blob Metdata (MD5): </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[4])) +
                        "<br><b>SHA512/Signature: </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[5])) + "<br><b>Blob Metdata (ContentType): </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[6])) +
                        "<br><b>Anonymous Access Enabled: </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[7])));
                }
                else if (FileWasDeleted == true)
                {
                    BaselineBlobData = ("<b>ContainerName: </b>" + XmlConvert.DecodeName(containername_baseline) + "<br><b>BlobName: </b>" + XmlConvert.DecodeName(blobname_baseline) +
                        "<br><b>DownloadURL: </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[1])) + "<br><b>LastModified: </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[2])) +
                        "<br><b>Blob Metdata (Size in Bytes): </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[3])) + "<br><b>Blob Metdata (MD5): </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[4])) +
                        "<br><b>SHA512/Signature: </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[5])) + "<br><b>Blob Metdata (ContentType): </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[6])) +
                        "<br><b>Anonymous Access Enabled: </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[7])));
                }
                else
                {
                    CurrentBlobData = ("<b>ContainerName: </b>" + XmlConvert.DecodeName(containername_current) + "<br><b>BlobName: </b>" + XmlConvert.DecodeName(blobname_current) +
                        "<br><b>DownloadURL: </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[1])) + "<br><b>LastModified: </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[2])) +
                        "<br><b>Blob Metdata (Size in Bytes): </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[3])) + "<br><b>Blob Metdata (MD5): </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[4])) +
                        "<br><b>SHA512/Signature: </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[5])) + "<br><b>Blob Metdata (ContentType): </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[6])) +
                        "<br><b>Anonymous Access Enabled: </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[7])));

                    BaselineBlobData = ("<b>ContainerName: </b>" + XmlConvert.DecodeName(containername_baseline) + "<br><b>BlobName: </b>" + XmlConvert.DecodeName(blobname_baseline) +
                        "<br><b>DownloadURL: </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[1])) + "<br><b>LastModified: </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[2])) +
                        "<br><b>Blob Metdata (Size in Bytes): </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[3])) + "<br><b>Blob Metdata (MD5): </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[4])) +
                        "<br><b>SHA512/Signature: </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[5])) + "<br><b>Blob Metdata (ContentType): </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[6])) +
                        "<br><b>Anonymous Access Enabled: </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[7])));
                }

                string toprint = "<br>" +
                "<br> <center>" +
                "<table style=\"word-wrap:break-word; text-align: left; width: 800px; table-layout: fixed;\" border=\"1\" " +
                "cellspacing=\"0\" align=\"left\" border=\"1\" cellpadding=\"2\" cellspacing=\"2\" width=\"800\">" +
                    "<tbody>" +
                    "<tr>" +
                        "<td colspan=\"2\" rowspan=\"1\" width: 800 style='word-wrap:break-word;width:233.75pt;border:solid windowtext 1.0pt;padding:0in 5.4pt 0in 5.4pt'><b>BlobName: </b>" + XmlConvert.DecodeName(blobname_baseline) + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td width: 800 colspan=\"2\" rowspan=\"1\" style='word-wrap:break-word;width:233.75pt;border:solid windowtext 1.0pt;padding:0in 5.4pt 0in 5.4pt'><b>DateDetected: </b>" + DateOfDetection + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td width: 800 colspan=\"2\" rowspan=\"1\" style='word-wrap:break-word;width:233.75pt;border:solid windowtext 1.0pt;padding:0in 5.4pt 0in 5.4pt'><b>Event: </b>" + Event + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td colspan=\"1\" rowspan=\"1\" width: 400 style='word-wrap:break-word;width:233.75pt;border:solid windowtext 1.0pt;padding:0in 5.4pt 0in 5.4pt'><u>Baseline" +
                "Blob State</u><br>" +
                "" + BaselineBlobData + "</td>" +
                        "<td colspan=\"1\" rowspan=\"1\" width: 400 style='word-wrap:break-word;width:233.75pt;border:solid windowtext 1.0pt;padding:0in 5.4pt 0in 5.4pt'><u>Current Blob State</u><br>" +
                "" + CurrentBlobData + "</td>" +
                    "</tr>" +
                    "</tbody>" +
                "</table></center>";  

                PrintToReport_HTML(toprint, "part3");
            }
            if (Config.Settings.SendReportAs_CSV == true)
            {
                if (FileIsNew == true)
                {
                    PrintToReport_CSV(DateOfDetection + "," + Event + "," + XmlConvert.DecodeName(containername_current) + "," + XmlConvert.DecodeName(blobname_current) + 
                        "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[1])) + 
                        "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[2])) + "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[3])) + "," + 
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[4])) + "," +  XmlConvert.DecodeName((Parsed_CurrentBlobData[5])) + "," + 
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[6])) + "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[7])));
                }
                else if (FileWasDeleted == true)
                {
                    PrintToReport_CSV(DateOfDetection + "," + Event + "," + XmlConvert.DecodeName(containername_baseline) + "," + XmlConvert.DecodeName(blobname_baseline) + 
                        "," + XmlConvert.DecodeName((Parsed_BaselineBlobData[1])) + "," + 
                        XmlConvert.DecodeName((Parsed_BaselineBlobData[2])) + "," + XmlConvert.DecodeName((Parsed_BaselineBlobData[3])) + "," + XmlConvert.DecodeName((Parsed_BaselineBlobData[4])) + 
                        "," + XmlConvert.DecodeName((Parsed_BaselineBlobData[5])) + "," + XmlConvert.DecodeName((Parsed_BaselineBlobData[6])) + "," + XmlConvert.DecodeName((Parsed_BaselineBlobData[7])));
                }
                else
                {
                    PrintToReport_CSV(DateOfDetection + "," + Event + "," + XmlConvert.DecodeName(containername_current) + "," + XmlConvert.DecodeName(blobname_current) + 
                        "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[1])) +
                        "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[2])) + "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[3])) + "," +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[4])) + "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[5])) + "," +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[6])) + "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[7])));
                }

            }
            if (Config.Settings.EventLog_SaveEvents == true)
            {
                if (FileIsNew == true)
                {
                    ResultsLogging.PrintToReport_Log("\"" + DateOfDetection + "\",\"" + Event + "\",\"" + XmlConvert.DecodeName(containername_current) + "\",\"" + 
                        XmlConvert.DecodeName(blobname_current) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[1])) + "\",\"" + XmlConvert.DecodeName((Parsed_CurrentBlobData[2])) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[3])) + "\",\"" + XmlConvert.DecodeName((Parsed_CurrentBlobData[4])) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[5])) + "\",\"" + XmlConvert.DecodeName((Parsed_CurrentBlobData[6])) + "\",\"" + XmlConvert.DecodeName((Parsed_CurrentBlobData[7])) + "\"");
                }
                else if (FileWasDeleted == true)
                {
                    ResultsLogging.PrintToReport_Log("\"" + DateOfDetection + "\",\"" + Event + "\",\"" + XmlConvert.DecodeName(containername_baseline) + "\",\"" + 
                        XmlConvert.DecodeName(blobname_baseline) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_BaselineBlobData[1])) + "\",\"" + XmlConvert.DecodeName((Parsed_BaselineBlobData[2])) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_BaselineBlobData[3])) + "\",\"" + XmlConvert.DecodeName((Parsed_BaselineBlobData[4])) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_BaselineBlobData[5])) + "\",\"" + XmlConvert.DecodeName((Parsed_BaselineBlobData[6])) + "\",\"" + XmlConvert.DecodeName((Parsed_BaselineBlobData[7])) + "\"");
                }
                else
                {
                    ResultsLogging.PrintToReport_Log("\"" + DateOfDetection + "\",\"" + Event + "\",\"" + XmlConvert.DecodeName(containername_current) + 
                        "\",\"" + XmlConvert.DecodeName(blobname_current) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[1])) + "\",\"" + XmlConvert.DecodeName((Parsed_CurrentBlobData[2])) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[3])) + "\",\"" + XmlConvert.DecodeName((Parsed_CurrentBlobData[4])) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[5])) + "\",\"" + XmlConvert.DecodeName((Parsed_CurrentBlobData[6])) + "\",\"" + XmlConvert.DecodeName((Parsed_CurrentBlobData[7])) + "\"");
                }
            }



            //here print to both the windows eventlog and the taskbar messages
            if (FileIsNew == true)
            {
                Alerting.ResultsLogging.WriteTo_TaskBar_WinEventLog("New Blob Found", ("Time Scan Started: " + DateOfDetection + "\r\nEvent: " + Event +
                    "\r\nContainerName: " + XmlConvert.DecodeName(containername_current) +
                    "\r\nBlobName: " + XmlConvert.DecodeName(blobname_current) + "\r\nDownloadURL: " + XmlConvert.DecodeName((Parsed_CurrentBlobData[1])) +
                    "\r\nLastModified: " + XmlConvert.DecodeName((Parsed_CurrentBlobData[2])) + "\r\nBlob Metdata (Size in Bytes): " + XmlConvert.DecodeName((Parsed_CurrentBlobData[3])) +
                    "\r\nBlob Metdata (MD5): " + XmlConvert.DecodeName((Parsed_CurrentBlobData[4])) + "\r\nSHA512 Signature: " + XmlConvert.DecodeName((Parsed_CurrentBlobData[5])) +
                    "\r\nBlob Metdata (ContentType): " + XmlConvert.DecodeName((Parsed_CurrentBlobData[6])) + "\r\nAnonymous Access Enabled: " + XmlConvert.DecodeName((Parsed_CurrentBlobData[7]))));
            }
            else if (FileWasDeleted == true)
            {
                Alerting.ResultsLogging.WriteTo_TaskBar_WinEventLog("Blob was Deleted from Storage", ("Time Scan Started: " + DateOfDetection +
                    "\r\nEvent: " + Event + "\r\nContainerName: " + XmlConvert.DecodeName(containername_baseline) +
                    "\r\nBlobName: " + XmlConvert.DecodeName(blobname_baseline) + "\r\nDownloadURL: " + XmlConvert.DecodeName((Parsed_BaselineBlobData[1])) +
                    "\r\nLastModified: " + XmlConvert.DecodeName((Parsed_BaselineBlobData[2])) + "\r\nBlob Metdata (Size in Bytes): " + XmlConvert.DecodeName((Parsed_BaselineBlobData[3])) +
                    "\r\nBlob Metdata (MD5): " + XmlConvert.DecodeName((Parsed_BaselineBlobData[4])) + "\r\nSHA512 Signature: " + XmlConvert.DecodeName((Parsed_BaselineBlobData[5])) +
                    "\r\nBlob Metdata (ContentType): " + XmlConvert.DecodeName((Parsed_BaselineBlobData[6])) + "\r\nAnonymous Access Enabled: " + XmlConvert.DecodeName((Parsed_BaselineBlobData[7]))));
            }
            else
            {
                Alerting.ResultsLogging.WriteTo_TaskBar_WinEventLog(Event, ("Time Scan Started: " + DateOfDetection + "\r\nEvent: " + Event +
                    "\r\nContainerName: " + XmlConvert.DecodeName(containername_current) +
                    "\r\nBlobName: " + XmlConvert.DecodeName(blobname_current) + "\r\nDownloadURL: " + XmlConvert.DecodeName((Parsed_CurrentBlobData[1])) +
                    "\r\nLastModified: " + XmlConvert.DecodeName((Parsed_CurrentBlobData[2])) + "\r\nBlob Metdata (Size in Bytes): " + XmlConvert.DecodeName((Parsed_CurrentBlobData[3])) +
                    "\r\nBlob Metdata (MD5): " + XmlConvert.DecodeName((Parsed_CurrentBlobData[4])) + "\r\nSHA512 Signature: " + XmlConvert.DecodeName((Parsed_CurrentBlobData[5])) +
                    "\r\nBlob Metdata (ContentType): " + XmlConvert.DecodeName((Parsed_CurrentBlobData[6])) + "\r\nAnonymous Access Enabled: " + XmlConvert.DecodeName((Parsed_CurrentBlobData[7]))));
            }
        }

        public static void GenerateReport_Item_Step3_DeletedBlob(string containername_current, string blobname_current, string containername_baseline, string blobname_baseline,
    string DateOfDetection, string Event, List<string> Parsed_BaselineBlobData)
        {
            if (Config.Settings.SendReportAs_HTML == true)
            {
                string CurrentBlobData = "N/A";
                string BaselineBlobData = "N/A";

                BaselineBlobData = ("<b>ContainerName: </b>" + XmlConvert.DecodeName(containername_baseline) + "<br><b>BlobName: </b>" + XmlConvert.DecodeName(blobname_baseline) +
                    "<br><b>DownloadURL: </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[1])) + "<br><b>LastModified: </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[2])) +
                    "<br><b>Blob Metdata (Size in Bytes): </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[3])) + "<br><b>Blob Metdata (MD5): </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[4])) +
                    "<br><b>SHA512/Signature: </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[5])) + "<br><b>Blob Metdata (ContentType): </b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[6])) +
                    "<br><b>Anonymous Access Enabled</b>" + XmlConvert.DecodeName((Parsed_BaselineBlobData[7])));

                string toprint = "<br>" +
                "<br>" +
                "<table style=\"text-align: left; height: 63px; width: 617px; table-layout: fixed;\"" +
                    "border=\"1\" cellpadding=\"2\" cellspacing=\"2\">" +
                    "<tbody>" +
                    "<tr>" +
                        "<td colspan=\"2\" rowspan=\"1\" style=\"width: 300px; word-wrap: break-word;\"><b>BlobName: </b>" + blobname_baseline + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td style=\"width: 300px; word-wrap: break-word;\" colspan=\"2\" rowspan=\"1\"><b>DateDetected: </b>" + DateOfDetection + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td style=\"width: 300px; word-wrap: break-word;\" colspan=\"2\" rowspan=\"1\"><b>Event: </b>" + Event + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td colspan=\"1\" rowspan=\"1\" style=\"width: 300px; word-wrap: break-word;\"><u>Baseline" +
                "Blob State</u><br>" +
                "" + BaselineBlobData + "</td>" +
                        "<td style=\"width: 300px; word-wrap: break-word;\"><u>Current Blob State</u><br>" +
                "" + CurrentBlobData + "</td>" +
                    "</tr>" +
                    "</tbody>" +
                "</table>";

                PrintToReport_HTML(toprint, "part3");
            }
            if (Config.Settings.SendReportAs_CSV == true)
            {
                    PrintToReport_CSV(DateOfDetection + "," + Event + "," + XmlConvert.DecodeName(containername_baseline) + "," + XmlConvert.DecodeName(blobname_baseline) + 
                        "," + XmlConvert.DecodeName((Parsed_BaselineBlobData[1])) + "," +
                        XmlConvert.DecodeName((Parsed_BaselineBlobData[2])) + "," + XmlConvert.DecodeName((Parsed_BaselineBlobData[3])) + "," + XmlConvert.DecodeName((Parsed_BaselineBlobData[4])) +
                        "," + XmlConvert.DecodeName((Parsed_BaselineBlobData[5])) + "," + XmlConvert.DecodeName((Parsed_BaselineBlobData[6])) + "," + XmlConvert.DecodeName((Parsed_BaselineBlobData[7])));
            }
            if (Config.Settings.EventLog_SaveEvents == true)
            {
                ResultsLogging.PrintToReport_Log("\"" + DateOfDetection + "\",\"" + Event + "\",\"" + XmlConvert.DecodeName(containername_baseline) + "\",\"" + 
                    XmlConvert.DecodeName(blobname_baseline) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_BaselineBlobData[1])) + "\",\"" + XmlConvert.DecodeName((Parsed_BaselineBlobData[2])) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_BaselineBlobData[3])) + "\",\"" + XmlConvert.DecodeName((Parsed_BaselineBlobData[4])) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_BaselineBlobData[5])) + "\",\"" + XmlConvert.DecodeName((Parsed_BaselineBlobData[6])) + "\",\"" + XmlConvert.DecodeName((Parsed_BaselineBlobData[7])) + "\"");
            }

            //here print to both the windows eventlog and the taskbar messages

            Alerting.ResultsLogging.WriteTo_TaskBar_WinEventLog("Blob was Deleted from Storage", ("Time Scan Started: " + DateOfDetection + "\r\nEvent: " + Event +
                    "\r\nContainerName: " + XmlConvert.DecodeName(containername_baseline) +
                    "\r\nBlobName: " + XmlConvert.DecodeName(blobname_baseline) + "\r\nDownloadURL: " + XmlConvert.DecodeName((Parsed_BaselineBlobData[1])) +
                    "\r\nLastModified: " + XmlConvert.DecodeName((Parsed_BaselineBlobData[2])) + "\r\nBlob Metdata (Size in Bytes): " + XmlConvert.DecodeName((Parsed_BaselineBlobData[3])) +
                    "\r\nBlob Metdata (MD5): " + XmlConvert.DecodeName((Parsed_BaselineBlobData[4])) + "\r\nSHA512 Signature: " + XmlConvert.DecodeName((Parsed_BaselineBlobData[5])) +
                    "\r\nBlob Metdata (ContentType): " + XmlConvert.DecodeName((Parsed_BaselineBlobData[6])) + "\r\nAnonymous Access Enabled: " + XmlConvert.DecodeName((Parsed_BaselineBlobData[7]))));
        }

        public static void GenerateReport_Item_Step3_NewBlob(string containername_current, string blobname_current, string containername_baseline, string blobname_baseline,
    string DateOfDetection, string Event, List<string> Parsed_CurrentBlobData)
        {
            if (Config.Settings.SendReportAs_HTML == true)
            {
                string CurrentBlobData = "N/A";
                string BaselineBlobData = "N/A";

                    CurrentBlobData = ("<b>ContainerName: </b>" + XmlConvert.DecodeName(containername_current) + "<br><b>BlobName: </b>" + XmlConvert.DecodeName(blobname_current) +
                        "<br><b>DownloadURL: </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[1])) + "<br><b>LastModified: </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[2])) +
                        "<br><b>Blob Metdata (Size in Bytes): </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[3])) + "<br><b>Blob Metdata (MD5): </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[4])) +
                        "<br><b>SHA512/Signature: </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[5])) + "<br><b>Blob Metdata (ContentType): </b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[6])) +
                        "<br><b>Anonymous Access Enabled</b>" + XmlConvert.DecodeName((Parsed_CurrentBlobData[7])));

                string toprint = "<br>" +
                "<br>" +
                "<table style=\"text-align: left; height: 63px; width: 617px; table-layout: fixed;\"" +
                    "border=\"1\" cellpadding=\"2\" cellspacing=\"2\" >" +
                    "<tbody>" +
                    "<tr>" +
                        "<td colspan=\"2\" rowspan=\"1\" style=\"width: 300px; word-wrap: break-word;\" ><b>BlobName: </b>" + XmlConvert.DecodeName(blobname_baseline) + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td style=\"width: 300px; word-wrap: break-word;\" colspan=\"2\" rowspan=\"1\"><b>DateDetected: </b>" + DateOfDetection + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td style=\"width: 300px; word-wrap: break-word;\" colspan=\"2\" rowspan=\"1\"><b>Event: </b>" + Event + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td colspan=\"1\" rowspan=\"1\" style=\"width: 300px; word-wrap: break-word;\"><u>Baseline" +
                "Blob State</u><br>" +
                "" + BaselineBlobData + "</td>" +
                        "<td style=\"width: 300px; word-wrap: break-word;\"><u>Current Blob State</u><br>" +
                "" + CurrentBlobData + "</td>" +
                    "</tr>" +
                    "</tbody>" +
                "</table>";

                PrintToReport_HTML(toprint, "part3");
            }
            if (Config.Settings.SendReportAs_CSV == true)
            {
                    PrintToReport_CSV(DateOfDetection + "," + Event + "," + XmlConvert.DecodeName(containername_current) + 
                        "," + XmlConvert.DecodeName(blobname_current) + "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[1])) +
                        "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[2])) + "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[3])) + "," +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[4])) + "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[5])) + "," +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[6])) + "," + XmlConvert.DecodeName((Parsed_CurrentBlobData[7])));
            }
            if (Config.Settings.EventLog_SaveEvents == true)
            {
                    ResultsLogging.PrintToReport_Log("\"" + DateOfDetection + "\",\"" + Event + "\",\"" + XmlConvert.DecodeName(containername_current) + 
                        "\",\"" + XmlConvert.DecodeName(blobname_current) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[1])) + "\",\"" + XmlConvert.DecodeName((Parsed_CurrentBlobData[2])) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[3])) + "\",\"" + XmlConvert.DecodeName((Parsed_CurrentBlobData[4])) + "\",\"" +
                        XmlConvert.DecodeName((Parsed_CurrentBlobData[5])) + "\",\"" + XmlConvert.DecodeName((Parsed_CurrentBlobData[6])) + "\",\"" + XmlConvert.DecodeName((Parsed_CurrentBlobData[7])) + "\"");
            }

            //here print to both the windows eventlog and the taskbar messages
            Alerting.ResultsLogging.WriteTo_TaskBar_WinEventLog("New Blob Found", ("Time Scan Started: " + DateOfDetection + "\r\nEvent: " + Event +
                    "\r\nContainerName:" + XmlConvert.DecodeName(containername_current) +
                    "\r\nBlobName: " + XmlConvert.DecodeName(blobname_current) + "\r\nDownloadURL: " + XmlConvert.DecodeName((Parsed_CurrentBlobData[1])) +
                    "\r\nLastModified: " + XmlConvert.DecodeName((Parsed_CurrentBlobData[2])) + "\r\nBlob Metdata (Size in Bytes): " + XmlConvert.DecodeName((Parsed_CurrentBlobData[3])) +
                    "\r\nBlob Metdata (MD5): " + XmlConvert.DecodeName((Parsed_CurrentBlobData[4])) + "\r\nSHA512 Signature:" + XmlConvert.DecodeName((Parsed_CurrentBlobData[5])) +
                    "\r\nBlob Metdata (ContentType): " + XmlConvert.DecodeName((Parsed_CurrentBlobData[6])) + "\r\nAnonymous Access Enabled: " + XmlConvert.DecodeName((Parsed_CurrentBlobData[7]))));
        }

        private static void GenerateReport_HTML_Finish_Step5()
        {
            if (Config.Settings.SendReportAs_HTML == true)
            {
                string toprint = "</body>" +
                                "</html>";

                PrintToReport_HTML(toprint, "part5");
            }
        }
        private static void PrintToReport_HTML(string toprint, string FilePart)
        {
            try
            {
                if (Config.Settings.SendReportAs_HTML == true)
                {
                    using (StreamWriter sw = File.AppendText(Config.Settings.Report_FileName_html + "." + FilePart))
                    {
                        sw.WriteLine(toprint);
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// <para>CSV should be printed in the format</para>
        /// <para>PrintToReport_CSV("Time Scan Started,Event,ContainerName,BlobName,DownloadURL,LastModified,Blob Metdata (Size in Bytes),Blob Metdata (MD5),SHA512 Signature,Blob Metdata (ContentType),Anonymous Access Enabled");</para>
        /// </summary>
        /// <param name="toprint"></param>
        private static void PrintToReport_CSV(string toprint)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(Config.Settings.Report_FileName_csv))
                {
                    sw.WriteLine(toprint);
                }
            }
            catch
            {

            }
        }

    }
}
