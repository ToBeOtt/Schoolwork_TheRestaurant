namespace TheRestaurant.Domain.Entities.Menu
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] MenuPhoto { get; set; }
        public ICollection<MenuItemCategory> MenuItemCategories { get; set; }
        public ICollection<MenuItemAllergy> MenuItemAllergies { get; set; }
        public MenuItem()
        {
            
        }
    }
}
