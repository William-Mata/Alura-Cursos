using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Services.Abstracoes;
using Alura.Adopet.Console.Services.Arquivos;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Htpp;
using Alura.Adopet.Console.Services.Email;
using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Comands;

public class FabricaImport : IFabricaComando
{
    public IComando? CriarComando(string[] argumentos)
    {
        ILeitorArquivos<Pet> leitorArquivo = FabricaArquivo.FabricarArquivoPet(arquivo: argumentos.Length > 1 ? argumentos[1] : "")!;
        IServiceAPI<Pet> serviceApiPet = new ServicePet(new HttpClientFactory().CreateClient());
        if (leitorArquivo is null) { return null; }
        var import =  new Import(serviceApiPet, leitorArquivo);
        import.DepoisDaExecucao += EnvioDeEmail.Disparar;
        import.ProgressChanged += ProcessaProgresso.ProgressChanged;
        return import;
    }

    public bool ConsegueCriarComando(Type tipoComando)
    {
        return Type.Equals(tipoComando, typeof(Import));
    }
}