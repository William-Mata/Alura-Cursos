using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstracoes;
using Alura.Adopet.Console.Services.Arquivos;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comands;

[DocComando("show", " adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Show : IComando
{
    private ILeitorArquivos<Pet> _leitorArquivos;

    public Show(ILeitorArquivos<Pet> leitorArquivos)
    {
        this._leitorArquivos = leitorArquivos;
    }

    public Task<Result> ExecutarAsync()
    {
        try
        {   
            return ListarPetsArquivo();
        }
        catch (Exception exception)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição do arquivo falhou!").CausedBy(exception)));
        }
    }

    public Task<Result> ListarPetsArquivo()
    {
        IEnumerable<Pet> listaPets = _leitorArquivos.LerConteudoArquivo();

        return Task.FromResult(Result.Ok().WithSuccess(new SucessPets(listaPets, "Serão importados os dados acima")));
    }
}
