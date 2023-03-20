using Logistics.Core.Context;
using Logistics.Core.Service.Admin;
using Logistics.Core.Service.Auth;
using Logistics.Core.Service.Deliveries;
using Logistics.Core.Service.Orders;
using Logistics.Core.Service.Users;
using Logistics.Core.Service.WarehouseGoodes;
using Logistics.Shared.Model;
using Logistics.Core.Hubs;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.ResponseCompression;

namespace Logistics.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<LogisticsContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("LogisticsConnection");
                options.UseSqlite(connectionString);
            });
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            //SignalRÒýÈë
            builder.Services.AddSignalR();
            builder.Services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IDeliveryService, DeliveryService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IWarehouseService, WarehouseService>();
            builder.Services.AddScoped<IGoodsService, GoodsService>();

            var app = builder.Build();
            app.UseResponseCompression();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            //app.MapRazorPages();
            app.MapControllers();
            app.MapHub<SendOrderHub>("/sendorderhub");
            app.Run();
        }
    }
}