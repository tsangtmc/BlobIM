using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

// you need the azure SDK "https://www.nuget.org/packages/WindowsAzure.Storage/" 
// you need the azure active diretory sdk https://www.nuget.org/packages/Microsoft.IdentityModel.Clients.ActiveDirectory/

namespace BlobIDS_Worker.BlobStorage
{
    class Metadata_PageBlob
    {
        /// <summary>
        /// Returns a String value of the blob's MD5 Metadata Property.
        /// </summary>
        /// <param name="listBlobItem">Consumes Microsoft.WindowsAzure.StorageClient.CloudBlockBlob</param>
        /// <returns>Returns string of blob's MD5, Will return "N/A" if getting the blob metadata was unsuccessful</returns>
        public static string GetBlob_MD5(CloudPageBlob listBlobItem)
        {
            try
            {
                var md5 = listBlobItem.Properties.ContentMD5;
                string Smd5 = Convert.ToString(md5);
                if (Smd5.Length < 1)
                {return "N/A";}
                return XmlConvert.EncodeName(Smd5);
            }
            catch
            {
                return "N/A";
            }
        }
        /// <summary>
        /// Returns a String value of the blob's Name Metadata Property.
        /// </summary>
        /// <param name="listBlobItem">Consumes Microsoft.WindowsAzure.StorageClient.CloudBlockBlob</param>
        /// <returns>Returns string of blob's Name, Will return "N/A" if getting the blob metadata was unsuccessful</returns>
        public static string GetBlob_Name(CloudPageBlob listBlobItem)
        {
            try
            {
                var name = listBlobItem.Name;
                string Sname = Convert.ToString(name);
                if (Sname.Length < 1)
                { return "N/A"; }
                return XmlConvert.EncodeName(Sname);
            }
            catch
            {
                return "N/A";
            }
        }
        /// <summary>
        /// Returns a String value of the blob's Size Metadata Property.
        /// </summary>
        /// <param name="listBlobItem">Consumes Microsoft.WindowsAzure.StorageClient.CloudBlockBlob</param>
        /// <returns>Returns string of blob's Size in Bytes, Will return "N/A" if getting the blob metadata was unsuccessful</returns>
        public static string GetBlob_Size(CloudPageBlob listBlobItem)
        {
            try
            {
                var size = listBlobItem.Properties.Length;
                string Ssize = Convert.ToString(size);
                if (Ssize.Length < 1)
                { return "N/A"; }
                return XmlConvert.EncodeName(Ssize);
            }
            catch
            {
                return "N/A";
            }
        }
        /// <summary>
        /// Returns a String value of the blob's ContentType Metadata Property.
        /// </summary>
        /// <param name="listBlobItem">Consumes Microsoft.WindowsAzure.StorageClient.CloudBlockBlob</param>
        /// <returns>Returns string of blob's Content Type, Will return "N/A" if getting the blob metadata was unsuccessful</returns>
        public static string GetBlob_ContentType(CloudPageBlob listBlobItem)
        {
            try
            {
                var ContentType = listBlobItem.Properties.ContentType;
                string SContentType = Convert.ToString(ContentType);
                if (SContentType.Length < 1)
                { return "N/A"; }
                return XmlConvert.EncodeName(SContentType); 
            }
            catch
            {
                return "N/A";
            }
        }
        /// <summary>
        /// Returns a String value of the blob's DownloadLocation Metadata Property.
        /// </summary>
        /// <param name="listBlobItem">Consumes Microsoft.WindowsAzure.StorageClient.CloudBlockBlob</param>
        /// <returns>Returns string of blob's download location, Will return "N/A" if getting the blob metadata was unsuccessful</returns>
        public static string GetBlob_DownloadLocation(CloudPageBlob listBlobItem)
        {
            try
            {
                var DownloadLocation = listBlobItem.Uri;
                string SDownloadLocation = Convert.ToString(DownloadLocation);
                if (SDownloadLocation.Length < 1)
                { return "N/A"; }
                return XmlConvert.EncodeName(SDownloadLocation);
            }
            catch
            {
                return "N/A";
            }
        }

        /// <summary>
        /// Returns a String value of the blob's Last Modified Date in UTC.
        /// </summary>
        /// <param name="listBlobItem">Consumes Microsoft.WindowsAzure.StorageClient.CloudBlockBlob</param>
        /// <returns>Returns string of blob's Last Modified Date in UTC, Will return "N/A" if getting the blob metadata was unsuccessful</returns>
        public static string GetBlob_LastModifiedUtc(CloudPageBlob listBlobItem)
        {
            try
            {
                var LastModifiedUtc = listBlobItem.Properties.LastModifiedUtc;
                string SLastModifiedUtc = Convert.ToString(LastModifiedUtc);
                if (SLastModifiedUtc.Length < 1)
                { return "N/A"; }
                return XmlConvert.EncodeName(SLastModifiedUtc);
            }
            catch
            {
                return "N/A";
            }
        }


        /// <summary>
        /// Returns a String value of the Containers name Metadata Property.
        /// </summary>
        /// <param name="container">Consumes Microsoft.WindowsAzure.StorageClient.CloudBlobContainer</param>
        /// <returns>Returns string of container's name, Will return "N/A" if getting the blob metadata was unsuccessful</returns>
        public static string GetContainer_Name(CloudBlobContainer container)
        {
            try
            {
                var name = container.Name;
                string Sname = Convert.ToString(name);
                if (Sname.Length < 1)
                { return "N/A"; }
                return XmlConvert.EncodeName(Sname);
            }
            catch
            {
                return "N/A";
            }
        }

        /// Returns a String value of the Containers name Metadata Property.
        /// </summary>
        /// <param name="container">Consumes Microsoft.WindowsAzure.StorageClient.CloudBlobContainer</param>
        /// <returns>Returns string of container's name, Will return "N/A" if getting the blob metadata was unsuccessful</returns>
        public static string GetContainer_Name_Raw(CloudBlobContainer container)
        {
            try
            {
                var name = container.Name;
                string Sname = Convert.ToString(name);
                if (Sname.Length < 1)
                { return "N/A"; }
                return Sname;
            }
            catch
            {
                return "N/A";
            }
        }
    }
}
