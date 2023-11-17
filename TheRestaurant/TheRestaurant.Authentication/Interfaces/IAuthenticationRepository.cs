using Microsoft.AspNetCore.Identity;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Authentication.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<AppUser> GetUserByEmail(string email);
        Task<AppUser> GetUserById(string id);
        Task<SignInResult> CheckLoginCredentials(string username, string password);
    }
}
