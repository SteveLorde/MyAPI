using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Data.JointModels;

public class DiscountProduct
{
    public Guid ProductId { get; set; }
    public Guid EventId { get; set; }
    public DiscountEvent discountevent { get; set; }
    public Product product { get; set; }
}