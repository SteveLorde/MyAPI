using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyAPI.EShopApp.Data;
using MyAPI.EShopApp.Data.Seeding;
using MyAPI.EShopApp.Services.Repositories.DiscountEventsRepository;
using MyAPI.EShopApp.Services.Repositories.ProductsRepository;
using MyAPI.Services.Startup;

namespace MyAPI.EShopApp;

public class EShopAppStartup
{
    private readonly IServiceProvider _serviceprovider;
    private readonly EShopCustomSeeding _eShopCustomSeeding;

    public EShopAppStartup(IServiceProvider serviceProvider, IWebHostEnvironment webenv, IStorageStartup storagestartup, EShopCustomSeeding eShopCustomSeeding)
    {
        _serviceprovider = serviceProvider;
        _eShopCustomSeeding = eShopCustomSeeding;
    }

    public void ExecuteServices()
    {
        CreateStorage();
        var eshopdb = _serviceprovider.CreateScope().ServiceProvider.GetRequiredService<EShopDataContext>();
        eshopdb.Database.Migrate();
        _eShopCustomSeeding.SeedDiscountsProducts();
    }

    private void CreateStorage()
    {
        var scope1 = _serviceprovider.CreateScope();
        var servicescoper1 = scope1.ServiceProvider;
        var newsservice = servicescoper1.GetRequiredService<IDiscountEventsRepository>();
        newsservice.CreateEventsFolders();
        
        var scope2 = _serviceprovider.CreateScope();
        var servicescoper2 = scope2.ServiceProvider;
        var productservice = servicescoper2.GetRequiredService<IProductsRepository>();
        productservice.CreateAssetsFolders();
    }
}