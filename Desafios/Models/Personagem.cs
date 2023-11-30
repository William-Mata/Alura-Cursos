using System.Text.Json.Serialization;

namespace Desafios.Models
{
    public class Personagem
    {
        [JsonPropertyName("name")]
        public string? Nome { get; set; }

        [JsonPropertyName("gender")]
        public string? Genero { get; set; }

        [JsonPropertyName("culture")]
        public string? Cultura { get; set; }

        [JsonPropertyName("born")]
        public string? Nascimento { get; set; }

        [JsonPropertyName("aliases")]
        public List<string>? Apelidos { get; set; }

        public void ExibirDetalhe()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Gênero: {Genero}");
            Console.WriteLine($"Cultura: {Cultura}");
            Console.WriteLine($"Nascimento: {Nascimento}");
            Console.WriteLine($"Apelidos: {string.Join(", ", Apelidos!)}");
        }
    }
}
