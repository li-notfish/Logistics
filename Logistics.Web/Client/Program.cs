using Logistics.Shared.Service;
using Logistics.Shared.Service.WarehouseGoodsServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Logistics.Web {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            // Add services to the container.
            builder.Services.AddMasaBlazor();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5173/") });
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<IDeliveryService, DeliveryService>();
            builder.Services.AddScoped<IGoodsService, GoodsService>();
            builder.Services.AddScoped<IWarehouseService, WarehouseService>();
            await builder.Build().RunAsync();
        }
    }
}