using Alura.Adopet.Console.Models;
using FluentResults;

namespace Alura.Adopet.Console.Utils;

public class SucessPet : Success
{
    public IEnumerable<Pet> Data { get;}

    public SucessPet(IEnumerable<Pet> data)
    {
        Data = data;
    }
}
