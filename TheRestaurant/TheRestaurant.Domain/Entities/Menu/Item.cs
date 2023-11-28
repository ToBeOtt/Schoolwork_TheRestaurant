namespace TheRestaurant.Domain.Entities.Menu
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsFoodItem { get; set; }
        public string Description { get; set; }
        public byte[] MenuPhoto { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<MenuItemCategory> MenuItemCategories { get; set; }
        public ICollection<MenuItemAllergy> MenuItemAllergies { get; set; }
        public Item()
        {
            
        }
    }
}
