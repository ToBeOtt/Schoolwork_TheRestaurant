using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Authentication.Interfaces;
using TheRestaurant.Authentication.Requests;
using TheRestaurant.Authentication.Services.AuthenticationServices;
using TheRestaurant.Authentication.Services.RegistrationServices;

namespace TheRestaurant.Presentation.Server.Controllers.Authentication
{
    [ApiController]
    [Route("auth")]
    public class HomeController : ControllerBase
    {
        private readonly RegistrationService _registrationService;
        private readonly AuthenticationService _authenticationService;
        private readonly IJwtTokenRepository _jwtTokenRepository;
        private readonly HttpContext _httpContext;

        public HomeController(
            RegistrationService registrationService,
            AuthenticationService authenticationService,
             IJwtTokenRepository jwtTokenRepository,
            HttpContext httpContext
           )
        {
            _registrationService = registrationService;
            _authenticationService = authenticationService;
            _jwtTokenRepository = jwtTokenRepository;
            _httpContext = httpContext;
        }

        // REGISTRATION
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _registrationService.Register
                (request.Email, request.Alias, request.Password);
            if(!result.IsSuccess)
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
            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }

        // Token
        [HttpPost]
        [Route("GetToken")]
        public async Task<IActionResult> GetToken(IAccessTokenProvider TokenProvider)
        {
            var hm = await TokenProvider.RequestAccessToken();
            //var result = await _jwtTokenRepository.ValidateToken(hm);

            return Ok();
        }
    }
}
