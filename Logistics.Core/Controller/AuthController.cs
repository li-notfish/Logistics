using Logistics.Core.Service.Auth;
using Logistics.Shared;
using Logistics.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService) 
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<string>>> Login(LoginRequest login) {
            var response = await authService.Login(login.Name,login.Password,login.LoginType);
            if (!response.Success) {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
