﻿using Microsoft.AspNetCore.Http;

namespace MyAPI.Services.Mail.Model;

public class MailDTO
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<IFormFile> Attachments { get; set; }
}