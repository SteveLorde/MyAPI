namespace MyAPI.ForumApp.Data.Models;

public class Post
{
    public Guid Id { get; set; }
    public string body { get; set; }
    public Guid UserId { get; set; }
    public User userposter { get; set; }
    public DateTime date { get; set; }
    public Guid ThreadId { get; set; }
    public Thread thread { get; set; }
    
}