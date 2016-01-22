using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobIDS.Alerting
{
    class GeneratePermissionsReport
    {
        /// <summary>
        /// uses the permissions snapshot to generate a permissions report
        /// </summary>
        /// <param name="SnapshotFilename"></param>
        /// <returns></returns>
        public static int ToCSV(string SnapshotFilename)
        {
            if (File.Exists("BlobPermissionsReport.csv"))
            {
                File.Delete("BlobPermissionsReport.csv");
            }
            int CountLineNumber = 0;
            //First check if snapshot file already exists, and if so, if it should be over written or not
            bool donotoverwrite = false;
            if (File.Exists(SnapshotFilename))
            {
                foreach (string line in File.ReadLines(SnapshotFilename))
                {
                    if (line.ToLower().Contains("shapshot donotoverwrite=\"true\""))
                    {
                        donotoverwrite = true;
                        break;
                    }
                    if (line.ToLower().Contains("shapshot donotoverwrite=\"false\""))
                    {
                        break;
                    }
                }
            }
            if (donotoverwrite == false)
            {
                //choosing to read the xmlfile line by line instead of XML readers to preserve memory
                //just in case the xml file is huge, reducing the footprint of the tool.
                string line;
                int anonfound = 0;
                System.IO.StreamReader file = new System.IO.StreamReader(@"" + SnapshotFilename);
                try
                {
                    string blobname = "N/A";
                    string downloadurl = "N/A";
                    string anonaccess = "N/A";
                    while ((line = file.ReadLine()) != null)
                    {
                        CountLineNumber = CountLineNumber + 1;

                        if (CountLineNumber == 1)
                        {
                            try
                            {
                                using (StreamWriter sw = File.AppendText("BlobPermissionsReport.csv"))
                                {
                                    sw.WriteLine(XmlConvert.DecodeName(("\"" + "Time of Check"+ "\",\"" + "Blob Name" + "\",\"" + "Anonymous Access Enabled" + "\",\"" + "Download URL" + "\"")));
                                }
                            }
                            catch
                            {

                            }
                        }
                        if (line.Contains("<Name>"))
                        {
                            blobname = Snapshot.Compare.ParseXMLContent(line);
                        }
                        else if (line.Contains("<DownloadLocation>"))
                        {
                            downloadurl = Snapshot.Compare.ParseXMLContent(line);
                        }
                        else if (line.Contains("<AnonymousAccessEnabled>"))
                        {
                            anonaccess = Snapshot.Compare.ParseXMLContent(line);
                        }
                        else if (line.Contains("</Blob>"))
                        {
                            //write out everything
                            try
                            {
                                using (StreamWriter sw = File.AppendText("BlobPermissionsReport.csv"))
                                {
                                    DateTime now = DateTime.Now;
                                    sw.WriteLine(XmlConvert.DecodeName(("\"" + now + "\",\"" + blobname + "\",\"" + anonaccess + "\",\"" + downloadurl + "\"")));
                                    if (anonaccess.ToLower().Equals("true"))
                                    {
                                        anonfound = anonfound + 1;
                                    }
                                }
                            }
                            catch
                            {

                            }
                            blobname = "N/A";
                            downloadurl = "N/A";
                            anonaccess = "N/A";
                            
                        }
                    }
                    return anonfound;
                }
                catch (Exception e)
                {
                    Alerting.ErrorLogging.WriteTo_Log("Failed Generate Permission Report _AAA1", e.ToString());
                    return -1;
                }
                finally
                {
                    file.Close();
                }
            }
            else
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed Generate Permission Report _AAA1", "Could not create new snapshot");
                return -1;
            }
        }
    }
}
