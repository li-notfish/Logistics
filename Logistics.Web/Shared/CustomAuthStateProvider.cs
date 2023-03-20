using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace Logistics.Web.Shared
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;
        private readonly HttpClient http;

        public CustomAuthStateProvider(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            this.localStorageService = localStorageService;
            this.http = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string authToken = await localStorageService.GetItemAsStringAsync("authToken");

            var identity = new ClaimsIdentity();

            http.DefaultRequestHeaders.Authorization = null;
            if(!string.IsNullOrEmpty(authToken) )
            {
                try
                {
                    identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken),"jwt");
                    http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",authToken.Replace("\"",""));
                }
                catch(Exception ex)
                {
                    await localStorageService.RemoveItemAsync("authToken");
                    Console.WriteLine(ex.Message);
                    identity = new ClaimsIdentity();
                }
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
        private byte[] ParseBase64WithoutPadding(string input)
        {
            input = input.Replace('-', '+'); // 62nd char of encoding
            input = input.Replace('_', '/'); // 63rd char of encoding
            switch (input.Length % 4)
            {
                case 0: break;
                case 2: input += "=="; break;
                case 3: input += "="; break;
            }
            return Convert.FromBase64String(input);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            Console.WriteLine(payload);
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer
                .Deserialize<Dictionary<string, object>>(jsonBytes);

            var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key,kvp.Value.ToString()));

            return claims;
        }
    }

}
