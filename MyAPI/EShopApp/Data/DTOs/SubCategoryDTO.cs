using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Data.DTOs;

public class SubCategoryDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid MainCategoryId { get; set; }
    public MainCategory MainCategory { get; set; }
    
    public List<ProductDTO> Products { get; set; }
}