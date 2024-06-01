using System.ComponentModel.DataAnnotations;

namespace MyAPI.EShopApp.Data.Models;

public class PurchaseLog
{
    public Guid Id { get; set; }
    public List<PurchaseLogProduct> PurchaseLogProducts { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime CheckoutOn { get; set; } = DateTime.Now;
    public decimal ExtraFees { get; set; }
    public bool IsAccepted { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsShipped { get; set; }
}