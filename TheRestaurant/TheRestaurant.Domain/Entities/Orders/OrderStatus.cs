namespace TheRestaurant.Domain.Entities.Orders
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Order> Orders { get; set; }

        public OrderStatus() { }
    }
}
