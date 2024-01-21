using Microsoft.AspNetCore.Mvc;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;
using MyAPI.EShopApp.Services.Repositories.DiscountEventsRepository;

namespace MyAPI.Controllers.EShopApp;

/*
[Authorize]
*/
[ApiController]
[Route("eshop/news")]
public class DiscountEventsController : Controller
{
    private readonly IDiscountEventsRepository _eventsrepo;

    public DiscountEventsController(IDiscountEventsRepository eventsrepo)
    {
        _eventsrepo = eventsrepo;
    }
    
    
    [HttpGet("getevents")]
    public async Task<List<DiscountEvent>> GetNews()
    {
        return await _eventsrepo.GetEvents();
    }
    
    [HttpPost("addevent")]
    public async Task<bool> AddNews(DiscountEventDTO eventtoadd)
    {
        return await _eventsrepo.AddDiscountEvent(eventtoadd);
    }
    
    
    
}