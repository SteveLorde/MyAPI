using MyAPI.DailyBuyerApp.Data;
using MyAPI.DailyBuyerApp.Services.AutoMappingProfile;
using MyAPI.DailyBuyerApp.Services.PurchaseManager;

namespace MyAPI.DailyBuyerApp.Services;

public static class DailyBuyerAppServicesRegister
{
    public static void AddDailyBuyerAppServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<DailyBuyerDataContext>();
        serviceCollection.AddAutoMapper(typeof(DailyBuyerAutoMappingProfile));
        serviceCollection.AddScoped<IPurchaseManager, PurchaseManager.PurchaseManager>();

    }
}