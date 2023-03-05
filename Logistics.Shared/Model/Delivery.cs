using Logistics.Shared.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Logistics.Shared.Model
{
    public class Delivery
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("姓名")]
        public string Name { get; set; }
        [Required,StringLength(18,MinimumLength = 8)]
        [DisplayName("密码")]
        public string Password { get; set; }
        [Required]
        [DisplayName("地址")]
        public string Address { get; set; }
        [Required,Phone]
        [DisplayName("电话号码")]
        public string Phone { get; set; }
        [DisplayName("备注")]
        public string Description { get; set; }
        [DisplayName("当前状态")]
        public DeliveryState State { get; set; } = DeliveryState.Idle;

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
