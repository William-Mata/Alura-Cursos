namespace Alura.Adopet.Console.Settings;

public class EmailSettings
{
    public const string Section = "AdopetEmailConfiguration";
    public string Servidor { get; set; } = string.Empty;
    public int Porta { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}
