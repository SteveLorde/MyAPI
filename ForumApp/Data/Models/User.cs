using System.ComponentModel.DataAnnotations.Schema;

namespace MyAPI.ForumApp.Data.Models;

public class User
{
    public Guid Id { get; set; }
    public string username { get; set; }
    [NotMapped]
    public string password { get; set; }
    public string pass_salt { get; set; }
    public string hashedpassword { get; set; }
    public string usertype { get; set; }
    public string email { get; set; }
    public string profileimage { get; set; }
}