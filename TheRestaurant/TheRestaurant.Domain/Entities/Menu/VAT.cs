namespace TheRestaurant.Domain.Entities.Menu
{
    public class VAT
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Adjustment { get; set; }
        public bool IsDeleted { get; set; }
    }
}
