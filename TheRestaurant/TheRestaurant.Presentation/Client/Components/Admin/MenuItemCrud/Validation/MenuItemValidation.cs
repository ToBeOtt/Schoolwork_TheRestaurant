using System.ComponentModel.DataAnnotations;

namespace TheRestaurant.Presentation.Client.Components.Admin.MenuItemCrud.Validation
{
    public class MenuItemValidation
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Namn behövs")]
        [StringLength(100, ErrorMessage ="Namnet kan inte överstiga 100 karaktärer")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Description is required")]
        [StringLength(500, ErrorMessage ="Beskrivningen kan inte överstiga 500 karaktärer")]
        public string Description { get; set; }

        // Validate Photo of menu item
        public byte[] MenuPhoto { get; set; }

        // Implement Validation classes for Category & Allergy
        [Required(ErrorMessage ="Behöver ha en kategori")]
        public ICollection<MenuItemCategoryValidation> MenuItemCategories { get; set; }
        public ICollection<MenuItemAllergyValidation>? MenuItemAllergies { get; set; }
    }

    // TODO: Remove these 2 mock classes below when actual implementation once available, just wanted to get rid of build erros in the meanwhile.
    public class MenuItemCategoryValidation
    {
        public int Id { get;set; }
        public string Name { get; set; }
    }

    public class MenuItemAllergyValidation
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
