using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Data.DataSeed;
using MyAPI.ForumApp.Services.Repositories.Users;
using MyAPI.Services.Startup;

namespace MyAPI.ForumApp;

public class ForumAppStartup
{
    private readonly IServiceProvider _serviceprovider;
    private readonly IWebHostEnvironment _webenv;

    public ForumAppStartup(IServiceProvider serviceProvider, IWebHostEnvironment webenv, IStorageStartup storagestartup)
    {
        _webenv = webenv;
        _serviceprovider = serviceProvider;
    }

    public void ExecuteServices()
    {
        CreateStorage();
        var scopedb = _serviceprovider.CreateScope();
        var servicescopedb = scopedb.ServiceProvider;
        var forumdbservice = servicescopedb.GetRequiredService<ForumAppDbContext>();
        forumdbservice.Database.Migrate();
    }

    private void CreateStorage()
    {
        var forumappstoragefolder = Path.Combine(_webenv.ContentRootPath, "Storage", "ForumApp");
        if (!Directory.Exists(forumappstoragefolder))
        {
            Directory.CreateDirectory(forumappstoragefolder);
            Console.WriteLine("craated ForumApp Storage folder");
        }

        var forumscope = _serviceprovider.CreateScope();
        var forumuserrepo = forumscope.ServiceProvider.GetRequiredService<IUsersRepository>();
        forumuserrepo.CreateUsersFolders();
    }
    

}