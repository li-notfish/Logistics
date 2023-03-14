using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Logistics.AppClient.Pages;
using Logistics.Shared.Model;
using Logistics.Shared.Service;
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

        [ObservableProperty]
        private Order order;

        public NewOrderViewModel(IOrderService orderService)
        {
            this._orderService = orderService;
            order = new Order();
        }

        [RelayCommand]
        public async Task Submit() {
            if(Order.HasErrors != true) {
               var result = await  _orderService.AddAsync(Order);
                if(result != null) {
                    await Shell.Current.GoToAsync("MainPage");
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
    }
}
