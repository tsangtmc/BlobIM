using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;

namespace BlobIDS_Worker.BlobStorage
{
    class Logs
    {
        /// <summary>
        /// Enable logging for storage account
        /// </summary>
        /// <param name="accountname"></param>
        /// <param name="accountkey"></param>
        /// <param name="SnapshotFileName"></param>
        public static void EnableLogging(string accountname, string accountkey, string SnapshotFileName)
        {
            Microsoft.WindowsAzure.Storage.CloudStorageAccount storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=" + accountname + ";AccountKey=" + accountkey);

            //var queueClient = storageAccount.CreateCloudQueueClient();
            var blobClient = storageAccount.CreateCloudBlobClient();
            var serviceProperties = blobClient.GetServiceProperties();

            serviceProperties.Logging.LoggingOperations = Microsoft.WindowsAzure.Storage.Shared.Protocol.LoggingOperations.All;
            serviceProperties.Logging.RetentionDays = 2;

            blobClient.SetServiceProperties(serviceProperties);
        }

        public static void DownloadLogs()
        {
           // AzCopy 
        }
    }
}
