using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MyAPI.Services.Startup;

public class StorageStartup : IStorageStartup
{
    private readonly IServiceProvider _serviceprovider;
    private readonly IWebHostEnvironment _webenv;

    public StorageStartup(IServiceProvider serviceProvider, IWebHostEnvironment webenv)
    {
        _serviceprovider = serviceProvider;

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
    }
    
    
}