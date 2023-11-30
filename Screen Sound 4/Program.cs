using Screen_Sound_4.Modelos;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
    try
    {
        string musicasApi = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");

        var musicas = JsonSerializer.Deserialize<List<Musica>>(musicasApi)!;
        musicas.ForEach(x => x.ExibirDetalhesDaMusica());

    }
    catch(Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");   
    }
}

