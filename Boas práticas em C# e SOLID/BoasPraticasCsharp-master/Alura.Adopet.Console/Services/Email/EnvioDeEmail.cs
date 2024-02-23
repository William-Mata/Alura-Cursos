using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Settings;
using Alura.Adopet.Console.Utils;
using FluentResults;
using System.Net;
using System.Net.Mail;

namespace Alura.Adopet.Console.Services.Email;

public static class EnvioDeEmail
{
    private static IEmailService CriarEmailService()
    {
        EmailSettings settings = Configurations.EmailSettings;

        SmtpClient smtp = new SmtpClient()
        {
            Host = settings.Servidor,
            Port = settings.Porta,
            Credentials = new NetworkCredential(settings.Email, settings.Senha),
            EnableSsl = true,
            UseDefaultCredentials = false
        };

        return new SmtpEmailService(smtp);
    }

    public static void Disparar(Result result)
    {
        ISuccess? success = result.Successes.FirstOrDefault();
        if (success != null) return;
        if(success is SucessPets sucesso)
        {
            var emailService = CriarEmailService();
            emailService.SendEmailAsync(
                 remetente: "no-reply@adopet.com.br",
                 titulo: $"[Adopet] {sucesso.Message}",
                 corpo: $"Foram importados {sucesso.Data.Count()} pets.",
                 destinatario: "sistema.adopet@gmail.com"
            );
        }
    }
}
