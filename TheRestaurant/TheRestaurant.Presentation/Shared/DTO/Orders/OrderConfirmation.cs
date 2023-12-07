namespace TheRestaurant.Presentation.Shared.DTO.Orders
{
    public record OrderConfirmation(
          bool IsSuccess,
          int OrderNr );
}
