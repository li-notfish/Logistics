using CommunityToolkit.Mvvm.ComponentModel;
using Logistics.Shared.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistics.Shared.Model
{
    public partial class Order : ObservableValidator
    {

        private string orderId;

        [DisplayName("订单号")]
        [Column(TypeName = "varchar(64)")]
        public string OrderId {
            get => orderId;
            set => this.SetProperty(ref orderId, value,true);
        }
        [Required]
        private string recipient;
        [DisplayName("收件人")]
        public string Recipient {
            get => recipient;
            set => this.SetProperty(ref recipient,value,true);
        }

        private string recipientPhone;
        [Phone]
        [Required]
        [DisplayName("收件人电话")]
        public string RecipientPhone {
            get => recipientPhone; 
            set => this.SetProperty(ref recipientPhone, value, true);
        }

        private string sender;
        [Required]
        [DisplayName("寄件人")]
        public string Sender {
            get => sender;
            set => this.SetProperty(ref sender, value, true);
        }

        private string senderPhone;
        [Phone]
        [Required]
        [DisplayName("寄件人电话")]
        public string SenderPhone {
            get => senderPhone; 
            set => this.SetProperty(ref senderPhone, value, true);
        }

        private string senderCity;
        [Required]
        [DisplayName("寄件人地址")]
        public string SenderCity {
            get => senderCity; 
            set => this.SetProperty(ref senderCity, value, true);
        }

        private string recipientCity;
        [Required]
        [DisplayName("收件人地址")]
        public string RecipientCity {
            get => recipientCity;
            set => SetProperty(ref recipientCity, value,true);
        }

        private string orderInfo;
        [Required]
        [DisplayName("订单详情")]
        public string OrderInfo {
            get => orderInfo;
            set => SetProperty(ref orderInfo, value, true);
        }

        private decimal cost = decimal.Zero;
        [DisplayName("费用")]
        public decimal Cost {
            get => cost;
            set => SetProperty(ref cost, value, true);
        }

        private DateTime orderDate = DateTime.Now;
        [DisplayName("创建日期")]
        public DateTime OrderDate {
            get => orderDate;
            set => SetProperty(ref orderDate,value,true);
        }

        private OrderState orderState = OrderState.None;
        [DisplayName("订单状态")]
        public OrderState OrderState {
            get => orderState;
            set => SetProperty(ref orderState,value,true);
        }


        private int? deliveryId;
        [DisplayName("派送员ID")]
        public int? DeliveryId {
            get => deliveryId;
            set => SetProperty(ref deliveryId, value, true);
        }

        [ObservableProperty]
        private Delivery? delivery;

        [ObservableProperty]
        private Goods? goods;

        public Order()
        {
            
        }

        public Order(string orderId, string recipient, string recipientPhone, string sender, string senderCity, string senderPhone, string recipientCity, string orderInfo)
        {
            this.OrderId = orderId;
            this.Recipient = recipient;
            this.RecipientPhone = recipientPhone;
            this.Sender = sender;
            this.SenderCity = senderCity;
            this.SenderPhone = senderPhone;
            this.RecipientCity = recipientCity;
            this.OrderInfo = orderInfo;
        }

        public override string ToString() {
            return $"OrderId:{OrderId},DeliveryId:{DeliveryId},OrderInfo:{OrderInfo}";
        }
    }
}
