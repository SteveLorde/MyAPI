using System.ComponentModel.DataAnnotations;

namespace MyAPI.EShoppApp.Data.Models;



public class User
{
    [Key]
    public Guid Id { get; set; }
    public string username { get; set; }
    public string? pass_salt { get; set; }
    public string? hashedpassword { get; set; }
    public string usertype { get; set; }
    public int? phonenumber { get; set; }
    public string? email { get; set; }
    public string? profileimage { get; set; }

}