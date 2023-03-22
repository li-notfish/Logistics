using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Logistics.AppClient.Pages;
using Logistics.Shared.Model;
using Logistics.Shared.Service;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AppClient.ViewModels
{
    public partial class NewOrderViewModel : ObservableObject
    {
        private readonly IOrderService _orderService;

        private readonly HubConnection hubConnection;

        [ObservableProperty]
        private Order order;

        [ObservableProperty]
        private List<string> users;

        public NewOrderViewModel(IOrderService orderService)
        {
            this._orderService = orderService;
            order = new Order();

            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://logisticscore20230322160309.azurewebsites.net/sendorderhub")
                .Build();
            hubConnection.On<List<string>>("Users",RefreshUsers);

            LinkTo();
        }

        private async void LinkTo()
        {
            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("SignalR错误", ex.Message,"Ok");
            }
        }
        

        [RelayCommand]
        public async Task Submit() {
            if(Order.HasErrors != true) {
                try {
                    if (Order.Goods == null)
                    {
                        Order.Goods = new Goods();
                    }
                    Order.Goods.Name = Order.OrderInfo;
                    var result = await _orderService.AddAsync(Order);
                    if (result != null) {
                        await hubConnection.InvokeAsync("SendMessage", Order.Sender,Order.OrderId,"Admin");
                        await Shell.Current.GoToAsync("../");
                    }
                    else {
                        var toast = Toast.Make("可能出现了错误！", ToastDuration.Short, 14);
                        await toast.Show();
                    }
                }
                catch (Exception ex) {
                    var toast = Toast.Make(ex.Message, ToastDuration.Short, 14);
                    await toast.Show();
                }
            }
            else {
                await Shell.Current.DisplayAlert("输入的快递信息有误!","请检查输入的信息是否正确","Ok");
            }
        }

        [RelayCommand]
        public async Task Back() {
            await Shell.Current.GoToAsync("../");
        }

        private void RefreshUsers(List<string> users)
        {
            this.Users = users;
        }
    }
}
