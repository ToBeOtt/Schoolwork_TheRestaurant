using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace TheRestaurant.Presentation.Client
{
    public class ServerAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public ServerAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var authToken = await _localStorage.GetItemAsync<string>("authToken");

            if (!string.IsNullOrEmpty(authToken))
            {
                var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(authToken) as System.IdentityModel.Tokens.Jwt.JwtSecurityToken;

                if (jsonToken != null)
                {
                    var userId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
                    var userName = jsonToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
                    var userRoles = jsonToken.Claims.Where(claim => claim.Type == ClaimTypes.Role).Select(claim => claim.Value).ToList();

                    var claims = new List<Claim>
                    {
                        new Claim("UserId", userId),
                        new Claim(ClaimTypes.Name, userName),
                    };

                    // Add roles to claims
                    claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

                    var identity = new ClaimsIdentity(claims, "jwt");
                    var user = new ClaimsPrincipal(identity);
                    return new AuthenticationState(user);
                }
            }

            // If no valid token is found, return an unauthenticated state
            return new AuthenticationState(new ClaimsPrincipal());
        }
    }
}
