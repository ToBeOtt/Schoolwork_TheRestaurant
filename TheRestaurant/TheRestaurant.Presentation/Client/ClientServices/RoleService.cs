using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace TheRestaurant.Presentation.Client.ClientServices
{


    public class RoleService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public RoleService(ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<(bool IsAdmin, bool IsManager)> GetRolesAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();

            // Check user roles
            var isAdmin = authState.User.IsInRole("admin");
            var isManager = authState.User.IsInRole("manager");

            return (isAdmin, isManager);
        }
    }

}
