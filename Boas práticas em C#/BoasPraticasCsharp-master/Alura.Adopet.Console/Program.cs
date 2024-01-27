using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.UI;
using Alura.Adopet.Console.Util;
using FluentResults;

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

string comandosASerExecutado = args[0].Trim();
if (comandosDoSistema.ContainsKey(comandosASerExecutado))
{
    IComando? comando = comandosDoSistema[comandosASerExecutado];
    var result = await comando.ExecutarAsync(args); 
    ConsoleUI.ExibirResultado(result);
}
else
{
    ConsoleUI.ExibirResultado(Result.Fail("Comando inválido!"));
}
