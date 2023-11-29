using Screen_Sound_3.Interface;

namespace Screen_Sound_3.Models;
public class Album : IAvaliavel
{
    #region Atributos/Propriedades
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public float Duracao => Musicas.Sum(x => x.Duracao);

    public static int QuantidadeDeAlbunsCriados;
    public IEnumerable<Musica> Musicas { get; set; } = new List<Musica>();
    public List<Avaliacao> Avaliacoes { get; } = new List<Avaliacao>();

    #endregion

    #region Métodos/Construtores
    public Album(string nome, List<Musica> musicas, string? descricao)
    {
        this.Nome = nome;
        this.Musicas = musicas;
        Descricao = descricao;
        QuantidadeDeAlbunsCriados++;
    }

    public void ExibirInformacoesDoAlbum()
    {
        Console.WriteLine($"        Nome: {Nome}");
        Console.WriteLine($"        Duração: {Duracao}");
        Console.WriteLine($"        Média de Avalição: {this.CalcularMedia()}");
        Console.WriteLine($"        Descrição: {Descricao}");
        Console.WriteLine($"        Músicas: ");

        Musica.ListarTodasMusicas(Musicas.ToList());
        Console.WriteLine();
    }

    public void AdicionarNota(string nota)
    {
        if (float.TryParse(nota, out _))
        {
            Avaliacao Avaliacao = new(float.Parse(nota));
            Avaliacoes.Add(Avaliacao);
        }
    }

    public float CalcularMedia()
    {
        return Avaliacoes.Count() > 0 ? Avaliacoes.Average(x => x.Nota) : 0;
    }

    public static void ListarTodosAlbuns(List<Album> albuns)
    {
        int contador = 1;
        albuns.ForEach(x => Console.WriteLine($"{contador++} - {x.Nome}"));
    }

    #endregion
}
