using System.ComponentModel.DataAnnotations.Schema;
using MyAPI.ForumApp.Services.Repositories;

namespace MyAPI.ForumApp.Data.Models;

public class User
{
    public Guid Id { get; set; }
    public string username { get; set; }
    public DateTime date { get; set; }
    public string hashedpassword { get; set; }
    public string usertype { get; set; }
    public string email { get; set; }
    public string profileimage { get; set; }
}