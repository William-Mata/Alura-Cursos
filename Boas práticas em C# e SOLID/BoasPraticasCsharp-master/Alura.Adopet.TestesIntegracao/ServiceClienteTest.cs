using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.TestesIntegracao.Builder;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Sockets;

namespace Alura.Adopet.Testes.Servicos;

public class ServiceClienteTest
{
    [Fact]
    public async Task ListClienteAsyncVerificarSeNaoEstaVazia()
    {
        // Arrange
        var mock = HttpClientMockBuilder.CriarMock(@"
        [
            {
                ""id"": ""ed48920c-5adb-4684-9b8f-ba8a94775a11"",
                ""nome"": ""Fulano de Tal"",
                ""email"": ""fulano @example.org""
            }
        ]");

        IServiceAPI<Cliente> serviceAPI = new ServiceCliente(mock.Object);

        // Act
        var pets = await serviceAPI.ListAsync();

        // Assert
        Assert.NotNull(pets);
        Assert.NotEmpty(pets);
        Assert.Single(pets);
    }

    [Fact]
    public async Task VerificarSeApiEstaForaDoAr()
    {
        // Arrange
        var mock = HttpClientMockBuilder.CriarMockList();
        IServiceAPI<Cliente> serviceAPI = new ServiceCliente(mock.Object);

        // Act Assert
        await Assert.ThrowsAnyAsync<Exception>(() => serviceAPI.ListAsync());
    }
}