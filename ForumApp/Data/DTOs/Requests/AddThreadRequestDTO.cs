using MyAPI.ForumApp.Data.Models;

namespace MyAPI.ForumApp.Data.DTOs.Requests;

public class AddThreadRequestDTO
{
    public Guid userid { get; set; }
    public string title { get; set; }
    public AddPostRequestDTO firstpost { get; set; }
    public Guid subcategoryid { get; set; }
}