namespace TheRestaurant.Domain.Entities.Menu
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public Category Categories { get; set; }
        public int CategoriesId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public ProductCategory()
        {
            
        }
    }
}
