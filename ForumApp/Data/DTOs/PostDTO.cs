using MyAPI.Data.DTOs;

namespace MyAPI.ForumApp.Data.DTOs;

public interface PostDTO : TDTO
{
    public Guid Id { get; set; }
    public string body { get; set; }
    public Guid UserId { get; set; }
    public Guid ThreadId { get; set; }

}