namespace MyAPI.EShopApp.Data.DTOs;

public record PurchaseLogProductDTO
{
    public Guid Id { get; set; }
    public Guid PurchaseLogId { get; set; }
    public Guid ProductId { get; set; }
    public int PurchasedQuantity { get; set; }
};