using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Logistics.Shared.Enums;
using Logistics.Shared.Model;
using Logistics.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AppClient.ViewModels
{
    public partial class OrderDetailViewModel : ObservableObject , IQueryAttributable
    {
        private readonly IOrderService orderService;

        [ObservableProperty]
        private string orderId = string.Empty;

        [ObservableProperty]
        public List<string> orderStateString;

        [ObservableProperty]
        private Order orderDetail;

        [ObservableProperty]
        private int stateIndex;

        [ObservableProperty]
        private int loginType = 1;

        [ObservableProperty]
        private bool isDelivery = false;

        public OrderDetailViewModel(IOrderService orderService)
        {
            this.orderService = orderService;
            OrderStateString = new List<string>
        {
                "未派送",
        "正在运输",
        "正在派送",
        "已签收",
        "签收失败",
        "退回",
        "等待签收",
        };
            
        }


        private async Task GetOrder(string orderId)
        {
            LoginType = Preferences.Default.Get<int>("Type", -1);
            IsDelivery = LoginType == 2;
            if (OrderId == string.Empty)
            {
                return;
            }
            var result = await orderService.GetFirstOfDefaultAsync(orderId);
            if(result != null)
            {
                OrderDetail = result;
                StateIndex = (int)OrderDetail.OrderState;
            }
        }

        [RelayCommand]
        private async Task UpdateState()
        {
            if(StateIndex == (int)OrderDetail.OrderState)
            {
                return;
            }
            else
            {
                OrderDetail.OrderState = (OrderState)StateIndex;
                var result = orderService.UpdateAsync(OrderDetail);
                if(result != null )
                {
                    var toast = Toast.Make("更新状态成功！");
                    await toast.Show();
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    var toast = Toast.Make("更新状态失败！");
                    await toast.Show();
                }
            }
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            OrderId = query["orderId"].ToString();
            await GetOrder(OrderId);
        }
    }
}
