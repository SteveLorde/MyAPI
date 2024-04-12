using System.Text.Json.Serialization;

namespace MyAPI.ForumApp.Data.DTOs.Requests;

public class AddPostRequestDTO
{
    public Guid UserId { get; set; }
    public string Body { get; set; }
    public Guid ThreadId { get; set; }
    public DateTime Date { get; set; }
}