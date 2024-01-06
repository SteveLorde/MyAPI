namespace MyAPI.ForumApp.Data.DTOs;

public class RegisterDTO
{
    public string username { get; set; }
    public string password { get; set; }
    public string? email { get; set; }
    public string? profilepicfilename { get; set; }
    public IFormFile? profilepic { get; set; }
}