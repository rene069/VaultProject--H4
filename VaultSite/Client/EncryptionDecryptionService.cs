using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace VaultSite.Client
{
    public class EncryptionDecryptionService
    {
        private readonly HttpClient _httpClient;

        public EncryptionDecryptionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> EncryptFile(Stream fileStream, string password)
        {
            var json = JsonSerializer.Serialize(new { File = fileStream, Password = password });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/encrypt", content);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DecryptFile(Stream fileStream, string password)
        {
            var json = JsonSerializer.Serialize(new { File = fileStream, Password = password });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/decrypt", content);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

    }

}
