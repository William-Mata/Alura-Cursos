using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstracoes;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comands;

[DocComando("import-cliente", " adopet import-cliente <arquivo> comando que realiza a importação do arquivo de clientese.")]
public class ImportCliente : IComando
{
    private IServiceAPI<Cliente> _serviceAPI;
    private ILeitorArquivos<Cliente> _leitorArquivos;

    public ImportCliente(IServiceAPI<Cliente> serviceAPI, ILeitorArquivos<Cliente> leitorArquivos)
    {
        _serviceAPI = serviceAPI;
        _leitorArquivos = leitorArquivos;
    }

    public async Task<Result> ExecutarAsync()
    {
        try
        {
            var lista = _leitorArquivos.LerConteudoArquivo();

            foreach (var cliente in lista)
            {
                await _serviceAPI.CreateAsync(cliente);
            }

            return Result.Ok().WithSuccess(new SucessClientes(lista, "Importação realizada com sucesso!"));
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error("Importação falhou.").CausedBy(ex));
        }
    }
}
