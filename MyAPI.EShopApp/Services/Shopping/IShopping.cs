using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.DTOs.Requests;
using MyAPI.EShopApp.Data.DTOs.Responses;

namespace MyAPI.EShopApp.Services.Shopping;

public interface IShopping
{
    public Task<CheckOutFinalCostResponseDTO> GetFinalPrice(FinalPriceRequestDTO finalPriceRequestDto);
    public Task<bool> AddProductToCartCheck(Guid productid);
    public Task<bool> Checkout(PurchaseLogDTO purchasetolog);
    public Task RetrieveCart();
}