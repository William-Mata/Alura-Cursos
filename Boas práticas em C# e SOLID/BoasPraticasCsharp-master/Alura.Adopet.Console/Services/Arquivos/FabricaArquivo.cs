using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstracoes;

namespace Alura.Adopet.Console.Services.Arquivos;

public static class FabricaArquivo
{
    public static ILeitorArquivos<Pet>? FabricarArquivoPet(string arquivo)
    {
        if (!string.IsNullOrEmpty(arquivo))
        {
            string caminhoArquivoImportacao = Path.GetFullPath(arquivo);

            if (Path.Exists(caminhoArquivoImportacao))
            {
                var extensao = Path.GetExtension(arquivo);
        
                switch (extensao)
                {
                    case ".csv": return new PetCsv(caminhoArquivoImportacao);
                    case ".json": return new PetJson(caminhoArquivoImportacao);
                    default: return null;
                }
            }
        }

        return null;
    }

    public static ILeitorArquivos<Cliente>? FabricarArquivoCliente(string arquivo)
    {
        if (!string.IsNullOrEmpty(arquivo))
        {
            string caminhoArquivoImportacao = Path.GetFullPath(arquivo);

            if (Path.Exists(caminhoArquivoImportacao))
            {
                var extensao = Path.GetExtension(arquivo);

                switch (extensao)
                {
                    case ".csv": return new ClienteCsv(caminhoArquivoImportacao);
                    case ".json": return new ClienteJson(caminhoArquivoImportacao);
                    default: return null;
                }
            }
        }

        return null;
    }
}
