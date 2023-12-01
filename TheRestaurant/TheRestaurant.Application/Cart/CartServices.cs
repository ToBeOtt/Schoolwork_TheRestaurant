using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;
using TheRestaurant.Application.Cart.Interfaces;
using TheRestaurant.Contracts.Responses;

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

        public async Task<ServiceResponse<List<CartResponse>>> FetchAllCartItems(List<int> cartItemIds)
        {
            ServiceResponse<List<CartResponse>> response = new();

            var listOfCartItems = await _cartRepository.GetAllCartItems(cartItemIds);
            if (listOfCartItems == null)
                return await response.ErrorResponse
                    (response, "CartItems could not be found", _logger);

            response.Data = listOfCartItems;
            return await response.SuccessResponse(response, response.Data);
        }

    }
}
