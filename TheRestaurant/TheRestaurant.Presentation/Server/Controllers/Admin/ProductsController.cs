using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using TheRestaurant.Application.Interfaces.IProduct;
using TheRestaurant.Contracts.Requests.Product;
using TheRestaurant.Domain.Entities.Menu;
using TheRestaurant.Presentation.Client.Components.Admin.ProductCrud.DTO;

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
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                MenuPhoto = product.MenuPhoto,
                IsDeleted = product.IsDeleted,
                IsFoodItem = product.IsFoodItem,
                Allergies = product.ProductAllergies
                    .Select(pa => new AllergyDto { Id = pa.AllergyId, Name = pa.Allergy.Name })
                    .ToList(),
                Categories = product.ProductCategories
                    .Select(pc => new CategoryDto { Id = pc.CategoryId, Name = pc.Category.Name })
                    .ToList(),
            };

            return Ok(productDto);
        }

        [HttpGet]
        [Route("admin/Order")]
        [Route("Order")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
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
                var product = await _productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }

                product.IsDeleted = true;
                await _productService.SoftDeleteProductAsync(product.Id);

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
                var product = await _productService.UpdateProductAsync(id, request);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Ett fel uppstod när menyalternativet skulle uppdateras");
            }
        }
    }
}
