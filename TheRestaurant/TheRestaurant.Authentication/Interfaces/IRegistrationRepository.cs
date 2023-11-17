using Microsoft.AspNetCore.Identity;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Authentication.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<bool> CheckNoUserExist(string email);
        Task<IdentityResult> AddUser(AppUser user, string password);
    }
}
