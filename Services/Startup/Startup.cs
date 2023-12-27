using Microsoft.EntityFrameworkCore;
using MyAPI.Data;

namespace MyAPI.Services.Startup;

public class Startup
{
    private readonly IServiceProvider _serviceprovider;
    private readonly IWebHostEnvironment _webenv;

    public Startup(IServiceProvider serviceProvider, IWebHostEnvironment webenv)
    {
        _serviceprovider = serviceProvider;
        _webenv = webenv;
    }

    public void ExecuteServices()
    {
        var storagefolder = Path.Combine(_webenv.ContentRootPath, "Storage");
        Directory.CreateDirectory(storagefolder);
        var scopedb = _serviceprovider.CreateScope();
        var servicescopedb = scopedb.ServiceProvider;
        var dbservice = servicescopedb.GetRequiredService<DataContext>();
        dbservice.Database.Migrate();
    }
}