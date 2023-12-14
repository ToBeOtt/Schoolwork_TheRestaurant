namespace TheRestaurant.Domain.Entities.Menu
{
    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int VATId { get; set; }
        public VAT VAT { get; set; }
        public double PriceBeforeVAT { get; set; }
        public double Price { get; set; }


        public bool IsFoodItem { get; set; }
        public string Description { get; set; }
        public byte[]? MenuPhoto { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<ProductAllergy>? ProductAllergies { get; set; }
        public Product()
        {
            
        }

        public void SetPriceWithVAT(Product product)
        {
            var calculatedPrice = this.Price = (PriceBeforeVAT * VAT.Adjustment);
            product.Price = (int)Math.Round(calculatedPrice);
        }

    }
}
