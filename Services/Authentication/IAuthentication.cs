using MyAPI.ForumApp.Data.DTOs;

namespace MyAPI.Services.Authentication;

public interface IAuthentication
{
    public Task Login(AuthRequestDTO loginreq);
    public Task Register();
    public Task GetUser(string userid);
}