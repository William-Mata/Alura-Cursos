using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comands;

[DocComando("list", " adopet list comando que exibe no terminal a lista de pets já importados.")]
public class List : IComando
{
    private IServiceAPI<Pet> _serviceAPI;

    public List(IServiceAPI<Pet> serviceAPI)
    {
        _serviceAPI = serviceAPI;
    }

    public virtual async Task<Result> ExecutarAsync()
    {
        try 
        {
            return await this.ListarAsync();
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
        }
    }

    public virtual async Task<Result> ListarAsync()
    {
        var pets = await _serviceAPI.ListAsync();

        return Result.Ok().WithSuccess(new SucessPets(pets!, "Lista de Pets")); ;
    }
}
