using System.ComponentModel.DataAnnotations;

namespace MyAPI.EShopApp.Data.Models;

public class PurchaseLog
{
    [Key]
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public decimal totalcost { get; set; }
    public bool IsAccepted { get; set; }
    public DateTime CheckoutOn { get; set; }
}