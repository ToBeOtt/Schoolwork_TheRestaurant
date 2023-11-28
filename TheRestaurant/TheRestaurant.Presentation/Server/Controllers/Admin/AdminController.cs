using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheRestaurant.Presentation.Server.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("adminHome")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Example")]
        public async Task<bool> Example()
        {
            bool validated = true;
            return validated;
        }

    }
}


