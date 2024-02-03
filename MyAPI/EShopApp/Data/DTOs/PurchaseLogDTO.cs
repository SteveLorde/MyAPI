using System.ComponentModel.DataAnnotations;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Data.DTOs;

public class PurchaseLogDTO
{
    public Guid Id { get; set; }
    public List<Product> Products { get; set; }
    public Guid UserId { get; set; }
    public DateTime CheckoutOn { get; set; }
    public decimal Extrafees { get; set; }
    public decimal Totalamount { get; set; }
}