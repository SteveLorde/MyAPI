using Microsoft.AspNetCore.Mvc;
using MyAPI.EShoppApp.Data.Models;
using MyAPI.EShoppApp.Services.Repositories.NewsRepository;

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
    public async Task<List<News>> AddNews()
    {
        return await _newsrepo.AddNews();
    }
    
    
    
}