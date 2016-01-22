using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

// you need the azure SDK "https://www.nuget.org/packages/WindowsAzure.Storage/" 
// you need the azure active diretory sdk https://www.nuget.org/packages/Microsoft.IdentityModel.Clients.ActiveDirectory/

namespace BlobIDS_Worker.Snapshot
{
    class Generate
    {
        /// <summary>
        /// Generates a Snapshot of blobs in blob storage, XML config file will include info such as:
        ///<para> • Account - specific account being monitored </para>
        ///<para> • Container - name of the container</para>
        ///<para> • Name - name of the file/blob</para>
        ///<para> • MonitorThisFile - This setting controls if a file/blob should be monitored</para>
        ///<para> • BlobProperty_LastModified - METADATA of the blob of when it was last modifed, note metadata can be altered freely in blob storage</para>
        ///<para> • BlobProperty_Size - METADATA of size in bytes of the file/blob, note metadata can be altered freely in blob storage</para>
        ///<para> • BlobProperty_MD5 - METADATA of the blob of its md5 checksum, note metadata can be altered freely in blob storage</para>
        ///<para> • SHA512 - This is calculated when snapshot is created, files/blobs are downloaded and SHA512 is calculated</para>
        ///<para> • ContentType - METADATA of the blob of data type, note metadata can be altered freely in blob storage</para>
        ///<para> • DownloadLocation - The url to download the file/blob</para>
        ///<para> • AnonymousAccessEnabled - This shows it if was possible to anonymously download the blob at the time of snapshot creation</para>
        /// </summary>
        /// <param name="accountname"></param>
        /// <param name="accountkey"></param>
        public static void ConfigFile_Snapshot(string BlobEndpoint, string accountname, string accountkey, string SnapshotFileName, bool isbaseline, bool ispermissionscheck)
        {
            try
            {
                List<string> MonitorContainers = new List<string>();
                List<string> SnapShotList_Baseline;
                int BaseLineListCount;

                //Generate a list of containers from the baseline snapshot to use to check if the container should be monitored
                if ((isbaseline == false) && ( ispermissionscheck == false ))
                {
                    SnapShotList_Baseline = Compare.ParseSnapshot(Config.Settings.SnapShotFileName_Baseline);
                    BaseLineListCount = SnapShotList_Baseline.Count();
                    for (int i = 0; i < BaseLineListCount; i++)
                    {
                        string BaselineBlob = SnapShotList_Baseline[i]; //(monitorcontainer]1,_1_[CurrentContainer]2,_2_[blobname]3,_3_[LineNumber)
                        string monitorcontainer = BaselineBlob.Substring(0, BaselineBlob.IndexOf("]1,_1_[")); // true or fase if container should be monitored
                        string BaselineContainer = BaselineBlob.Substring(0, BaselineBlob.IndexOf("]2,_2_["));
                        BaselineContainer = BaselineContainer.Substring((BaselineContainer.IndexOf("]1,_1_[")) + 7);
                        if ((monitorcontainer.ToLower()).Contains("false"))
                        {
                            MonitorContainers.Add(BaselineContainer);
                        }
                    }
                }

                if (DoNoOverwrite_Check(SnapshotFileName) == false)
                {
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("BlobEndpoint=https://" + accountname + "."+BlobEndpoint + ";DefaultEndpointsProtocol=https;AccountName=" + accountname + ";AccountKey=" + accountkey);
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    IEnumerable<CloudBlobContainer> containers = blobClient.ListContainers();
                    List<CloudBlob> blobsArray = new List<CloudBlob>();

                    XmlWriterSettings settings = new XmlWriterSettings();
                    //this will auto indent as well as put everything on a new line
                    settings.Indent = true;

                    using (XmlWriter writer = XmlWriter.Create(SnapshotFileName, settings))
                    {
                        //Inital information for the general config file
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Shapshot");
                        DateTime now = DateTime.Now;
                        writer.WriteAttributeString("DoNotOverwrite", "False");
                        writer.WriteAttributeString("Created", Convert.ToString(now));

                        //Acount information
                        writer.WriteStartElement("Account");
                        writer.WriteAttributeString("Name", accountname);

                        foreach (CloudBlobContainer container in containers)
                        {
                            /*
                            IEnumerable<Microsoft.WindowsAzure.StorageClient.IListBlobItem> blobs = container.ListBlobs(new BlobRequestOptions()
                            {
                                BlobListingDetails = BlobListingDetails.All,
                                UseFlatBlobListing = true,
                            }).Cast<Microsoft.WindowsAzure.StorageClient.CloudBlockBlob>();
                            */

                            //Container Information
                            writer.WriteStartElement("Container");
                            writer.WriteAttributeString("Name", BlobStorage.Metadata_BlockBlob.GetContainer_Name(container));
                           
                            //monitor container (true or false)
                            writer.WriteElementString("MonitorThisContainer", "True");
                            
                            //do a check if the current container is marked as true or false for monitoring in the baseline snapshot
                            bool monitorthiscontainer = true;
                            if (isbaseline == false)
                            {
                                for (int x = 0; x < MonitorContainers.Count; x++)
                                {
                                    if (MonitorContainers[x].Contains(BlobStorage.Metadata_BlockBlob.GetContainer_Name(container)))
                                    {
                                        monitorthiscontainer = false;
                                    }
                                }
                            }

                            //iterate over all the blobs in the container
                            if (monitorthiscontainer == true)
                            {
                                foreach (IListBlobItem listBlobItem in container.ListBlobs(new BlobRequestOptions()
                                        {
                                            BlobListingDetails = BlobListingDetails.All,
                                            UseFlatBlobListing = true,
                                        }) 
                                )
                                {
                                    /*
                                     * The storage service offers three types of blobs, block blobs, append blobs, and page blobs. 
                                     * You specify the blob type when you create the blob. Once the blob has been created, its type cannot be changed, 
                                     * and it can be updated only by using operations appropriate for that blob type, 
                                     * i.e., writing a block or list of blocks to a block blob, appending blocks to a append blob, and writing pages to a page blob. 
                                     */

                                    //Block Blob
                                    if (listBlobItem.GetType() == typeof(CloudBlockBlob))
                                    {
                                        CloudBlockBlob blob = (CloudBlockBlob)listBlobItem;
                                        string blobname = BlobStorage.Metadata_BlockBlob.GetBlob_Name(blob);
                                        string BlobSize = BlobStorage.Metadata_BlockBlob.GetBlob_Size(blob);
                                        string downloadpath = BlobStorage.Metadata_BlockBlob.GetBlob_DownloadLocation(blob);
                                        writer.WriteStartElement("Blob");
                                        writer.WriteAttributeString("Name", blobname);
                                        writer.WriteElementString("Name", blobname);
                                        writer.WriteElementString("MonitorThisFile", "True");
                                        writer.WriteElementString("BlobProperty_LastModified", BlobStorage.Metadata_BlockBlob.GetBlob_LastModifiedUtc(blob));
                                        writer.WriteElementString("BlobProperty_Size", BlobSize);
                                        writer.WriteElementString("BlobProperty_MD5", BlobStorage.Metadata_BlockBlob.GetBlob_MD5(blob));
                                        writer.WriteElementString("SHA512", BlobStorage.Signature.CalculateBlockBlob_SHA512(blob, (ConvertToInt64(XmlConvert.DecodeName(BlobSize)))));
                                        writer.WriteElementString("ContentType", BlobStorage.Metadata_BlockBlob.GetBlob_ContentType(blob));
                                        writer.WriteElementString("DownloadLocation", downloadpath);
                                        writer.WriteElementString("AnonymousAccessEnabled", Convert.ToString(BlobStorage.CheckFileAccess.Anonymous_BlobStorageFile(XmlConvert.DecodeName(downloadpath))));
                                        writer.WriteEndElement(); // blob
                                        //try to find a way to read only certain bytes from a blob to try to do a signature check on those... problem
                                        //is however that something like this has to be done in the blob storage itself which is not possibe. To check 
                                        //certain bytes you would have to download the whole file over the wire anyway...

                                        //for big files... it would have to be a very superficial check based on metadata properties or something of the sort...
                                    }
                                    else if (listBlobItem.GetType() == typeof(CloudPageBlob))
                                    {
                                        CloudPageBlob pageBlob = (CloudPageBlob)listBlobItem;
                                        string blobname = BlobStorage.Metadata_PageBlob.GetBlob_Name(pageBlob);
                                        string BlobSize = BlobStorage.Metadata_PageBlob.GetBlob_Size(pageBlob);
                                        string downloadpath = BlobStorage.Metadata_PageBlob.GetBlob_DownloadLocation(pageBlob);
                                        writer.WriteStartElement("Blob");
                                        writer.WriteAttributeString("Name", blobname);
                                        writer.WriteElementString("Name", blobname);
                                        writer.WriteElementString("MonitorThisFile", "True");
                                        writer.WriteElementString("BlobProperty_LastModified", BlobStorage.Metadata_PageBlob.GetBlob_LastModifiedUtc(pageBlob));
                                        writer.WriteElementString("BlobProperty_Size", BlobSize);
                                        writer.WriteElementString("BlobProperty_MD5", BlobStorage.Metadata_PageBlob.GetBlob_MD5(pageBlob));
                                        writer.WriteElementString("SHA512", BlobStorage.Signature.CalculatePageBlob_SHA512(pageBlob, (ConvertToInt64(XmlConvert.DecodeName(BlobSize)))));
                                        writer.WriteElementString("ContentType", BlobStorage.Metadata_PageBlob.GetBlob_ContentType(pageBlob));
                                        writer.WriteElementString("DownloadLocation", downloadpath);
                                        writer.WriteElementString("AnonymousAccessEnabled", Convert.ToString(BlobStorage.CheckFileAccess.Anonymous_BlobStorageFile(XmlConvert.DecodeName(downloadpath))));
                                        writer.WriteEndElement();
                                        Console.WriteLine("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri);
                                    }
                                    else if (listBlobItem.GetType() == typeof(CloudBlobDirectory))
                                    {
                                        CloudBlobDirectory directory = (CloudBlobDirectory)listBlobItem;
                                        Alerting.ErrorLogging.WriteTo_Log("ConfigFile_Snapshot - Could Not Read CloudBlobDirectory as a Blob: ", directory.ToString());
                                        Console.WriteLine("Directory: {0}", directory.Uri);
                                    }
                                }
                            }
                            writer.WriteEndElement(); // container
                        }
                        writer.WriteEndElement(); // account
                        writer.WriteEndElement(); // snapshot
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                    }
                }
            }
            catch(Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed ConfigFile_Snapshot", e.ToString());
            }
        }


        /// <summary>
        /// will return a int64 converted datatype of a string, if not possible return -1
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static long ConvertToInt64(string number)
        {
            try
            {
                return(Convert.ToInt64(number));
            }
            catch
            {
                return -1;
            }
        }

        public static bool DoNoOverwrite_Check(string SnapshotFileName)
        {
            //First check if snapshot file already exists, and if so, if it should be over written or not
            if (File.Exists(SnapshotFileName))
            {
                try
                {
                    Config.Settings._ReadWriteLock_Snapshot.EnterWriteLock();

                    //choosing to read the xmlfile line by line instead of XML readers to preserve memory
                    //just in case the xml file is huge, reducing the footprint of the tool.
                    string line;
                    System.IO.StreamReader file = new System.IO.StreamReader(@"" + SnapshotFileName);

                    //Looking for <Shapshot DoNotOverwrite="True" 
                    try
                    {
                        while ((line = file.ReadLine()) != null)
                        {
                            if ((line.ToLower()).Contains("<Shapshot DoNotOverwrite".ToLower()))
                            {
                                if ((line.ToLower()).Contains("True".ToLower()))
                                {
                                    return true;
                                }
                                else if ((line.ToLower()).Contains("False".ToLower()))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        Alerting.ErrorLogging.WriteTo_Log("Failed DoNotOverwrite_Check", e.ToString());
                    }
                    finally
                    {
                        file.Close();
                    }
                }
                finally
                {
                    Config.Settings._ReadWriteLock_Snapshot.ExitWriteLock();
                }
            }
            return false;
        }
    }
}
