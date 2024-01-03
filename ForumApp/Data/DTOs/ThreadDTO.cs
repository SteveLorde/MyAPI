using MyAPI.Data.DTOs;
using MyAPI.ForumApp.Data.Models;

namespace MyAPI.ForumApp.Data.DTOs;

public interface ThreadDTO : TDTO
{
    public Guid Id { get; set; }
    public string title { get; set; }
    public DateTime date { get; set; }
    public List<Post> posts { get; set; }
    public Guid UserId { get; set; }
    
}