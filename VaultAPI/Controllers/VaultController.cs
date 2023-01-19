using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;

namespace VaultAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaultController : ControllerBase
    {

        private readonly IFileEncryption _fileEncryption;

        public VaultController(IFileEncryption fileEncryption)
        {
            _fileEncryption = fileEncryption;
        }

        [HttpPost]
        public IActionResult Encrypt(IFormFile file, string password)
        {
            string outputfile = Path.GetTempPath();
            try
            {
                _fileEncryption.EncryptFile(file, password, outputfile);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }           
        }

        public IActionResult DecryptFile(IFormFile file, string password)
        {
            string outputfile = Path.GetTempPath();

            try
            {
                // Decrypt the file
                _fileEncryption.DecryptFile(file, password, outputfile);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
