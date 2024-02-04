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
        foreach (var thread in subcatresponse.threads)
        {
            thread.numofposts = thread.posts.Count;
            thread.lastpost = thread.posts.Last();
        }
        return subcatresponse;
    }

    public async Task<ThreadResponseDTO> GetThread(string threadid)
    {
        var queriedthread = await _db.forumapp_threads.Include(t => t.posts).ThenInclude(p => p.userposter).FirstAsync(t => t.Id == Guid.Parse(threadid));
        queriedthread.posts.OrderBy(p => p.ordernum);
        queriedthread.numofposts = queriedthread.posts.Count;
        ThreadResponseDTO threadResponse = _mapper.Map<ThreadResponseDTO>(queriedthread);
        return threadResponse;
    }

    public async Task<bool> AddThread(AddThreadRequestDTO threadtoadd)
    {
        var subcategory = await _db.forumapp_subcategories.Include(s => s.threads).FirstAsync(s => s.Id == threadtoadd.subcategoryid);
        Thread newthread = _mapper.Map<Thread>(threadtoadd);
        newthread.posts[0].ordernum = 1;
        subcategory.threads.Add(newthread);
        await _db.SaveChangesAsync();
        return true;
    }
    public async Task<bool> AddPost(AddPostRequestDTO posttoadd)
    {
        var thread = await _db.forumapp_threads.Include(t => t.posts).FirstAsync(t => t.Id == posttoadd.threadid);
        Post newpost = _mapper.Map<Post>(posttoadd);
        newpost.ordernum = thread.posts.Last().ordernum + 1;
        thread.posts.Add(newpost);
        await _db.SaveChangesAsync();
        return true;
    }

}