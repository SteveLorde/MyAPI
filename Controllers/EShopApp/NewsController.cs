using Microsoft.AspNetCore.Mvc;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;
using MyAPI.EShopApp.Services.Repositories.NewsRepository;

namespace MyAPI.Controllers.EShopApp;

/*
[Authorize]
*/
[ApiController]
[Route("eshop/news")]
public class NewsController : Controller
{
    private readonly INewsRepository _newsrepo;

    public NewsController(INewsRepository newsrepo)
    {
        _newsrepo = newsrepo;
    }
    
    
    [HttpGet("getnews")]
    public async Task<List<News>> GetNews()
    {
        return await _newsrepo.GetNews();
    }
    
    [HttpPost("addnews")]
    public async Task<bool> AddNews(NewsDTO newstoadd)
    {
        return await _newsrepo.AddNews(newstoadd);
    }
    
    
    
}