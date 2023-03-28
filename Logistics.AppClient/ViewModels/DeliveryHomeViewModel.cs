using CommunityToolkit.Maui.Alerts;
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
    public partial class DeliveryHomeViewModel : ObservableObject
    {
        private readonly IDeliveryService deliveryService;
        private readonly IOrderService orderService;

        [ObservableProperty]
        private ObservableCollection<OrderStateColletion> data;

        [ObservableProperty]
        private string orderId;

        [ObservableProperty]
        private Delivery deliveryHome;

        [ObservableProperty]
        private List<Order> orders;

        public DeliveryHomeViewModel(IDeliveryService deliveryService, IOrderService orderService)
        {
            this.deliveryService = deliveryService;
            this.orderService = orderService;

            Task.Run(async () =>
            {
                await GetDelivery();
                //await GetDeliveryOrder();
                await Refrash();
			});
		}

        private async Task GetDelivery()
        {
            var id = Preferences.Default.Get("Id", -1);
            if (id != -1)
            {
                DeliveryHome = await deliveryService.GetFirstOfDefaultAsync(id);
                if (DeliveryHome != null)
                {
                    Orders = DeliveryHome.Orders;
                }
            }

        }

        [RelayCommand]
        private async Task SearchOrder()
        {
            if(Orders.Any(x => x.OrderId == OrderId))
            {
                var navigationParamters = new Dictionary<string, object>();
                navigationParamters.Add("orderId", OrderId);
                await Shell.Current.GoToAsync($"{nameof(OrderDetail)}", navigationParamters);
            }
            else
            {
                var toast = Toast.Make("你的配送表里没这个订单！");
            }
        }

        [RelayCommand]
        private async Task GetDeliveryOrder()
        {
            if (DeliveryHome != null)
            {
                Orders = await orderService.GetAllAsync(DeliveryHome.Id);
            }
        }

        [RelayCommand]
        private async Task ToCompleteOrder()
        {

        }

        [RelayCommand]
        private async Task Refrash()
        {
            Data = new ObservableCollection<OrderStateColletion>() {
                new OrderStateColletion("派送中",0),
                new OrderStateColletion("运输中",0),
                new OrderStateColletion("未发货",0),
                new OrderStateColletion("已签收",0),
            };

            foreach (var item in Orders.GroupBy(x => x.OrderState))
            {
                switch (item.Key)
                {
                    case Shared.Enums.OrderState.None:
                        Data[2].Number += item.Count();
                        break;
                    case Shared.Enums.OrderState.InWay:
                        Data[1].Number += item.Count();
                        break;
                    case Shared.Enums.OrderState.Dispatch:
                        Data[0].Number += item.Count();
                        break;
                    case Shared.Enums.OrderState.Received:
                        Data[3].Number += item.Count();
                        break;
                    default:
                        break;
                }
            }
        }


        [RelayCommand]
        private async Task OpenBarcodeReader()
        {
            await Shell.Current.GoToAsync($"{nameof(BarcodeReaderView)}");
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


