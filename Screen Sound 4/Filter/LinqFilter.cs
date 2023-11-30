using Screen_Sound_4.Modelos;

namespace Screen_Sound_4.LinqFilter;

internal class LinqFilter
{
    public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
    {
        Console.WriteLine("\n1- Exibir todos os gêneros musicais da lista\n");
        var generos = musicas.DistinctBy(x => x.Genero).ToList();
        generos.ForEach(x => Console.WriteLine($"Genêro: {x.Genero}"));
    }

    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas)
    {
        Console.WriteLine("\n3- Filtrar artistas por gênero musical");
        Console.Write("\nDigite o gênero musical: ");
        var generoFiltro = Console.ReadLine()!;

        Console.WriteLine();
        var musicasFiltradasPorGenero = musicas.Where(x => x.Genero!.ToLower().Contains(generoFiltro.ToLower())).Select(x => x.Artista).Distinct().ToList();
        musicasFiltradasPorGenero.ForEach(Console.WriteLine);
    }

    public static void FiltrarMusicasPorArtista(List<Musica> musicas)
    {
        Console.WriteLine("\n4- Filtrar as músicas de um artista");
        Console.Write("\nDigite o nome do Artista: ");
        var artistaFiltro = Console.ReadLine()!;

        Console.WriteLine();
        var musicasFiltradasPorArtista = musicas.Where(x => x.Artista!.ToLower().Contains(artistaFiltro.ToLower())).Select(x => x.Nome).Distinct().ToList();
        musicasFiltradasPorArtista.ForEach(Console.WriteLine);
    }

    public static void FiltrarMusicasPorAnoDeLancamento(List<Musica> musicas)
    {
        Console.WriteLine("\n4- Filtrar as músicas por ano de lançamento");
        Console.Write("\nDigite o ano de lançamento: ");
        var anoLancamentoFiltro = Console.ReadLine()!;

        Console.WriteLine();
        var musicasFiltradasPorAnoLancamento = musicas.Where(x => x.AnoDeLancamento!.ToLower().Contains(anoLancamentoFiltro.ToLower())).Select(x => x.Nome).Distinct().ToList();
        musicasFiltradasPorAnoLancamento.ForEach(Console.WriteLine);
    }

    public static void FiltrarMusicasPorTonalidade(List<Musica> musicas)
    {
        Console.Clear();
        Console.Write("Digite a tonalidade: ");
        string tonalidade = Console.ReadLine()!;

        var musicasPorTonalidade = musicas.Where(x => x.Tonalidade!.Equals(tonalidade)).ToList();
        musicasPorTonalidade.ForEach(x => x.ExibirDetalhesDaMusica());
    }
}
