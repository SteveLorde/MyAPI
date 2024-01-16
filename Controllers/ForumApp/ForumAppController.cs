using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs.Requests;
using MyAPI.ForumApp.Data.DTOs.Responses;
using MyAPI.ForumApp.Data.Models;
using MyAPI.ForumApp.Services.Repositories.Forum;
using MyAPI.ForumApp.Services.Repositories.Threads;
using MyAPI.Services.Authentication;
using IAuthentication = MyAPI.ForumApp.Services.Authentication.IAuthentication;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.Controllers.ForumApp;

[ApiController]
[Route("ForumApp")]
public class ForumAppController : ControllerBase
{
    private readonly IForumService _dataservice;
    private readonly ForumAppDbContext _db;
    private readonly IAuthentication _authservice;
    private readonly IThreadsService _threadsservice;

    public ForumAppController(IForumService dataservice, IThreadsService threadsservice ,IAuthentication authservice ,ForumAppDbContext db)
    {
        _dataservice = dataservice;
        _db = db;
        _authservice = authservice;
        _threadsservice = threadsservice;
    }
    
    //Categories
    //-----------------------
    
    [HttpGet("categories/getcategories")]
    public async Task<List<CategoryResponseDTO>> GetCategories()
    {
        return await _dataservice.GetMainCategories();
    }
    
    //Authentcation
    //-----------------------
    
    [HttpPost("authentication/login")]
    public async Task<string> Login(LoginRequestDTO loginreq)
    {
        return await _authservice.Login(loginreq);
    }
    
    [HttpPost("authentication/register")]
    public async Task<bool> Register(RegisterRequestDTO registerreq)
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
    
    //Forum
    //-------------------------
    
    [HttpGet("threads/getthread/{threadid}")]
    public async Task<ThreadResponseDTO> GetThread(string threadid)
    {
        return await _threadsservice.GetThread(threadid);
    }
    
    [HttpGet("threads/getsubcategorythreads/{subcategoryid}")]
    public async Task<SubCategoryResponseDTO> GetSubCategoryThreads(string subcategoryid)
    {
        return await _threadsservice.GetSubCategoryThreads(subcategoryid);
    }
    
    [Authorize]
    [HttpPost("threads/AddThread")]
    public async Task<bool> AddPost(AddThreadRequestDTO threadtoadd)
    {
        string userid = HttpContext.User.FindFirst("userid").Value;
        return await _threadsservice.AddThread(userid, threadtoadd);
    }
    
    //Posts
    //-------------------------
    [Authorize]
    [HttpPost("posts/AddPost")]
    public async Task<bool> AddPost(AddPostRequestDTO posttoadd)
    {
        string userid = HttpContext.User.FindFirst("userid").Value;
        return await _dataservice.AddPost(userid, posttoadd);
    }
    
    //Users
    //-----------------------
    [HttpGet("users/getuser/{userid}")]
    public async Task<UserResponseDTO> GetUserInfo(string userid)
    {
        return await _dataservice.GetUser(userid);
    }
    
}