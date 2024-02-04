using System.ComponentModel.DataAnnotations.Schema;
using MyAPI.ForumApp.Services.Repositories;

namespace MyAPI.ForumApp.Data.Models;

public class Post : IEntity
{
    public Guid Id { get; set; }
    public int ordernum { get; set; }
    [Column(TypeName = "json")]
    public string body { get; set; }
    public Guid UserId { get; set; }
    public User userposter { get; set; }
    public DateTime date { get; set; }
    public Guid ThreadId { get; set; }
    public Thread thread { get; set; }
    
}