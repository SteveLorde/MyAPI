using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs.Requests;

namespace MyAPI.Services.Authentication;

public interface IAuthentication
{
    public Task Login(LoginRequestDTO loginreq);
    public Task Register();
    public Task GetUser(string userid);
}