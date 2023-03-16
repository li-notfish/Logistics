using Logistics.AppClient.ViewModels;

namespace Logistics.AppClient.Pages {
    public partial class MainPage : ContentPage {
        readonly MainViewModel mainViewModel;
        public MainPage(MainViewModel mainViewModel) {
            InitializeComponent();
            BindingContext = this.mainViewModel = mainViewModel;
        }
    }
}