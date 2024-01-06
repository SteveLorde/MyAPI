using MyAPI.Data;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Data.DataSeed;
using MyAPI.ForumApp.Services.Authentication;
using MyAPI.ForumApp.Services.Repositories.Posts;
using MyAPI.ForumApp.Services.Repositories.Threads;
using MyAPI.ForumApp.Services.Repositories.Users;
using MyAPI.Services.JWT;
using MyAPI.Services.PasswordHash;
using MyAPI.Services.Startup;
using IStartup = MyAPI.Services.Startup.IStartup;

namespace MyAPI.Services;

public static class ServicesExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        //General
        services.AddDbContext<DataContext>();
        services.AddScoped<IStartup,Startup.Startup>();
        services.AddScoped<IStorageStartup, StorageStartup>();
        services.AddScoped<IPasswordHash, PasswordHash.PasswordHash>();
        services.AddScoped<IJWT, JWT.JWT>();
        services.AddHttpContextAccessor();
        
        //ForumApp Services
        services.AddDbContext<ForumAppDbContext>();
        services.AddScoped<IPostsService, PostsService>();
        services.AddScoped<IThreadsService,ThreadsService>();
        services.AddScoped<IAuthentication,ForumApp.Services.Authentication.Authentication>();
        services.AddScoped<IUsersRepository,UsersRepository>();
        
    }
    
    
}