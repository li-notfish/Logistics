
using Logistics.Core.Context;
using Logistics.Core.Service.Admin;
using Logistics.Core.Service.Auth;
using Logistics.Core.Service.Car;
using Logistics.Core.Service.Delivery;
using Logistics.Core.Service.Order;
using Logistics.Core.Service.User;
using Logistics.Shared.Model;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IOrderService<Order>, OrderService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IDeliveryService, DeliveryService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}