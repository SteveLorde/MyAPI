using MyAPI.EShoppApp.Data.Models;

namespace MyAPI.EShoppApp.Services.Repositories.NewsRepository;

public interface INewsRepository
{
    public Task CreateNewsFolders();
    public Task<List<News>> GetNews();
    public Task AddNews(News newstoadd);
    public Task UpdateNews(News newstoupdate);
    public Task RemoveNews(News newstoremove);
}