namespace MyAPI.EShopApp.Data.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string username { get; set; }
    public int phonenumber { get; set; }
    public string email { get; set; }
    public string profileimage { get; set; }
}