namespace TheRestaurant.Contracts.Requests.Order
{
    public class CreateOrderRequest
    {
        public List<ProductAggregateForCreateOrder> ProductAggregate { get; set; } = new List<ProductAggregateForCreateOrder>();
        public string? Comment { get; set; }
        public CreateOrderRequest()
        {
            
        }
    }

    public class ProductAggregateForCreateOrder
    {
        public int ProductCount { get; set; }
        public int ProductId { get; set; }

        public ProductAggregateForCreateOrder(int count, int productId)
        {
            ProductCount = count;
            ProductId = productId;
        }
    }
}
