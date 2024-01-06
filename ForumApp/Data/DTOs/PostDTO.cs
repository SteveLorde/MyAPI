using MyAPI.Data.DTOs;

namespace MyAPI.ForumApp.Data.DTOs;

public class PostDTO : BaseDTO
{
    public string body { get; set; }
    public Guid UserId { get; set; }
    public Guid ThreadId { get; set; }

}