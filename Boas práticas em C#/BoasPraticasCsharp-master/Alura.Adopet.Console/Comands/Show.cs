using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comands;

[DocComando("show", " adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Show : IComando
{
    public Task ExecutarAsync(string[] args)
    {
        ListarPetsArquivo(caminhoArquivo:args[1]);
        return Task.CompletedTask;
    }

    public void ListarPetsArquivo(string caminhoArquivo)
    {
        caminhoArquivo = Path.GetFullPath(caminhoArquivo);
        IEnumerable<Pet> listaPets = Arquivo.ExtrairConteudoArquivoPets(caminhoArquivo);

        System.Console.WriteLine("----- Serão importados os dados abaixo -----");
        foreach (var pet in listaPets)
        {
            System.Console.WriteLine($"{pet}");
        }
    }

    
}
