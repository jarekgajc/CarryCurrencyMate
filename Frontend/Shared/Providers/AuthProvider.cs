using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Frontend.Shared.Providers
{
    public class AuthProvider : AuthenticationStateProvider
    {
        public bool Authorised { get; set; } = true;
        private readonly ILocalStorageService localStorage;

        public AuthProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Run(() => { });
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public void Authenticate(string token)
        {

        }
    }
}
