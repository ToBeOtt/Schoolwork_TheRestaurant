namespace TheRestaurant.Contracts.Responses.Orders
{
    public class ProductForReceipt
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Size { get; set; }
        public double Price { get; set; }
        public double PriceWithoutVAT { get; set; }
        public double VAT { get; set; }
    }
       

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