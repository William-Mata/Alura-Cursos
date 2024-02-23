using Alura.Adopet.Console.Modelos;
using FluentResults;

namespace Alura.Adopet.Console.Utils;

public class SucessClientes : Success
{
    public IEnumerable<Cliente> Data { get; }

    public SucessClientes(IEnumerable<Cliente> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }
}