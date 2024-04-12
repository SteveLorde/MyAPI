using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyAPI.EShopApp.Services.Repositories.DiscountEventsRepository;
using MyAPI.EShopApp.Services.Repositories.ProductsRepository;
using MyAPI.ForumApp.Services.Repositories.Users;

namespace MyAPI.Services.Startup;

public class StorageStartup : IStorageStartup
{
    private readonly IServiceProvider _serviceprovider;
    private readonly IWebHostEnvironment _webenv;

    public StorageStartup(IServiceProvider serviceProvider, IWebHostEnvironment webenv)
    {
        _serviceprovider = serviceProvider;
        _webenv = webenv;
    }
    
    public void CreateFolders()
    {
        //General
        var storagefolder = Path.Combine(_webenv.ContentRootPath, "Storage");
        if (!Directory.Exists(storagefolder))
        {
            Directory.CreateDirectory(storagefolder);
            Console.WriteLine("craated general Storage folder");
        }
        
        //Forum App
        var forumappstoragefolder = Path.Combine(_webenv.ContentRootPath, "Storage", "ForumApp");
        if (!Directory.Exists(forumappstoragefolder))
        {
            Directory.CreateDirectory(forumappstoragefolder);
            Console.WriteLine("craated ForumApp Storage folder");
        }

        var forumscope = _serviceprovider.CreateScope();
        var forumuserrepo = forumscope.ServiceProvider.GetRequiredService<IUsersRepository>();
        forumuserrepo.CreateUsersFolders();
        
        //Eshop App
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