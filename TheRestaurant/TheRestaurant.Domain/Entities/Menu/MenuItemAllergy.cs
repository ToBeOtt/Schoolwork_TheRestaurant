namespace TheRestaurant.Domain.Entities.Menu
{
    public class MenuItemAllergy
    {
        public int Id { get; set; }
        public Allergy Allergy { get; set; }
        public int AllergyId { get; set; }

        public Item MenuItem { get; set; }
        public int MenuItemId { get; set; }
        public MenuItemAllergy()
        {
            
        }
    }
}
