using Desafios.Models;
using Screen_Sound_4.Modelos;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
    try
    {

        //Desafio 1
        //Console.WriteLine("Desafio 1");
        //string animes = await client.GetStringAsync("https://cdn.animenewsnetwork.com/encyclopedia/api.xml?anime=4658&manga=4199&manga=11608");
        //Console.WriteLine(animes);
        //ExecutarProximoDesafio();

        //// Desafio 2
        //string musicasApi = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        //var musicas = JsonSerializer.Deserialize<List<Musica>>(musicasApi)!;

        //Console.WriteLine("\n1- Exibir todos os gêneros musicais da lista");
        //var generos = musicas.DistinctBy(x => x.Genero).ToList();
        //generos.ForEach(x => Console.WriteLine(x.Genero));
        //ExecutarProximoDesafio();


        //Console.WriteLine("\n2- Ordenar os artistas por nome");
        //var musicasOrdenadas = musicas.OrderBy(x => x.Artista).ToList();
        //musicasOrdenadas.ForEach(x => Console.WriteLine(x.Artista));
        //ExecutarProximoDesafio();


        //Console.WriteLine("\n3- Filtrar artistas por gênero musical");
        //Console.Write("\nDigite o gênero musical: ");
        //var generoFiltro = Console.ReadLine()!;
        //Console.Write("\nDigite o nome do Artista: ");
        //var artistaFiltro = Console.ReadLine()!;

        //var musicasFiltradasPorGenero = musicas.Where(x => x.Genero!.Equals(generoFiltro) && x.Artista!.Equals(artistaFiltro)).ToList();
        //musicasFiltradasPorGenero.ForEach(x => Console.WriteLine($"{x.Artista} - {x.Nome}  - {x.Genero}"));
        //ExecutarProximoDesafio();

        //Console.WriteLine("\n4- Filtrar as músicas de um artista");
        //Console.Write("\nDigite o nome do Artista: ");
        //artistaFiltro = Console.ReadLine()!;
        //var musicasFiltradasPorArtista = musicas.Where(x => x.Artista!.Equals(artistaFiltro)).ToList();
        //musicasFiltradasPorArtista.ForEach(x => Console.WriteLine($"{x.Artista} - {x.Nome} "));

        //// Desafio 3
        string result = await client.GetStringAsync("https://www.anapioficeandfire.com/api/characters/16");
        var personagem = JsonSerializer.Deserialize<Personagem>(result)!;
        personagem.ExibirDetalhe();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}


void ExecutarProximoDesafio()
{
    Console.WriteLine("\nPressione uma tecla para ver o resultado do próximo desafio");
    Console.ReadKey();
    Console.Clear();
}