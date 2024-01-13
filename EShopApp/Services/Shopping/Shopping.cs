using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAPI.EShopApp.Data;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Services.Shopping;

class Shopping : IShopping
{
    private readonly EShopDataContext _db;
    private readonly IMapper _mapper;

    public Shopping(EShopDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
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