using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comands;

[DocComando("import", " adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando
{
    private ServicePetAPI _servicePetAPI;
    private Arquivo _aquivo;

    public Import(ServicePetAPI servicePetAPI, Arquivo arquivo)
    {
        _servicePetAPI = servicePetAPI;
        _aquivo = arquivo!;
    }

    public async Task<Result> ExecutarAsync()
    {
        try
        {
            IEnumerable<Pet> listaDePet = _aquivo.LeitorConteudoArquivoPets();
            return await ImportacaoDeArquivoPetAsync(listaDePet);
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error(ex.Message).CausedBy(ex));
        }
    }

    private async Task<Result> ImportacaoDeArquivoPetAsync(IEnumerable<Pet> listaDePet)
    {
        try
        {    
            foreach (var pet in listaDePet)
            {
                var resposta = await _servicePetAPI.CreatePetAsync(pet);
            }

            return Result.Ok().WithSuccess(new SucessPets(listaDePet, "Importação concluída!"));

        }catch (Exception ex)
        {
            return Result.Fail(new Error(ex.Message).CausedBy(ex));
        }
    }
}
