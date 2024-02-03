using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Data.Models;
using MyAPI.ForumApp.Data.DTOs.Requests;
using MyAPI.ForumApp.Data.DTOs.Responses;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.ForumApp.Services.Repositories.Threads;

class ThreadsService : IThreadsService
{
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly IMapper _mapper;
    private readonly ForumAppDbContext _db;

    public ThreadsService(ForumAppDbContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment)
    {
        _db = db;
        _mapper = mapper;
        _hostingEnvironment = hostingEnvironment;

    }
    
    public async Task<SubCategoryResponseDTO> GetSubCategoryThreads(string subcatid)
    {
        var queriedsubcats = await _db.forumapp_subcategories.Include(subcat => subcat.threads).ThenInclude(t => t.posts).ThenInclude(p => p.userposter).Include(s => s.threads).ThenInclude(t => t.userowner).FirstAsync(subcat => subcat.Id == Guid.Parse(subcatid));
        SubCategoryResponseDTO subcatresponse = _mapper.Map<SubCategoryResponseDTO>(queriedsubcats);
        /*
        foreach (var thread in queriedsubcats.threads)
        {
            ThreadResponseDTO threaddto = _mapper.Map<ThreadResponseDTO>(thread);
            threaddto.lastpost = _mapper.Map<PostResponseDTO>(thread.posts.Last());
            subcatresponse.threads.Add(threaddto);
        }
        */
        return subcatresponse;
    }

    public async Task<ThreadResponseDTO> GetThread(string threadid)
    {
        var queriedthread = await _db.forumapp_threads.Include(t => t.posts).ThenInclude(p => p.userposter).FirstAsync(t => t.Id == Guid.Parse(threadid));
        ThreadResponseDTO thread = new ThreadResponseDTO();
        //DeSerialize POSTS DELTAS
        foreach (var post in queriedthread.posts)
        {
            PostResponseDTO postresponse = _mapper.Map<PostResponseDTO>(post);
            UserResponseDTO userresponse = _mapper.Map<UserResponseDTO>(post.userposter);
        }
        ThreadResponseDTO threadResponse = _mapper.Map<ThreadResponseDTO>(queriedthread);
        return threadResponse;
    }

    public async Task<bool> AddThread(string userid, AddThreadRequestDTO threadtoadd)
    {
        var subcategory = await _db.forumapp_subcategories.Include(s => s.threads).FirstAsync(s => s.Id == threadtoadd.subcategoryid);
        Thread newthread = _mapper.Map<Thread>(threadtoadd);
        subcategory.threads.Add(newthread);
        await _db.SaveChangesAsync();
        return true;
    }

}