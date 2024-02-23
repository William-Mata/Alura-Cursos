using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Sockets;

namespace Alura.Adopet.TestesIntegracao.Builder;

public static class HttpClientMockBuilder
{
    public static Mock<HttpClient> CriarMock(string content)
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(content)
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

        return httpClient;
    }

    public static Mock<HttpClient> CriarMockList()
    {
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

        return httpClient;
    }

}
