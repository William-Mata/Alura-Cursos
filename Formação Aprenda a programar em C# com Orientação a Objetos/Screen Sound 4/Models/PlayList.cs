using Screen_Sound_4.Modelos;
using System.Text.Json;

namespace Screen_Sound_4.Models;

public class PlayList
{
    #region Atributos/Propriedades
    public string? Nome { get; set; }
    public List<Musica> Musicas { get;} = new List<Musica>();
    #endregion

    #region Métodos/Construtores
    public PlayList(string nome) 
    {
        Nome = nome;
    }

    public void AdicionarMusicaNaPlayList(Musica musica)
    {
        Musicas.Add(musica);
    }

    public void ExibirDetalhesDaPlayList()
    {
        int contador = 1;
        Console.WriteLine($"\n{Nome}");
        Musicas.ForEach(musica => Console.WriteLine($"{contador++} - {musica.Nome} - {musica.Artista}"));
    }

    public void GerarArquivoJsonDaPlayList()
    {
        var musicasJson = JsonSerializer.Serialize(new {nome = Nome, musicas = Musicas });
        string caminho = "../../../Arquivos/";
        string nomeDoArquivo = $"{Nome}.json";
        File.WriteAllText(caminho+nomeDoArquivo, musicasJson);

        Console.WriteLine($"O arquivo {nomeDoArquivo} foi criado com sucesso no caminho {caminho + nomeDoArquivo}.");
    }


    public void GerarArquivoTxtDaPlayList()
    {
        string caminho = "../../../Arquivos/";
        string nomeDoArquivo = $"{Nome}.txt";

        using(StreamWriter arquivo = new StreamWriter(caminho + nomeDoArquivo))
        {
            arquivo.WriteLine($"{Nome}\n");
            int contador = 1;
            Musicas.ForEach(musica => arquivo.WriteLine($"{contador++} - {Nome} "));
        }

        Console.WriteLine($"O arquivo {nomeDoArquivo} foi criado com sucesso no caminho {caminho + nomeDoArquivo}.");
    }
    #endregion
}
