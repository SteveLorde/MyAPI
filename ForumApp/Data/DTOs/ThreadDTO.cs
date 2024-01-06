using MyAPI.Data.DTOs;
using MyAPI.ForumApp.Data.Models;

namespace MyAPI.ForumApp.Data.DTOs;

public class ThreadDTO : BaseDTO
{
    public string title { get; set; }
    public List<Post> posts { get; set; }
    public Guid UserId { get; set; }
    
}