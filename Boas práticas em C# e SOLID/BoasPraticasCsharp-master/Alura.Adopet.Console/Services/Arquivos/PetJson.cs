using Alura.Adopet.Console.Modelos;
using System.Text.Json;

namespace Alura.Adopet.Console.Services.Arquivos;

public class PetJson : LeitorArquivoJson<Pet>
{
    public PetJson(string caminhoDoArquivoDeImportacao) : base(caminhoDoArquivoDeImportacao)
    {
    }
}
