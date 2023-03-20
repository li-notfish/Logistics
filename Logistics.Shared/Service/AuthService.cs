using Logistics.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Service
{
	public class AuthService : IAuthService
	{
		private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<string>> Login(LoginRequest loginRequest)
		{
			var result = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);
			return await result.Content.ReadFromJsonAsync<ApiResponse<string>>();
		}
	}
}
