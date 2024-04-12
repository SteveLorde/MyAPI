using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Services.Authentication;
using MyAPI.ForumApp.Services.Repositories.Forum;
using MyAPI.ForumApp.Services.Repositories.Threads;
using MyAPI.ForumApp.Services.Repositories.Users;
using MyAPI.Services.AutoMapper;

namespace MyAPI.ForumApp.Services;

public static class ForumAppServicesRegister
{
    public static void AddForumAppServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ForumAppProfile));
        services.AddDbContext<ForumAppDbContext>();
        services.AddScoped<IForumService,ForumService>();
        services.AddScoped<IThreadsService,ThreadsService>();
        services.AddScoped<IAuthentication,ForumApp.Services.Authentication.Authentication>();
        services.AddScoped<IUsersRepository,UsersRepository>();
    }
    
}