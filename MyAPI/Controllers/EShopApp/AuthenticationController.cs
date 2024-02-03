using Microsoft.AspNetCore.Mvc;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;
using MyAPI.EShopApp.Services.Repositories.ProductsRepository;

namespace MyAPI.Controllers.EShopApp;

[ApiController]
[Route("eshop/warehouse")]
public class AuthenticationController : Controller
{
    
    public AuthenticationController()
    {

    }

    [HttpPost("login")]
    public async Task Login(LoginRequestDTO loginreq)
    {
        
    }
    
    [HttpPost("register")]
    public async Task Register(RegisterRequestDTO registerreq)
    {
        
    }
    
}