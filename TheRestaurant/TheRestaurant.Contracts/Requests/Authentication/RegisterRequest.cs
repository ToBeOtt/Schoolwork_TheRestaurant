namespace TheRestaurant.Contracts.Requests.Authentication
{
    public record RegisterRequest(
        string Email,
        string Alias,
        string Password);

}
