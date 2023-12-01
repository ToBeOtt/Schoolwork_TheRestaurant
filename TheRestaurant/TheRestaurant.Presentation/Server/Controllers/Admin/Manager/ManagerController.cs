using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Application.Employees;
using static TheRestaurant.Presentation.Shared.Requests.EmployeeRequests;

namespace TheRestaurant.Presentation.Server.Controllers.Admin.Manager
{
    [Authorize(Roles = "manager")]
    [ApiController]
    [Route("managerHome")]

    public class ManagerController : ControllerBase
    {
        private readonly EmployeeServices _employeeServices;
        private readonly ILogger<ManagerController> _logger;

        public ManagerController
            (EmployeeServices employeeServices,
            ILogger<ManagerController> logger)
        {
            _employeeServices = employeeServices;
            _logger = logger;
        }


        [HttpPost("RemoveEmployee")]
        public async Task<IActionResult> RemoveEmployee(DeleteEmployeeRequest request)
        {
            var result = await _employeeServices.RemoveEmployee(request.Id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorResponse);
            }
            return Ok();
        }


        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _employeeServices.FetchAllEmployees();
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorResponse);
            }

            return Ok(result.Data);
        }
    }
}


