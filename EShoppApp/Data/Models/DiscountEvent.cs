namespace MyAPI.EShoppApp.Data.Models;

public class DiscountEvent
{
    public Guid Id { get; set; }
    public string discountname { get; set; }
    public decimal discountamount { get; set; }
    public List<Product> Products { get; set; }
    
}