namespace TheRestaurant.Presentation.Shared.DTO.Orders
{
    public record ActiveOrdersDto(
       int OrderNr,
       DateTime DateTimeOfOrder,
       List<ProductAndQuantity> ProductAndQuantity
       );

    public record ProductAndQuantity(
        string ProductName,
        int Quantity);
}
