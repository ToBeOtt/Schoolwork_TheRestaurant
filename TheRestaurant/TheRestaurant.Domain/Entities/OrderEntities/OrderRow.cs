using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Domain.Entities.OrderEntities
{
    public class OrderRow
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public OrderRow(Product product, Order order)
        {
            Product = product;
            Order = order;
        }
        public OrderRow()
        {
            
        }
    }
}
