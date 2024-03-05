using MyAPI.TheDailyBuyerApp.Data;
using MyAPI.TheDailyBuyerApp.Services.AutoMappingProfile;

namespace MyAPI.TheDailyBuyerApp.Services;

public static class DailyBuyerAppServicesRegister
{
    public static void AddDailyBuyerAppServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<DailyBuyerDataContext>();
        serviceCollection.AddAutoMapper(typeof(DailyBuyerAutoMappingProfile));
        
    }
}