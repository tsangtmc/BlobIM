using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BlobIDS_Worker.Config
{
    class Resources
    {
        public static void ExtractAllResources()
        {
            if (!(File.Exists("./logo.ico")))
            {
                Resources.WriteResourceToFile("BlobIDS_Worker.Resources.logo.ico", "logo.ico");
            }
            if (!(File.Exists("./Microsoft.Data.Services.Client.dll")))
            {
                Resources.WriteResourceToFile("BlobIDS_Worker.Resources.Microsoft.Data.Services.Client.dll", "Microsoft.Data.Services.Client.dll");
                //SaveResourceToFile("BlobIDS_Worker.Resources.Microsoft.Data.Services.Client.dll", "Microsoft.Data.Services.Client.dll"); 
            }
            if (!(File.Exists("./Microsoft.WindowsAzure.Storage.dll")))
            {
                Resources.WriteResourceToFile("BlobIDS_Worker.Resources.Microsoft.WindowsAzure.Storage.dll", "Microsoft.WindowsAzure.Storage.dll");
                //SaveResourceToFile("BlobIDS_Worker.Resources.Microsoft.WindowsAzure.Storage.dll", "Microsoft.WindowsAzure.Storage.dll"); 
            }
            /*
            if (!(File.Exists("./Microsoft.WindowsAzure.StorageClient.dll")))
            {
                Resources.WriteResourceToFile("BlobIDS_Worker.Resources.Microsoft.WindowsAzure.StorageClient.dll", "Microsoft.WindowsAzure.StorageClient.dll");
               //SaveResourceToFile("BlobIDS_Worker.Resources.Microsoft.WindowsAzure.StorageClient.dll", "Microsoft.WindowsAzure.StorageClient.dll"); 
            }
             * */
        }
        public static void WriteResourceToFile(string resourceName, string fileName)
        {
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    resource.CopyTo(file);
                }
            }

        }
    }
}
