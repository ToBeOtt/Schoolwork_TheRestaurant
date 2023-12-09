namespace TheRestaurant.Contracts.Requests.Order
{
    public record UpdateOrderStatusRequest(
        int Id,
        string OrderStatus);
}
