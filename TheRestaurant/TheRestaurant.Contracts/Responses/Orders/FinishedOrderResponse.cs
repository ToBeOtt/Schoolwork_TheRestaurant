namespace TheRestaurant.Contracts.Responses.Orders
{
    public record FinishedOrderResponse(
       int OrderNr,
       DateTime DateTimeOfOrder,
       string EmployeeName
       );
}
