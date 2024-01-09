using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Comands;

[DocComando("list", " adopet list comando que exibe no terminal a lista de pets já importados.")]
public class ListPets : IComando
{
    public async Task ExecutarAsync(string[] args)
    {
        await this.ListarPetsAsync();
    }

    public async Task ListarPetsAsync()
    {
        ServicePetAPI _servicePetAPI = new ServicePetAPI();
        var pets = await _servicePetAPI.ListPetsAsync();

        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }

   
}
