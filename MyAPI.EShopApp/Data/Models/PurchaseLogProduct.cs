namespace MyAPI.EShopApp.Data.Models;

public class PurchaseLogProduct
{
    public Guid Id { get; set; }
    public Guid PurchaseLogId { get; set; }
    public Guid ProductId { get; set; }
    public PurchaseLog PurchaseLog { get; set; }
    public Product Product { get; set; }
    public int PurchasedQuantity { get; set; }
}