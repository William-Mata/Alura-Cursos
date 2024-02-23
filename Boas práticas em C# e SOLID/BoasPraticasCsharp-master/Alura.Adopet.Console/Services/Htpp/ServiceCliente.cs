using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Interfaces;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Services.Htpp;

public class ServiceCliente : IServiceAPI<Cliente>
{
    private HttpClient _client;

    public ServiceCliente(HttpClient cliente)
    {
        _client = cliente;
    }

    public Task<HttpResponseMessage> CreateAsync(Cliente cliente)
    {
        return _client.PostAsJsonAsync("cliente/add", cliente);
    }

    public async Task<IEnumerable<Cliente>?> ListAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("cliente/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
    }

    public void Dispose()
    {
        _client.Dispose();
    }

}
