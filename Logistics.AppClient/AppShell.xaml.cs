using Logistics.AppClient.Pages;
using Logistics.AppClient.ViewModels;

namespace Logistics.AppClient {
    public partial class AppShell : Shell {
        public AppShellViewModel ViewModel { get; set; }

        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ExpressPage), typeof(ExpressPage));
            Routing.RegisterRoute(nameof(MePage), typeof(MePage));
            Routing.RegisterRoute(nameof(MainPage),typeof(MainPage));
            Routing.RegisterRoute(nameof(NewOrderPage),typeof(NewOrderPage));
            Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
            Routing.RegisterRoute(nameof(DeliveryHome),typeof(DeliveryHome));
            Routing.RegisterRoute(nameof(OrderDetail),typeof(OrderDetail));
            Routing.RegisterRoute(nameof(MeDetailPage),typeof(MeDetailPage));
            BindingContext = ViewModel = new AppShellViewModel();
        }
       
    }
}