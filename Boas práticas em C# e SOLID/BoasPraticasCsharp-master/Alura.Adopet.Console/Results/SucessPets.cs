using Alura.Adopet.Console.Modelos;
using FluentResults;

namespace Alura.Adopet.Console.Utils;

public class SucessPets : Success
{
    public IEnumerable<Pet> Data { get;}

    public SucessPets(IEnumerable<Pet> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }

}
