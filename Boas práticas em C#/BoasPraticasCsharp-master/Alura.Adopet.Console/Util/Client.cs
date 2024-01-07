using System.Net.Http.Headers;

namespace Alura.Adopet.Console.Util;

public class Client
{
    public HttpClient httpCliente;

    public Client(string url)
    {
        httpCliente = new HttpClient();
        httpCliente.DefaultRequestHeaders.Accept.Clear();
        httpCliente.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        httpCliente.BaseAddress = new Uri(url);
    }
}
