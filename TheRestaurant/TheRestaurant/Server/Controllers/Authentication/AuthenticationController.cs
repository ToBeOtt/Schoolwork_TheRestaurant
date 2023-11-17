using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Authentication.Requests;
using TheRestaurant.Authentication.Services.AuthenticationServices;
using TheRestaurant.Authentication.Services.RegistrationServices;

namespace TheRestaurant.API.Controllers.Authentication
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class AuthenticationController : ControllerBase
    {
        private readonly RegistrationService _registrationService;
        private readonly AuthenticationService _authenticationService;

        public AuthenticationController(
            RegistrationService registrationService,
            AuthenticationService authenticationService
           )
        {
            _registrationService = registrationService;
            _authenticationService = authenticationService;
        }

        // REGISTRATION
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _registrationService.Register
                (request.Email, request.Alias, request.Password);

            return Ok(result);
        }

    // LOGIN
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authenticationService.Login
                (request.Email, request.Password); 
            if(result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
