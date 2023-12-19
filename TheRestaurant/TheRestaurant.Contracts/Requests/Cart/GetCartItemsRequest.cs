namespace TheRestaurant.Contracts.Requests.Cart
{
    public record GetCartItemRequest(
        List<int> ListOfCartItems);
}
