using Microsoft.AspNetCore.Http;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Data.DTOs;

public class ProductDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public string[] Images { get; set; }
    public IFormFile[] Imagefiles { get; set; }
    public List<DiscountEvent> DiscountEvents { get; set; }
}