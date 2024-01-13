using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Services.Repositories.NewsRepository;

public interface INewsRepository
{
    public Task CreateNewsFolders();
    public Task<List<News>> GetNews();
    public Task<bool> AddNews(NewsDTO newstoadd);
    public Task UpdateNews(NewsDTO newstoupdate);
    public Task RemoveNews(string newsid);
}