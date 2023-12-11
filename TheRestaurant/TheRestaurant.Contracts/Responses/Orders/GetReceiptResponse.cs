namespace TheRestaurant.Contracts.Responses.Orders
{
    public record ProductForReceipt(
       int ProductId,
       string ProductName,
       double Price,
       double PriceWithoutVAT);

    public class GetReceiptResponse
    {
        public int OrderNr { get; set; }
        public DateTime OrderDate { get; set; }
        public string EmployeeResponsible { get; set; } 
        public List<ProductForReceipt> Products { get; set; }
        public double Totalprice { get; set; }

        public GetReceiptResponse
            (int orderNr, DateTime orderDate, string employeeResponsible)
        {
            OrderNr = orderNr;
            OrderDate = orderDate;
            EmployeeResponsible = employeeResponsible;
            Products = new List<ProductForReceipt>();
        }
    }
        
}
