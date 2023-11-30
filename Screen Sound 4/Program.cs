using Screen_Sound_4.Filter;
using Screen_Sound_4.LinqFilter;
using Screen_Sound_4.Modelos;
using Screen_Sound_4.Models;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
    try
    {
        string musicasApi = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(musicasApi)!;

        //musicas.ForEach(x => x.ExibirDetalhesDaMusica());

        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas); 
        //LinqOrder.OrdenarOsArtistasPorNome(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas);
        //LinqFilter.FiltrarMusicasPorArtista(musicas);
        //LinqFilter.FiltrarMusicasPorAnoDeLancamento(musicas);
        LinqFilter.FiltrarMusicasPorTonalidade(musicas);

        //PlayList playList = new PlayList("Só as brabas do William");
        //playList.AdicionarMusicaNaPlayList(new Musica("Zóio de Lula", "Charlie Brown Jr"));
        //playList.AdicionarMusicaNaPlayList(new Musica("Não é Sério", "Charlie Brown Jr"));
        //playList.AdicionarMusicaNaPlayList(new Musica("Pescador de Ilusões", "O Rappa"));
        //playList.AdicionarMusicaNaPlayList(new Musica("Minha Alma", "O Rappa"));
        //playList.AdicionarMusicaNaPlayList(new Musica("Corte Americano", "Felipe Ret"));
        //playList.AdicionarMusicaNaPlayList(new Musica("Me Sinto Abençoado", "Felipe Ret"));

        //playList.ExibirDetalhesDaPlayList();
        //playList.GerarArquivoJsonDaPlayList();
        //playList.GerarArquivoTxtDaPlayList();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");   
    }
}

