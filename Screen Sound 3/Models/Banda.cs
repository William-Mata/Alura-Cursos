namespace Screen_Sound_3.Models;

public class Banda
{
    #region Atributos/Propriedades
    public string Nome { get; set; }
    public List<Album> Albuns { get; set; } = new List<Album>();
    public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    #endregion

    #region Métodos/Construtores
    public Banda(string nome)
    {
        Nome = nome;
    }

    public void ExibirInformacoesDaBanda()
    {
        Console.WriteLine();
        Console.WriteLine(new string('#', 27));
        Console.WriteLine(" Informações Sobre a Banda");
        Console.WriteLine(new string('#', 27));
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Álbuns: ");
        int contador = 1;
        Albuns.ForEach(x => { Console.WriteLine($"        {contador++} - Álbum");  x.ExibirInformacoesDoAlbum(); });;
    }

    public static void ListarBandas(List<Banda> bandas)
    {
        var posicao = 1;
        bandas.ForEach(x => Console.WriteLine((posicao++) + " - " + x.Nome));
    }
    #endregion
}