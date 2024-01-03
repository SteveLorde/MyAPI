using MyAPI.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.Models;
using MyAPI.ForumApp.Services.Authentication.Model;

namespace MyAPI.Services.JWT;

public interface IJWT
{
    public string CreateToken(User user);
}