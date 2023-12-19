namespace TheRestaurant.Presentation.Shared.DTO.Orders
{
    public record ActiveOrdersDto(
       int OrderNr,
       string? OrderComment,
       DateTime DateTimeOfOrder,
       List<ProductAndQuantity> ProductAndQuantity,
       string EmployeeName
       );

    public class ProductAndQuantity
    {
        public string ProductName { get; set; }
        public string? Size { get; set; }
        public int Quantity { get; set; }
    }
        
}
