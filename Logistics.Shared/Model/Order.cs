
namespace Logistics.Shared.Model
{
    public class Order
    {
        public string OrderId { get; set; }
        public string OrderState { get; set; }
        public string Recipient { get; set; }
        public string RecipientPhone { get; set; }
        public string Sender { get; set; }
        public string SenderPhone { get; set; }
        public string SenderCity { get; set; }
        public string RecipientCity { get; set;}
        public string OrderInfo { get; set; }
        public decimal Cost { get; set; }

        public Order()
        {
            
        }

        public Order(string orderId,string orderState, string recipient, string recipientPhone, string sender, string senderCity, string senderPhone, string recipientCity, string orderInfo, decimal cost)
        {
            this.OrderId = orderId;
            this.OrderState = orderState;
            this.Recipient = recipient;
            this.RecipientPhone = recipientPhone;
            this.Sender = sender;
            this.SenderCity = senderCity;
            this.SenderPhone = senderPhone;
            this.RecipientCity = recipientCity;
            this.OrderInfo = orderInfo;
            this.Cost = cost;
        }
    }
}
