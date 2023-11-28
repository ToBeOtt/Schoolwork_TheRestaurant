using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Contracts.DTOs;
using TheRestaurant.Domain.Entities.Menu;


namespace TheRestaurant.Presentation.Server.Controllers.Admin
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            if (categories.Count == 0)
            {
                return NotFound();
            };
            return Ok(categories);
        }

        // GET api/Category/5
        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {

            var categories = await _categoryService.GetAllAsync();
            if (categories.Count == 0)
            {
                return NotFound();
            };

            var categoriy = await _categoryService.GetAsync(id);
            if(categoriy == null)
            {
                return NotFound();
            };
            return Ok(categoriy);
        }


        // POST api/Category
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory([FromBody] CategoryDto categoryDto)
        {
            if (await _categoryService.GetAllAsync() == null)
            {
                return Problem("Entity set 'Categories'  is null.");
            }
            await _categoryService.AddAsync(categoryDto);
            
            return CreatedAtAction("GetCategory", new { id = categoryDto.Id }, categoryDto);
        }

        // PUT api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromBody] CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _categoryService.UpdateAsync(categoryDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_categoryService.Equals(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }


        // DELETE api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryDto = await  _categoryService.GetAsync(id);
            if (categories == null || categoryDto == null)
            {
                return NotFound();
            };

            await _categoryService.DeleteAsync(id);
            return NoContent();
        }



        //// PUT api/<CategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

    }
}
