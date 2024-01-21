using System.Net.Http.Headers;

namespace Alura.Adopet.Console.Services;

public class HttpClientFactory : IHttpClientFactory
{
    public HttpClient CreateClient(string url = "http://localhost:5057/")
    {
        HttpClient httpCliente = new HttpClient();
        httpCliente.DefaultRequestHeaders.Accept.Clear();
        httpCliente.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        httpCliente.BaseAddress = new Uri(url);

        return httpCliente;
    }
}
