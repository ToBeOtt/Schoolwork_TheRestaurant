using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Application.Cart;
using TheRestaurant.Contracts.Requests.Cart;
using TheRestaurant.Presentation.Shared.Requests;

namespace TheRestaurant.Presentation.Server.Controllers.Authentication
{
    [ApiController]
    [Route("Cart")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly CartServices _cartServices;

        public CartController(
            ILogger<CartController> logger,
            CartServices cartServices)
        {
            _logger = logger;
            _cartServices = cartServices;
        }


        [HttpPost("GetProductsForCart")]
        public async Task<IActionResult> GetProductsForCart(GetCartItemRequest request)
        {
            var result = await _cartServices.FetchAllCartItems(request);
            
            if(!result.IsSuccess)
                return BadRequest(result);

            return Ok(result.Data);
        }
    }
}
