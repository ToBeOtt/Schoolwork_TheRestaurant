namespace TheRestaurant.Domain.Entities.OrderEntities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }

        public OrderStatus() { }
    }
}
