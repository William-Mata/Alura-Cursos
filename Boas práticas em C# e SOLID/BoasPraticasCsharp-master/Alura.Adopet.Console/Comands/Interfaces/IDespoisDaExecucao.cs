using FluentResults;

namespace Alura.Adopet.Console.Comands.Interfaces;

public interface IDespoisDaExecucao
{
    event Action<Result>? DepoisDaExecucao;
}
