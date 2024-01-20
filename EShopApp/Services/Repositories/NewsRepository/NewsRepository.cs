using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAPI.EShopApp.Data;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Services.Repositories.NewsRepository;

class NewsRepository : INewsRepository
{
    
    private readonly EShopDataContext _db;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _hostenv;

    public NewsRepository(EShopDataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment)
    {
        _db = db;
        _mapper = mapper;
        _hostenv = hostingEnvironment;
    }
    
    public async Task CreateNewsFolders()
    {
            var newsfoldertocheck = Path.Combine(_hostenv.ContentRootPath, "Storage", "EShopApp", "DiscountEvent");
            bool checkdirectory = Directory.Exists(newsfoldertocheck);
            if (!checkdirectory)
            {
                List<DiscountEvent> allnews = await _db.DiscountEvents.ToListAsync();
                foreach (DiscountEvent news in allnews)
                {
                    var newsfoldertocreate = Path.Combine(_hostenv.ContentRootPath, "Storage", "EShopApp" , "DiscountEvent",
                        $"{news.Id}", "Images");
                    Directory.CreateDirectory(newsfoldertocreate); 
                }
                Console.WriteLine("EShop: Created DiscountEvent folders successfully");
            }
            else
            {
                return;
            }
    }
    
    public async Task<List<DiscountEvent>> GetNews()
    {
        return await _db.DiscountEvents.ToListAsync();
    }

    public async Task<bool> AddNews(EventDTO newstoadd)
    {
        DiscountEvent discountEvent = new DiscountEvent();
        discountEvent = _mapper.Map<DiscountEvent>(newstoadd);
        await _db.DiscountEvents.AddAsync(discountEvent);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task UpdateNews(EventDTO newstoupdate)
    {
        DiscountEvent selectednews = await _db.DiscountEvents.FirstAsync(x => x.Id == newstoupdate.Id);
        selectednews = _mapper.Map<DiscountEvent>(newstoupdate);
        _db.DiscountEvents.Update(selectednews);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveNews(string newsid)
    {
        DiscountEvent selectednews = await _db.DiscountEvents.FirstAsync(x => x.Id == Guid.Parse(newsid));
        _db.DiscountEvents.Remove(selectednews);
        await _db.SaveChangesAsync();
    }
    
}