using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyAPI.DailyBuyerApp.Data;
using MyAPI.DailyBuyerApp.Data.DTO;
using MyAPI.DailyBuyerApp.Data.Models;

namespace MyAPI.DailyBuyerApp.Services.PurchaseManager;

class PurchaseManager : IPurchaseManager
{
    private readonly DailyBuyerDataContext _db;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _hostenv;

    public PurchaseManager(DailyBuyerDataContext db, IMapper mapper, IWebHostEnvironment hostenv)
    {
        _db = db;
        _mapper = mapper;
        _hostenv = hostenv;
    }
    
    public async Task<List<PurchaseResponseDto>> GetPurchases()
    {
        return await _db.Purchases.ProjectTo<PurchaseResponseDto>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<bool> AddPurchase(PurchaseRequestDto purchaseRequest)
    {
        Purchase newpurchase = new Purchase();
        newpurchase = _mapper.Map<Purchase>(purchaseRequest);
        await CreateDataFolder(newpurchase.Id, purchaseRequest.Imagefile);
        newpurchase.Imagename = purchaseRequest.Imagefile.FileName;
        await _db.Purchases.AddAsync(newpurchase);
        await _db.SaveChangesAsync();
        return true;
    }

    private async Task CreateDataFolder(Guid newProductId, IFormFile imageFile)
    {
        string dataFolder = Path.Combine(_hostenv.ContentRootPath,"Storage","DailyBuyer",$"{newProductId}");
        Directory.CreateDirectory(dataFolder);
        string imageFilePath = Path.Combine(dataFolder, imageFile.FileName);
        var stream = new FileStream(imageFilePath,FileMode.Create);
        await imageFile.CopyToAsync(stream);
    }

    public async Task DecidePurchase(bool decision)
    {
        //to be made later
    }
}