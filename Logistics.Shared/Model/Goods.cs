using CommunityToolkit.Mvvm.ComponentModel;
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

        [JsonIgnore]
        [ObservableProperty]
        private ICollection<WareHouseGoods> warehouses = new List<WareHouseGoods>();

        public Goods()
        {
            
        }

        public Goods(string name, int count)
        {
            this.Name = name;
            this.count = count;
        }
    }
}
