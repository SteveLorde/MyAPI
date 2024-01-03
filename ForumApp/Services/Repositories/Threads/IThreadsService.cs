using MyAPI.Services.Repositories;
using Models_Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.ForumApp.Services.Repositories.Threads;

public interface IThreadsService : IGenericRepository<Models_Thread>
{
    
}