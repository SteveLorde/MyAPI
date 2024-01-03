using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.ForumApp.Data;

namespace MyAPI.Services.Startup;

public class Startup : IStartup
{
    private readonly IServiceProvider _serviceprovider;
    private readonly IWebHostEnvironment _webenv;
    private readonly IStorageStartup _storagestartup;

    public Startup(IServiceProvider serviceProvider, IWebHostEnvironment webenv, IStorageStartup storagestartup)
    {
        _serviceprovider = serviceProvider;
        _webenv = webenv;
        _storagestartup = storagestartup;
    }

    public void ExecuteServices()
    {
        _storagestartup.CreateFolders();
        
        /*
        var scopedb = _serviceprovider.CreateScope();
        var servicescopedb = scopedb.ServiceProvider;
        var dbservice = servicescopedb.GetRequiredService<DataContext>();
        dbservice.Database.Migrate();
        */
        
    }
}