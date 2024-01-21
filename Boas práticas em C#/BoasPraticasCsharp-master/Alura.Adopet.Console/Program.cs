using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Util;

ServicePetAPI servicePetApi = new ServicePetAPI(new HttpClientFactory().CreateClient());
Arquivo arquivo = new Arquivo("");

if(args.Length > 1)
{
    arquivo = new Arquivo(caminhoDoArquivoDeImportacao: args[1]);
}

Dictionary<string, IComando> comandosDoSistema = new()
{
    {"import", new Import(servicePetApi, arquivo) },
    {"help", new Help() },
    {"show", new Show(arquivo) },
    {"list", new List(servicePetApi)}
};

Console.ForegroundColor = ConsoleColor.Green;

try
{
    string comandosASerExecutado = args[0].Trim();
    if (comandosDoSistema.ContainsKey(comandosASerExecutado))
    {
        IComando? comando = comandosDoSistema[comandosASerExecutado];
        await comando.ExecutarAsync(args); 
    }
    else
    {
        Console.WriteLine("Comando inválido!");
    }
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}