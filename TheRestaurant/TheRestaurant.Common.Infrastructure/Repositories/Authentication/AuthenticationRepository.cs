using Common.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using TheRestaurant.Authentication.Interfaces;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Common.Infrastructure.Repositories.Authentication
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly RestaurantDbContext _context;
        private readonly SignInManager<Employee> _signInManager;

        public AuthenticationRepository(
            RestaurantDbContext context,
            SignInManager<Employee> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<Employee> GetUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).SingleOrDefault();
        }

        public async Task<Employee> GetUserById(string id)
        {
            return _context.Users.Where(u => u.Id == id).SingleOrDefault();
        }

        public async Task<SignInResult> CheckLoginCredentials(string username, string password)
        {
            return await _signInManager.PasswordSignInAsync(username, password, false, false);
        }
    }
}
