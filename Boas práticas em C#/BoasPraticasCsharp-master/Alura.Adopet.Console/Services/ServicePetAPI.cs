using Alura.Adopet.Console.Models;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Services;

public class ServicePetAPI 
{
    private HttpClient _client;

    public ServicePetAPI(HttpClient cliente)
    {
        _client = cliente;
    }

    public virtual Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        return _client.PostAsJsonAsync("pet/add", pet);
    }

    public virtual async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}
