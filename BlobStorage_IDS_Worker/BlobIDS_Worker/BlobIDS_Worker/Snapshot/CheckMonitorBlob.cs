using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobIDS_Worker.Snapshot
{
    class CheckMonitorBlob
    {

        /// <summary>
        /// <para>this function will return a list of blob that should NOT be monitored (e.g &#x3C;MonitorThisFile&#x3E;True&#x3C;/MonitorThisFile&#x3E;)</para>
        /// </summary>
        /// <param name="ContainerName"></param>
        /// <returns></returns>
        public static List<string> BaselineSnapshot()
        {
            return (ParseSnapshotForBlobsToIgnore());
        }

        /// <summary>
        /// <para>this function will return a list of blob that should NOT be monitored (e.g &#x3C;MonitorThisFile&#x3E;True&#x3C;/MonitorThisFile&#x3E;)</para>
        /// </summary>
        /// <param name="ContainerName"></param>
        /// <returns></returns>
        private static List<string> ParseSnapshotForBlobsToIgnore()
        {
            try
            {
                Config.Settings._ReadWriteLock_Snapshot.EnterWriteLock();
                List<string> BlobsToIgnore = new List<string>();

                if (File.Exists(Config.Settings.SnapShotFileName_Baseline))
                {
                    string line;
                    System.IO.StreamReader file = new System.IO.StreamReader(@"" + Config.Settings.SnapShotFileName_Baseline);

                    try
                    {
                        string blobname = "N/A";
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line.Contains("<Blob Name="))
                            {
                                blobname = Compare.GetBlobName(line);
                            }
                            else if (line.Contains("<MonitorThisFile>"))
                            {
                                if (((Compare.ParseXMLContent(line)).ToLower()).Equals("false"))
                                {
                                    BlobsToIgnore.Add(blobname);
                                }
                            }
                            else if (line.Contains("</Blob>"))
                            {
                                blobname = "N/A";
                            }
                        }
                        return BlobsToIgnore;
                    }
                    catch (Exception e)
                    {
                        Alerting.ErrorLogging.WriteTo_Log("Failed ParseSnapshotForBlobsInContainer", e.ToString());
                        return BlobsToIgnore;
                    }
                    finally
                    {
                        file.Close();
                    }
                }
                else
                {
                    Alerting.ErrorLogging.WriteTo_Log("Failed ParseSnapshotForBlobsInContainer", "Baseline Snapshot Not Found");
                    return BlobsToIgnore;
                }
            }
            finally
            {
                Config.Settings._ReadWriteLock_Snapshot.ExitWriteLock();
            }
        }
    }
}
