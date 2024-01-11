using MyAPI.EShoppApp.Services.Repositories.NewsRepository;
using MyAPI.EShoppApp.Services.Repositories.ProductsRepository;

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
        Directory.CreateDirectory(storagefolder);
        Console.WriteLine("craated general Storage folder");
        
        //Forum App
        var forumappstoragefolder = Path.Combine(_webenv.ContentRootPath, "Storage", "ForumApp");
        Directory.CreateDirectory(forumappstoragefolder);
        Console.WriteLine("craated ForumApp Storage folder");
        
        //Eshop App
        var scope1 = _serviceprovider.CreateScope();
        var servicescoper1 = scope1.ServiceProvider;
        var newsservice = servicescoper1.GetRequiredService<INewsRepository>();
        newsservice.CreateNewsFolders();
        
        var scope2 = _serviceprovider.CreateScope();
        var servicescoper2 = scope2.ServiceProvider;
        var productservice = servicescoper2.GetRequiredService<IProductsRepository>();
        productservice.CreateAssetsFolders();
        
        
    }
    
    
}