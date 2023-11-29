namespace TheRestaurant.Domain.Entities.Menu
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ProductCategory> MenuItemCategories { get; set; }

        public Category()
        {
            
        }
    }
}
