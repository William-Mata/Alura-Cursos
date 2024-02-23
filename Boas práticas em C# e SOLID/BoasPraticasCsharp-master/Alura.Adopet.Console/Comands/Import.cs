using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstracoes;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comands;

[DocComando("import", " adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando, IDespoisDaExecucao, IRequisicaoProgresso
{
    private IServiceAPI<Pet> _serviceAPI;
    private ILeitorArquivos<Pet> _leitorArquivos;

    public Import(IServiceAPI<Pet> serviceAPI, ILeitorArquivos<Pet> leitorArquivos)
    {
        _serviceAPI = serviceAPI;
        _leitorArquivos = leitorArquivos!;
    }

    public event Action<Result>? DepoisDaExecucao;
    public event Action<int, int>? ProgressChanged;

    public async Task<Result> ExecutarAsync()
    {
        try
        {
            IEnumerable<Pet> listaDePet = _leitorArquivos.LerConteudoArquivo();
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
            int i = 0;

            foreach (var pet in listaDePet)
            {
                i++;
                await _serviceAPI.CreateAsync(pet);
                OnProgressChanged(i, listaDePet.Count());
            }

            var result = Result.Ok().WithSuccess(new SucessPets(listaDePet, "Importação concluída!"));
            DepoisDaExecucao?.Invoke(result);
            return result;

        }catch (Exception ex)
        {
            return Result.Fail(new Error(ex.Message).CausedBy(ex));
        }
    }


    private void OnProgressChanged(int i, int total)
    {
        ProgressChanged?.Invoke(i, total);
        Thread.Sleep(100);
    }
}
