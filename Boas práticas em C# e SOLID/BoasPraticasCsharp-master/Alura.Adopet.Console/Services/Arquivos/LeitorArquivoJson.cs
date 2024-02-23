using Alura.Adopet.Console.Services.Abstracoes;
using System.Text.Json;

namespace Alura.Adopet.Console.Services.Arquivos;

public abstract class LeitorArquivoJson<T> : ILeitorArquivos<T>
{
    private string _caminhoDoArquivoDeImportacao;

    public LeitorArquivoJson(string caminhoDoArquivoDeImportacao)
    {
        _caminhoDoArquivoDeImportacao = caminhoDoArquivoDeImportacao;
    }

    public IEnumerable<T> LerConteudoArquivo()
    {
        List<T> listaObjetos = new();

        using (var stream = new FileStream(_caminhoDoArquivoDeImportacao, FileMode.Open, FileAccess.Read))
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            listaObjetos = JsonSerializer.Deserialize<List<T>>(stream, options)!;
        }

        return listaObjetos;
    }
}
