using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BlobIDS_Worker.Config
{
    class DPAPI
    {
        //https://msdn.microsoft.com/en-us/library/ms229741%28v=vs.110%29.aspx
        //https://msdn.microsoft.com/en-us/library/2fh8203k%28v=vs.110%29.aspx

        // Create byte array for additional entropy when using Protect method.
        static byte[] s_aditionalEntropy = { 9, 8, 7, 6, 5 };
        private static byte[] Protect(byte[] data)
        {
            try
            {
                // Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
                //  only by the same current user.
                return ProtectedData.Protect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed To DPAPI Protect Secret", e.ToString());
                return null;
            }
        }

        private static byte[] Unprotect(byte[] data)
        {
            try
            {
                //Decrypt the data using DataProtectionScope.CurrentUser.
                return ProtectedData.Unprotect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed To DPAPI Un-Protect Secret", e.ToString());
                return null;
            }
        }

        public static string Encrypt(string secret)
        {
            try
            {
                var secret_bytes = Encoding.Unicode.GetBytes(secret);
                byte[] encrypted_secret_bytes = Protect(secret_bytes);
                return Convert.ToBase64String(encrypted_secret_bytes);
            }
            catch (CryptographicException e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed To Encrypt Secret", e.ToString());
                return null;
            }

        }

        public static string Decrypt(string Base64Encoded_secret)
        {
            try
            {
                byte[] encrypted_secret_bytes = Convert.FromBase64String(Base64Encoded_secret);
                var secret_bytes = Unprotect(encrypted_secret_bytes);
                return Encoding.Unicode.GetString(secret_bytes);
            }
            catch (CryptographicException e)
            {
                Alerting.ErrorLogging.WriteTo_Log("Failed To Decrypt Secret", e.ToString());
                return null;
            }

        }
    }
}
