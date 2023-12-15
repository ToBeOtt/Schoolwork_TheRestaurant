using Microsoft.Extensions.Logging;
using TheRestaurant.Authentication.Interfaces;
using TheRestaurant.Contracts.Responses.ServiceResponse;
using static TheRestaurant.Authentication.Services.AuthenticationServices.DTO.AuthenticationDTO;

namespace TheRestaurant.Authentication.Services.AuthenticationServices
{
    public class AuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IJwtTokenRepository _jwtTokenRepository;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(
            IAuthenticationRepository authenticationRepository,
            IJwtTokenRepository jwtTokenRepository,
            ILogger<AuthenticationService> logger)
        {
            _authenticationRepository = authenticationRepository;
            _jwtTokenRepository = jwtTokenRepository;
            _logger = logger;
        }


        public async Task<ServiceResponse<ProvideJwtTokenDTO>> Login
            (string email, string password)
        {
            ServiceResponse <ProvideJwtTokenDTO> response = new();
            var user = await _authenticationRepository.GetUserByEmail(email);
            if (user == null)
                return await response.ErrorResponse
                    (response, "Invalid credentials.", _logger, "Invalid credentials.");


            var result = await _authenticationRepository.CheckLoginCredentials(user.UserName, password);
            if (!result.Succeeded)
                return await response.ErrorResponse
                    (response, "Invalid credentials.", _logger, "Invalid credentials.");

            var token = await _jwtTokenRepository.GenerateToken(user);

            ProvideJwtTokenDTO data = new(
                AppUser: user,
                Token: token);

            return await response.SuccessResponse
                    (response, data);
        }
    }
}
