using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comands;

[DocComando("list-cliente", " adopet list comando que exibe no terminal a lista de clientes já importados.")]
public class ListCliente : IComando
{
    private readonly IServiceAPI<Cliente> _serviceAPI;

    public ListCliente(IServiceAPI<Cliente> serviceAPI)
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
        var clientes = await _serviceAPI.ListAsync();

        return Result.Ok().WithSuccess(new SucessClientes(clientes!, "Lista de Clientes")); ;
    }
}
