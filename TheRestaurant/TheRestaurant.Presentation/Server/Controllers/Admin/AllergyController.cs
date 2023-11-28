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
    public class AllergyController : ControllerBase
    {
        private readonly ILogger<AllergyController> _logger;
        private readonly IAllergyService _allergyService;

        public AllergyController(ILogger<AllergyController> logger,IAllergyService allergyService)
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
                _logger.LogError(@"TEST allAllergies log TEST");
                   
                return Ok(allergies);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                //Put Logger of some kind to log ex to console...

                return StatusCode(500, "Ett fel uppstod när allergiternativen hämtades");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AllergyRequest request)
        {
            
            try
            {

                var allergy = await _allergyService.CreateAllergyAsync(request);
                return CreatedAtAction(nameof(GetAllergy), new { id = allergy.Id }, allergy);

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                //Put Logger of some kind to log ex to console...

                return StatusCode(500 , $"{ex.Message} Ett fel uppstod när allergiternativet skapades");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllergy(int id)
        {
            var allergy = await _allergyService.GetAllergyById(id);
            if (allergy == null)
            {
                return NotFound();
            }
            return Ok(allergy);
        }

    }
}
