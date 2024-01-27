using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Utils;
using FluentResults;
using System;

namespace Alura.Adopet.Console.Comands;

[DocComando("list", " adopet list comando que exibe no terminal a lista de pets já importados.")]
public class List : IComando
{
    private ServicePetAPI _servicePetAPI;

    public List(ServicePetAPI servicePetAPI)
    {
        _servicePetAPI = servicePetAPI;
    }

    public async Task<Result> ExecutarAsync(string[] args)
    {
        try 
        {
            return await this.ListarPetsAsync();
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
        }
    }

    private async Task<Result> ListarPetsAsync()
    {
        var pets = await _servicePetAPI.ListPetsAsync();

        return Result.Ok().WithSuccess(new SucessPet(pets!, "Lista de Pets")); ;
    }
}
