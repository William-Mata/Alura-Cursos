using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Util;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Services;

public class ServicePetAPI : IDisposable
{
    private Client _client;

    public ServicePetAPI(string url = "http://localhost:5057")
    {
        this._client = new Client(url: url);
    }

    public Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            return _client.httpCliente.PostAsJsonAsync("pet/add", pet);
        }
    }

    public async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await _client.httpCliente.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }

    public void Dispose()
    {
        _client.httpCliente.Dispose();
    }

}
