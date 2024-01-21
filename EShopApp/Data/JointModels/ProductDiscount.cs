using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Data.JointModels;

public class ProductDiscount
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid DiscountEventId { get; set; }
    public DiscountEvent DiscountEvent { get; set; }
}