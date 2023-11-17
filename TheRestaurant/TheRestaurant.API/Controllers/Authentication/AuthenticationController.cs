using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Authentication.Requests;
using TheRestaurant.Authentication.Services.AuthenticationServices;
using TheRestaurant.Authentication.Services.RegistrationServices;

namespace TheRestaurant.API.Controllers.Authentication
{
    [ApiController]
    [Route("auth")]
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
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _registrationService.Register
                (request.Email, request.Alias, request.Password);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            string hello = "hello!";

            return Ok(hello);
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
