namespace TheRestaurant.Contracts.Responses.Orders
{
    public record FinishedOrderResponse(
       int OrderNr,
       string? OrderComment,
       DateTime DateTimeOfOrder,
       string EmployeeName
       );
}
