using CommunityToolkit.Mvvm.ComponentModel;
using Logistics.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.AppClient.ViewModels
{
    public class ExpressViewModel : ObservableObject
    {
        private readonly IOrderService _orderService;

        public ExpressViewModel(IOrderService orderService)
        {
            this._orderService = orderService;
        }
    }
}
