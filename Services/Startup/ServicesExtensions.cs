using MyAPI.Data;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Services.Authentication;
using MyAPI.ForumApp.Services.Repositories.Posts;
using MyAPI.ForumApp.Services.Repositories.Threads;
using MyAPI.Services.JWT;
using MyAPI.Services.PasswordHash;
using MyAPI.Services.Repositories;

namespace MyAPI.Services.Startup;

public static class ServicesExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        //General
        services.AddDbContext<DataContext>();
        services.AddScoped<IStartup,Startup>();
        services.AddScoped<IStorageStartup, StorageStartup>();
        services.AddScoped<IPasswordHash, PasswordHash.PasswordHash>();
        services.AddScoped<IJWT, JWT.JWT>();
        services.AddHttpContextAccessor();
        
        //ForumApp Services
        services.AddDbContext<ForumAppDbContext>();
        services.AddScoped<IPostsService, PostsService>();
        services.AddScoped<IThreadsService,ThreadsService>();
        services.AddScoped<IAuthentication,ForumApp.Services.Authentication.Authentication>();
        
    }
    
    
}