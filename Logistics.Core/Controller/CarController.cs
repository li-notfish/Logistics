using Logistics.Core.Service.Car;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Logistics.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase {

        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            this._carService = carService;
        }

        [HttpGet]
        public async Task<ApiResponse<List<Car>>> Get() => await _carService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ApiResponse<Car>> Get(int id) => await _carService.GetAsync(id);

        [HttpPost]
        public async Task<ApiResponse<Car>> Post([FromBody] Car car) => await _carService.CreateAsync(car);

        [HttpPut]
        public async Task<ApiResponse<Car>> Put([FromBody] Car car) => await _carService.UpdateAsync(car);

        [HttpDelete("{id}")]
        public async Task<ApiResponse<Car>> Delete(int id) => await _carService.DeleteAsync(id);
    }
}
