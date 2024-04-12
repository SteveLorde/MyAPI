namespace MyAPI.DailyBuyerApp.Data.DTO;

public class PurchaseRequestDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Storename { get; set; }
    public decimal Price { get; set; }
    public IFormFile Imagefile { get; set; }
    public DateOnly Date { get; set; }
    
}