namespace TheRestaurant.Contracts.Responses.Orders
{
    public record GetCustomerOrderDTO(
        int OrderNr,
        List<string> ProductName,
        string Status,
        double SumToPay
        );
 
}
