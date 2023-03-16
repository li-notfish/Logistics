using Logistics.Core.Service.WarehouseGoodes;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodsService goodsService;

        public GoodsController(IGoodsService goodsService)
        {
            this.goodsService = goodsService;
        }


        [HttpGet("{id}")]
        public async Task<ApiResponse<Goods>> Get(int id) => await goodsService.GetAsync(id);

        [HttpGet]
        public async Task<ApiResponse<List<Goods>>> GetAll() => await goodsService.GetAllAsync();

        [HttpPost]
        public async Task<ApiResponse<Goods>> Add([FromBody] Goods goods) => await goodsService.CreateAsync(goods);

        [HttpPut]
        public async Task<ApiResponse<Goods>> Update([FromBody] Goods goods) => await goodsService.UpdateAsync(goods);

        [HttpDelete("{id}")]
        public async Task<ApiResponse<Goods>> Delete(int id) => await goodsService.DeleteAsync(id);
    }
}
