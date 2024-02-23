namespace Alura.Adopet.Console.Services.Abstracoes;

public interface ILeitorArquivos <T>
{
   IEnumerable<T> LerConteudoArquivo();
}
