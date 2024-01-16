using MyAPI.EShopApp.Data.DTOs;

namespace MyAPI.EShopApp.Services.Authentication;

public interface IAuthService
{
    public Task<string> Login(LoginRequestDTO loginreq);
    public Task<bool> Register(RegisterRequestDTO registerreq);
    public Task<UserDTO> GetUser(string userid);
}