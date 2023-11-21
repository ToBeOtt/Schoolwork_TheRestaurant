using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheRestaurant.Presentation.Server.Controllers.Admin
{
    [Authorize(Roles = "admin, manager")]
    [ApiController]
    [Route("adminHome")]

    public class AdminController : ControllerBase
    {
        public AdminController()
        {
        }

    }
}


