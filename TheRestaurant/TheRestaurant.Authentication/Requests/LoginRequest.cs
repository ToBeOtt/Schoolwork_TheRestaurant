namespace TheRestaurant.Authentication.Requests
{
    public record LoginRequest(
         string Email,
         string Password
        );
}
