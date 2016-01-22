using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlobIDS.Snapshot
{
    class Compare
    {

        /// <summary>
        /// Parses out content from a xml element that is contained on one line, e.g: &ltMonitorThisFile>True&lt/MonitorThisFile>
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string ParseXMLContent(string line)
        {   //<MonitorThisFile>True</MonitorThisFile>
            try
            {
                string content = line.Substring(0, (line.IndexOf("</")));
                content = content.Substring((content.IndexOf(">")) + 1);
                return content;
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed ParseXMLContent", e.ToString());
                return "N/A";
            }
        }

    }
}
