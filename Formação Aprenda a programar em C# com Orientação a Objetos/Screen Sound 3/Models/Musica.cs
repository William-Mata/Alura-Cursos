namespace Screen_Sound_3.Models;

public class Musica
{
    #region Atributos/Propriedades
    public string Nome { get; set; }
    public float Duracao { get; set; }
    public int AnoDeLancamento { get; set; }
    public bool Disponivel { get; set; }

    //public string Descricao { get { return $"A música {Nome} foi lançada no ano de {AnoDeLancamento} pelo artista {Artista} e tem duração de {Duracao}"; } }
    public string Descricao => $"A música {Nome} do gênero {Genero.Nome} foi lançada no ano de {AnoDeLancamento} pela banda {Banda.Nome} e tem duração de {Duracao}";
    public Genero Genero { get; set; }
    public Banda Banda { get; }

    #endregion
   
    #region Métodos/Construtores
    public Musica(string nome, Banda banda) {
        this.Nome = nome;
        this.Banda = banda;
    }
    public void ExibirFichaTecnica()
    {
        Console.WriteLine(new string('*', 25));
        Console.WriteLine(" Ficha Tecnica da Música");
        Console.WriteLine(new string('*', 25));
        Console.WriteLine($"Música: {Nome}");
        Console.WriteLine($"Banda: {Banda.Nome}");
        Console.WriteLine($"Duração: {Duracao}");
        Console.WriteLine($"Ano de Lançamento: {AnoDeLancamento}");
        Console.WriteLine($"Gênero: {Genero.Nome}");
        Console.WriteLine($"Descrição: {Descricao}");
        Console.WriteLine($"Disponivel: {(Disponivel ? "Sim" : "Não")}\n");
    }
    public static void ListarTodasMusicas(List<Musica> musicas)
    {
        int contador = 1;
        musicas.ForEach(x => Console.WriteLine($"{contador++} - {x.Nome}"));
    }
    #endregion
}

