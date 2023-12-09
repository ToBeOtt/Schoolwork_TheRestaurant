namespace TheRestaurant.Presentation.Shared.DTO.Orders
{
    public record OrderDetailsDTO (
        int OrderNr,
        List<string> ProductName,
        string EmployeeName,
        double SumToPay,
        string comment
        );
}
