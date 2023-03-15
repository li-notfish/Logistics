using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Logistics.Shared.Model {
    public partial class Warehouse : ObservableValidator
    {
        private int id;
        public int Id {
            get => id;
            set => SetProperty(ref id, value, true);
        }

        private int capacity;

        [Required]
        public int Capacity {
            get => capacity;
            set => SetProperty(ref capacity, value,true);
        }

        [JsonIgnore]
        [ObservableProperty]
        private ICollection<WareHouseGoods> goods = new List<WareHouseGoods>();

        public Warehouse()
        {
            
        }
    }
}
