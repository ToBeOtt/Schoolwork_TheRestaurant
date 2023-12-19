using TheRestaurant.Contracts.Responses;

namespace TheRestaurant.Application.Cart.Interfaces
{
    public interface ICartRepository
    {
        Task<List<CartResponse>> GetAllCartItems(List<int> ListOfCartId);
    }
}
