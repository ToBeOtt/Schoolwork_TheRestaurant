namespace TheRestaurant.Authentication.Requests
{
    public record RegisterRequest(
        string Email,
        string Alias,
        string Password);

}
