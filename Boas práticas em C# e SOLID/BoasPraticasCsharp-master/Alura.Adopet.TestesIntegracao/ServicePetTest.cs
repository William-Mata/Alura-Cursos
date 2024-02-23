using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.TestesIntegracao.Builder;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Sockets;

namespace Alura.Adopet.Testes.Servicos;

public class ServicePetTest
{
    [Fact]
    public async Task ListPetsAsyncVerificarSeNaoEstaVazia()
    {
        // Arrange
        var mock = HttpClientMockBuilder.CriarMock(@"
        [
            {
                ""id"": ""08ee65b8-64ed-47cb-a52c-0b5ca8e16d1e"",
                ""nome"": ""Sábio"",
                ""tipo"": 0,
                ""proprietario"": {
                    ""id"": ""f2885412-21c9-48db-abb8-5219ba15be3f"",
                    ""nome"": ""André"",
                    ""cpf"": ""111.111.111-22"",
                    ""email"": ""andre@email.com""
                }
            }
        ]");
       
        IServiceAPI<Pet> serviceAPI = new ServicePet(mock.Object);

        // Act
        var pets = await serviceAPI.ListAsync();

        // Assert
        Assert.NotNull(pets);
    }

    [Fact]
    public async Task VerificarSeApiEstaForaDoAr()
    {
        // Arrange
        var mock = HttpClientMockBuilder.CriarMockList();
        IServiceAPI<Pet> serviceAPI = new ServicePet(mock.Object);

        // Act Assert
        await Assert.ThrowsAnyAsync<Exception>(() => serviceAPI.ListAsync());
    }
}