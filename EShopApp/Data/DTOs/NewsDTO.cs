namespace MyAPI.EShopApp.Data.DTOs;

public class NewsDTO
{
    public Guid Id { get; set; }
    public string title { get; set; }
    public string? subtitle { get; set; }
    public string? description { get; set; }
    public DateOnly? published { get; set; }
    public string? image { get; set; }
    public IFormFile imagefile { get; set; }
}