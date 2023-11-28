using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TheRestaurant.Application.Interfaces.IAllergy;
using TheRestaurant.Contracts.Requests.Allergy;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Presentation.Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,manager")]
    public class AllergyController : ControllerBase
    {
        private readonly ILogger<AllergyController> _logger;
        private readonly IAllergyService _allergyService;

        public AllergyController(ILogger<AllergyController> logger, IAllergyService allergyService)
        {
            _logger = logger;
            _allergyService = allergyService;
        }

        [HttpGet]

        public async Task<ActionResult<List<Allergy>>> GetAllAllergies()
        {
            try
            {
                var allergies = await _allergyService.GetAllAllergies();
                _logger.LogInformation(@"{0} was called by: {1} at: {2}",
                    nameof(GetAllAllergies),
                    User.Identity.Name,
                    DateTime.UtcNow.ToShortTimeString()
                    );

                return Ok(allergies);
            }
            catch (Exception ex)
            {
                _logger.LogError(@"Error: {0}{1} -- Caused by user: {2} at:{3}",
                    ex.Message,
                    ex.InnerException,
                    User.Identity.Name,
                    DateTime.UtcNow.ToLongTimeString()
                    );
                return StatusCode(500, "Ett fel uppstod när allergiternativen hämtades");
            }
        }

        [HttpPost("create")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> CreateAllergy(AllergyRequest request)
        {

            try
            {

                var allergy = await _allergyService.CreateAllergyAsync(request);
                _logger.LogInformation(@"{0} was called by: {1} at: {2}",
                  nameof(CreateAllergy),
                  User.Identity.Name,
                  DateTime.UtcNow.ToShortTimeString()
                  );
                return CreatedAtAction(nameof(GetAllergy), new { id = allergy.Id }, allergy);

            }
            catch (Exception ex)
            {
                _logger.LogError(@"Error: {0}{1} -- Caused by user: {2} at:{3}",
                    ex.Message,
                    ex.InnerException,
                    User.Identity.Name,
                    DateTime.UtcNow.ToLongTimeString()
                    );

                return StatusCode(500, "Ett fel uppstod när allergiternativet skapades");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllergy(int id)
        {
            try
            {
                var allergy = await _allergyService.GetAllergyById(id);
                if (allergy == null)
                {

                    _logger.LogInformation(@"{0} was called and nothing was found, using id:{1} by: {2} at: {3}",
                      nameof(GetAllergy),
                      id,
                      User.Identity.Name,
                      DateTime.UtcNow.ToShortTimeString()
                      );
                    return NotFound();
                }

                _logger.LogInformation(@"{0} was called using id:{1} by: {2} at: {3}",
                      nameof(GetAllergy),
                      id,
                      User.Identity.Name,
                      DateTime.UtcNow.ToShortTimeString()
                      );

                return Ok(allergy);

            }
            catch (Exception ex)
            {
                _logger.LogError(@"Error: {0}{1} -- Using id:{2} Caused by user: {3} at:{4}",
                    ex.Message,
                    ex.InnerException,
                    id,
                    User.Identity.Name,
                    DateTime.UtcNow.ToLongTimeString()
                    );

                return StatusCode(500, "Ett fel uppstod när allergiternativet hämtades");
            }
        } 

    }
}
