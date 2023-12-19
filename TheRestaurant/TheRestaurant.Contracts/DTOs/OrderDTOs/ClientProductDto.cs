namespace TheRestaurant.Contracts.DTOs.OrderDTOs
{
    public class ClientProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsFoodItem { get; set; }
        public string Description { get; set; }
        public string MenuPhoto { get; set; }
        public List<string> Category { get; set; }
        public List<string> Allergen { get; set; }
        public string? Size { get; set; }

    }
}
