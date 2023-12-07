using TheRestaurant.Presentation.Shared.DTO.Cart;

namespace TheRestaurant.Presentation.Shared.Requests.Order
{
    public record PlaceOrderRequest
    (
        List<AggregatedCartDto> ListOfAggregatedIds,
        string? Comment
    );
}
