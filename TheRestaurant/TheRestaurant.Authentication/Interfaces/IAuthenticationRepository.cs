using Microsoft.AspNetCore.Identity;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Authentication.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<Employee> GetUserByEmail(string email);
        Task<Employee> GetUserById(string id);
        Task<SignInResult> CheckLoginCredentials(string username, string password);
    }
}
