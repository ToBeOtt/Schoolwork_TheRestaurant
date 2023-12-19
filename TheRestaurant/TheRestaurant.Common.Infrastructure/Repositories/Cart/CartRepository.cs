using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheRestaurant.Application.Cart.Interfaces;
using TheRestaurant.Contracts.Responses;

namespace TheRestaurant.Common.Infrastructure.Repositories.Cart
{
    public class CartRepository : ICartRepository
    {
        private readonly ILogger<CartRepository> _logger;
        private readonly RestaurantDbContext _context;

        public CartRepository
            (ILogger<CartRepository> logger,
            RestaurantDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<List<CartResponse>> GetAllCartItems(List<int> ListOfCartId)
        {
            List<CartResponse> cartItems = new List<CartResponse>();

            foreach (var id in ListOfCartId)
            {
                var product = await _context.Products
                    .Include(x => x.ProductCategories)   
                        .ThenInclude(x => x.Category)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (product != null)
                {
                    CartResponse cartItem = new CartResponse
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price =  product.Price
                    };

                    if(product.Name.Contains("T-shirt"))
                    {
                        cartItem.Size = product.Size;
                    }

                    cartItems.Add(cartItem);
                }
            }
            return cartItems;
        }
    }
}
