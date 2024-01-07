using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Util;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Services;

public class ServicePetAPI
{
    private static string _urlAPI = "http://localhost:5057";
    private Client _client;

    public ServicePetAPI()
    {
        this._client = new Client(url: _urlAPI);
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
}
