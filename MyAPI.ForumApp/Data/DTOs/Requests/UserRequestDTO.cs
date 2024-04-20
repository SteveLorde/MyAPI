using Microsoft.AspNetCore.Http;

namespace MyAPI.ForumApp.Data.DTOs.Requests;

public class UserRequestDTO
{
    public string username { get; set; }
    public string password { get; set; }
    public string? email { get; set; }
    public IFormFile? profilepic { get; set; }
    public string? profilepicfilename { get; set; }
}