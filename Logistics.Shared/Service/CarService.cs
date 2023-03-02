

using Logistics.Shared.Model;

namespace Logistics.Shared.Service {
    public class CarService : BaseService<Car> , ICarService {
    
        private readonly HttpClient _httpClient;

        public CarService(HttpClient httpClient) : base("Car",httpClient)
        {
            this._httpClient = httpClient;
        }

    }
}
