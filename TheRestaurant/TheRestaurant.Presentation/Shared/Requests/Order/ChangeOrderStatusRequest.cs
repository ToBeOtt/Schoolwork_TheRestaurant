namespace TheRestaurant.Presentation.Shared.Requests.Order
{
    public record ChangeOrderStatusRequest(
        int Id,
        string OrderStatus);
}
