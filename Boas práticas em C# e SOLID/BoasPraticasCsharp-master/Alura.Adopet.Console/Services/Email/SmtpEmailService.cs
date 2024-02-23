
using System.Net.Mail;
using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Services.Email;

public class SmtpEmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;

    public SmtpEmailService(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }

    public Task SendEmailAsync(string remetente, string destinatario, string titulo, string corpo)
    {
        MailMessage email = new()
        {
            From = new MailAddress(remetente),
            Subject = titulo,
            Body = corpo
        };

        email.To.Add(new MailAddress(destinatario));
        _smtpClient.Send(email);

        return Task.CompletedTask;
    }
}
