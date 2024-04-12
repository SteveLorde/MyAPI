using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAPI.EShopApp.Data;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.JointModels;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Services.Repositories.DiscountEventsRepository;

class DiscountEventsRepository : IDiscountEventsRepository
{
    
    private readonly EShopDataContext _db;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _hostenv;

    public DiscountEventsRepository(EShopDataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment)
    {
        _db = db;
        _mapper = mapper;
        _hostenv = hostingEnvironment;
    }
    
    public async Task CreateEventsFolders()
    {
            var newsfoldertocheck = Path.Combine(_hostenv.ContentRootPath, "Storage", "EShopApp", "Events");
            bool checkdirectory = Directory.Exists(newsfoldertocheck);
            if (!checkdirectory)
            {
                List<DiscountEvent> allevents = await _db.DiscountEvents.ToListAsync();
                foreach (DiscountEvent discountevent in allevents)
                {
                    var newsfoldertocreate = Path.Combine(_hostenv.ContentRootPath, "Storage", "EShopApp" , "Events",
                        $"{discountevent.Id}", "Images");
                    Directory.CreateDirectory(newsfoldertocreate); 
                }
                var check1stentity = Path.Combine(_hostenv.ContentRootPath, "Storage", "EShopApp", "Events", $"{allevents.First().Id}");
                if (Directory.Exists(check1stentity))
                {
                    Console.WriteLine("EShop: Created Events folders successfully");
                }
                else
                {
                    Console.WriteLine("EShop: creating events foders failed");
                }

            }
            else
            {
                return;
            }
    }
    
    public async Task<List<DiscountEvent>> GetEvents()
    {
        return await _db.DiscountEvents.ToListAsync();
    }

    public async Task<bool> AddDiscountEvent(DiscountEventDTO newstoadd)
    {
        //1-create new Events
        DiscountEvent discountEvent = new DiscountEvent();
        discountEvent = _mapper.Map<DiscountEvent>(newstoadd);
        discountEvent.Id = Guid.NewGuid();
        await _db.DiscountEvents.AddAsync(discountEvent);
        //2-create new joint ProductDiscounts for each product in eventdto
        foreach (var product in newstoadd.products)
        {
            var queriedproduct = await _db.Products.FirstAsync(p => p.Id == product.Id);
            //ProductDiscount discountproduct = new ProductDiscount {DiscountEvent = discountEvent, Product = queriedproduct};
            //await _db.DiscountProducts.AddAsync(discountproduct);
        }
        await _db.SaveChangesAsync();
        return true;
    }

    
    public async Task UpdateEvent(DiscountEventDTO newstoupdate)
    {
        DiscountEvent selectednews = await _db.DiscountEvents.FirstAsync(x => x.Id == newstoupdate.Id);
        selectednews = _mapper.Map<DiscountEvent>(newstoupdate);
        _db.DiscountEvents.Update(selectednews);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveEvent(string newsid)
    {
        DiscountEvent selectednews = await _db.DiscountEvents.FirstAsync(x => x.Id == Guid.Parse(newsid));
        _db.DiscountEvents.Remove(selectednews);
        await _db.SaveChangesAsync();
    }
    
}