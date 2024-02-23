using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Services.Htpp;

namespace Alura.Adopet.Console.Comands;

public class FabricaList : IFabricaComando
{
    public IComando? CriarComando(string[] argumentos)
    {
        IServiceAPI<Pet> servicePetApiList = new ServicePet(new HttpClientFactory().CreateClient());
        return new List(servicePetApiList);
    }

    public bool ConsegueCriarComando(Type tipoComando)
    {
        return Type.Equals(tipoComando, typeof(List));
    }
}

