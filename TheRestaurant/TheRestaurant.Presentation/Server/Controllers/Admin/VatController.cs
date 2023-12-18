using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Application.Interfaces.IVat;
using TheRestaurant.Contracts.Requests.Vat;

namespace TheRestaurant.Presentation.Server.Controllers.Admin
{
    [Route("admin/[controller]")]
    [ApiController]
    public class VatController : ControllerBase
    {
        private readonly IVatService _vatService;

        public VatController(IVatService vatService)
        {
            _vatService = vatService;
        }

        // Get all
        [HttpGet]
        public async Task<IActionResult> GetAllVats()
        {
            try
            {
                var vats = await _vatService.GetAllVatsAsync();
                return Ok(vats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ett fel uppstod när momsen hämtades: {ex.Message}");
            }

        }

        // Get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVatById(int id)
        {
            try
            {
                var vat = await _vatService.GetVatByIdAsync(id);
                if (vat == null)
                {
                    return NotFound();
                }
                return Ok(vat);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ett fel uppstod när momsen hämtades: {ex.Message}");
            }

        }

        // Create 
        [HttpPost]
        public async Task<IActionResult> CreateVat(VatRequest vatRequest)
        {
            try
            {

                var createdVat = await _vatService.CreateVatAsync(vatRequest);
                return CreatedAtAction(nameof(GetVatById), new { id = createdVat.Id }, createdVat);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ett fel uppstod när momsen skapdes: {ex.Message}");
            }
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVat(int id, VatRequest vatRequest)
        {
            try
            {
                var updatedVat = await _vatService.UpdateVatAsync(id, vatRequest);
                if (updatedVat == null)
                {
                    return NotFound();
                }

                return Ok(updatedVat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ett fel uppstod när moms skulle uppdateras: {ex.Message}");
            }
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteVat(int id)
        {
            try
            {
                await _vatService.SoftDeleteVatAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ett fel uppstod när moms skulle raderas: {ex.Message}");
            }

        }
    }
}
