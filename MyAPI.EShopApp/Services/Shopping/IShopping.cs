using MyAPI.EShopApp.Data.DTOs;

namespace MyAPI.EShopApp.Services.Shopping;

public interface IShopping
{
    public Task<bool> AddProductToCartCheck(Guid productid);
    public Task<bool> Checkout(PurchaseLogDTO purchasetolog);
    public Task RetrieveCart();
}