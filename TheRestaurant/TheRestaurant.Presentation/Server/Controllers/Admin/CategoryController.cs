using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheRestaurant.Application.Interfaces.ICategory;
using TheRestaurant.Contracts.DTOs;
using TheRestaurant.Domain.Entities.Menu;


namespace TheRestaurant.Presentation.Server.Controllers.Admin
{
    [Route("api/Category")]
    [ApiController]
    [Authorize(Roles = "admin,manager")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            try
            {
                //throw new ArgumentException("Test Exception");
                var categories = await _categoryService.GetAllAsync();
                if (categories.Count == 0)
                {
                    LogWarn("Vi har inga kategorier");
                    return NotFound();
                };
                LogInfo($"Vi har {categories.Count} kategorier");
                return Ok(categories);
            }
            catch (Exception ex)
            {
                LogErr(ex.Message);
                return StatusCode(500, "Serverfel för att ladda ner alla kategorier");
                throw;
            }

        }

        // GET api/Category/2
        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {

            try
            {
                //throw new ArgumentException("Test Exception");

                if (await _categoryService.GetAllAsync() == null)
                {
                    LogWarn("Vi har inga kategorier");
                    return NotFound();
                }

                var categoriy = await _categoryService.GetAsync(id);
                if (categoriy == null)
                {
                    LogWarn($"Vi har ingen kategori med id {id}");
                    return NotFound();
                };
                return Ok(categoriy);
            }
            catch (Exception ex)
            {
                LogErr(ex.Message);
                return StatusCode(500, $"Serverfel för att ladda ner kategori med {id}");
                throw;
            }

        }


        // POST api/Category
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory([FromBody] CategoryDto categoryDto)
        {
            try
            {
                //throw new ArgumentException("Test Exception");
                await _categoryService.AddAsync(categoryDto);
                LogInfo($"kategori {categoryDto.Name} tillagd");
                return CreatedAtAction("GetCategory", new { id = categoryDto.Id }, categoryDto);
            }
            catch (Exception ex)
            {
                LogErr(ex.Message);
                return Problem($"Serverfel för lägg till kategori {categoryDto.Name}");
                throw;
            }
        }

        // PUT api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromBody] CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                LogWarn($"Id är inte detsamma som kategoriId");
                return BadRequest();
            }

            if (!_categoryService.Exists(id))
            {
                LogWarn($"Vi har ingen kategori med id {id}");
                return NotFound();
            }


            try
            {
                //throw new ArgumentException("Test Exception");
                await _categoryService.UpdateAsync(categoryDto);
                LogInfo($"kategori {categoryDto.Name} uppdaterade");
            }
            catch (Exception ex)
            {
                    LogErr(ex.Message);
                    return Problem($"Serverfel för uppdatera kategori {categoryDto.Name}");
                    throw;
            }

            return NoContent();

        }


        // DELETE api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryDto = await _categoryService.GetAsync(id);
            if (categories == null || categoryDto == null)
            {
                LogWarn($"Vi har ingen kategori med id {id}");
                return NotFound();
            };

            
            try
            {
                //throw new ArgumentException("Test Exception");
                await _categoryService.DeleteAsync(id);
                LogInfo($"kategori {categoryDto.Name} raderade");
            }
            catch (Exception ex)
            {
                LogErr(ex.Message);
                return Problem($"Serverfel för radera kategori {categoryDto.Name}");
                throw;
            }

            return NoContent();
        }




        // Logger ---------------------------------------------------------------------------
        private void LogErr(string message)
        {
            _logger.LogError($"*************************** LOGERROR: {message} ***");
        }

        private void LogInfo(string message)
        {
            _logger.LogInformation($"*************************** LOGINFO: {message} ***");
        }

        private void LogWarn(string message)
        {
            _logger.LogWarning($"*************************** LOGWARNING: {message} ***");
        }


    }
}
