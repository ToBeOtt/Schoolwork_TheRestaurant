namespace TheRestaurant.Contracts.Responses.Orders
{
    public record ActiveOrdersResponse(
        int OrderNr,
        string? OrderComment,
        DateTime DateTimeOfOrder,
        List<ProductAndQuantity> ProductAndQuantity,
        string EmployeeName
        );

    public record ProductAndQuantity(
        string ProductName,
        int Quantity);
   
}
