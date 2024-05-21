using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
        //Storage Service CreateFolders
        _storagestartup.CreateFolders();

        //ForumApp

        
        //EShopApp

        //DailyBuyerApp
        /*
        var dailybuyerdb = _serviceprovider.CreateScope().ServiceProvider.GetRequiredService<DailyBuyerDataContext>();
        dailybuyerdb.Database.Migrate();
        */
    }
    
    
    
}