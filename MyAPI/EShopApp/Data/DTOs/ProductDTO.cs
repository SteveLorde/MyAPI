using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Data.DTOs;

public class ProductDTO
{
    public Guid Id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public Guid? SubCategoryId { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
    public string[] images { get; set; }
    public IFormFile[] imagefiles { get; set; }
    public List<DiscountEvent> DiscountEvents { get; set; }
}