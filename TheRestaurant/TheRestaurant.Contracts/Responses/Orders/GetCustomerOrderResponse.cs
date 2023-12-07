namespace TheRestaurant.Contracts.Responses.Orders
{
    public record GetCustomerOrderResponse(
        int OrderNr,
        List<string> ProductName,
        string Status,
        double SumToPay
        );
 
}
