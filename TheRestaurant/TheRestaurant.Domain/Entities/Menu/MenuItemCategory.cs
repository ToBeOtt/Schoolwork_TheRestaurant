namespace TheRestaurant.Domain.Entities.Menu
{
    public class MenuItemCategory
    {
        public int Id { get; set; }

        public Category Categories { get; set; }
        public int CategoriesId { get; set; }

        public MenuItem MenuItem { get; set; }
        public int MenuItemId { get; set; }

        public MenuItemCategory()
        {
            
        }
    }
}
