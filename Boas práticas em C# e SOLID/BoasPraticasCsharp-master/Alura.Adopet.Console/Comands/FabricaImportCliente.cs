using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Services.Abstracoes;
using Alura.Adopet.Console.Services.Arquivos;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Htpp;

namespace Alura.Adopet.Console.Comands;

public class FabricaImportCliente : IFabricaComando
{
    public IComando? CriarComando(string[] argumentos)
    {
        ILeitorArquivos<Cliente> leitorArquivoCliente = FabricaArquivo.FabricarArquivoCliente(arquivo: argumentos.Length > 1 ? argumentos[1] : "")!;
        IServiceAPI<Cliente> serviceApiCliente = new ServiceCliente(new HttpClientFactory().CreateClient());
        return new ImportCliente(serviceApiCliente, leitorArquivoCliente);
    }

    public bool ConsegueCriarComando(Type tipoComando)
    {
        return Type.Equals(tipoComando, typeof(ImportCliente));
    }
}

