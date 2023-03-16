using CommunityToolkit.Mvvm.ComponentModel;
using Logistics.Shared.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Logistics.Shared.Model
{
    public partial class Goods : ObservableValidator
    {
        private int id;

        public int Id {
            get => id;
            set => SetProperty(ref id, value,true);
        }

        [ObservableProperty]
        private GoodsStates goodsState = GoodsStates.In;

        private string name;
        [Required]
        public string Name {
            get => name;
            set => SetProperty(ref name, value,true);
        }

        private int count;
        [Required]
        public int Count {
            get => count;
            set => SetProperty(ref count,value,true);
        }

        [ObservableProperty]
        private int? warehouseId;

        [ObservableProperty]
        private Warehouse? warehouse;

        private string orderId;

        public string OrderId
        {
            get => orderId;
            set => SetProperty(ref orderId, value, true);
        }

        [ObservableProperty]
        private Order? order;

        public Goods()
        {
            
        }

        public Goods(string name, int count,string orderId)
        {
            this.Name = name;
            this.count = count;
            this.OrderId = orderId;
        }
    }
}
