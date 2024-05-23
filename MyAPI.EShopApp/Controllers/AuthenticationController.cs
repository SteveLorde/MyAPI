using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.DTOs.Requests;
using MyAPI.EShopApp.Services.Authentication;

namespace MyAPI.EShopApp.Controllers;

[ApiController]
[Route("eshop/authentication")]
public class AuthenticationController : Controller
{
    private readonly IAuthService _authService;
    private readonly HttpContextAccessor _httpContextAccessor;

    public AuthenticationController(IAuthService authService, HttpContextAccessor httpContextAccessor)
    {
        _authService = authService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("login")]
    public async Task<string> Login(LoginRequestDTO loginreq)
    {
        return await _authService.Login(loginreq);
    }
    
    [HttpPost("register")]
    public async Task<bool> Register(RegisterRequestDTO registerreq)
    {
        return await _authService.Register(registerreq);
    }

    [Authorize]
    [HttpGet]
    public async Task<UserDTO> GetLoggedUserInfo()
    {
        string userId = _httpContextAccessor.HttpContext.User.FindFirst("userid").Value;
        return await _authService.GetUser(userId);
    }
    
}