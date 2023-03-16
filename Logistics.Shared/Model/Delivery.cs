using CommunityToolkit.Mvvm.ComponentModel;
using Logistics.Shared.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Logistics.Shared.Model
{
    public partial class Delivery : ObservableValidator
    {
        private int id;

        public int Id {
            get => this.id;
            set => SetProperty(ref this.id, value, true);
        }

        private string name;
        [Required]
        [DisplayName("姓名")]
        public string Name {
            get => this.name;
            set => this.SetProperty(ref this.name, value, true);
        }
        private string password;
        
        [Required,StringLength(18,MinimumLength = 8)]
        [DisplayName("密码")]
        public string Password {
            get => this.password;
            set => this.SetProperty(ref this.password,value,true);
        }

        private string address;
        [Required]
        [DisplayName("地址")]
        public string Address {
            get => this.address; 
            set => this.SetProperty(ref this.address, value, true);
        }

        private string phone;
        [Required,Phone]
        [DisplayName("电话号码")]
        public string Phone {
            get => this.phone;
            set => this.SetProperty(ref this.phone, value, true);
        }

        private string description;
        [DisplayName("备注")]
        public string Description {
            get => description;
            set => this.SetProperty(ref this.description, value, true);
        }

        private DeliveryState state = DeliveryState.Idle;
        [DisplayName("当前状态")]
        public DeliveryState State {
            get => state;
            set => this.SetProperty(ref state,value,true);
        }

        [ObservableProperty]
        public List<Order> orders = new List<Order>();

        public Delivery()
        {
            
        }

        public Delivery(int id, string name, string password, string address, string phone, string log)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.Address = address;
            this.Phone = phone;
            this.Description = log;
        }
    }
}
