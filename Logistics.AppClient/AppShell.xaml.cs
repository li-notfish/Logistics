using Logistics.AppClient.Pages;

namespace Logistics.AppClient {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute("addorder",typeof(NewOrderPage));
        }
       
    }
}