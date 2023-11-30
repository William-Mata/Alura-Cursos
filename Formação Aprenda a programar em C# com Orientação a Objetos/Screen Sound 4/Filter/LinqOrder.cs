using Screen_Sound_4.Modelos;

namespace Screen_Sound_4.Filter;

public class LinqOrder
{
    public static void OrdenarOsArtistasPorNome(List<Musica> musicas)
    {
        Console.WriteLine("\n2- Ordenar os artistas por nome\n");
        var musicasOrdenadas = musicas.Select(x => x.Artista).DistinctBy(x => x).OrderBy(x => x).ToList();
        musicasOrdenadas.ForEach(Console.WriteLine);
    }
}
