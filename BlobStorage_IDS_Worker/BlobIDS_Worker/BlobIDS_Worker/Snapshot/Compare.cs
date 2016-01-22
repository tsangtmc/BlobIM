using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlobIDS_Worker.Snapshot
{
    class Compare
    {
        /// <summary>
        /// When this funciton is called a new snapshot of the blob storage state is made, that new snapshot is then compared to the baseline.
        /// </summary>
        /// <param name="Snapshot_Baseline_Filename"></param>
        /// <param name="Snapshot_Current_Filename"></param>
        public static void ConfigFile_Snapshot()
        {
            // [1] Generate new current snapshot
            Snapshot.Generate.ConfigFile_Snapshot(Config.Settings.BlobStorage_Account_Environment, Config.Settings.BlobStorage_Account_Name, Config.Settings.BlobStorage_Account_Key, Config.Settings.SnapShotFileName_Current, false, false);

            // [2] Parse the snapshots into lists
            if(File.Exists(Config.Settings.SnapShotFileName_Baseline))
            {
                //make sure to add a condition for comparing against the baseline if not preivous snapshot is available
                if(File.Exists(Config.Settings.SnapShotFileName_Previous) == false)
                {
                    FileCopy(Config.Settings.SnapShotFileName_Baseline, Config.Settings.SnapShotFileName_Previous);
                }

                List<string> SnapShotList_Baseline = ParseSnapshot(Config.Settings.SnapShotFileName_Baseline);
                List<string> SnapShotList_Previous = ParseSnapshot(Config.Settings.SnapShotFileName_Previous);
                List<string> SnapShotList_Current = ParseSnapshot(Config.Settings.SnapShotFileName_Current);

                // [3] Get the List Count to be able to Compare the snapshots
                int PreviousListCount = SnapShotList_Previous.Count();
                int CurrentListCount = SnapShotList_Current.Count();
                int BaselineListCount = SnapShotList_Baseline.Count();

                // [4] Compare the current snapshot against the baseline first
                DateTime now = DateTime.Now;
                Alerting.GenerateReport.GenerateReport_Header_Step1(now.ToString());

                //Generate a list of containers from the baseline to use in checking if the container should NOT be monitored
                List<string> IgnoreContainers = new List<string>();
                for (int i = 0; i < BaselineListCount; i++)
                {
                    string BaselineBlob = SnapShotList_Baseline[i]; //(monitorcontainer]1,_1_[CurrentContainer]2,_2_[blobname]3,_3_[LineNumber)
                    string monitorcontainer = BaselineBlob.Substring(0, BaselineBlob.IndexOf("]1,_1_[")); // true or fase if container should be monitored
                    string BaselineContainer = BaselineBlob.Substring(0, BaselineBlob.IndexOf("]2,_2_["));
                    BaselineContainer = BaselineContainer.Substring((BaselineContainer.IndexOf("]1,_1_[")) + 7);
                    if ((monitorcontainer.ToLower()).Contains("false"))
                    {
                        IgnoreContainers.Add(BaselineContainer);
                    }
                }
                // for this bools, the 'A' and 'B' on the variable names does not matter, we just need to check if either function returns true
                bool BackupCurrentSnapshotA = Compare_PreviousVsCurrent(IgnoreContainers, PreviousListCount, SnapShotList_Current, SnapShotList_Previous);
                bool BackupCurrentSnapshotB = Compare_CurrentVsPrevious(IgnoreContainers, CurrentListCount, SnapShotList_Current, SnapShotList_Previous);

                // [5] Now move the current snapshot to the previous
                File.Delete(Config.Settings.SnapShotFileName_Previous);
                File.Copy(Config.Settings.SnapShotFileName_Current, Config.Settings.SnapShotFileName_Previous);

                // [6] Backup snapshot if something was found, then delete the current snapshot regardless to clean up                
                Alerting.ResultsLogging.BackupSnapshot(BackupCurrentSnapshotA, BackupCurrentSnapshotB);

                // [7] Compile all the reports, send out alerts, and cleanup
                if((BackupCurrentSnapshotA == true) || (BackupCurrentSnapshotB == true))
                {
                    Alerting.GenerateReport.GenerateReport_HTML_CompileAndSend();                  
                }
            }
            else
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed Compare.ConfigFile_Snapshot", "The baseline snapshot file is missing, must take baseline snapshot before hand");
            }
        }

        public static void FileCopy(string originalfile, string newfile)
        {
            try
            {
                File.Copy(originalfile, newfile);
            }
            catch(Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed FileCopy", e.ToString());
            }
        }

        /// <summary>
        /// <para>This is used to compare the Current against the Baseline snapshot and specifically in that order. This comparison will find New Files and Files which have changed.</para>
        /// <para>Will return true if changes were found, this indicates that the current snapshot should be saved for records.</para>
        /// </summary>
        /// <param name="CurrentListCount"></param>
        /// <param name="SnapShotList_Current"></param>
        /// <param name="SnapShotList_Baseline"></param>
        private static bool Compare_CurrentVsPrevious(List<string> IgnoreContainers, int CurrentListCount, List<string> SnapShotList_Current, List<string> SnapShotList_Previous)
        {
            bool EventFound = false;
            try
            {
                //get a list of blob which should NOT be monitored
                List<string> BlobsToIgnore = Snapshot.CheckMonitorBlob.BaselineSnapshot();

                for (int i = 0; i < CurrentListCount; i++)
                {
                    DateTime now = DateTime.Now;
                    string CurrentBlob = SnapShotList_Current[i]; //(monitorcontainer]1,_1_[CurrentContainer]2,_2_[blobname]3,_3_[LineNumber)
                    string monitorcontainer = CurrentBlob.Substring(0, CurrentBlob.IndexOf("]1,_1_[")); // true or fase if container should be monitored
                    string CurrentContainer = CurrentBlob.Substring(0, CurrentBlob.IndexOf("]2,_2_["));
                    CurrentContainer = CurrentContainer.Substring((CurrentContainer.IndexOf("]1,_1_[")) + 7);
                    string CurrentBlobName = CurrentBlob.Substring(0, CurrentBlob.IndexOf("]3,_3_["));
                    CurrentBlobName = CurrentBlobName.Substring((CurrentBlobName.IndexOf("]2,_2_[")) + 7);

                    //Current Blob Variables
                    string Current_MonitorThisFile;
                    string Current_DownloadLocation;
                    string Current_BlobProperty_LastModified;
                    string Current_BlobProperty_Size;
                    string Current_BlobProperty_MD5;
                    string Current_SHA512;
                    string Current_ContentType;
                    string Current_AnonymousAccessEnabled;

                    //Previous Blob Variables
                    string Previous_MonitorThisFile;
                    string Previous_DownloadLocation;
                    string Previous_BlobProperty_LastModified;
                    string Previous_BlobProperty_Size;
                    string Previous_BlobProperty_MD5;
                    string Previous_SHA512;
                    string Previous_ContentType;
                    string Previous_AnonymousAccessEnabled;

                    string CompareAgainstBlob = ListContains(SnapShotList_Previous, (CurrentContainer + "]2,_2_[" + CurrentBlobName));
                    string CompareAgainstContainer = ListContains(SnapShotList_Previous, (CurrentContainer + "]2,_2_["));

                    Tuple<string, string, string, string, string, string, string> CurrentBlobData = GetBlobData(CurrentBlob, Config.Settings.SnapShotFileName_Current);

                    List<string> Parsed_CurrentBlobData = new List<string>();
                    List<string> Parsed_PreviousBlobData = new List<string>();
                    Current_MonitorThisFile = (CurrentBlobData.Item1).Substring(0, ((CurrentBlobData.Item1).IndexOf(",")));
                    Parsed_CurrentBlobData.Add(Current_MonitorThisFile);
                    Current_DownloadLocation = (CurrentBlobData.Item1).Substring(((CurrentBlobData.Item1).IndexOf(",")) + 1);
                    Parsed_CurrentBlobData.Add(Current_DownloadLocation);
                    Current_BlobProperty_LastModified = CurrentBlobData.Item2;
                    Parsed_CurrentBlobData.Add(Current_BlobProperty_LastModified);
                    Current_BlobProperty_Size = CurrentBlobData.Item3;
                    Parsed_CurrentBlobData.Add(Current_BlobProperty_Size);
                    Current_BlobProperty_MD5 = CurrentBlobData.Item4;
                    Parsed_CurrentBlobData.Add(Current_BlobProperty_MD5);
                    Current_SHA512 = CurrentBlobData.Item5;
                    Parsed_CurrentBlobData.Add(Current_SHA512);
                    Current_ContentType = CurrentBlobData.Item6;
                    Parsed_CurrentBlobData.Add(Current_ContentType);
                    Current_AnonymousAccessEnabled = CurrentBlobData.Item7;
                    Parsed_CurrentBlobData.Add(Current_AnonymousAccessEnabled);

                    //check if this is in the list of containers that should not be monitored based on baseline snapshot settings
                    bool monitorthiscontainer = true;
                    if (!(ListContains(IgnoreContainers, CurrentContainer)).Equals("N/A"))
                    {
                        monitorthiscontainer = false;
                    }

                    if (monitorthiscontainer == true)
                    {
                        if ((ListContains(BlobsToIgnore, CurrentBlobName)).Equals("N/A"))
                        {
                            if (!(CompareAgainstBlob.Equals("N/A")))
                            {
                                Tuple<string, string, string, string, string, string, string> PreviousBlobData = GetBlobData(CompareAgainstBlob, Config.Settings.SnapShotFileName_Previous);
                                Previous_MonitorThisFile = (PreviousBlobData.Item1).Substring(0, ((PreviousBlobData.Item1).IndexOf(",")));
                                Parsed_PreviousBlobData.Add(Previous_MonitorThisFile);
                                Previous_DownloadLocation = (PreviousBlobData.Item1).Substring(((PreviousBlobData.Item1).IndexOf(",")) + 1);
                                Parsed_PreviousBlobData.Add(Previous_DownloadLocation);
                                Previous_BlobProperty_LastModified = PreviousBlobData.Item2;
                                Parsed_PreviousBlobData.Add(Previous_BlobProperty_LastModified);
                                Previous_BlobProperty_Size = PreviousBlobData.Item3;
                                Parsed_PreviousBlobData.Add(Previous_BlobProperty_Size);
                                Previous_BlobProperty_MD5 = PreviousBlobData.Item4;
                                Parsed_PreviousBlobData.Add(Previous_BlobProperty_MD5);
                                Previous_SHA512 = PreviousBlobData.Item5;
                                Parsed_PreviousBlobData.Add(Previous_SHA512);
                                Previous_ContentType = PreviousBlobData.Item6;
                                Parsed_PreviousBlobData.Add(Previous_ContentType);
                                Previous_AnonymousAccessEnabled = PreviousBlobData.Item7;
                                Parsed_PreviousBlobData.Add(Previous_AnonymousAccessEnabled);

                                if ((Previous_MonitorThisFile.ToLower()).Contains("true"))
                                {
                                    // The File has changed, signature is different
                                    if ((!(Current_SHA512.Equals(Previous_SHA512))) && (!((Previous_SHA512.Equals("N/A")) || (Config.Settings.MaxDownloadSize == 0))))
                                    {
                                        //Add to report
                                        Alerting.GenerateReport.GenerateReport_HTML_AddToSummary_Step2(CurrentBlobName, "File SHA512 signature has changed");
                                        Alerting.GenerateReport.GenerateReport_Item_Step3(CurrentContainer, CurrentBlobName, CurrentContainer, CurrentBlobName, now.ToString(),
                                            "File SHA512 signature has changed", Parsed_CurrentBlobData, Parsed_PreviousBlobData, false, false);
                                        EventFound = true;
                                    }
                                    // The File has changed, the last modified date has changed
                                    else if (!(Current_BlobProperty_LastModified.Equals(Previous_BlobProperty_LastModified)))
                                    {
                                        //Add to report
                                        Alerting.GenerateReport.GenerateReport_HTML_AddToSummary_Step2(CurrentBlobName, "File Date LastModified has changed");
                                        Alerting.GenerateReport.GenerateReport_Item_Step3(CurrentContainer, CurrentBlobName, CurrentContainer, CurrentBlobName, now.ToString(),
                                            "File Date LastModified has changed", Parsed_CurrentBlobData, Parsed_PreviousBlobData, false, false);
                                        EventFound = true;
                                    }
                                    // The File has changed, the size of the file has changed
                                    else if (!(Current_BlobProperty_Size.Equals(Previous_BlobProperty_Size)))
                                    {
                                        //Add to report
                                        Alerting.GenerateReport.GenerateReport_HTML_AddToSummary_Step2(CurrentBlobName, "File Size has changed");
                                        Alerting.GenerateReport.GenerateReport_Item_Step3(CurrentContainer, CurrentBlobName, CurrentContainer, CurrentBlobName, now.ToString(),
                                            "File Size has changed", Parsed_CurrentBlobData, Parsed_PreviousBlobData, false, false);
                                        EventFound = true;
                                    }
                                    else if (!(Current_BlobProperty_MD5.Equals(Previous_BlobProperty_MD5)))
                                    {
                                        //Add to report
                                        Alerting.GenerateReport.GenerateReport_HTML_AddToSummary_Step2(CurrentBlobName, "Blob Metadata for MD5 value has changed");
                                        Alerting.GenerateReport.GenerateReport_Item_Step3(CurrentContainer, CurrentBlobName, CurrentContainer, CurrentBlobName, now.ToString(),
                                            "Blob Metadata for MD5 value has changed", Parsed_CurrentBlobData, Parsed_PreviousBlobData, false, false);
                                        EventFound = true;
                                    }
                                    else if (!(Current_ContentType.Equals(Previous_ContentType)))
                                    {
                                        //Add to report
                                        Alerting.GenerateReport.GenerateReport_HTML_AddToSummary_Step2(CurrentBlobName, "Blob Metadata for ContentType value has changed");
                                        Alerting.GenerateReport.GenerateReport_Item_Step3(CurrentContainer, CurrentBlobName, CurrentContainer, CurrentBlobName, now.ToString(),
                                            "Blob Metadata for ContentType value has changed", Parsed_CurrentBlobData, Parsed_PreviousBlobData, false, false);
                                        EventFound = true;
                                    }
                                    else if (!(Current_AnonymousAccessEnabled.Equals(Previous_AnonymousAccessEnabled)))
                                    {
                                        //Add to report
                                        Alerting.GenerateReport.GenerateReport_HTML_AddToSummary_Step2(CurrentBlobName, "Access Permissions for the blob has changed");
                                        Alerting.GenerateReport.GenerateReport_Item_Step3(CurrentContainer, CurrentBlobName, CurrentContainer, CurrentBlobName, now.ToString(),
                                            "Access Permissions for the blob has changed", Parsed_CurrentBlobData, Parsed_PreviousBlobData, false, false);
                                        EventFound = true;
                                    }
                                    else if (!(Current_DownloadLocation.Equals(Previous_DownloadLocation)))
                                    {
                                        //Add to report
                                        Alerting.GenerateReport.GenerateReport_HTML_AddToSummary_Step2(CurrentBlobName, "Download URL for the blob has changed");
                                        Alerting.GenerateReport.GenerateReport_Item_Step3(CurrentContainer, CurrentBlobName, CurrentContainer, CurrentBlobName, now.ToString(),
                                            "Download URL for the blob has changed", Parsed_CurrentBlobData, Parsed_PreviousBlobData, false, false);
                                        EventFound = true;
                                    }
                                }
                            }
                            else
                            {
                                //this is a new blob!
                                Alerting.GenerateReport.GenerateReport_HTML_AddToSummary_Step2(CurrentBlobName, "New Blob was Found");
                                Alerting.GenerateReport.GenerateReport_Item_Step3_NewBlob(CurrentContainer, CurrentBlobName, CurrentContainer, CurrentBlobName, now.ToString(),
                                    "New Blob was Found", Parsed_CurrentBlobData);
                                EventFound = true;
                            }
                        }
                    }
                }
                return EventFound;
            }
            catch(Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed Compare_CurrentVsBaseline", e.ToString());
                return false;
            }
        }

        /// <summary>
        /// This is used to compare the baseline against the current snapshot and specifically in that order. This comparison is done only to find out if blobs have been removed.
        /// <para>Will return true if changes were found, this indicates that the current snapshot should be saved for records.</para>
        /// </summary>
        /// <param name="BaselineListCount"></param>
        /// <param name="SnapShotList_Current"></param>
        /// <param name="SnapShotList_Baseline"></param>
        private static bool Compare_PreviousVsCurrent(List<string> IgnoreContainers, int PreviousListCount, List<string> SnapShotList_Current, List<string> SnapShotList_Previous)
        {
            bool EventFound = false;
            try
            {
                //get a list of blob which should NOT be monitored
                List<string> BlobsToIgnore = Snapshot.CheckMonitorBlob.BaselineSnapshot();

                for (int i = 0; i < PreviousListCount; i++)
                {
                    DateTime now = DateTime.Now;
                    string PreviousBlob = SnapShotList_Previous[i]; //(monitorcontainer]1,_1_[CurrentContainer]2,_2_[blobname]3,_3_[LineNumber)
                    string monitorcontainer = PreviousBlob.Substring(0, PreviousBlob.IndexOf("]1,_1_[")); // true or fase if container should be monitored
                    string PreviousContainer = PreviousBlob.Substring(0, PreviousBlob.IndexOf("]2,_2_["));
                    PreviousContainer = PreviousContainer.Substring((PreviousContainer.IndexOf("]1,_1_[")) + 7);
                    string PreviousBlobName = PreviousBlob.Substring(0, PreviousBlob.IndexOf("]3,_3_["));
                    PreviousBlobName = PreviousBlobName.Substring((PreviousBlobName.IndexOf("]2,_2_[")) + 7);

                    //Baseline Blob Variables
                    string Previous_MonitorThisFile;
                    string Previous_DownloadLocation;
                    string Previous_BlobProperty_LastModified;
                    string Previous_BlobProperty_Size;
                    string Previous_BlobProperty_MD5;
                    string Previous_SHA512;
                    string Previous_ContentType;
                    string Previous_AnonymousAccessEnabled;

                    string CompareAgainstBlob = ListContains(SnapShotList_Current, (PreviousContainer + "]2,_2_[" + PreviousBlobName));

                    //check if this is in the list of containers that should not be monitored based on baseline snapshot settings
                    bool monitorthiscontainer = true;
                    if (!(ListContains(IgnoreContainers, PreviousContainer)).Equals("N/A"))
                    {
                        monitorthiscontainer = false;
                    }

                    if (monitorthiscontainer == true)
                    {
                        if ((ListContains(BlobsToIgnore, PreviousBlobName)).Equals("N/A"))
                        {
                            if (!(CompareAgainstBlob.Equals("N/A")))
                            {
                                // Blob is new - Do nothing, this was observed in the other comparison
                            }
                            else
                            {
                                Tuple<string, string, string, string, string, string, string> PreviousBlobData = GetBlobData(PreviousBlob, Config.Settings.SnapShotFileName_Previous);

                                Previous_MonitorThisFile = (PreviousBlobData.Item1).Substring(0, ((PreviousBlobData.Item1).IndexOf(",")));
                                Previous_DownloadLocation = (PreviousBlobData.Item1).Substring(((PreviousBlobData.Item1).IndexOf(",")) + 1);
                                Previous_BlobProperty_LastModified = PreviousBlobData.Item2;
                                Previous_BlobProperty_Size = PreviousBlobData.Item3;
                                Previous_BlobProperty_MD5 = PreviousBlobData.Item4;
                                Previous_SHA512 = PreviousBlobData.Item5;
                                Previous_ContentType = PreviousBlobData.Item6;
                                Previous_AnonymousAccessEnabled = PreviousBlobData.Item7;

                                List<string> Parsed_PreviousBlobData = new List<string>();

                                Parsed_PreviousBlobData.Add(Previous_MonitorThisFile);
                                Parsed_PreviousBlobData.Add(Previous_DownloadLocation);
                                Parsed_PreviousBlobData.Add(Previous_BlobProperty_LastModified);
                                Parsed_PreviousBlobData.Add(Previous_BlobProperty_Size);
                                Parsed_PreviousBlobData.Add(Previous_BlobProperty_MD5);
                                Parsed_PreviousBlobData.Add(Previous_SHA512);
                                Parsed_PreviousBlobData.Add(Previous_ContentType);
                                Parsed_PreviousBlobData.Add(Previous_AnonymousAccessEnabled);

                                //The blob has been deleted when compared to the baseline!
                                //Add to report
                                Alerting.GenerateReport.GenerateReport_HTML_AddToSummary_Step2(PreviousBlobName, "Blob has been Deleted");
                                Alerting.GenerateReport.GenerateReport_Item_Step3_DeletedBlob(PreviousContainer, PreviousBlobName, PreviousContainer, PreviousBlobName, now.ToString(),
                                    "Blob has been Deleted", Parsed_PreviousBlobData);
                                EventFound = true;
                            }
                        }
                    }
                }
                return EventFound;
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed Compare_BaselineVsCurrent", e.ToString());
                return false;
            }
        }

        /// <summary>
        /// <para>Returns a tuple of information by parsing out only the relavent lines in a file.</para>
        /// <para>Will return: Tuple.Create(MonitorThisFile___DownloadLocation, BlobProperty_LastModified, BlobProperty_Size, BlobProperty_MD5, SHA512, ContentType, AnonymousAccessEnabled);</para>
        /// <para>Tuple (1) MonitorThisFile___DownloadLocation </para>
        /// <para>Tuple (2) BlobProperty_LastModified </para>
        /// <para>Tuple (3) BlobProperty_Size </para>
        /// <para>Tuple (4) BlobProperty_MD5 </para>
        /// <para>Tuple (5) SHA512 </para>
        /// <para>Tuple (6) ContentType </para>
        /// <para>Tuple (7) AnonymousAccessEnabled </para>
        /// </summary>
        /// <param name="currentblob"></param>
        /// <param name="SnapshotFilename"></param>
        /// <returns></returns>
        private static Tuple<string, string, string, string, string, string, string> GetBlobData(string currentblob, string SnapshotFilename)
        {
            try
            {
                Config.Settings._ReadWriteLock_Snapshot.EnterWriteLock();

                long CountLineNumber = 0;
                string line;
                string MonitorThisFile___DownloadLocation = "N/A";
                string BlobProperty_LastModified = "N/A";
                string BlobProperty_Size = "N/A";
                string BlobProperty_MD5 = "N/A";
                string SHA512 = "N/A";
                string ContentType = "N/A";
                string AnonymousAccessEnabled = "N/A";
                long linenumber;

                //First check if snapshot file already exists, and if so, if it should be over written or not
                if (File.Exists(SnapshotFilename))
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(@"" + SnapshotFilename);

                    try
                    {
                        //(monitorcontainer]1,_1_[CurrentContainer]2,_2_[blobname]3,_3_[LineNumber)
                        linenumber = Convert.ToInt64(currentblob.Substring((currentblob.IndexOf("]3,_3_[")) + 7));
                        bool done = false;
                        while (((line = file.ReadLine()) != null) && (done == false))
                        {
                            CountLineNumber = CountLineNumber + 1;

                            if (CountLineNumber == (linenumber + 1)) //<Name>
                            {
                                // name can be grabbed from the "currentblob" string variable
                            }
                            else if (CountLineNumber == (linenumber + 2)) //<MonitorThisFile>
                            {
                                MonitorThisFile___DownloadLocation = ParseXMLContent(line);
                            }
                            else if (CountLineNumber == (linenumber + 3)) //<BlobProperty_LastModified>
                            {
                                BlobProperty_LastModified = ParseXMLContent(line);
                            }
                            else if (CountLineNumber == (linenumber + 4)) //<BlobProperty_Size>
                            {
                                BlobProperty_Size = ParseXMLContent(line);
                            }
                            else if (CountLineNumber == (linenumber + 5)) //<BlobProperty_MD5>
                            {
                                BlobProperty_MD5 = ParseXMLContent(line);
                            }
                            else if (CountLineNumber == (linenumber + 6)) //<SHA512>
                            {
                                SHA512 = ParseXMLContent(line);
                            }
                            else if (CountLineNumber == (linenumber + 7)) //<ContentType>
                            {
                                ContentType = ParseXMLContent(line);
                            }
                            else if (CountLineNumber == (linenumber + 8)) //<DownloadLocation>
                            {
                                MonitorThisFile___DownloadLocation = MonitorThisFile___DownloadLocation + "," + ParseXMLContent(line);
                            }
                            else if (CountLineNumber == (linenumber + 9)) //<AnonymousAccessEnabled>
                            {
                                AnonymousAccessEnabled = ParseXMLContent(line);
                            }
                            else if (CountLineNumber == (linenumber + 10)) //Done!
                            {
                                done = true;
                            }
                            else
                            {
                                //skip lines
                            }
                        }
                        return Tuple.Create(MonitorThisFile___DownloadLocation, BlobProperty_LastModified, BlobProperty_Size, BlobProperty_MD5, SHA512, ContentType, AnonymousAccessEnabled);
                    }
                    catch (Exception e)
                    {
                        Alerting.ErrorLogging.WriteTo_Log("Failed GetBlobData", e.ToString());
                        return Tuple.Create(MonitorThisFile___DownloadLocation, BlobProperty_LastModified, BlobProperty_Size, BlobProperty_MD5, SHA512, ContentType, AnonymousAccessEnabled);
                    }
                    finally
                    {
                        file.Close();
                    }
                }
                else
                {
                    Alerting.ErrorLogging.WriteTo_Log("Failed GetBlobData", "Current Snapshot Not Found");
                    return Tuple.Create(MonitorThisFile___DownloadLocation, BlobProperty_LastModified, BlobProperty_Size, BlobProperty_MD5, SHA512, ContentType, AnonymousAccessEnabled);
                }
            }
            finally
            {
                Config.Settings._ReadWriteLock_Snapshot.ExitWriteLock();
            }
        }

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
            catch(Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed ParseXMLContent", e.ToString());
                return "N/A";
            }
        }

        /// <summary>
        /// A for loop appears to be faster than a list.contains - Returns "N/A" if not found in list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string ListContains(List<string> list, string value)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Contains(value))
                {
                    return list[i];
                }
            }
            return "N/A";
        }

        /// <summary>
        /// <para>Converts the Blob Snapshot XML file into a list</para>
        /// <para>______________________________________________________________________________________________________________________________</para>
        /// <para>|        [0]                       [1]                    [2]                 </para>
        /// <para>|[0] (monitorcontainer]1,_1_[CurrentContainer]2,_2_[blobname]3,_3_[LineNumber) (monitorcontainer]1,_1_[CurrentContainer]2,_2_[blobname]3,_3_[LineNumber) (monitorcontainer]1,_1_[CurrentContainer]2,_2_[blobname]3,_3_[LineNumber)</para>
        /// <para>|_____________________________________________________________________________________________________________________________</para>
        /// <para>Then returns that list</para>
        /// </summary>
        /// <returns>Blob Snapshot XML file into a list</returns>
        public static List<string> ParseSnapshot(string SnapshotFilename)
        {
            try
            {
                Config.Settings._ReadWriteLock_Snapshot.EnterWriteLock();

                List<string> ContainerName_BlobName_LineNumber = new List<string>();
                int CountLineNumber = 0;
                //First check if snapshot file already exists, and if so, if it should be over written or not
                if (File.Exists(SnapshotFilename))
                {
                    //choosing to read the xmlfile line by line instead of XML readers to preserve memory
                    //just in case the xml file is huge, reducing the footprint of the tool.
                    string line;
                    string monitorcontainer = "True";
                    string CurrentContainer = "N/A";

                    System.IO.StreamReader file = new System.IO.StreamReader(@"" + SnapshotFilename);

                    try
                    {
                        while ((line = file.ReadLine()) != null)
                        {
                            string blobname = "N/A";
                            CountLineNumber = CountLineNumber + 1;

                            if (line.Contains("<Container Name="))
                            {
                                CurrentContainer = GetContainerName(line);
                            }
                            else if (line.Contains("<MonitorThisContainer>"))
                            {
                                monitorcontainer = ParseXMLContent(line);
                            }
                            else if (line.Contains("<Blob Name="))
                            {
                                blobname = GetBlobName(line);
                                //(monitorcontainer]1,_1_[CurrentContainer]2,_2_[blobname]3,_3_[LineNumber)
                                ContainerName_BlobName_LineNumber.Add(monitorcontainer + "]1,_1_[" + CurrentContainer + "]2,_2_[" + blobname + "]3,_3_[" + Convert.ToString(CountLineNumber));
                            }
                        }
                        return ContainerName_BlobName_LineNumber;
                    }
                    catch (Exception e)
                    {
                        Alerting.ErrorLogging.WriteTo_Log("Failed ConfigFile_Snapshot", e.ToString());
                        return ContainerName_BlobName_LineNumber;
                    }
                    finally
                    {
                        file.Close();
                    }
                }
                else
                {
                    Alerting.ErrorLogging.WriteTo_Log("Failed ConfigFile_Snapshot", "Current Snapshot Not Found");
                    return ContainerName_BlobName_LineNumber;
                }
            }
            finally
            {
                Config.Settings._ReadWriteLock_Snapshot.ExitWriteLock();
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
            catch(Exception e)
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
        public static string GetBlobName(string line)
        {
            try
            {
                if (line.Contains("<Blob Name="))
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
                Alerting.ErrorLogging.WriteTo_Log("Failed GetBlobName", e.ToString());
                return "N/A";
            }
        }
    }
}
