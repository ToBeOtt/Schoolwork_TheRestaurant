using Common.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheRestaurant.Authentication.Interfaces;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Common.Infrastructure.Repositories.Authentication
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly RestaurantDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public RegistrationRepository(RestaurantDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUser(AppUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<bool> CheckNoUserExist(string email)
        {
            return await _context.Users.Where(u => u.Email == email).AnyAsync();
        }
    }
}
