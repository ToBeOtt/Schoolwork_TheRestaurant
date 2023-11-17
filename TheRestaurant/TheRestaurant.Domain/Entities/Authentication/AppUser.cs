using Microsoft.AspNetCore.Identity;

namespace TheRestaurant.Domain.Entities.Authentication
{
    public sealed class AppUser : IdentityUser
    {
        public string Alias { get; private set; }

        public AppUser() { }

        public void CreateUser(string email, string alias)
        {
            Email = email;
            Alias = alias;
        }


        private void UpdateRole(AppUser user)
        {
            throw new NotImplementedException();
        }
        private void DeleteUser(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
