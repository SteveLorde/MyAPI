namespace MyAPI.EShopApp.Data.DTOs.Requests;

public record CartProduct
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

public record FinalPriceRequestDTO
{
    public Guid UserId { get; set; }
    public List<CartProduct> CartProducts { get; set; }
};