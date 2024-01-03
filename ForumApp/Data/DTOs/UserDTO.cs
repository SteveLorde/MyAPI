namespace MyAPI.ForumApp.Data.DTOs;

public class UserDTO
{
    public string username { get; set; }
    public string password { get; set; }
    public string? email { get; set; }
    public IFormFile? profilepic { get; set; }
    public string? profilepicfilename { get; set; }
}