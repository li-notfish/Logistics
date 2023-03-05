using Logistics.Shared.Enums;
using System.ComponentModel;

namespace Logistics.Shared.Model {
    public class OrderDeliveryResponse {
        public string OrderId { get; set; }
        public int DeliveryId { get; set; }
        [DisplayName("订单状态")]
        public OrderState OrderState { get; set; } = OrderState.None;

        public OrderDeliveryResponse()
        {
            
        }
    }
}
