namespace TheRestaurant.Presentation.Shared.DTO.Orders
{
    public record ActiveOrdersDto(
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
