using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Security.Claims;

namespace TheRestaurant.Presentation.Client
{
    public class ServerAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        public ServerAuthenticationStateProvider()
        {
            
        }
        public ServerAuthenticationStateProvider(ILocalStorageService localStorage, HttpClient httpClient)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
        }

        public void StateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }


        public void NotifyAuthenticationStateChanged()
        {
            var authState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
            NotifyAuthenticationStateChanged(authState);
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
                    var userIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "UserId");
                    var userId = userIdClaim?.Value;

                    // Check if both userId and userName are not null or empty
                    if (!string.IsNullOrEmpty(userId))
                    {
                        var claims = new List<Claim>
                        {
                            new Claim("UserId", userId),
                        };

                        // Set authorization header for API requests
                        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                        // Check if the expiration time is already in local storage
                        var expirationTime = await _localStorage.GetItemAsync<DateTimeOffset?>("TokenExpiration");

                        // Extract expiration time if not available in local storage or if the token is refreshed
                        if (!expirationTime.HasValue || expirationTime < DateTimeOffset.UtcNow)
                        {
                            if (jsonToken.Payload.TryGetValue("exp", out var exp) &&
                                exp is long expirationUnix)
                            {
                                expirationTime = DateTimeOffset.FromUnixTimeSeconds(expirationUnix).UtcDateTime;
                                claims.Add(new Claim("TokenExpiration", expirationTime.ToString()));

                                // Store expiration time in local storage
                                await _localStorage.SetItemAsync("TokenExpiration", expirationTime);
                            }
                        }

                        // Add roles to claims
                        var userRoles = jsonToken.Claims
                                        .Where(claim => claim.Type.Equals("role", StringComparison.OrdinalIgnoreCase))
                                        .Select(claim => claim.Value);
                        foreach (var role in userRoles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }
                        
                        var identity = new ClaimsIdentity(claims, "jwt");
                        var user = new ClaimsPrincipal(identity);
                        return new AuthenticationState(user);
                    }
                }
            }

            // If no valid token is found, return an unauthenticated state
            return new AuthenticationState(new ClaimsPrincipal());
        }
    }
}
