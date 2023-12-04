namespace TheRestaurant.Presentation.Shared.DTO.Cart
{
    public record AggregatedCartDto(
        int IdOfOrderAggregate,
        string Name,
        double TotalPrice,
        int Count
        );
}
