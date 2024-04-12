using MyAPI.ForumApp.Data.Models;

namespace MyAPI.ForumApp.Data.DTOs.Responses;

public class ThreadResponseDTO
{
    public ThreadResponseDTO()
    {
        if (posts != null) this.lastpost = posts.Last();
    }
    
    public Guid Id { get; set; }
    public string title { get; set; }
    public string date { get; set; }
    
    public List<PostResponseDTO> posts { get; set; }
    public int numofposts { get; set; }
    public Guid SubCategoryId { get; set; }
    public UserResponseDTO userowner { get; set; }
    public PostResponseDTO lastpost { get; set; }
}