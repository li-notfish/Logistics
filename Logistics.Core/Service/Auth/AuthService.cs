using Logistics.Core.Context;
using Logistics.Shared;
using Logistics.Shared.Enums;
using Logistics.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Logistics.Core.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly LogisticsContext logistics;
        private readonly IConfiguration configuration;
        public AuthService(LogisticsContext logistics, IConfiguration configuration)
        {
            this.logistics = logistics;
            this.configuration = configuration;
        }

        public async Task<bool> AdminExists(string name, string password)
        {
            if (await logistics.Administrators.AnyAsync(admin => admin.Name.Equals(name) && admin.Password.Equals(password)))
            {
                return true;
            }
            return false;
        }

        public async Task<ApiResponse<string>> Login(string name, string password,LoginType loginType)
        {
            var respone = new ApiResponse<string>();
            object result = new object();
            switch (loginType)
            {
                case LoginType.Admin:
					result = await logistics.Administrators.FirstOrDefaultAsync(x => x.Name.Equals(name) && x.Password.Equals(password));
					break;
                case LoginType.User:
                    result = await logistics.Users.FirstOrDefaultAsync(x => x.Name.Equals(name) && x.Password.Equals(password));
                    break;
                case LoginType.Delivery:
                    result = await logistics.Deliveries.FirstOrDefaultAsync(x => x.Name.Equals(name) && x.Password.Equals(password));
					break;
            }
            
            if (result != null)
            {
                respone.Success = true;
                LoginRequest loginRequest = new LoginRequest(name, password);
                switch (loginType)
                {
                    case LoginType.Admin:
                        loginRequest.Id = (result as Administrators).Id;
						break;
                    case LoginType.User:
						loginRequest.Id = (result as User).Id;
						break;
                    case LoginType.Delivery:
						loginRequest.Id = (result as Delivery).Id;
						break;
                }
                respone.Data = CreateToken(loginRequest);
            }
            else
            {
                respone.Success = false;
                respone.Message = "管理员名字或者密码不正确!";
            }
            return respone;
        }

        public Task<ApiResponse<int>> Ragister(Administrators administrators, string password)
        {
            throw new NotImplementedException();
        }

        private string CreateToken(LoginRequest loginRequest)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,loginRequest.Id.ToString()),
                new Claim(ClaimTypes.Name,loginRequest.Name.ToString()),
                new Claim(ClaimTypes.Role, loginRequest.LoginType.ToString())

            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
    .GetBytes(configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
