namespace Screen_Sound_3.Models;
public class Album
{
    #region Atributos/Propriedades
    public string Nome { get; set; }
    public float Duracao => Musicas.Sum(x => x.Duracao);
    public List<Musica> Musicas { get; set; } = new List<Musica>();
    public static int QuantidadeDeAlbunsCriados;
    #endregion

    #region Métodos/Construtores
    public Album(string nome, List<Musica> musicas)
    {
        this.Nome = nome;
        this.Musicas = musicas;
        QuantidadeDeAlbunsCriados++;
    }

    public void ExibirInformacoesDoAlbum()
    {
        Console.WriteLine($"        Nome: {Nome}");
        Console.WriteLine($"        Duração: {Duracao}");
        Console.WriteLine($"        Músicas: ");

        int contador = 1;
        Musicas.ForEach(x => Console.WriteLine($"                {contador++} - {x.Nome}"));
        Console.WriteLine();
    }
    #endregion
}
