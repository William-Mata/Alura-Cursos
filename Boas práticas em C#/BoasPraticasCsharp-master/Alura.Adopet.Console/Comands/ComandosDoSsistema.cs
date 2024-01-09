using Alura.Adopet.Console.Comands.Interfaces;

namespace Alura.Adopet.Console.Comands;

public class ComandosDoSsistema
{

    private Dictionary<string, IComando> comandosDoSistema = new()
    {
        {"import", new Import() },
        {"help", new Help() },
        {"show", new Show() },
        {"list", new ListPets()}
    };

    // INDEXAÇAO DA CLASSE
    public IComando? this[string key] => comandosDoSistema.ContainsKey(key) ? comandosDoSistema[key] : null;
}
