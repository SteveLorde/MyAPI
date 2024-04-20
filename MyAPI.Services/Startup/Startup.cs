using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MyAPI.Services.Startup;

public class Startup : IStartup
{
    private readonly IServiceProvider _serviceprovider;
    private readonly IWebHostEnvironment _webenv;
    private readonly IStorageStartup _storagestartup;
    private readonly EShopCustomSeeding _eShopCustomSeeding;

    public Startup(IServiceProvider serviceProvider, IWebHostEnvironment webenv, IStorageStartup storagestartup, EShopCustomSeeding eShopCustomSeeding)
    {
        _serviceprovider = serviceProvider;
        _webenv = webenv;
        _storagestartup = storagestartup;
        _eShopCustomSeeding = eShopCustomSeeding;
    }

    public void ExecuteServices()
    {
        //Storage Service CreateFolders
        _storagestartup.CreateFolders();

        //ForumApp
        var scopedb = _serviceprovider.CreateScope();
        var servicescopedb = scopedb.ServiceProvider;
        var forumdbservice = servicescopedb.GetRequiredService<ForumAppDbContext>();
        forumdbservice.Database.Migrate();
        
        //EShopApp
        var eshopdb = _serviceprovider.CreateScope().ServiceProvider.GetRequiredService<EShopDataContext>();
        eshopdb.Database.Migrate();
        _eShopCustomSeeding.SeedDiscountsProducts();
        
        //DailyBuyerApp
        var dailybuyerdb = _serviceprovider.CreateScope().ServiceProvider.GetRequiredService<DailyBuyerDataContext>();
        dailybuyerdb.Database.Migrate();
    }
    
    
    
}