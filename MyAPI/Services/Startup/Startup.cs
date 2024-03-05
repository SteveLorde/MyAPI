using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.EShopApp.Data;
using MyAPI.EShopApp.Data;
using MyAPI.EShopApp.Data.Seeding;
using MyAPI.ForumApp.Data;

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
        //forumdbservice.Database.Migrate();
        forumdbservice.Database.EnsureCreated();
        
        //EShopApp
        var eshopscopedb = _serviceprovider.CreateScope();
        var servicedb = eshopscopedb.ServiceProvider;
        var eshopdbservice = servicedb.GetRequiredService<EShopDataContext>();
        eshopdbservice.Database.Migrate();
        _eShopCustomSeeding.SeedDiscountsProducts();
    }
    
    
    
}