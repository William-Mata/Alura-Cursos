using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Menu;

[DocComando("show", " adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
public static class Show 
{
    public static void ListarPetsArquivo(string caminhoArquivo)
    {
        IEnumerable<Pet> listaPets = Arquivo.ExtrairConteudoArquivoPets(caminhoArquivo);

        System.Console.WriteLine("----- Serão importados os dados abaixo -----");
        foreach (var pet in listaPets)
        {
            System.Console.WriteLine($"{pet}");
        }
    }
}
