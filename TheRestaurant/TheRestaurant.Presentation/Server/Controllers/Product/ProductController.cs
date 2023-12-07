using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Application.Services.ProductServices;

namespace TheRestaurant.Presentation.Server.Controllers.Admin
{
    [ApiController]
    [Route("Products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductService _productService;

        public ProductController
            (ILogger<ProductController> logger,
            ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result.Data);
        }

        [HttpGet("GetCategoriesForProducts")]
        public async Task<IActionResult> GetCategoriesForProducts()
        {
            var result = await _productService.FetchAllCategoryNames();
            return Ok(result);
        }
        
    }
}


