using Logistics.AppClient.Pages;

namespace Logistics.AppClient {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ExpressPage), typeof(ExpressPage));
            Routing.RegisterRoute(nameof(MePage), typeof(MePage));
            Routing.RegisterRoute(nameof(MainPage),typeof(MainPage));
            Routing.RegisterRoute(nameof(NewOrderPage),typeof(NewOrderPage));
            Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
        }
       
    }
}