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
    
    public partial class MainViewModel : ObservableObject
    {
        private readonly IOrderService _orderService;
        [ObservableProperty]
        private ObservableCollection<OrderStateColletion> data;

        [ObservableProperty]
        private List<Order> orders = new List<Order>();

        private string currentUser = string.Empty;

        [ObservableProperty]
        private Order singleOrder;

        [ObservableProperty]
        private string orderId = string.Empty;

        [ObservableProperty]
        private bool isSearch = false;

        public MainViewModel(IOrderService orderService)
        {
            this._orderService = orderService;
            currentUser = Preferences.Default.Get("UserName", string.Empty);

			GetRecOrderCount();
        }

        private async Task GetOrderList(int type) {
            try {
                var result = await _orderService.GetAllAsync();
                if (result != null) {
                    if(type == 1)
                    {
                        Orders = result.Where(x => x.Recipient.Equals(currentUser)).ToList();
					}
                    else
                    {
                        Orders = result.Where(x => x.Sender.Equals(currentUser)).ToList();
                    }
                    
                }
            }
            catch (Exception ex) {
                var toast = Toast.Make(ex.Message, ToastDuration.Short, 14);
                await toast.Show();
            }
            
        }

        [RelayCommand]
        public async Task SearchOrder(string id)
        {
            SingleOrder = Orders.SingleOrDefault(x => x.OrderId.Equals(OrderId));
            if(SingleOrder != null)
            {
                IsSearch = true;
            }
		}

		[RelayCommand]
        public async Task ToCreateOrder() {
            await Shell.Current.GoToAsync($"{nameof(NewOrderPage)}");
        }

        [RelayCommand]
        public async Task GetRecOrderCount() {
            await GetOrderList(0);
            Data = new ObservableCollection<OrderStateColletion>() {
                new OrderStateColletion("派送中",0),
                new OrderStateColletion("运输中",0),
                new OrderStateColletion("未发货",0),
                new OrderStateColletion("已签收",0),
            };

            foreach(var item in Orders.GroupBy(x => x.OrderState)) {
                switch (item.Key) {
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
        public async Task GetSendOrderCount() {
            await GetOrderList(1);
            Data = new ObservableCollection<OrderStateColletion>() {
                new OrderStateColletion("待寄出",0),
                new OrderStateColletion("待收件",0),
                new OrderStateColletion("派送中",0),
                new OrderStateColletion("运输中",0),
                new OrderStateColletion("已签收",0),
            };

            foreach (var item in Orders.GroupBy(x => x.OrderState)) {
                switch (item.Key) {
                    case Shared.Enums.OrderState.None:
                        Data[0].Number += item.Count();
                        break;
                    case Shared.Enums.OrderState.InWay:
                        Data[3].Number += item.Count();
                        break;
                    case Shared.Enums.OrderState.Dispatch:
                        Data[2].Number += item.Count();
                        break;
                    case Shared.Enums.OrderState.Received:
                        Data[4].Number += item.Count();
                        break;
                    case Shared.Enums.OrderState.WaitRecived:
                        Data[1].Number += item.Count();
                        break;
                    default:
                        break;
                }
            }
        }
        [RelayCommand]
        private async Task GoToDetail(string orderId)
        {
            var navigationParamters = new Dictionary<string, object>();
            navigationParamters.Add("orderId",orderId);
            await Shell.Current.GoToAsync($"{nameof(OrderDetail)}",navigationParamters);
        }
    }

    public record OrderStateColletion {
        public string Name { get; set; }
        public int Number { get; set; }
        public OrderStateColletion()
        {
            
        }

        public OrderStateColletion(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }
}
