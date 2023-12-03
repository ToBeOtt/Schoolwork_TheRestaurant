using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Application.Cart;
using TheRestaurant.Authentication.Requests;
using TheRestaurant.Authentication.Services.AuthenticationServices;
using TheRestaurant.Authentication.Services.RegistrationServices;
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
            var result = await _cartServices.FetchAllCartItems(request.ListOfId);
            return Ok(result.Data);
        }
    }
}
