using MyAPI.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.Models;
using MyAPI.ForumApp.Services.Authentication.Model;
using MyAPI.Services.JWT.DTO;

namespace MyAPI.Services.JWT;

public interface IJWT
{
    public string CreateToken(JWTRequestDTO userjwtreq);
    //public bool VerifyToken(string token);
}