using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;
using Alura.Adopet.Testes.Builders;
using ListPets = Alura.Adopet.Console.Comands.List;

namespace Alura.Adopet.Testes.Comandos;

public class ListTest
{
    [Fact]
    public async Task VerificarSeComandoRetornaListaDePets()
    {
        // Arrange
        List<Pet> listaDePet = new();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"), "Lima", TipoPet.Cachorro);
        listaDePet.Add(pet);
        var servicePetApi = ApiServiceBuilder.CriarMockListPets(listaDePet);

        // Act
        var retorno = await new ListPets(servicePetApi.Object).ExecutarAsync();

        // Assert
        var resultado = (SucessPets)retorno.Successes[0];
        Assert.Single(resultado.Data);
    }
}