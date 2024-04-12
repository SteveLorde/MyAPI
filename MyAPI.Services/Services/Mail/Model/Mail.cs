using Microsoft.AspNetCore.Http;

namespace MyAPI.Services.Mail.Model;

public class Mail
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<IFormFile> Attachments { get; set; }
}