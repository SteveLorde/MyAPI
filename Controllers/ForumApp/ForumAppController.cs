using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.Models;
using MyAPI.ForumApp.Services.Repositories.Posts;
using MyAPI.ForumApp.Services.Repositories.Threads;
using MyAPI.Services.Authentication;
using IAuthentication = MyAPI.ForumApp.Services.Authentication.IAuthentication;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.Controllers.ForumApp;

[ApiController]
[Route("ForumApp")]
public class ForumAppController : ControllerBase
{
    private readonly IThreadsService _threadsservice;
    private readonly IPostsService _postsservice;
    private readonly ForumAppDbContext _db;
    private readonly IAuthentication _authservice;

    public ForumAppController(IThreadsService threadsservice, IPostsService postsservice, IAuthentication authservice ,ForumAppDbContext db)
    {
        _threadsservice = threadsservice;
        _postsservice = postsservice;
        _db = db;
        _authservice = authservice;
    }
    
    //Categories
    //-----------------------
    
    [HttpGet("categories/getcategories")]
    public async Task<List<Category>> GetCategories()
    {
        return await _db.forumapp_categories.Include(category => category.subcategories).ToListAsync();
    }
    
    //Authentcation
    //-----------------------
    
    [HttpPost("authentication/login")]
    public async Task<string> Login(LoginDTO loginreq)
    {
        return await _authservice.Login(loginreq);
    }
    
    [HttpPost("authentication/register")]
    public async Task<bool> Register(RegisterDTO registerreq)
    {
        return await _authservice.Register(registerreq);
    }
    
    [Authorize]
    [HttpGet("getactiveuserinfo")]
    public async Task<User> GetActiveUserInfo()
    {
        //VALIDATE TOKEN AUTOMATICALLY
        string userid = HttpContext.User.FindFirst("userid").Value;
        return await _authservice.GetUser(userid);
    }
    
    //Threads
    //-------------------------
    
    [HttpGet("threads/getthread/{threadid}")]
    public async Task<Thread?> GetThread(string threadid)
    {
        return await _threadsservice.Get(threadid, thread => thread.posts, thread => thread.userowner);
    }
    
    [HttpGet("threads/getsubcategorythreads/{subcategoryid}")]
    public async Task<List<ThreadDTO>> GetSubCategoryThreads(string subcategoryid)
    {
        var queriedthreads = await _db.forumapp_subcategories.Where(subcat => subcat.Id == Guid.Parse(subcategoryid)).SelectMany(subcat => subcat.threads).Include(t => t.posts).ToListAsync();
        List<ThreadDTO> subcategorythreads = new List<ThreadDTO>();
        foreach (var thread in queriedthreads)
        {
            ThreadDTO threaddto = new ThreadDTO
            {
                 Id = thread.Id.ToString(),
                 title = thread.title,
                 lastpost = thread.posts.Last(),
                 date = thread.date.ToString(),
                 numofposts = thread.posts.Count
            };
            subcategorythreads.Add(threaddto);
        }
        return subcategorythreads;
    }
    
    [Authorize]
    [HttpPost("threads/AddThread")]
    public async Task<bool> AddPost(ThreadDTO newthread)
    {
        string userid = HttpContext.User.FindFirst("userid").Value;
        var check = _db.forumapp_users.FindAsync(Guid.Parse(userid)).IsCompletedSuccessfully;
        if (check)
        {
            return await _threadsservice.Add(newthread);
        }
        else
        {
            return false;
        }
    }
    
    //Posts
    //-------------------------
    [Authorize]
    [HttpPost("posts/AddPost")]
    public async Task<bool> AddPost(PostDTO newpost)
    {
        string userid = HttpContext.User.FindFirst("userid").Value;
        var check = _db.forumapp_users.FindAsync(Guid.Parse(userid)).IsCompletedSuccessfully;
        if (check)
        {
            return await _postsservice.Add(newpost);
        }
        else
        {
            return false;
        }
    }
    
    //Users
    //-----------------------
    [HttpGet("users/getuser/{userid}")]
    public async Task<User> GetUserInfo(string userid)
    {
        return await _db.forumapp_users.FirstAsync(user => user.Id == Guid.Parse(userid));
    }
    
}