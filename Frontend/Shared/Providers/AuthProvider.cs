using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;

namespace Frontend.Shared.Providers
{
    public class AuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly HttpClient httpClient;

        public AuthProvider(ILocalStorageService localStorage, HttpClient httpClient)
        {
            this.localStorage = localStorage;
            this.httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await localStorage.GetItemAsync<string>("token");
            if (string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var jwtToken = new JwtSecurityToken(token);
            if (jwtToken.ValidTo < DateTime.UtcNow)
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims, "auth")));
        }

        public async void Authenticate(string token)
        {
            await localStorage.SetItemAsync("token", token);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async void Unauthenticate()
        {
            await localStorage.RemoveItemAsync("token");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
