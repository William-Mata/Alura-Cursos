namespace Alura.Adopet.Console.Comands.Interfaces;

public interface IRequisicaoProgresso
{
    event Action<int, int>? ProgressChanged;
}
