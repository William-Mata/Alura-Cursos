using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Interfaces;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Services.Htpp;

public class ServicePet : IServiceAPI<Pet>
{
    private HttpClient _client;

    public ServicePet(HttpClient cliente)
    {
        _client = cliente;
    }

    public virtual Task<HttpResponseMessage> CreateAsync(Pet pet)
    {
        return _client.PostAsJsonAsync("pet/add", pet);
    }

    public virtual async Task<IEnumerable<Pet>?> ListAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}
