using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BlobIDS.View
{
    class SnapShot
    {

        /// <summary>
        /// <para>this function will return a list of blob that should NOT be monitored (e.g &#x3C;MonitorThisFile&#x3E;True&#x3C;/MonitorThisFile&#x3E;)</para>
        /// </summary>
        /// <param name="ContainerName"></param>
        /// <returns></returns>
        public static bool HTML_Format(string SnapShotFilename)
        {

            //write to the html template "E:\Custom Code\BlobIDS\ViewSnapshot\ViewSnapshotTemplate.html" when done parsing every container and blob
            if (File.Exists(SnapShotFilename))
            {
                string htmlfile = SnapShotFilename + ".html";
                try
                {
                    if (File.Exists(htmlfile))
                    {
                        File.Delete(htmlfile);
                    }
                }
                catch
                {

                }
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(@"" + Config.Settings.SnapShotFileName_Baseline);

                try
                {
                    using (System.IO.StreamWriter html_file = new System.IO.StreamWriter(@"" + htmlfile, true))
                    {
                        string blobname = "N/A";
                        string containername = "N/A";
                        string LastModified = "N/A";
                        string MonitorThisFile = "N/A";
                        string Size = "N/A";
                        string MD5 = "N/A";
                        string SHA512 = "N/A";
                        string ContentType = "N/A";
                        string AnonymousAccessEnabled = "N/A";
                        string DownloadLocation = "N/A";

                        string SnapshotDetail_DoNotOverWrite = "N/A";
                        string SnapshotDetail_Created = "N/A";
                        string SnapshotDetail_AzureAccountName = "N/A";
                        string MonitorThisContainer = "N/A";

                        string html_blob = "N/A";
                        string html_container = "N/A";

                        html_file.WriteLine(html_template.Get_StartOfHTMLTemplate());
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line.Contains("<Shapshot DoNotOverwrite="))
                            {
                                SnapshotDetail_DoNotOverWrite = Parse.GetDoNotOverwriteSnapshot(line);
                                SnapshotDetail_Created = Parse.GetDateCreatedSnapshot(line);
                                html_file.WriteLine("<div style=\"line-height:22px;\"><b><u>Snapshot Details</u></b><br>\r\n");
                                html_file.WriteLine("<b>DoNotOverwrite:</b> " + SnapshotDetail_DoNotOverWrite + "<br>\r\n");
                                html_file.WriteLine("<b>Created:</b> " + SnapshotDetail_Created + "<br>\r\n");
                            }
                            else if (line.Contains("<Account Name="))
                            {
                                SnapshotDetail_AzureAccountName = Parse.GetAccountName(line);
                                html_file.WriteLine("<b>Azure Account Name:</b> " + SnapshotDetail_AzureAccountName + "<br>\r\n</div>\r\n");
                            }
                            else if (line.Contains("<Container Name="))
                            {
                                /*
                                 <li >Container Name <!-- new container -->
                                 <ul id="ChildList" class="Child">
                                 */
                                containername = Parse.GetContainerName(line);
                                html_container = "<li >" + containername;
                                html_file.WriteLine(html_container);
                            }
                            else if (line.Contains("<Name>"))
                            {
                                if (MonitorThisContainer.Contains("N/A"))
                                {
                                    html_file.WriteLine("<ul id=\"ChildList\" class=\"Child\">");
                                }
                                blobname = Parse.Get_BlobName(line);
                            }
                            else if (line.Contains("<MonitorThisFile>"))
                            {
                                MonitorThisFile = Parse.Get_MonitorThisFile(line);
                            }
                            else if (line.Contains("<MonitorThisContainer>"))
                            {
                                MonitorThisContainer = Parse.Get_MonitorThisContainer(line);
                                if (MonitorThisContainer.ToLower().Contains("false"))
                                {
                                    html_file.WriteLine(" <FONT COLOR=\"BLACK\">(NOT Currently Monitored)</FONT> <ul id=\"ChildList\" class=\"Child\">");
                                }
                                else
                                {
                                    html_file.WriteLine("<ul id=\"ChildList\" class=\"Child\">");
                                }
                                
                            }
                            else if (line.Contains("<BlobProperty_LastModified>"))
                            {
                                LastModified = Parse.Get_LastModified(line);
                            }
                            else if (line.Contains("<BlobProperty_Size>"))
                            {
                                Size = Parse.Get_Size(line);
                            }
                            else if (line.Contains("<BlobProperty_MD5>"))
                            {
                                MD5 = Parse.Get_MD5(line);
                            }
                            else if (line.Contains("<SHA512>"))
                            {
                                SHA512 = Parse.Get_SHA512(line);
                            }
                            else if (line.Contains("<ContentType>"))
                            {
                                ContentType = Parse.Get_ContentType(line);
                            }
                            else if (line.Contains("<AnonymousAccessEnabled>"))
                            {
                                AnonymousAccessEnabled = Parse.Get_AnonymousAccessEnabled(line);
                            }
                            else if (line.Contains("<DownloadLocation>"))
                            {
                                DownloadLocation = Parse.Get_DownloadLocation(line);
                            }
                            else if (line.Contains("</Blob>"))
                            {
                                /*
                                       <li> <!-- new blob -->
                                            <div class="hover">
                                            <div ondblclick="popupBlobData('helloblobname','containername','LastModified','MonitorThisFile','Size,MD5','SHA512','ContentType','AnonymousAccessEnabled','DownloadLocation')">
                                                Blob Name
                                                <div class="tooltip">
                                                    Blob Data
                                                </div>	
                                            </div>
                                        </li>
                                 */
                                html_blob = "\r\n <li><div class=\"hover\">\r\n" +
                                    " <div ondblclick=\"popupBlobData('" + blobname + "','" + containername + "','" + LastModified + "','" +
                                    MonitorThisFile + "','" + Size + "','" + MD5 + "','" + SHA512 + "','" + ContentType + "','" + 
                                    AnonymousAccessEnabled + "','" + DownloadLocation+ "')\">" +
                                    blobname + "</div>\r\n <div class=\"tooltip\">" +
                                    "\r\n  <b>Blob Name:</b> " + blobname + "<br>" +
                                    "\r\n  <b>Contianer of Blob:</b> " + containername + "<br>" +
                                    "\r\n  <b>Monitoring Blob:</b> " + MonitorThisFile + "<br>" +
                                    "\r\n  <b>Size:</b> " + Size + "<br>" +
                                    "\r\n  <b>ContentType:</b> " + ContentType + "<br>" +
                                    "\r\n  <b>LastModified:</b> " + LastModified + "<br>" +
                                    "\r\n  <b>MD5:</b> " + MD5 + "<br>" +
                                    "\r\n  <b>SHA512:</b> " + SHA512 + "<br>" +
                                    "\r\n  <b>AnonymousAccessEnabled:</b> " + AnonymousAccessEnabled + "<br>" +
                                    "\r\n  <b>DownloadLocation:</b> " + DownloadLocation + "<br>"
                                    + "\r\n </div></div></li>\r\n ";

                                html_file.WriteLine(html_blob);

                                blobname = "N/A";
                                LastModified = "N/A";
                                MonitorThisFile = "N/A";
                                Size = "N/A";
                                MD5 = "N/A";
                                SHA512 = "N/A";
                                ContentType = "N/A";
                                AnonymousAccessEnabled = "N/A";
                                DownloadLocation = "N/A";
                                html_blob = "N/A";
                            }
                            else if (line.Contains("</Container>"))
                            {
                                html_file.WriteLine("</ul></li>\r\n");
                                containername = "N/A";
                            }
                        }

                        html_file.WriteLine(html_template.Get_EndOfHTMLTemplate());
                        SnapshotDetail_DoNotOverWrite = "N/A";
                        SnapshotDetail_Created = "N/A";
                        SnapshotDetail_AzureAccountName = "N/A";
                    }
                    System.Diagnostics.Process.Start(htmlfile);
                }
                catch (Exception e)
                {
                    Alerting.ErrorLogging.WriteTo_Log("Failed Generate HTML View of Snapshot: ", e.ToString());
                    return false;
                }
                finally
                {
                    file.Close();
                }
                return true;
            }
            else
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed Generate HTML View of Snapshot: ", "File Not Found");
                return false;
            }
        }

        public static bool CSV_Format(string SnapShotFilename)
        {

            //write to the html template "E:\Custom Code\BlobIDS\ViewSnapshot\ViewSnapshotTemplate.html" when done parsing every container and blob
            if (File.Exists(SnapShotFilename))
            {
                string csvfile = SnapShotFilename + ".csv";
                try
                {
                    if (File.Exists(csvfile))
                    {
                        File.Delete(csvfile);
                    }
                }
                catch
                {

                }
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(@"" + Config.Settings.SnapShotFileName_Baseline);

                try
                {
                    using (System.IO.StreamWriter csv_file = new System.IO.StreamWriter(@"" + csvfile, true))
                    {
                        string blobname = "N/A";
                        string containername = "N/A";
                        string LastModified = "N/A";
                        string MonitorThisFile = "N/A";
                        string Size = "N/A";
                        string MD5 = "N/A";
                        string SHA512 = "N/A";
                        string ContentType = "N/A";
                        string AnonymousAccessEnabled = "N/A";
                        string DownloadLocation = "N/A";

                        string SnapshotDetail_DoNotOverWrite = "N/A";
                        string SnapshotDetail_Created = "N/A";
                        string SnapshotDetail_AzureAccountName = "N/A";
                        string MonitorThisContainer = "N/A";

                        csv_file.WriteLine("DateofSnapshot,AccountName,ContainerName,BlobName,BlobContentType,BlobSize,BlobLastModified,ContainerMonitored,BlobMonitored,BlobMD5,BlobSHA512,BlobAnonymousAccessEnabled,BlobDownloadLocation");
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line.Contains("<Shapshot DoNotOverwrite="))
                            {
                                SnapshotDetail_DoNotOverWrite = Parse.GetDoNotOverwriteSnapshot(line);
                                SnapshotDetail_Created = Parse.GetDateCreatedSnapshot(line);
                            }
                            else if (line.Contains("<Account Name="))
                            {
                                SnapshotDetail_AzureAccountName = Parse.GetAccountName(line);
                            }
                            else if (line.Contains("<Container Name="))
                            {
                                containername = Parse.GetContainerName(line);
                            }
                            else if (line.Contains("<Name>"))
                            {
                                blobname = Parse.Get_BlobName(line);
                            }
                            else if (line.Contains("<MonitorThisContainer>"))
                            {
                                MonitorThisContainer = Parse.Get_MonitorThisContainer(line);
                            }
                            else if (line.Contains("<MonitorThisFile>"))
                            {
                                MonitorThisFile = Parse.Get_MonitorThisFile(line);
                            }
                            else if (line.Contains("<BlobProperty_LastModified>"))
                            {
                                LastModified = Parse.Get_LastModified(line);
                            }
                            else if (line.Contains("<BlobProperty_Size>"))
                            {
                                Size = Parse.Get_Size(line);
                            }
                            else if (line.Contains("<BlobProperty_MD5>"))
                            {
                                MD5 = Parse.Get_MD5(line);
                            }
                            else if (line.Contains("<SHA512>"))
                            {
                                SHA512 = Parse.Get_SHA512(line);
                            }
                            else if (line.Contains("<ContentType>"))
                            {
                                ContentType = Parse.Get_ContentType(line);
                            }
                            else if (line.Contains("<AnonymousAccessEnabled>"))
                            {
                                AnonymousAccessEnabled = Parse.Get_AnonymousAccessEnabled(line);
                            }
                            else if (line.Contains("<DownloadLocation>"))
                            {
                                DownloadLocation = Parse.Get_DownloadLocation(line);
                            }
                            else if (line.Contains("</Blob>"))
                            {
                                //"snapshotcreated,AccountName,ContainerName,BlobName,BlobContentType,BlobSize,BlobLastModified,ContainerMonitored,BlobMonitored,BlobMD5,BlobSHA512,BlobAnonymousAccessEnabled,BlobDownloadLocation
                                string csv_blob = "\"" + SnapshotDetail_Created + "\",\"" + SnapshotDetail_AzureAccountName + "\",\"" + containername + "\",\"" + blobname + "\",\"" +
                                    ContentType + "\",\""+ Size + "\",\""+ LastModified + "\",\""+MonitorThisContainer+ "\",\""+MonitorThisFile+ "\",\""+
                                    MD5 + "\",\""+ SHA512 + "\",\""+ AnonymousAccessEnabled + "\",\""+ DownloadLocation + "\"";

                                csv_file.WriteLine(csv_blob);

                                blobname = "N/A";
                                LastModified = "N/A";
                                MonitorThisFile = "N/A";
                                Size = "N/A";
                                MD5 = "N/A";
                                SHA512 = "N/A";
                                ContentType = "N/A";
                                AnonymousAccessEnabled = "N/A";
                                DownloadLocation = "N/A";

                            }
                            else if (line.Contains("</Container>"))
                            {
                                containername = "N/A";
                            }
                        }
                        SnapshotDetail_DoNotOverWrite = "N/A";
                        SnapshotDetail_Created = "N/A";
                        SnapshotDetail_AzureAccountName = "N/A";
                    }
                    System.Diagnostics.Process.Start(csvfile);
                }
                catch (Exception e)
                {
                    Alerting.ErrorLogging.WriteTo_Log("Failed Generate CSV View of Snapshot: ", e.ToString());
                    return false;
                }
                finally
                {
                    file.Close();
                }
                return true;
            }
            else
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed Generate CSV View of Snapshot: ", "File Not Found");
                return false;
            }
        }

    }
}
