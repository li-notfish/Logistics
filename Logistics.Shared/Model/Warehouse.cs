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

        [Required(ErrorMessage = "这是必须填写的")]
        public int Capacity {
            get => capacity;
            set => SetProperty(ref capacity, value,true);
        }

        private string? address = string.Empty;

        [Required(ErrorMessage ="这是必须填写的")]
        public string? Address
        {
            get => address;
            set => SetProperty<string>(ref address, value,true);
        }

        [JsonIgnore]
        [ObservableProperty]
        private ICollection<Goods>? goods = new List<Goods>();

        public Warehouse()
        {
            
        }
    }
}
