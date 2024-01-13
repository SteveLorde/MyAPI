using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Services.Repositories.ProductsRepository;
using MyAPI.EShopApp.Services.Shopping;

namespace MyAPI.Controllers.EShopApp;


[ApiController]
[Route("eshop/shopping")]
public class ShoppingController : Controller
{
    private readonly IShopping _shoppingservice;
    private readonly IProductsRepository _productrepo;

    public ShoppingController(IShopping shoppingservice, IProductsRepository productrepo)
    {
        _shoppingservice = shoppingservice;
        _productrepo = productrepo;
    }
    
    [Authorize]
    [HttpPost("checkout")]
    public async Task<bool> Checkout(PurchaseLogDTO purchasetolog)
    { 
        return await _shoppingservice.Checkout(purchasetolog);
    }
    
    [HttpGet("addtocartcheck/{id}")]
    public async Task<bool> AddToCartCheck(string productid)
    {
        return await _productrepo.CheckProduct(productid);
    }
    
    
    
}