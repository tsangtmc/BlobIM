using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BlobIDS.View
{
    class Parse
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

        public static string GetDoNotOverwriteSnapshot(string line)
        {
            try
            {
                if (line.Contains("<Shapshot DoNotOverwrite="))
                {
                    if (line.ToLower().Contains("false"))
                    {
                        return "False";
                    }
                    else if (line.ToLower().Contains("true"))
                    {
                        return "True";
                    }
                    return "N/A";
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed GetDoNotOverwriteSnapshot", e.ToString());
                return "N/A";
            }
        }

        public static string GetDateCreatedSnapshot(string line)
        {
            try
            {
                if (line.Contains("<Shapshot DoNotOverwrite="))
                {
                    int startpos = line.IndexOf("reated=\"");
                    startpos = startpos + 8;
                    int namelength = line.Length - 2 - startpos;

                    return line.Substring(startpos, namelength);
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed GetDoNotOverwriteSnapshot", e.ToString());
                return "N/A";
            }
        }

        public static string GetAccountName(string line)
        {
            try
            {
                if (line.Contains("<Account Name="))
                {
                    int startpos = line.IndexOf("=\"");
                    startpos = startpos + 2;
                    int namelength = line.Length - 2 - startpos;

                    return line.Substring(startpos, namelength);
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed GetAccountName", e.ToString());
                return "N/A";
            }
        }

        /// <summary>
        /// Parses out the container name from xml snapshot file, must specifically be in this format "&lt;Container Name="devicereadings"&gt;"
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string GetContainerName(string line)
        {
            try
            {
                if (line.Contains("<Container Name="))
                {
                    int startpos = line.IndexOf("=\"");
                    startpos = startpos + 2;
                    int namelength = line.Length - 2 - startpos;

                    return line.Substring(startpos, namelength);
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed GetContainerName", e.ToString());
                return "N/A";
            }
        }

        /// <summary>
        /// Parses out the Blob name from xml snapshot file, must specifically be in this format "&lt;Blob Name="devicereadings"&gt;"
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string Get_BlobName(string line)
        {
            try
            {
                if (line.Contains("<Name>"))
                {
                    string value = RegularParse_BetweenTwoStrings(line, ">", "</", 1);
                    value = System.Xml.XmlConvert.DecodeName(value);
                    return value;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                return "N/A";
            }
        }

        public static string Get_MonitorThisFile(string line)
        {
            try
            {
                if (line.Contains("<MonitorThisFile>"))
                {
                    string value = RegularParse_BetweenTwoStrings(line, ">", "</", 1);
                    value = System.Xml.XmlConvert.DecodeName(value);
                    return value;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                return "N/A";
            }
        }

        public static string Get_MonitorThisContainer(string line)
        {
            try
            {
                if (line.Contains("<MonitorThisContainer>"))
                {
                    string value = RegularParse_BetweenTwoStrings(line, ">", "</", 1);
                    value = System.Xml.XmlConvert.DecodeName(value);
                    return value;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                return "N/A";
            }
        }

        public static string Get_LastModified(string line)
        {
            try
            {
                if (line.Contains("<BlobProperty_LastModified>"))
                {
                    string value = RegularParse_BetweenTwoStrings(line, ">", "</", 1);
                    value = System.Xml.XmlConvert.DecodeName(value);
                    return value;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                return "N/A";
            }
        }

        public static string Get_Size(string line)
        {
            try
            {
                if (line.Contains("<BlobProperty_Size>"))
                {
                    string value = RegularParse_BetweenTwoStrings(line, ">", "</", 1);
                    value = System.Xml.XmlConvert.DecodeName(value);
                    return value;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                return "N/A";
            }
        }

        public static string Get_MD5(string line)
        {
            try
            {
                if (line.Contains("<BlobProperty_MD5>"))
                {
                    string value = RegularParse_BetweenTwoStrings(line, ">", "</", 1);
                    value = System.Xml.XmlConvert.DecodeName(value);
                    return value;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                return "N/A";
            }
        }
        public static string Get_SHA512(string line)
        {
            try
            {
                if (line.Contains("<SHA512>"))
                {
                    string value = RegularParse_BetweenTwoStrings(line, ">", "</", 1);
                    value = System.Xml.XmlConvert.DecodeName(value);
                    return value;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed GetBlobName", e.ToString());
                return "N/A";
            }
        }
        public static string Get_ContentType(string line)
        {
            try
            {
                if (line.Contains("<ContentType>"))
                {
                    string value = RegularParse_BetweenTwoStrings(line, ">", "</", 1);
                    value = System.Xml.XmlConvert.DecodeName(value);
                    return value;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                return "N/A";
            }
        }
        public static string Get_DownloadLocation(string line)
        {
            try
            {
                if (line.Contains("<DownloadLocation>"))
                {
                    string value = RegularParse_BetweenTwoStrings(line, ">", "</", 1);
                    value = System.Xml.XmlConvert.DecodeName(value);
                    return value;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed GetBlobName", e.ToString());
                return "N/A";
            }
        }
        public static string Get_AnonymousAccessEnabled(string line)
        {
            try
            {
                if (line.Contains("<AnonymousAccessEnabled>"))
                {
                    string value = RegularParse_BetweenTwoStrings(line, ">", "</", 1);
                    value = System.Xml.XmlConvert.DecodeName(value);
                    return value;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception e)
            {
                return "N/A";
            }
        }

        public static string RegularParse_BetweenTwoStrings(string StringToBeParsed, string FirstOccuranceOfStringA, string StringB, int OccuranceOfStringB)
        {
            try
            {
                // parse the stringtobeparsed, you will get back a substring starting from the firstoccuranceofstringa to the occuranceofstringb 
                string lowerstringtobeparsed = StringToBeParsed.ToLower();
                string lowerstringb = StringB.ToLower();
                string lowerFirstOccuranceOfStringA = FirstOccuranceOfStringA.ToLower();
                string finalstring = StringToBeParsed.Substring(0, (GetNthIndex(lowerstringtobeparsed, lowerstringb, OccuranceOfStringB, false)));
                string lowerfinalstring = finalstring.ToLower();
                int lengthA = ((GetNthIndex(lowerfinalstring, lowerFirstOccuranceOfStringA, 1, false)) + FirstOccuranceOfStringA.Length);
                if (lengthA > finalstring.Length)
                { return "N/A"; }
                finalstring = finalstring.Substring(lengthA);
                //finalstring = "OriginalParse: [" + finalstring + "]" + "Parameter: [" + parameter + "]";
                return finalstring;
            }
            catch
            {
                return "N/A";
            }
        }

        /// <summary>
        /// [public static int GetNthIndex]
        /// this will return the position in the string of the nth occurance of a substring
        /// </summary>
        /// <returns>
        /// The the number of lines
        /// </returns>
        public static int GetNthIndex(string wholestring, string substring, int n, bool debug)
        {
            int position = -1;
            string temp = wholestring;
            int lengthofwhole = wholestring.Length;
            int substringlength = substring.Length;
            int currentindex = 0;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    currentindex = temp.IndexOf(substring);
                    if (currentindex == -1) { return -1; }
                    temp = temp.Substring(currentindex + substringlength);
                    position = lengthofwhole - (temp.Length + substringlength);
                }
            }
            catch (Exception ex)
            {  //return -1 if not found
                return -1;
            }
            //if (debug == true) { Console.WriteLine("fuzzing - GetNthIndex: " + position); }
            //Console.WriteLine(wholestring);
            //Console.WriteLine("test 2 - "+position);
            return position;
        }
    }
}
