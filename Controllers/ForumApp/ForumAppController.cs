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
    
    [HttpGet("GetThread/{threadid}")]
    public async Task<Thread?> GetThread(string threadid)
    {
        return await _threadsservice.Get(threadid, thread => thread.posts, thread => thread.userowner);
    }
    
    [HttpGet("getsubcategorythreads/{subcategoryid}")]
    public async Task<List<List<Thread>>> GetSubCategoryThreads(string subcategoryid)
    {
        return await _db.forumapp_subcategories.Where(subcat => subcat.Id == Guid.Parse(subcategoryid)).Select(subcat => subcat.threads).ToListAsync();
    }
    
    [HttpGet("getsubcategories")]
    public async Task<List<Category>> GetSubCategories()
    {
        return await _db.forumapp_categories.Include(category => category.subcategories).ToListAsync();
    }

    [HttpGet("getuser/{userid}")]
    public async Task<User> GetUserInfo(string userid)
    {
        return await _db.forumapp_users.FirstAsync(user => user.Id == Guid.Parse(userid));
    }
    
    //-----------------------
    
    [HttpPost("login")]
    public async Task<string> Login(AuthRequestDTO loginreq)
    {
        return await _authservice.Login(loginreq);
    }
    
    [HttpPost("register")]
    public async Task<bool> Register(AuthRequestDTO registerreq)
    {
        return await _authservice.Register(registerreq);
    }
    
    [Authorize]
    [HttpGet("getuserinfo")]
    public async Task<User> GetActiveUserInfo()
    {
        //VALIDATE TOKEN AUTOMATICALLY
        string userid = HttpContext.User.FindFirst("userid").Value;
        return await _authservice.GetUser(userid);
    }
    
    //-------------------------
    [HttpPost("AddPost")]
    public async Task<bool> AddPost(PostDTO newpost)
    {
        return await _postsservice.Add(newpost);
    }
    
    [HttpPost("AddThread")]
    public async Task<bool> AddPost(ThreadDTO newthread)
    {
        return await _threadsservice.Add(newthread);
    }
    
    
    
    
}