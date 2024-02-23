namespace Alura.Adopet.Console.Services.Interfaces;

public interface IEmailService
{
    public Task SendEmailAsync(string remetente, string destinatario, string titulo, string corpo);
}
