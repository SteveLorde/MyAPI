using MyAPI.Data;
using MyAPI.EShopApp.Data;
using MyAPI.EShopApp.Services.Repositories.NewsRepository;
using MyAPI.EShopApp.Services.Repositories.ProductsRepository;
using MyAPI.EShopApp.Data;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Data.DataSeed;
using MyAPI.ForumApp.Services.Authentication;
using MyAPI.ForumApp.Services.Repositories.Forum;
using MyAPI.ForumApp.Services.Repositories.Threads;
using MyAPI.ForumApp.Services.Repositories.Users;
using MyAPI.Services.AutoMapper;
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
        services.AddAutoMapper(typeof(AutoProfile));
        services.AddScoped<IStartup,Startup.Startup>();
        services.AddScoped<IStorageStartup, StorageStartup>();
        services.AddScoped<IPasswordHash, PasswordHash.PasswordHash>();
        services.AddScoped<IJWT, JWT.JWT>();
        services.AddHttpContextAccessor();
        
        //ForumApp Services
        services.AddAutoMapper(typeof(ForumAppProfile));
        services.AddDbContext<ForumAppDbContext>();
        services.AddScoped<IForumService,ForumService>();
        services.AddScoped<IThreadsService,ThreadsService>();
        services.AddScoped<IAuthentication,ForumApp.Services.Authentication.Authentication>();
        services.AddScoped<IUsersRepository,UsersRepository>();
        
        //EShop Services
        services.AddDbContext<EShopDataContext>();
        services.AddAutoMapper(typeof(EShopMappingProfile));
        services.AddScoped<INewsRepository, NewsRepository>();
        services.AddScoped<IProductsRepository, ProductsRepository>();

    }
    
    
}