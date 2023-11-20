using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TheRestaurant.Authentication.Interfaces;
using TheRestaurant.Authentication.Requests;
using TheRestaurant.Authentication.Services.AuthenticationServices;
using TheRestaurant.Authentication.Services.RegistrationServices;

namespace TheRestaurant.Presentation.Server.Controllers.Authentication
{
    [ApiController]
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        private readonly IJwtTokenRepository _jwtTokenRepository;
        private readonly HttpContext httpContext;

        public AdminController(
            IJwtTokenRepository jwtTokenRepository,
            HttpContext httpContext
           )
        {
            _jwtTokenRepository = jwtTokenRepository;
            this.httpContext = httpContext;
        }

        // REGISTRATION
        [HttpPost]
        [Route("index")]
        public async Task<IActionResult> Index(string token)
        {
            httpContext.User.IsInRole("Admin");
            var result = await _jwtTokenRepository.ValidateToken(token);

            return Ok();
        }
    }
}


