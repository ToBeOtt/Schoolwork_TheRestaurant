namespace TheRestaurant.Contracts.Responses.Orders
{
    public record ActiveOrdersResponse(
        int OrderNr,
        DateTime DateTimeOfOrder,
        List<ProductAndQuantity> ProductAndQuantity
        );

    public record ProductAndQuantity(
        string ProductName,
        int Quantity);
   
}
