using Microsoft.Extensions.Logging;
using TheRestaurant.Application.Cart.Interfaces;
using TheRestaurant.Contracts.Requests.Cart;
using TheRestaurant.Contracts.Responses;
using TheRestaurant.Contracts.Responses.ServiceResponse;

namespace TheRestaurant.Application.Cart
{
    public class CartServices
    {

        private readonly ILogger<CartServices> _logger;
        private readonly ICartRepository _cartRepository;

        public CartServices
            (ILogger<CartServices> logger,
            ICartRepository cartRepository)
        {
            _logger = logger;
            _cartRepository = cartRepository;
        }

        public async Task<ServiceResponse<List<CartResponse>>> FetchAllCartItems(GetCartItemRequest request)
        {
            ServiceResponse<List<CartResponse>> response = new();

            var listOfCartItems = await _cartRepository.GetAllCartItems(request.ListOfCartItems);
            if (listOfCartItems == null)
                return await response.ErrorResponse
                    (response, "CartItems could not be found", _logger);

            response.Data = listOfCartItems;
            return await response.SuccessResponse(response, response.Data);
        }

    }
}
