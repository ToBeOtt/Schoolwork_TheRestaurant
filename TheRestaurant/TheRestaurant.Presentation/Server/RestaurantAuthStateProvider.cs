using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace TheRestaurant.Presentation.Server
{
    public class RestaurantAuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Replace this with your logic to retrieve the authentication state
            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, "JohnDoe"), // Replace with the actual username
            new Claim(ClaimTypes.Role, "Admin"),   // Replace with the actual roles
        }, "custom");

            var user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
        }
    }
}
