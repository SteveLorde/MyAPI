namespace MyAPI.EShopApp.Data.DTOs.Responses;

public record PaginatedProductsResponseDTO
{
    public IEnumerable<ProductDTO> Products { get; set; }
    public int TotalPages { get; set; }
}