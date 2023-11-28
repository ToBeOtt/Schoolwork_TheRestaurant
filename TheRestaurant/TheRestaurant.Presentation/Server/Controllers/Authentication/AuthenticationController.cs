using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Authentication.Requests;
using TheRestaurant.Authentication.Services.AuthenticationServices;
using TheRestaurant.Authentication.Services.RegistrationServices;

namespace TheRestaurant.Presentation.Server.Controllers.Authentication
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly RegistrationService _registrationService;
        private readonly AuthenticationService _authenticationService;

        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            RegistrationService registrationService,
            AuthenticationService authenticationService
           )
        {
            _logger = logger;
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
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorResponse);
            }

            return Ok();
        }


        // LOGIN
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authenticationService.Login
                (request.Email, request.Password);
            if (!result.IsSuccess)
            {
                return Unauthorized();
            }
            string token = result.Data.Token;
            return Ok(token);
        }


        [HttpGet("Example")]
        public async Task<bool> TestExample()
        {
            bool validated = true;
            return validated;
        }
    }
}
