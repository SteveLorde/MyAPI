using MyAPI.ForumApp.Data.Models;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.ForumApp.Data.DTOs.Responses;

public class PostResponseDTO
{

    public Guid Id { get; set; }
    public string body { get; set; }
    public Guid UserId { get; set; }
    public User userposter { get; set; }
    public DateTime date { get; set; }
    public Guid ThreadId { get; set; }
    public Thread thread { get; set; }

}