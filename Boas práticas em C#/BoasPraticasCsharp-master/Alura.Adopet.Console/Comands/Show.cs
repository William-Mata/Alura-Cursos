using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comands;

[DocComando("show", " adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Show : IComando
{
    private Arquivo _arquivo;

    public Show(Arquivo arquivo)
    {
        this._arquivo = arquivo;
    }

    public Task<Result> ExecutarAsync(string[] args)
    {
        try
        {   
            return ListarPetsArquivo(caminhoArquivo: args[1]);
        }
        catch (Exception exception)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição do arquivo falhou!").CausedBy(exception)));
        }
    }

    public Task<Result> ListarPetsArquivo(string caminhoArquivo)
    {
        IEnumerable<Pet> listaPets = _arquivo.LeitorConteudoArquivoPets();

        return Task.FromResult(Result.Ok().WithSuccess(new SucessPet(listaPets, "Serão importados os dados acima")));
    }
}
