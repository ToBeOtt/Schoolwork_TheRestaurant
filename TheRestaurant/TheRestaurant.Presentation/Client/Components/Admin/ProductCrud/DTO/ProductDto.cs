using TheRestaurant.Contracts.DTOs;

namespace TheRestaurant.Presentation.Client.Components.Admin.ProductCrud.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double PriceBeforeVat { get; set; }
        public string Description { get; set; }
        public bool IsFoodItem { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] MenuPhoto { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<AllergyDto> Allergies { get; set; }
        public int VatId { get; set; }
    }
}
