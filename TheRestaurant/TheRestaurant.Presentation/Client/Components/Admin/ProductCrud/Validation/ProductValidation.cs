using System.ComponentModel.DataAnnotations;

namespace TheRestaurant.Presentation.Client.Components.Admin.ProductCrud.Validation
{
    public class ProductValidation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn krävs")]
        [StringLength(100, ErrorMessage = "Namnet kan inte överstiga 100 karaktärer")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Beskrivning krävs")]
        [StringLength(500, ErrorMessage = "Beskrivningen kan inte överstiga 500 karaktärer")]
        public string Description { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Pris kan inte vara negativt")]
        public double Price { get; set; }
        [Required]
        public bool IsFoodItem { get; set; }

        public bool IsDeleted { get; set; } = false;

        [Required]
        public byte[] MenuPhoto { get; set; }

        [Required(ErrorMessage = "Åtminstone en kategori krävs")]
        public List<int> SelectedCategoryIds { get; set; }

        public List<int> SelectedAllergyIds { get; set; }
    }
}
