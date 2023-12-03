namespace TheRestaurant.Presentation.Client.Components.Menu.Dto
{
    public record ClientProductDto(
         int Id,
         string Name,
         double Price,
         bool IsFoodItem,
         string Description,
         string MenuPhoto,
         List<string> Category,
         List<string> Allergen
         );
}
