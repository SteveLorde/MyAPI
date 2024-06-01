namespace MyAPI.EShopApp.Data.DTOs.Responses;

public record CheckOutFinalCostResponseDTO
{
    public decimal ProductsCost { get; set; }
    public decimal ImportFees { get; set; }
    public decimal ExtraFees { get; set; }
    public decimal FinalCost { get; set; }
};