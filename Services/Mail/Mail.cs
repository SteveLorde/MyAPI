﻿using System.Net.Mail;
using AutoMapper;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MyAPI.Services.Mail.Model;
using ContentType = System.Net.Mime.ContentType;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace MyAPI.Services.Mail;

class Mail : IMail
{
    private readonly MailSettings _mailSettings;
    private readonly IMapper _mapper;

    public Mail(IOptions<MailSettings> mailSettings, IMapper mapper)
    {
        _mailSettings = mailSettings.Value;
        _mapper = mapper;
    }
    public async Task SendEmailAsync(MailDTO mailRequest)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        email.Subject = mailRequest.Subject;
        var builder = new BodyBuilder();
        if (mailRequest.Attachments != null)
        {
            byte[] fileBytes;
            foreach (var file in mailRequest.Attachments)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                    builder.Attachments.Add(file.FileName, fileBytes);
                }
            }
        }
        builder.HtmlBody = mailRequest.Body;
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
    }
}