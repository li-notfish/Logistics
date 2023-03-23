using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AppClient.ViewModels
{
    public partial class BarcodeReaderViewModel : ObservableObject
    {
        [ObservableProperty]
        private string orderId = string.Empty;

        public BarcodeReaderViewModel()
        {
            
        }


        private async Task ShowOrderId(string value)
        {
            var toast = Toast.Make(value);
            await toast.Show();
        }
    }
}
