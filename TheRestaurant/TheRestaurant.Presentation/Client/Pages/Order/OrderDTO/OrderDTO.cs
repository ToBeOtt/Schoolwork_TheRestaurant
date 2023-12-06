using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Presentation.Client.Pages.Order.OrderDTO;

namespace TheRestaurant.Presentation.Shared.OrderDTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderProductDto> CartItems { get; set; }
        public string? Comment { get; set; }
    }
}