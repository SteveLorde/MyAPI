
using MyAPI.EShopApp.Data.JointModels;

namespace MyAPI.EShopApp.Data.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; }
    public int Price { get; set; }
    public int Barcode { get; set; }
    public int Quantity { get; set; } = 1;
    public DateOnly AddedOn { get; set; }
    public string[] Images { get; set; }
    public int Sells { get; set; }
    public List<DiscountEvent> DiscountEvents { get; set; }
    public List<PurchaseLog> PurchaseLogs { get; set; }

}