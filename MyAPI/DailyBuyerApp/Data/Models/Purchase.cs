namespace MyAPI.DailyBuyerApp.Data.Models;

public class Purchase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Storename { get; set; }
    public decimal Price { get; set; }
    public string Imagename { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public Boolean IsVerified { get; set; } = true;
}