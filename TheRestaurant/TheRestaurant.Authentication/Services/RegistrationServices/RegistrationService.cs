using Microsoft.Extensions.Logging;
using TheRestaurant.Authentication.Interfaces;
using TheRestaurant.Authentication.Services.RegistrationServices.DTO;
using TheRestaurant.Authentication.Services.RoleServices;
using TheRestaurant.Contracts.Responses.ServiceResponse;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Authentication.Services.RegistrationServices
{
    public class RegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly RoleService _roleServices;
        private readonly ILogger<RegistrationService> _logger;

        public RegistrationService(
            IRegistrationRepository registrationRepository,
            RoleService roleServices,
            ILogger<RegistrationService> logger)
        {
            _registrationRepository = registrationRepository;
            _roleServices = roleServices;
            _logger = logger;
        }

        public async Task<ServiceResponse<RegistrationDto>> Register(string email, string alias, string password)
        {
            ServiceResponse<RegistrationDto> response = new();

            if (await _registrationRepository.CheckNoUserExist(email))
                return await response.ErrorResponse
                    (response, "Invalid credentials.", _logger, "Invalid credentials.");

            var user = new Employee();
            user.CreateUser(email, alias);
            user.UserName = alias;

            var result = await _registrationRepository.AddUser(user, password);
            if (!result.Succeeded)
                return await response.ErrorResponse
                    (response, "User could not be added.", _logger, "Invalid credentials.");

            var roleAssignment = await _roleServices.AssignRoleToUserAsync(user.Id, "admin");
            if(!roleAssignment.IsSuccess)
            {
                return await response.ErrorResponse
                   (response, "User could not be added.", _logger, "Invalid credentials.");
            }

            RegistrationDto data = new(
              AppUser: user);
            return await response.SuccessResponse
                    (response, data);
        }
    }
}
