using Logistics.Shared.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace Logistics.Shared.Service {
    public class OrderService : BaseService<Order>, IOrderService {
		private readonly HttpClient _httpClient;
		private string Route = string.Empty;

        public OrderService(HttpClient httpClient) : base("Order",httpClient)
        {
            _httpClient = httpClient;
			this.Route = $"api/Order/";
		}

		public async Task<List<Order>> GetAllAsync(int deliveryId)
		{
			var result = await _httpClient.GetFromJsonAsync<ApiResponse<List<Order>>>(Route + $"{deliveryId}/delivery");
			return result.Data;
		}
	}
}
