using Logistics.Shared.Model;

namespace Logistics.Shared.Service {
    public class DeliveryService : BaseService<Delivery>, IDeliveryService {
        private readonly HttpClient _httpClient;

        public DeliveryService(HttpClient httpClient) : base("Delivery",httpClient)
        {
            this._httpClient = httpClient;
        }
    }
}
