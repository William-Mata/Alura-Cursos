using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Services.Htpp;

namespace Alura.Adopet.Console.Comands;

public class FabricaListCliente : IFabricaComando
{
    public IComando? CriarComando(string[] argumentos)
    {
        IServiceAPI<Cliente> serviceApiList = new ServiceCliente(new HttpClientFactory().CreateClient());
        return new ListCliente(serviceApiList);
    }

    public bool ConsegueCriarComando(Type tipoComando)
    {
        return Type.Equals(tipoComando, typeof(ListCliente));
    }
}

