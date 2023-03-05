using Logistics.Core.Context;
using Logistics.Shared;
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

        public async Task<ApiResponse<string>> Login(string name, string password)
        {
            var respone = new ApiResponse<string>();
            var result = await logistics.Administrators.FirstOrDefaultAsync(x => x.Name.Equals(name) && x.Password.Equals(password));
            if (result != null)
            {
                respone.Success = true;
                respone.Data = CreateToken(result);
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

        private string CreateToken(Administrators administrators)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,administrators.Id.ToString()),
                new Claim(ClaimTypes.Name,administrators.Name.ToString()),

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
