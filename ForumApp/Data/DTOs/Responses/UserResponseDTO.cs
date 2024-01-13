namespace MyAPI.ForumApp.Data.DTOs.Responses;

public class UserResponseDTO
{
    public Guid Id { get; set; }
    public string username { get; set; }
    public DateTime date { get; set; }
    public string usertype { get; set; }
    public string email { get; set; }
    public string profileimage { get; set; }
}