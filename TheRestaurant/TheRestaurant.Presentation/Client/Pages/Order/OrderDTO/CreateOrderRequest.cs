namespace TheRestaurant.Presentation.Client.Pages.Order.OrderDTO
{
    public class CreateOrderRequest
    {
        public DateTime OrderDate { get; set; }
        public List<OrderProductDto> OrderItems { get; set; }
    }

}
