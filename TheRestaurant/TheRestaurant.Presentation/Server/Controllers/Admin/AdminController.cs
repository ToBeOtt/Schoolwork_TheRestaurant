using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheRestaurant.Presentation.Server.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("adminHome")]

    public class AdminController : ControllerBase
    {
        public AdminController()
        {
        }


        [HttpGet("Example")]
        public async Task<bool> Example()
        {
            bool validated = true;
            return validated;
        }

    }
}


