using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Contracts.Responses;

namespace TheRestaurant.Application.Cart.Interfaces
{
    public interface ICartRepository
    {
        Task<List<CartResponse>> GetAllCartItems(List<int> ListOfCartId);
    }
}
