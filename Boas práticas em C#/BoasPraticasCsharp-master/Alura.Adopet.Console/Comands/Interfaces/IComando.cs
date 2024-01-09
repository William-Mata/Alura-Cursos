namespace Alura.Adopet.Console.Comands.Interfaces;

public interface IComando
{
    Task ExecutarAsync(string[] args);
}
