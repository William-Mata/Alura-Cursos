using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comands;

[DocComando("show", " adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Show : IComando
{
    private Arquivo _arquivo;
    private Arquivo arquivo;

    public Show(Arquivo arquivo)
    {
        this.arquivo = arquivo;
    }

    public Task<Result> ExecutarAsync(string[] args)
    {
        try { 
            ListarPetsArquivo(caminhoArquivo:args[1]);
            return Task.FromResult(Result.Ok());
        }
        catch (Exception exception)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição do arquivo falhou!").CausedBy(exception)));
        }
    }

    public void ListarPetsArquivo(string caminhoArquivo)
    {
        _arquivo = new Arquivo(caminhoArquivo);
        caminhoArquivo = Path.GetFullPath(caminhoArquivo);
        IEnumerable<Pet> listaPets = _arquivo.LeitorConteudoArquivoPets();

        System.Console.WriteLine("----- Serão importados os dados abaixo -----");
        foreach (var pet in listaPets)
        {
            System.Console.WriteLine($"{pet}");
        }
    }
}
