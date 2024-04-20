using MyAPI.Services.Mail.Model;

namespace MyAPI.Services.Mail;

public interface IMail
{
    public Task SendEmailAsync(MailDTO mailRequest);
}