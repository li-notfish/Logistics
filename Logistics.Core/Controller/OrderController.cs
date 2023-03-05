using Logistics.Core.Service.Order;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {
        private readonly IOrderService<Order> orderService;
        public OrderController(IOrderService<Order> orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Order>>>> GetAll() => await orderService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Order>>> Get(string id) => await orderService.GetAsync(id);

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Order>>> Add([FromBody] Order order) => await orderService.CreateAsync(order);

        [HttpPut]
        public async Task<ActionResult<ApiResponse<Order>>> Update([FromBody] Order order) => await orderService.UpdateAsync(order);
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<Order>>> Delete(string id) => await orderService.DeleteAsync(id); 
    }
}
