using Logistics.Core.Service.Delivery;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            this._deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<ApiResponse<List<Delivery>>> Get() => await _deliveryService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ApiResponse<Delivery>> Get(int id) => await _deliveryService.GetAsync(id);

        [HttpPost]
        public async Task<ApiResponse<Delivery>> Post([FromBody] Delivery delivery) => await _deliveryService.CreateAsync(delivery);

        [HttpPut]
        public async Task<ApiResponse<Delivery>> Put([FromBody] Delivery delivery) => await _deliveryService.UpdateAsync(delivery);

        [HttpDelete("{id}")]
        public async Task<ApiResponse<Delivery>> Delete(int id) => await _deliveryService.DeleteAsync(id);
    }
}
