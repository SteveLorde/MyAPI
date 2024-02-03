using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Services.Repositories.DiscountEventsRepository;

public interface IDiscountEventsRepository
{
    public Task CreateEventsFolders();
    public Task<List<DiscountEvent>> GetEvents();
    public Task<bool> AddDiscountEvent(DiscountEventDTO eventtoadd);
    public Task UpdateEvent(DiscountEventDTO eventtoupdate);
    public Task RemoveEvent(string eventid);
}