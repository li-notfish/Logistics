using CommunityToolkit.Maui;
using Logistics.AppClient.Pages;
using Logistics.AppClient.ViewModels;
using Logistics.Shared.Service;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace Logistics.AppClient {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseBarcodeReader()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .Services
                    .AddTransient<MainPage>()
                    .AddTransient<BarcodeReaderView>()
                    .AddTransient<OrderDetail>()
                    .AddTransient<NewOrderPage>()
                    .AddTransient<ExpressPage>()
                    .AddScoped<MePage>()
                    .AddScoped<LoginPage>()
                    .AddTransient<MeDetailPage>()
                    .AddTransient<DeliveryHome>()
                    .AddTransient<LoginViewModel>()
                    .AddTransient<MainViewModel>()
                    .AddTransient<MeViewModel>()
                    .AddTransient<ExpressViewModel>()
                    .AddTransient<NewOrderViewModel>()
                    .AddTransient<DeliveryHomeViewModel>()
                    .AddTransient<OrderDetailViewModel>()
                    .AddTransient<BarcodeReaderViewModel>()
                    .AddTransient<MeDetailViewModel>()
                    .AddTransient<IDeliveryService, DeliveryService>()
                    .AddScoped<IOrderService,OrderService>()
                    .AddScoped<IUserService,UserService>()
                    .AddScoped<IAuthService,AuthService>()
                    .AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://logisticscore20230322160309.azurewebsites.net/") }); ;

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}