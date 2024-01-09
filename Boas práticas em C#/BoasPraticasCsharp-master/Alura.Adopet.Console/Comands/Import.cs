using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comands;

[DocComando("Import", " adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando
{
    private ServicePetAPI _servicePetAPI;

    public Import()
    {
        _servicePetAPI = new ServicePetAPI();
    }

    public async Task ExecutarAsync(string[] args)
    {
        await ImportacaoDeArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
    }

    private async Task ImportacaoDeArquivoPetAsync(string caminhoDoArquivoDeImportacao)
    {
        IEnumerable<Pet> listaDePet = Arquivo.ExtrairConteudoArquivoPets(caminhoDoArquivoDeImportacao);

        foreach (var pet in listaDePet)
        {
            try
            {
                var resposta = await _servicePetAPI.CreatePetAsync(pet);
                System.Console.WriteLine(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        System.Console.WriteLine("Importação concluída!");
    }

}
