using System.ComponentModel.DataAnnotations;

namespace MyAPI.EShopApp.Data.Models;

public class PurchaseLog
{
    public Guid Id { get; set; }
    public List<Product> Products { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime CheckoutOn { get; set; }
    public decimal Extrafees { get; set; }
    public bool IsAccepted { get; set; }
    public decimal Totalamount { get; set; }
    public bool IsShipped { get; set; }
}