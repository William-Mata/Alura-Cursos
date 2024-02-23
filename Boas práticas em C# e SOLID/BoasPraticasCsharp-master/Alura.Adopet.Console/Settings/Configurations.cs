using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings;

public static class Configurations
{

    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets("8f78100b-c6cb-47bb-b86a-2796efd04ecf").Build();
    }

    public static APISettings ApiSetting
    {
        get{
            var config = BuildConfiguration();
            return config.GetSection(APISettings.Section).Get<APISettings>() ?? 
            throw new ArgumentException("Seção para configuração da API não encontrada.");
        } 
    }

    public static EmailSettings EmailSettings
    {
        get
        {
            var config = BuildConfiguration();
            return config.GetSection(EmailSettings.Section).Get<EmailSettings>() ??
            throw new ArgumentException("Seção para configuração do email não encontrada.");
        }
    }
}
