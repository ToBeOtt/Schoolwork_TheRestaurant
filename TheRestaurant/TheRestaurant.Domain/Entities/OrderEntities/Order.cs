namespace TheRestaurant.Domain.Entities.OrderEntities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } 


        public ICollection<EmployeeOrder> EmployeeOrders { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderRow> OrderRows { get; set; }

        public Order()
        {
            
        }
    }
}
