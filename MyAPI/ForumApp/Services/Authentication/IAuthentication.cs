using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs.Requests;
using MyAPI.ForumApp.Data.Models;

namespace MyAPI.ForumApp.Services.Authentication;

public interface IAuthentication
{
    public Task<string> Login(LoginRequestDTO loginreq);
    public Task<bool> Register(RegisterRequestDTO registerreq);
    public Task<User> GetUser(string userid);
}