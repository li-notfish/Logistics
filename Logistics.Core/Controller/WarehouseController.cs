using Logistics.Core.Service.WarehouseGoodes;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Logistics.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            this.warehouseService = warehouseService;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<Warehouse>> Get(int id) => await warehouseService.GetAsync(id);

        [HttpGet]
        public async Task<ApiResponse<List<Warehouse>>> GetAll() => await warehouseService.GetAllAsync();

        [HttpPost]
        public async Task<ApiResponse<Warehouse>> Add([FromBody] Warehouse warehouse) => await warehouseService.CreateAsync(warehouse);

        [HttpPut]
        public async Task<ApiResponse<Warehouse>> Update([FromBody] Warehouse warehouse) => await warehouseService.UpdateAsync(warehouse);

        [HttpDelete("{id}")]
        public async Task<ApiResponse<Warehouse>> Delete(int id) => await warehouseService.DeleteAsync(id);
    }
}
