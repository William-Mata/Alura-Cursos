using SevenDaysOfCode.Dtos;
using SevenDaysOfCode.Models;
using System.Text.Json;

namespace SevenDaysOfCode.Client;

public static class PokeApi
{
    private static string url = "https://pokeapi.co/api/v2/pokemon/";

    public static async Task<Mascote> ConsultarMascotePorNomeAsync(string nome)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                var consulta = $"{url}{nome}";
                var result = await client.GetStringAsync(consulta);
                Mascote mascote =  JsonSerializer.Deserialize<Mascote>(result)!;

                return mascote;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Temos um problema: {ex.Message}");
                throw ex;
            }
        }
    }

    public static async Task<ListMascoteDto> ListarMascoteApiAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                var result = await client.GetStringAsync(url);
                ListMascoteDto mascotes = JsonSerializer.Deserialize<ListMascoteDto>(result)!;

                return mascotes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Temos um problema: {ex.Message}");
                throw ex;
            }
        }
    }
}
