namespace TheRestaurant.Presentation.Shared.DTO.Orders
{
    public record FinishedOrderDto(
       int OrderNr,
       DateTime DateTimeOfOrder,
       string EmployeeName
       );
}
