using Logistics.Core.Service;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Logistics.Core.Controller {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<User>>>> GetAll() => await userService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<User>>> Get(int id) => await userService.GetAsync(id);

        [HttpPost]
        public async Task<ActionResult<ApiResponse<User>>> Add([FromBody] User user) => await userService.CreateAsync(user);

        [HttpPut]
        public async Task<ActionResult<ApiResponse<User>>> Update([FromBody] User user) => await userService.UpdateAsync(user);

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<User>>> Delete(int id) => await userService.DeleteAsync(id);
    } 
}
