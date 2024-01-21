using Alura.Adopet.Console.Services;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Sockets;

namespace Alura.Adopet.Testes.Testes;

public class ServicePetAPITest
{
    [Fact]
    public async Task ListPetsAsyncVerificarSeNaoEstaVazia()
    {
        // Arrange
        var handlerMock = new Mock<HttpMessageHandler>();
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(@"
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
            ]")
        };

        handlerMock.
            Protected().
            Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            ).ReturnsAsync(response);

        var httpClient = new Mock<HttpClient>(MockBehavior.Default, handlerMock.Object);
        httpClient.Object.BaseAddress = new Uri("http://localhost:5057");
        ServicePetAPI servicePetAPI = new ServicePetAPI(httpClient.Object);

        // Act
        var pets = await servicePetAPI.ListPetsAsync();

        // Assert
        Assert.NotNull(pets);
    }

    [Fact]
    public async Task VerificarSeApiEstaForaDoAr()
    {
        // Arrange
        var handlerMock = new Mock<HttpMessageHandler>();
       
        handlerMock.
            Protected().
            Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            ).ThrowsAsync(new SocketException());

        var httpClient = new Mock<HttpClient>(MockBehavior.Default, handlerMock.Object);
        httpClient.Object.BaseAddress = new Uri("http://localhost:5057");
        ServicePetAPI servicePetAPI = new ServicePetAPI(httpClient.Object);

        // Act Assert
        await Assert.ThrowsAnyAsync<Exception>(() => servicePetAPI.ListPetsAsync());
    }
}