using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Utils;
using Alura.Adopet.Testes.Builders;

namespace Alura.Adopet.Testes.Testes;

public class ShowTest
{
    [Fact]
    public async Task VerificarSeComandoRetornaListaDePets()
    {
        // Arrange
        List<Pet> listaDePet = new();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"), "Lima", TipoPet.Cachorro);
        listaDePet.Add(pet);
        var arquivo = ArquivoBuilder.CriarMock(listaDePet);

        // Act
        var retorno = await new Show(arquivo.Object).ExecutarAsync();

        // Assert
        var resultado = (SucessPets)retorno.Successes[0];
        Assert.Single(resultado.Data);
    }
}