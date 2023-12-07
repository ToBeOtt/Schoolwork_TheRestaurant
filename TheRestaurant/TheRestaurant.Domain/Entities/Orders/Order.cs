using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Domain.Entities.Orders
{
    public enum Status
    {
        Pending,
        Started,
        Done
    }
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } 

        public Employee? Employee { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public int OrderStatusId { get; set; }
        public ICollection<OrderRow>? OrderRows { get; set; }

        public Order()
        {
            
        }
    }
}
