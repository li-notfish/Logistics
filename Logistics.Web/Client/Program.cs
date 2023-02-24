using Logistics.Shared.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Logistics.Web {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddBootstrapBlazor();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5173/") });
            builder.Services.AddTransient<IAdminService, AdminService>();
            await builder.Build().RunAsync();
        }
    }
}