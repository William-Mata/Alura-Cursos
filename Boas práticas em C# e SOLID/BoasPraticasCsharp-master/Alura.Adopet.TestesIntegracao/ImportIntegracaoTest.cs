using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.TestesIntegracao.Builder;

namespace Alura.Adopet.Testes;

public class ImportIntegracaoTest
{
    [Fact]
    public async void QuandoAPIEstaNoArDeveRetornarListaDePet()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
              "Lima", TipoPet.Cachorro); 
        listaDePet.Add(pet);
        var arquivo = ArquivoBuilder.CriarMock(listaDePet);
        IServiceAPI<Pet> serviceAPI = new ServicePet(new HttpClientFactory().CreateClient());
        var import = new Import(serviceAPI, arquivo.Object);
        
        //Act
        await import.ExecutarAsync();
        
        //Assert
        var listaPet = await serviceAPI.ListAsync();
        Assert.NotNull(listaPet);
    }
}
