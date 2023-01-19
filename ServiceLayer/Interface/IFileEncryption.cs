using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IFileEncryption
    {
        void EncryptFile(IFormFile file, string password, string outputpath);

        void DecryptFile(IFormFile file, string password, string outputpath);

    }
}
