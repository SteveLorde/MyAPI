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
        
        
    }
    
    
}