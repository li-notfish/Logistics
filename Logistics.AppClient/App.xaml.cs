using Logistics.AppClient.Pages;
using Logistics.AppClient.ViewModels;
using Logistics.Shared.Service;

namespace Logistics.AppClient {
    public partial class App : Application {
        public App() {
            InitializeComponent();
			MainPage = new AppShell();
			Shell.SetTabBarIsVisible(this, false);
        }
    }
}