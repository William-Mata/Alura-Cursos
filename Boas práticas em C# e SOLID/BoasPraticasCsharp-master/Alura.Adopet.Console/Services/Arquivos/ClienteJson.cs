using Alura.Adopet.Console.Modelos;
using System.Text.Json;

namespace Alura.Adopet.Console.Services.Arquivos;

public class ClienteJson : LeitorArquivoJson<Cliente>
{
    public ClienteJson(string caminhoDoArquivoDeImportacao) : base(caminhoDoArquivoDeImportacao)
    {
    }
}
