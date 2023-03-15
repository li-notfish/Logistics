using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Logistics.Shared.Model;
using Logistics.Shared.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AppClient.ViewModels
{
    public partial class ExpressViewModel : ObservableObject
    {
        private readonly IOrderService _orderService;

        [ObservableProperty]
        private List<Order> orders = new List<Order>() { 
            new Order() {
                OrderId = "1244312341",
                OrderDate = DateTime.Now,
                OrderState = Shared.Enums.OrderState.None,
                OrderInfo = "锅",
                Sender = "MASA",
                SenderCity = "广东深圳",
                SenderPhone = "1234512312",
                Recipient = "Stack",
                RecipientCity = "广西南宁",
                RecipientPhone = "12314123213",
                Cost = 100,
            }
        };

        public ExpressViewModel(IOrderService orderService)
        {
            this._orderService = orderService;
            GetOrderList();
        }

        private async Task GetOrderList() {
            try {
                var result = await _orderService.GetAllAsync();
                if (result != null) {
                    Orders = result;
                }
            }
            catch (Exception ex) {
                var toast = Toast.Make(ex.Message,ToastDuration.Short,14);
                await toast.Show();
            }
            
        }

        [RelayCommand]
        private async Task GetRecOrder() {
            await GetOrderList();
        }
        [RelayCommand]
        private async Task GetSendOrder() {
            await GetOrderList();
        }
    }
}
