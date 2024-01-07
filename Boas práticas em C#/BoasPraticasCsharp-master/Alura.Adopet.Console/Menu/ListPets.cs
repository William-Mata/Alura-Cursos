using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Menu;

[DocComando("list", " adopet list comando que exibe no terminal a lista de pets já importados.")]
public static class ListPets
{
    public static async Task ListarPetsAsync()
    {
        ServicePetAPI _servicePetAPI = new ServicePetAPI();
        var pets = await _servicePetAPI.ListPetsAsync();

        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }

   
}
