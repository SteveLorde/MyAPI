using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.Models;

namespace MyAPI.ForumApp.Services.Authentication;

public interface IAuthentication
{
    public Task<string> Login(LoginDTO loginreq);
    public Task<bool> Register(RegisterDTO registerreq);
    public Task<User> GetUser(string userid);
}