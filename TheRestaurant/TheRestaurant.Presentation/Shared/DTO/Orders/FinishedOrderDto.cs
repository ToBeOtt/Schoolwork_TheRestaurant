namespace TheRestaurant.Presentation.Shared.DTO.Orders
{
    public record FinishedOrderDto(
       int OrderNr,
       string? OrderComment,
       DateTime DateTimeOfOrder,
       string EmployeeName
       );
}
