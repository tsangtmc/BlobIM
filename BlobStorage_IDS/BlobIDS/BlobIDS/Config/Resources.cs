using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BlobIDS.Config
{
    class Resources
    {
        public static void ExtractAllResources()
        {
            WriteResourceToFile("BlobIDS.Resources.logo.ico", "logo.ico");
            WriteResourceToFile("BlobIDS.Resources.Microsoft.Data.Services.Client.dll", "Microsoft.Data.Services.Client.dll");
            WriteResourceToFile("BlobIDS.Resources.Microsoft.WindowsAzure.Storage.dll", "Microsoft.WindowsAzure.Storage.dll");
            WriteResourceToFile("BlobIDS.Resources.Microsoft.WindowsAzure.StorageClient.dll", "Microsoft.WindowsAzure.StorageClient.dll");
            WriteResourceToFile("BlobIDS.Resources.BlobIM_Worker.exe", "BlobIM_Worker.exe");
            WriteResourceToFile("BlobIDS.Resources.BIM_Settings.exe", "BIM_Settings.exe");
        }
        public static void WriteResourceToFile(string resourceName, string fileName)
        {
            try
            {
                using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    {
                        resource.CopyTo(file);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
