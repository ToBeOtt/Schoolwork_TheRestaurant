namespace TheRestaurant.Domain.Entities.Menu
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MenuItemCategory> MenuItemCategories { get; set; }

        public Category()
        {
            
        }
    }
}
