using Microsoft.AspNetCore.Components.Authorization;

namespace TheRestaurant.Presentation.Client.Helpers
{
    public class CheckRole
    {
        private readonly ServerAuthenticationStateProvider _authState;

        public CheckRole(ServerAuthenticationStateProvider AuthState)
        {
            _authState = AuthState;
        }

        private bool IsAuthenticated;
        public async Task<bool> CheckIfActiveRole()
        {
            // Subscribe to the authentication state changed event
            _authState.AuthenticationStateChanged += HandleAuthenticationStateChanged;

            return await UpdateSuccessState();

        }     

        private async Task<bool> UpdateSuccessState()
        {
            var user = await _authState.GetAuthenticationStateAsync();

            if ((user.User.IsInRole("manager")) || (user.User.IsInRole("admin")))
                IsAuthenticated = true;

            else IsAuthenticated = false;

            return IsAuthenticated;
        }

        private async void HandleAuthenticationStateChanged(Task<AuthenticationState> authenticationStateTask)
        {
            await UpdateSuccessState();
        }
    }
}
