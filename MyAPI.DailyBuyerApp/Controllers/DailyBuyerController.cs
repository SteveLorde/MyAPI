using Microsoft.AspNetCore.Mvc;
using MyAPI.DailyBuyerApp.Data.DTO;
using MyAPI.DailyBuyerApp.Services.PurchaseManager;

namespace MyAPI.Controllers.DailyBuyerApp;

[ApiController]
[Route("dailybuyer")]
public class DailyBuyerController : Controller
{
    private readonly IPurchaseManager _purchaseManager;

    public DailyBuyerController(IPurchaseManager purchaseManager)
    {
        _purchaseManager = purchaseManager;
    }

    [HttpGet("getpurchases")]
    public async Task<List<PurchaseResponseDto>> GetPurchases()
    {
        return await _purchaseManager.GetPurchases();
    }
    
    [HttpPost("submitpurchase")]
    public async Task<bool> SubmitPurchase(PurchaseRequestDto purchaseReq)
    {
        return await _purchaseManager.AddPurchase(purchaseReq);
    }
    
    
    
    
}