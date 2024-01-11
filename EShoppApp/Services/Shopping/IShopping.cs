using MyAPI.EShoppApp.Data.DTOs;

namespace MyAPI.EShoppApp.Services.Shopping;

public interface IShopping
{
    public Task<bool> AddProductToCartCheck(Guid productid);
    public Task<bool> Checkout(PurchaseLogDTO purchasetolog);
    public Task RetrieveCart();
}