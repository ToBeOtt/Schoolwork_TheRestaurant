using TheRestaurant.Presentation.Shared.DTO.Cart;

namespace TheRestaurant.Presentation.Shared.Requests
{
    public record PlaceOrderRequest
    (
        List<AggregatedCartDto> ListOfAggregatedIds,
        string? Comment
    );
}
