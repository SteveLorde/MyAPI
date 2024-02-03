using System.Text.Json.Serialization;

namespace MyAPI.ForumApp.Data.DTOs.Requests;

public class AddPostRequestDTO
{
    public Guid userid { get; set; }
    public string title { get; set; }
    [JsonPropertyName("body")]
    public string body { get; set; }
    public Guid threadid { get; set; }
}