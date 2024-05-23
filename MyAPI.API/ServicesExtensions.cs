using MyAPI.Services.AutoMapper;
using MyAPI.Services.JWT;
using MyAPI.Services.PasswordHash;
using MyAPI.Services.Startup;
using IStartup = MyAPI.Services.Startup.IStartup;

namespace MyAPI.API;

public static class ServicesExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        //General
        services.AddAutoMapper(typeof(AutoProfile));
        services.AddScoped<IStartup,Startup>();
        services.AddScoped<IStorageStartup, StorageStartup>();
        services.AddScoped<IPasswordHash, PasswordHash>();
        services.AddScoped<IJWT, JWT>();
        services.AddHttpContextAccessor();
    }
    
    
}