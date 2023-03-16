﻿using CommunityToolkit.Maui;
using Logistics.AppClient.Pages;
using Logistics.AppClient.ViewModels;
using Logistics.Shared.Service;
using Microsoft.Extensions.Logging;

namespace Logistics.AppClient {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .Services
                    .AddScoped<MainPage>()
                    .AddScoped<NewOrderPage>()
                    .AddScoped<ExpressPage>()
                    .AddScoped<MePage>()
                    .AddScoped<MainViewModel>()
                    .AddScoped<MeViewModel>()
                    .AddScoped<ExpressViewModel>()
                    .AddScoped<NewOrderViewModel>()
                    .AddScoped<IOrderService,OrderService>()
                    .AddScoped<IUserService,UserService>()
                    .AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5173/") }); ;

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}