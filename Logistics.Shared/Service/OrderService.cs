using Logistics.Shared.Model;


namespace Logistics.Shared.Service {
    public class OrderService : BaseService<Order>, IOrderService {
        public OrderService(HttpClient httpClient) : base("Order",httpClient)
        {
            
        }
    }
}
