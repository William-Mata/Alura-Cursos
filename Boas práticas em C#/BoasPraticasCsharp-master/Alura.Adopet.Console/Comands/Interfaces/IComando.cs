using FluentResults;

namespace Alura.Adopet.Console.Comands.Interfaces;

public interface IComando
{
    Task<Result> ExecutarAsync(string[] args);
}
