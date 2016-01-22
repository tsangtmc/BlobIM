using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

// you need the azure SDK "https://www.nuget.org/packages/WindowsAzure.Storage/" 
// you need the azure active diretory sdk https://www.nuget.org/packages/Microsoft.IdentityModel.Clients.ActiveDirectory/


namespace BlobIDS_Worker.BlobStorage
{
    class Access
    {
        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        /// <summary>
        /// given a specific CloudBlockBlob blob, this will download the blob to a specifed location with a guid as the file name
        /// </summary>
        /// <param name="blob">Consumes Microsoft.WindowsAzure.StorageClient.CloudBlockBlob</param>
        /// <param name="LocalDownloadPath">A string of where the blob should be downloaded to</param>
        /// <returns>Returns a string of the name of the file the blob was saved to, it will be random guid</returns>
        public static string DownloadBlockBlob(CloudBlockBlob blob, string LocalDownloadPath)
        {
            try
            {
                // Create and display the value of two GUIDs.
                string filename = Guid.NewGuid().ToString();
                string contianername = blob.Container.Name;
                string blobname = blob.Name;

                if (contianername.Length > 50)
                {
                    contianername = contianername.Substring(0, 49);
                }
                if (blobname.Length > 50)
                {
                    blobname = blobname.Substring(0, 49);
                }
                filename = filename.Substring(0, 8);
                filename = filename+"_" + contianername + "_" + blobname;
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    filename = filename.Replace(c, '-');
                }
    
                using (var fileStream = System.IO.File.OpenWrite(LocalDownloadPath + "/" + filename))
                {
                    blob.DownloadToStream(fileStream);
                }
                return filename;
            }
            catch (Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed Download Blob", e.ToString());
                return "N/A";
            }
        }

        public static string DownloadPageBlob(CloudPageBlob blob, string LocalDownloadPath)
        {
            try
            {
                string filename = Guid.NewGuid().ToString();
                string contianername = blob.Container.Name;
                string blobname = blob.Name;

                if (contianername.Length > 50)
                {
                    contianername = contianername.Substring(0, 49);
                }
                if (blobname.Length > 50)
                {
                    blobname = blobname.Substring(0, 49);
                }
                filename = filename.Substring(0, 8);
                filename = filename+"_" + contianername + "_" + blobname;
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    filename = filename.Replace(c, '-');
                }

                using (var fileStream = System.IO.File.OpenWrite(LocalDownloadPath + "/" + filename))
                {
                    blob.DownloadToStream(fileStream);
                }
                return filename;
            }
            catch(Exception e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed Download Blob", e.ToString());
                return "N/A";
            }
        }

        public static void DownloadAll_ContianersAndBlobs(string accountname, string accountkey)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=" + accountname + ";AccountKey=" + accountkey);
            CloudBlobContainer blobContainer = storageAccount.CreateCloudBlobClient().GetContainerReference("pentest");

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            var containers = blobClient.ListContainers();
            List<CloudBlob> blobsArray = new List<CloudBlob>();
            foreach (var container in containers)
            {
                var blobs = container.ListBlobs(new BlobRequestOptions()
                {
                    BlobListingDetails = BlobListingDetails.All,
                    UseFlatBlobListing = true,
                }).Cast<CloudBlockBlob>();

                Console.WriteLine("===========================================================");
                Console.WriteLine("containers: " + container.Name);

                foreach (var listBlobItem in blobs)
                {
                    Console.WriteLine("Name: " + listBlobItem.Name);
                    Console.WriteLine("Size: " + listBlobItem.Properties.Length + " / " + ConvertBytesToMegabytes(listBlobItem.Properties.Length));
                    Console.WriteLine("Content type: " + listBlobItem.Properties.ContentType);
                    Console.WriteLine("Download location: " + listBlobItem.Uri);
                    Console.WriteLine(listBlobItem.DownloadText());
                    DownloadBlockBlob(listBlobItem, "./test/");
                    Console.WriteLine(" ");
                }
            }
        }
        public static void ListAll_ContianersAndBlobs(string accountname, string accountkey)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=" + accountname + ";AccountKey=" + accountkey);
            CloudBlobContainer blobContainer = storageAccount.CreateCloudBlobClient().GetContainerReference("pentest");

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            var containers = blobClient.ListContainers();
            List<CloudBlob> blobsArray = new List<CloudBlob>();
            foreach (var container in containers)
            {
                var blobs = container.ListBlobs(new BlobRequestOptions()
                {
                    BlobListingDetails = BlobListingDetails.All,
                    UseFlatBlobListing = true,
                }).Cast<CloudBlockBlob>();

                Console.WriteLine("===========================================================");
                Console.WriteLine("containers: " + container.Name);

                foreach (var listBlobItem in blobs)
                {
                    Console.WriteLine("Name: " + listBlobItem.Name);
                    Console.WriteLine("Size: " + listBlobItem.Properties.Length);

                    // can use the md5 function to "help" check small files.. since md5 appears to be meta data you can
                    // both read and set for a blob if you have the key, you would have to download the file and then
                    // do a local md5 check of the existing file against recorded/set md5 value on the blob

                    // NEED TO DO: need to check on blob storage pricing models.. if a text read vs a file download makes
                    // a difference in pricing/costs, or if its all the same.

                     Console.WriteLine("MD5: " + listBlobItem.Properties.ContentMD5.ToString());

                    //try to find a way to read only certain bytes from a blob to try to do a signature check on those... problem
                    //is however that something like this has to be done in the blob storage itself which is not possibe. To check 
                    //certain bytes you would have to download the whole file over the wire anyway...

                    //for big files... it would have to be a very superficial check based on metadata properties or something of the sort...

                    Console.WriteLine("Content type: " + listBlobItem.Properties.ContentType);
                    Console.WriteLine("Download location: " + listBlobItem.Uri);
                    Console.WriteLine(" ");
                }
            }
        }
    }
}
