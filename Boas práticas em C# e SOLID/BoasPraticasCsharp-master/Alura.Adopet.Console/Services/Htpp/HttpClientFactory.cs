using Alura.Adopet.Console.Settings;
using System.Net.Http.Headers;

namespace Alura.Adopet.Console.Services.Htpp;

public class HttpClientFactory : IHttpClientFactory
{
    public HttpClient CreateClient(string name)
    {
        HttpClient httpCliente = new HttpClient();
        httpCliente.DefaultRequestHeaders.Accept.Clear();
        httpCliente.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        httpCliente.BaseAddress = new Uri(Configurations.ApiSetting.Uri);

        return httpCliente;
    }
}
