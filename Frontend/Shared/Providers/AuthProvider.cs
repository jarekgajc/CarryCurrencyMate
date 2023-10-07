using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Frontend.Shared.Providers
{
    public class AuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;

        public AuthProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await localStorage.GetItemAsync<string>("token");
            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            
            var jwtToken = new JwtSecurityToken(token);
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
