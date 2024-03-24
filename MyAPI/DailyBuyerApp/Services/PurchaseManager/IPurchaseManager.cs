using MyAPI.DailyBuyerApp.Data.DTO;

namespace MyAPI.DailyBuyerApp.Services.PurchaseManager;

public interface IPurchaseManager
{
    public Task<List<PurchaseResponseDto>> GetPurchases();
    public Task<bool> AddPurchase(PurchaseRequestDto purchaseRequest);
    public Task DecidePurchase(bool decision);
}