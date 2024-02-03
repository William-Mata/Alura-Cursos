using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Util;
namespace Alura.Adopet.Console.Comands
{
    public static class FabricaComando
    {
        public static IComando? FabricarComando(string[] args)
        {
            ServicePetAPI servicePetApi = new ServicePetAPI(new HttpClientFactory().CreateClient());
            Arquivo arquivo = new Arquivo(caminhoDoArquivoDeImportacao: args.Length > 1 ? args[1] : "");

            var comando = args[0];
            switch (comando) 
            {
                case "import":
                    return new Import(servicePetApi, arquivo);
                case "help":
                    return new Help(args.Length > 1 ? args[1] : null);
                case "show":
                    return new Show(arquivo);
                case "list":
                    return new List(servicePetApi);
                default:
                   return null;
            }
        }

    }
}
