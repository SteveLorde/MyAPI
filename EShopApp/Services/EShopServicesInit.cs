using MyAPI.EShopApp.Data;
using MyAPI.EShopApp.Data.Seeding;
using MyAPI.EShopApp.Services.Repositories.DiscountEventsRepository;
using MyAPI.EShopApp.Services.Repositories.ProductsRepository;
using MyAPI.Services.AutoMapper;

namespace MyAPI.EShopApp.Services;

public static class EShopServicesInit
{
    public static void AddEShopServices(this IServiceCollection services)
    {
        services.AddDbContext<EShopDataContext>();
        services.AddAutoMapper(typeof(EShopMappingProfile));
        services.AddScoped<IDiscountEventsRepository, DiscountEventsRepository>();
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<EShopCustomSeeding>();
    }
}