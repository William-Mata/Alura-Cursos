using Alura.Adopet.Console.Comands.Interfaces;

namespace Alura.Adopet.Console.Comands;

public class FabricaHelp : IFabricaComando
{
    public IComando? CriarComando(string[] argumentos)
    {
        return new Help(argumentos.Length > 1 ? argumentos[1] : null);
    }

    public bool ConsegueCriarComando(Type tipoComando)
    {
        return Type.Equals(tipoComando, typeof(Help));
    }
}
