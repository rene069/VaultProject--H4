using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using VaultSite;
using VaultSite.Client;

namespace VaultSite
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddBlazoredToast();

            builder.Services.AddHttpClient<EncryptionDecryptionService>(config => config.BaseAddress = AppConfig.VaultAPI_BaseAdress);
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = AppConfig.VaultAPI_BaseAdress });
            
            await builder.Build().RunAsync();
        }
    }
}