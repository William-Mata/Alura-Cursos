using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Utils;
using Alura.Adopet.Testes.Builders;
using FluentResults.Extensions;
using Moq;

namespace Alura.Adopet.Testes.Testes;
public class ImportTest
{
    [Fact]
    public async void QuandoListaVaziaNaoDeveChamarCreatPetAsync()
    {
        // Arrange
        var pets = new List<Pet>();
        var arquivo = ArquivoBuilder.CriarMock(pets);
        var servicePetApi = ServicePetAPIBuilder.CriarMock();
        var import = new Import(servicePetApi.Object, arquivo.Object);
        string[] args = { "import", "lista.csv" };

        // Act
        await import.ExecutarAsync(args);

        // Assert
        servicePetApi.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
    }

    [Fact]
    public async Task QuandoArquivoNaoExistenteDeveGerarException()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var arquivo = ArquivoBuilder.CriarMock(listaDePet);
        arquivo.Setup(_ => _.LeitorConteudoArquivoPets()).Throws<FileNotFoundException>();

        var servicePetApi = ServicePetAPIBuilder.CriarMock();
        string[] args = { "import", "listadas.csv" };
        var import = new Import(servicePetApi.Object, arquivo.Object);

        //Act
        var result = await import.ExecutarAsync(args);

        //Assert
         Assert.True(result.HasException<Exception>());
    }

    [Fact]
    public async Task VerificarSePetFoiImportado()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"), "Lima", TipoPet.Cachorro);
        listaDePet.Add(pet);
        var arquivo = ArquivoBuilder.CriarMock(listaDePet);

        var servicePetApi = ServicePetAPIBuilder.CriarMock();
        string[] args = { "import", "lista.csv" };
        var import = new Import(servicePetApi.Object, arquivo.Object);

        //Act
        var resultado = await import.ExecutarAsync(args);
        var petsRetorno = (SucessPet)resultado.Successes[0];

        //Assert
        Assert.True(resultado.IsSuccess);
        Assert.Equal("Lima", petsRetorno.Data.First().Nome);
    }


    [Fact]
    public async Task VerificarSePetFalhoImportacao()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var arquivo = ArquivoBuilder.CriarMock(listaDePet);
        arquivo.Setup(_ => _.LeitorConteudoArquivoPets()).Throws<FileNotFoundException>();

        var servicePetApi = ServicePetAPIBuilder.CriarMock();
        string[] args = { "import", "lista.csv" };
        var import = new Import(servicePetApi.Object, arquivo.Object);

        //Act
        var resultado = await import.ExecutarAsync(args);

        //Assert
        Assert.True(resultado.IsFailed);
    }
}
