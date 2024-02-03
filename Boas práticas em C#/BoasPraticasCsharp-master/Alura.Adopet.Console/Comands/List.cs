﻿using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comands;

[DocComando("list", " adopet list comando que exibe no terminal a lista de pets já importados.")]
public class List : IComando
{
    private ServicePetAPI _servicePetAPI;

    public List(ServicePetAPI servicePetAPI)
    {
        _servicePetAPI = servicePetAPI;
    }

    public virtual async Task<Result> ExecutarAsync()
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

    public virtual async Task<Result> ListarPetsAsync()
    {
        var pets = await _servicePetAPI.ListPetsAsync();

        return Result.Ok().WithSuccess(new SucessPets(pets!, "Lista de Pets")); ;
    }
}
