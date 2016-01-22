using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BlobIDS_Worker.BlobStorage
{
    class CheckFileAccess
    {
        /// <summary>
        /// Function will return true if the resource can be accessed anonymously
        /// </summary>
        /// <param name="DownloadPath">takes a string path of the file (e.g: http\://www.bing.com/robots.txt)</param>
        /// <returns>Returns TRUE for files which can be reaches anonymous, FALSE for file which can NOT be reached</returns>
        public static bool Anonymous_BlobStorageFile(string DownloadPath)
        {
            HttpWebResponse response = null;
            var request = (HttpWebRequest)WebRequest.Create(DownloadPath);
            request.Method = "HEAD";


            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                /* A WebException will be thrown if the status of the response is not `200 OK` */
                return false;
            }
            finally
            {
                // Don't forget to close your response.
                if (response != null)
                {
                    response.Close();
                }
            }
            return true;
        }

        public static void FileAccess_Snapshot()
        {
            if (File.Exists(Config.Settings.SnapShotFileName_FileAccess))
            {
                File.Delete(Config.Settings.SnapShotFileName_FileAccess);
            }
            Snapshot.Generate.ConfigFile_Snapshot(Config.Settings.BlobStorage_Account_Environment, Config.Settings.BlobStorage_Account_Name, Config.Settings.BlobStorage_Account_Key, Config.Settings.SnapShotFileName_FileAccess, false, true);
        }
    }
}
