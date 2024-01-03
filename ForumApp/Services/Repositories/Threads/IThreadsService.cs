using MyAPI.ForumApp.Data.Models;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.ForumApp.Services.Repositories.Threads;

public interface IThreadsService : IGenericRepository<Thread>
{
    
}