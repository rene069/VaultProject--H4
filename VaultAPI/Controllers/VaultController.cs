using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;
using System;
using static System.Net.Mime.MediaTypeNames;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace VaultAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaultController : ControllerBase
    {

        private readonly IFileEncryption _fileEncryption;
        private IWebHostEnvironment hostingEnv;

        public VaultController(IFileEncryption fileEncryption, IWebHostEnvironment env)
        {
            this.hostingEnv = env;
            _fileEncryption = fileEncryption;
        }

        [HttpPost]
        [Route("EncryptFile")]
        public IActionResult Encrypt(IFormFile file, string password)
        {
            string path = Path.Combine(hostingEnv.ContentRootPath, "Files", "Encrypted.txt");
            try
            {
                _fileEncryption.EncryptFile(file, password, path);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }           
        }
        [HttpPost]
        [Route("DecryptFile")]
        public IActionResult DecryptFile(IFormFile file, string password)
        {
            string path = Path.Combine(hostingEnv.ContentRootPath, "Files", "Decrypted.txt");
            try
            {
                // Decrypt the file
                _fileEncryption.DecryptFile(file, password, path);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
