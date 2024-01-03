using AutoMapper;
using MyAPI.ForumApp.Data;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.ForumApp.Services.Repositories.Threads;

class ThreadsService : GenericRepository<Thread>, IThreadsService
{
    public ThreadsService(ForumAppDbContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment) : base(db,
        mapper, hostingEnvironment)
    {

    }
    
    
}