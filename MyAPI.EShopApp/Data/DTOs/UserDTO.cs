namespace MyAPI.EShopApp.Data.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public string UserName { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
    public string ProfileImage { get; set; }
}