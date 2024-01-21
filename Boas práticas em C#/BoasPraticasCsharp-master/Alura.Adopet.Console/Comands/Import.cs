using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comands;

[DocComando("Import", " adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando
{
    private ServicePetAPI _servicePetAPI;
    private Arquivo _aquivo;

    public Import(ServicePetAPI servicePetAPI, Arquivo arquivo)
    {
        _servicePetAPI = servicePetAPI;
        _aquivo = arquivo!;
    }

    public async Task<Result> ExecutarAsync(string[] args)
    {
        return await ImportacaoDeArquivoPetAsync();
    }

    private async Task<Result> ImportacaoDeArquivoPetAsync()
    {
        try
        {    
            IEnumerable<Pet> listaDePet = _aquivo.LeitorConteudoArquivoPets();
            foreach (var pet in listaDePet)
            {
                var resposta = await _servicePetAPI.CreatePetAsync(pet);
                System.Console.WriteLine(pet);
            }

            System.Console.WriteLine("Importação concluída!");
            return Result.Ok().WithSuccess(new SucessPet(listaDePet));

        }catch (Exception ex)
        {
            return Result.Fail(new Error(ex.Message).CausedBy(ex));
        }
    }
}
