using System.Security.Claims;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Authentication.Interfaces
{
    public interface IJwtTokenRepository
    {
        Task<string> GenerateToken(AppUser user);
        Task<ClaimsPrincipal> ValidateToken(string token);
    }
}
