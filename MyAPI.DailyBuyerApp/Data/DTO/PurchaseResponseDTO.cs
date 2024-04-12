namespace MyAPI.DailyBuyerApp.Data.DTO;

public class PurchaseResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Storename { get; set; }
    public decimal Price { get; set; }
    public string Imagename { get; set; }
    public DateTime Date { get; set; }
    public Boolean IsVerified { get; set; }
}