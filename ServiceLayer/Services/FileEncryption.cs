using Microsoft.AspNetCore.Http;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ServiceLayer.Services
{
    public class FileEncryption : IFileEncryption
    {

        public void EncryptFile(IFormFile file, string password, string outputpath)
        {

            AesManaged aes = new AesManaged();


            //set the key and IV (initialization vector) from the password
            byte[] key = Encoding.UTF8.GetBytes(password);
            byte[] iv = Encoding.UTF8.GetBytes(password);
            aes.Key = key;
            aes.IV = iv;

 
            // open the file for reading

            using(var input = file.OpenReadStream())
            {
                // create a new file for writing the encrypted data
                using(var output = new FileStream(outputpath, FileMode.Create, FileAccess.Write))
                {
                    // create a cryptostream to encrypt data
                    using (var cryptoStream = new CryptoStream(output, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        // read the data from the input file and write it to the output file
                        input.CopyTo(cryptoStream);
                    }
                }
            }
        }

        public void DecryptFile(IFormFile file, string password, string outputpath)
        {
            // Create a new instance of the RijndaelManaged class
            AesManaged aes = new AesManaged();

            // Set the key and IV from the password
            byte[] key = Encoding.UTF8.GetBytes(password);
            byte[] iv = Encoding.UTF8.GetBytes(password);
            aes.Key = key;
            aes.IV = iv;

            // Open the encrypted file for reading
            using (var input = file.OpenReadStream())
            {
                // Create a new file for writing the decrypted data
                using (var output = new FileStream(outputpath, FileMode.Create, FileAccess.Write))
                {
                    // Create a CryptoStream to decrypt the data
                    using (var cryptoStream = new CryptoStream(input, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        // Read the data from the input file and write it to the output file
                        cryptoStream.CopyTo(output);
                    }
                }
            }
        }

        
    }
}
