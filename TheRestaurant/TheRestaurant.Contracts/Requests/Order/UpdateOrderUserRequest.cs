namespace TheRestaurant.Contracts.Requests.Order
{
    public record UpdateOrderUserRequest(
        int Id,
        string EmployeeId);
   
}
