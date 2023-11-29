using Screen_Sound_3.Interface;

namespace Screen_Sound_3.Models;

public class Banda : IAvaliavel
{
    #region Atributos/Propriedades
    public string Nome { get; set; }
    public string? Descricao { get; }
    public  IEnumerable<Album> Albuns { get; private set; } = new List<Album>();
    public List<Avaliacao> Avaliacoes { get; } = new();
    #endregion

    #region Métodos/Construtores
    public Banda(string nome, string? descricao)
    {
        Nome = nome;
        Descricao = descricao;
    }

    public void ExibirInformacoesDaBanda()
    {
        Console.WriteLine();
        Console.WriteLine(new string('#', 27));
        Console.WriteLine(" Informações Sobre a Banda");
        Console.WriteLine(new string('#', 27));
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Descrição: {Descricao}");
        Console.WriteLine($"Álbuns: ");
        int contador = 1;
        Albuns.ToList().ForEach(x => { Console.WriteLine($"        {contador++} - Álbum");  x.ExibirInformacoesDoAlbum(); });;
    }

    public static void ListarBandas(List<Banda> bandas)
    {
        var posicao = 1;
        bandas.ForEach(x => Console.WriteLine((posicao++) + " - " + x.Nome));
    }

    public void AdicionarNota(string nota)
    {
        if(float.TryParse(nota, out _))
        {
            Avaliacao Avaliacao = new(float.Parse(nota));
            Avaliacoes.Add(Avaliacao);
        }
    }

    public float CalcularMedia()
    {
        return Avaliacoes.Count() > 0 ? Avaliacoes.Average(x => x.Nota) : 0; 
    }

    public void CadastrarAlbum(Album album)
    {
        var albuns = Albuns.ToList();
        albuns.Add(album);
        Albuns = albuns.AsEnumerable();
    }
    #endregion
}