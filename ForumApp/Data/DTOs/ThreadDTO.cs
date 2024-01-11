using MyAPI.Data.DTOs;
using MyAPI.ForumApp.Data.Models;

namespace MyAPI.ForumApp.Data.DTOs;

public class ThreadDTO : BaseDTO
{
    public string title { get; set; }
    public string date { get; set; }
    public int numofposts { get; set; }
    public Post lastpost { get; set; }
    
}