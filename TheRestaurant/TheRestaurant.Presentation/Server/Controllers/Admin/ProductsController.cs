using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using TheRestaurant.Application.Interfaces.IProduct;
using TheRestaurant.Contracts.Requests.Product;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Presentation.Server.Controllers.Admin
{
    [ApiController]
    [Route("admin/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger,IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            try
            {
                var product = await _productService.CreateProductAsync(request);
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, new { product.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ett fel uppstod när menyalternativet skapades");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var menuItem = await _productService.GetProductById(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return Ok(menuItem);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var menuItems = await _productService.GetAllProducts();
                return Ok(menuItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ett fel uppstod när menyalternativen hämtades");
            }
        }
        [HttpPut("delete/{id}")]
        public async Task<IActionResult> SoftDeleteProduct(int id)
        {
            try
            {
                var menuItem = await _productService.GetProductById(id);
                if (menuItem == null)
                {
                    return NotFound();
                }

                menuItem.IsDeleted = true;
                await _productService.SoftDeleteProductAsync(menuItem.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ett fel uppstod när menyalternativet skulle raderas");
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, EditProductRequest request)
        {
            try
            {
                var menuItem = await _productService.UpdateProductAsync(id, request);
                if (menuItem == null)
                {
                    return NotFound();
                }
                return Ok(menuItem);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Ett fel uppstod när menyalternativet skulle uppdateras");
            }
        }
    }
}
