using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAPI.EShopApp.Data;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.DTOs.Requests;
using MyAPI.EShopApp.Data.DTOs.Responses;
using MyAPI.EShopApp.Data.Models;
using MyAPI.EShopApp.Services.Repositories.ProductsRepository;

namespace MyAPI.EShopApp.Services.Shopping;

class Shopping : IShopping
{
    private readonly EShopDataContext _db;
    private readonly IMapper _mapper;
    private readonly IProductsRepository _productsRepo;

    public Shopping(EShopDataContext db, IProductsRepository productsRepo ,IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        _productsRepo = productsRepo;
    }

    public async Task<CheckOutFinalCostResponseDTO> GetFinalPrice(FinalPriceRequestDTO finalPriceRequestDto)
    {
        decimal productsCost = 0;
        decimal finalPrice = 0;
        decimal importFees = 0;
        decimal extraFees = 0;
        foreach (var cartProduct in finalPriceRequestDto.CartProducts)
        {
            ProductDTO product = await _productsRepo.GetProduct(cartProduct.ProductId.ToString());
            productsCost += product.Price;
        }
        //calculate import fees
        
        //calculate extra fees
        
        //calculate final price
        finalPrice = productsCost + importFees + extraFees;
        CheckOutFinalCostResponseDTO checkoutCostResponse = new CheckOutFinalCostResponseDTO()
            { ProductsCost = productsCost, ImportFees = importFees, ExtraFees = extraFees, FinalCost = finalPrice };
        return checkoutCostResponse;
    }

    public async Task<bool> AddProductToCartCheck(Guid productid)
    {
        return await _db.Products.AnyAsync(x => x.Id == productid);
    }

    public async Task<bool> Checkout(PurchaseLogDTO purchasetolog)
    {
        PurchaseLog purchaselog = _mapper.Map<PurchaseLog>(purchasetolog);
        await _db.PurchaseLogs.AddAsync(purchaselog);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task RetrieveCart()
    {
        throw new NotImplementedException();
    }
    
    
    
}