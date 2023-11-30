using System.Text.Json.Serialization;

namespace Screen_Sound_4.Modelos
{
    public class Musica
    {
        private string[] Tonalidades = { "C", "C#", "D", "Eb", "E", "F", "F#", "G", "Ab", "A", "Bb", "B" };

        [JsonPropertyName("key")]
        public int Id {get ; set; }

        [JsonPropertyName("song")]
        public string? Nome { get; set; }

        [JsonPropertyName("artist")]
        public string? Artista { get; set; }

        [JsonPropertyName("duration_ms")]
        public int Duracao { get; set; }

        [JsonPropertyName("year")]
        public string? AnoDeLancamento { get; set; }

        [JsonPropertyName("genre")]
        public string? Genero { get; set; }

        public string? Tonalidade => Tonalidades[Id];

        public Musica(string nome, string artista)
        {
            Nome = nome;
            Artista = artista;
        }

        public void ExibirDetalhesDaMusica()
        {
            TimeSpan time = new TimeSpan(0, 0, 0, 0, Duracao);

            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Artista: {Artista}");
            Console.WriteLine($"Duração: {time.ToString()}");
            Console.WriteLine($"Ano De Lançamento: {AnoDeLancamento}");
            Console.WriteLine($"Gênero: {Genero}");
            Console.WriteLine($"Tonalidade: {Tonalidade}");
            Console.WriteLine("\n");
        }
    }
}
