using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Logistics.AppClient.Pages;
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

        private readonly IUserService _userService;

        private string currentUser = string.Empty;

        [ObservableProperty]
        private List<Order> orders = new List<Order>();

        public ExpressViewModel(IOrderService orderService,IUserService userService)
        {
            this._orderService = orderService;
            currentUser = Preferences.Default.Get("UserName", string.Empty);
			GetOrderList(0);
        }

        private async Task GetOrderList(int type) {
            try {
                var result = await _orderService.GetAllAsync();
                if (result != null) {
                    if(type == 1)
                    {
						Orders = result.Where(x => x.Sender.Equals(currentUser)).ToList();
					}
                    else
                    {
						Orders = result.Where(x => x.Recipient.Equals(currentUser)).ToList();
					}
                }
            }
            catch (Exception ex) {
                var toast = Toast.Make(ex.Message,ToastDuration.Short,14);
                await toast.Show();
            }
            
        }

        [RelayCommand]
        private async Task GetRecOrder() {
            await GetOrderList(0);
        }
        [RelayCommand]
        private async Task GetSendOrder() {
            await GetOrderList(1);
        }

        [RelayCommand]
        private async Task GoToDetail(string orderId)
        {
            var navigationParamters = new Dictionary<string, object>();
            navigationParamters.Add("orderId", orderId);
            await Shell.Current.GoToAsync($"{nameof(OrderDetail)}", navigationParamters);
        }
    }
}
