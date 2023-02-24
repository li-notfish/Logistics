using Logistics.Core.Service;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService service)
        {
            this.adminService = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Administrators>>> Get(int id) => await adminService.GetAsync(id);

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Administrators>>>> GetAll() => await adminService.GetAllAsync();

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Administrators>>> Add([FromBody] Administrators admin) => await adminService.CreateAsync(admin);

        [HttpPut]
        public async Task<ActionResult<ApiResponse<Administrators>>> Update([FromBody] Administrators admin) => await adminService.UpdateAsync(admin);

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<Administrators>>> Delete(int id) => await adminService.DeleteAsync(id);
    }
}
