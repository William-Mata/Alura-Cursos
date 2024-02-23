namespace Alura.Adopet.Console.Comands.Interfaces;

public interface IFabricaComando
{
    public IComando? CriarComando(string[] argumentos);
    public bool ConsegueCriarComando(Type tipoComando);
}
