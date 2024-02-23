using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;
using Alura.Adopet.Testes.Builders;
using FluentResults.Extensions;
using Moq;

namespace Alura.Adopet.Testes.Comandos;
public class ImportTest
{
    [Fact]
    public async void QuandoListaVaziaNaoDeveChamarCreatAsync()
    {
        // Arrange
        var pets = new List<Pet>();
        var arquivo = LeitorArquivoBuilder.CriarMock(pets);
        var servicePetApi = ApiServiceBuilder.CriarMock<Pet>();
        var import = new Import(servicePetApi.Object, arquivo.Object);

        // Act
        await import.ExecutarAsync();

        // Assert
        servicePetApi.Verify(_ => _.CreateAsync(It.IsAny<Pet>()), Times.Never);
    }

    [Fact]
    public async Task QuandoArquivoNaoExistenteDeveGerarException()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var arquivo = LeitorArquivoBuilder.CriarMock(listaDePet);
        arquivo.Setup(_ => _.LerConteudoArquivo()).Throws<FileNotFoundException>();

        var servicePetApi = ApiServiceBuilder.CriarMock<Pet>();
        var import = new Import(servicePetApi.Object, arquivo.Object);

        //Act
        var result = await import.ExecutarAsync();

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
        var arquivo = LeitorArquivoBuilder.CriarMock(listaDePet);

        var servicePetApi = ApiServiceBuilder.CriarMock<Pet>();
        var import = new Import(servicePetApi.Object, arquivo.Object);

        //Act
        var resultado = await import.ExecutarAsync();
        var petsRetorno = (SucessPets)resultado.Successes[0];

        //Assert
        Assert.True(resultado.IsSuccess);
        Assert.Equal("Lima", petsRetorno.Data.First().Nome);
    }


    [Fact]
    public async Task VerificarSePetFalhoImportacao()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var arquivo = LeitorArquivoBuilder.CriarMock(listaDePet);
        arquivo.Setup(_ => _.LerConteudoArquivo()).Throws<FileNotFoundException>();

        var servicePetApi = ApiServiceBuilder.CriarMock<Pet>();
        var import = new Import(servicePetApi.Object, arquivo.Object);

        //Act
        var resultado = await import.ExecutarAsync();

        //Assert
        Assert.True(resultado.IsFailed);
    }
}
