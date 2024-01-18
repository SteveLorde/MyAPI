using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Services.Repositories.NewsRepository;

public interface INewsRepository
{
    public Task CreateNewsFolders();
    public Task<List<Event>> GetNews();
    public Task<bool> AddNews(EventDTO newstoadd);
    public Task UpdateNews(EventDTO newstoupdate);
    public Task RemoveNews(string newsid);
}