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
            var newsfoldertocheck = Path.Combine(_hostenv.ContentRootPath, "Storage", "EShopApp", "News");
            bool checkdirectory = Directory.Exists(newsfoldertocheck);
            if (!checkdirectory)
            {
                List<News> allnews = await _db.News.ToListAsync();
                foreach (News news in allnews)
                {
                    var newsfoldertocreate = Path.Combine(_hostenv.ContentRootPath, "Storage", "EShopApp" , "News",
                        $"{news.Id}", "Images");
                    Directory.CreateDirectory(newsfoldertocreate); 
                }
                Console.WriteLine("EShop: Created News folders successfully");
            }
            else
            {
                return;
            }
    }
    
    public async Task<List<News>> GetNews()
    {
        return await _db.News.ToListAsync();
    }

    public async Task<bool> AddNews(NewsDTO newstoadd)
    {
        News news = new News();
        news = _mapper.Map<News>(newstoadd);
        await _db.News.AddAsync(news);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task UpdateNews(NewsDTO newstoupdate)
    {
        News selectednews = await _db.News.FirstAsync(x => x.Id == newstoupdate.Id);
        selectednews = _mapper.Map<News>(newstoupdate);
        _db.News.Update(selectednews);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveNews(string newsid)
    {
        News selectednews = await _db.News.FirstAsync(x => x.Id == Guid.Parse(newsid));
        _db.News.Remove(selectednews);
        await _db.SaveChangesAsync();
    }
    
}