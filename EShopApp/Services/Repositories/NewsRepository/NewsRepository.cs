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
            var newsfoldertocheck = Path.Combine(_hostenv.ContentRootPath, "Storage", "EShopApp", "Event");
            bool checkdirectory = Directory.Exists(newsfoldertocheck);
            if (!checkdirectory)
            {
                List<Event> allnews = await _db.News.ToListAsync();
                foreach (Event news in allnews)
                {
                    var newsfoldertocreate = Path.Combine(_hostenv.ContentRootPath, "Storage", "EShopApp" , "Event",
                        $"{news.Id}", "Images");
                    Directory.CreateDirectory(newsfoldertocreate); 
                }
                Console.WriteLine("EShop: Created Event folders successfully");
            }
            else
            {
                return;
            }
    }
    
    public async Task<List<Event>> GetNews()
    {
        return await _db.News.ToListAsync();
    }

    public async Task<bool> AddNews(EventDTO newstoadd)
    {
        Event @event = new Event();
        @event = _mapper.Map<Event>(newstoadd);
        await _db.News.AddAsync(@event);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task UpdateNews(EventDTO newstoupdate)
    {
        Event selectednews = await _db.News.FirstAsync(x => x.Id == newstoupdate.Id);
        selectednews = _mapper.Map<Event>(newstoupdate);
        _db.News.Update(selectednews);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveNews(string newsid)
    {
        Event selectednews = await _db.News.FirstAsync(x => x.Id == Guid.Parse(newsid));
        _db.News.Remove(selectednews);
        await _db.SaveChangesAsync();
    }
    
}