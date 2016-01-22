using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.IO;
using System.Security.Cryptography;

// you need the azure SDK "https://www.nuget.org/packages/WindowsAzure.Storage/" 
// you need the azure active diretory sdk https://www.nuget.org/packages/Microsoft.IdentityModel.Clients.ActiveDirectory/

namespace BlobIDS_Worker.BlobStorage
{
    class Signature
    {
        public static string CalculateBlockBlob_SHA512(CloudBlockBlob blob, long BlobByteSize)
        {
            if ((BlobByteSize < Config.Settings.MaxDownloadSize) && (BlobByteSize > 0))
            {
                try
                {
                    string filename = BlobStorage.Access.DownloadBlockBlob(blob, Config.Settings.DownloadPath);
                    string StaticFilePath = Config.Settings.DownloadPath + filename;
                    string checksumSha512 = GetChecksum(StaticFilePath, Algorithms.SHA512);
                    DeleteFile(StaticFilePath);
                    if (checksumSha512.Equals("N/A"))
                    { return "N/A"; }
                    return checksumSha512;
                }
                catch
                {
                    return "N/A";
                }
            }
            return "N/A";
        }

        public static string CalculatePageBlob_SHA512(CloudPageBlob blob, long BlobByteSize)
        {
            if ((BlobByteSize < Config.Settings.MaxDownloadSize) && (BlobByteSize > 0))
            {
                try
                {
                    string filename = BlobStorage.Access.DownloadPageBlob(blob, Config.Settings.DownloadPath);
                    string StaticFilePath = Config.Settings.DownloadPath + filename;
                    string checksumSha512 = GetChecksum(StaticFilePath, Algorithms.SHA512);
                    DeleteFile(StaticFilePath);
                    if (checksumSha512.Equals("N/A"))
                    { return "N/A"; }
                    return checksumSha512;
                }
                catch
                {
                    return "N/A";
                }
            }
            return "N/A";
        }

        public static class Algorithms
        {
            public static readonly HashAlgorithm MD5 = new MD5CryptoServiceProvider();
            public static readonly HashAlgorithm SHA1 = new SHA1Managed();
            public static readonly HashAlgorithm SHA256 = new SHA256Managed();
            public static readonly HashAlgorithm SHA384 = new SHA384Managed();
            public static readonly HashAlgorithm SHA512 = new SHA512Managed();
            public static readonly HashAlgorithm RIPEMD160 = new RIPEMD160Managed();
        }

        /// <summary>
        ///<para> Usage:</para>
        ///<para> string path = @"C:\Folder\test.jpg";</para>
        ///<para> string checksumMd5 = GetChecksum(path, Algorithms.MD5);</para>
        ///<para> string checksumSha1 = GetChecksum(path, Algorithms.SHA1);</para>
        ///<para> string checksumSha256 = GetChecksum(path, Algorithms.SHA256);</para>
        ///<para> string checksumSha384 = GetChecksum(path, Algorithms.SHA384);</para>
        ///<para> string checksumSha512 = GetChecksum(path, Algorithms.SHA512);</para>
        ///<para> string checksumRipemd160 = GetChecksum(path, Algorithms.RIPEMD160);</para>
        /// </summary>
        /// <param name="filePath">a string representation of the file path</param>
        /// <param name="algorithm">a specific hashing algorithm</param>
        /// <returns>a string value of the checksum of the selected algorithm</returns>
        public static string GetChecksum(string filePath, HashAlgorithm algorithm)
        {
            try
            {
                using (var stream = new BufferedStream(File.OpenRead(filePath), 100000))
                {
                    byte[] hash = algorithm.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", String.Empty);
                }
            }
            catch
            {
                return "N/A";
            }
        }

        /// <summary>
        /// Tries to delete a file, returns true or false if successful
        /// </summary>
        /// <param name="file">string path to file</param>
        /// <returns>true or false if file could be deleted</returns>
        static bool DeleteFile(string file)
        {
            try
            {
                File.Delete(file);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

    }

}
