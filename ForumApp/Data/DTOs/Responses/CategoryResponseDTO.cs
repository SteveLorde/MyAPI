using MyAPI.ForumApp.Data.Models;

namespace MyAPI.ForumApp.Data.DTOs.Responses;

public class CategoryResponseDTO
{
    public Guid Id { get; set; }
    public string name { get; set; }
    public int orderingid { get; set; }
    public List<SubCategoryResponseDTO> subcategories { get; set; }
    
}