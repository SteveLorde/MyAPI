namespace MyAPI.ForumApp.Data.DTOs.Responses;

public class SubCategoryResponseDTO
{
    public Guid Id { get; set; }
    public string name { get; set; }
    public int numofthreads { get; set; }
    public List<ThreadResponseDTO> threads { get; set; }
}