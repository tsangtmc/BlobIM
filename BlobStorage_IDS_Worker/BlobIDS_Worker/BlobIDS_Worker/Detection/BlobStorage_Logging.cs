using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BlobIDS_Worker.Detection
{
    class BlobStorage_Logging
    {
        public static void Enable(string accountname, string accountkey)
        {
            Microsoft.WindowsAzure.Storage.CloudStorageAccount storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=" + accountname + ";AccountKey=" + accountkey);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            var serviceProperties = blobClient.GetServiceProperties();
            //var queueClient = storageAccount.CreateCloudQueueClient();
            //var serviceProperties = queueClient.GetServiceProperties();

            serviceProperties.Logging.LoggingOperations = Microsoft.WindowsAzure.Storage.Shared.Protocol.LoggingOperations.All; 
            serviceProperties.Logging.RetentionDays = 2;

            blobClient.SetServiceProperties(serviceProperties);
        }
    }
}
