using SevenDaysOfCode.Client;
using SevenDaysOfCode.Util;
using System.Text.Json.Serialization;

namespace SevenDaysOfCode.Models;

public class Mascote
{

    public int id { get; set; }

    [JsonPropertyName("name")]
    public string Nome { get; set; }

    [JsonPropertyName("height")]
    public float Altura { get; set; }    
    
    [JsonPropertyName("weight")]
    public float Peso { get; set; }

    [JsonPropertyName("base_experience")]
    public int Experiencia { get; set; }

    [JsonPropertyName("abilities")]
    public List<Habilidades> Habilidades { get; set; } = new List<Habilidades>();

    public static async Task ListarMascotes()
    {
        var result = await PokeApi.ListarMascoteApiAsync();
        Console.Clear();
        Console.WriteLine($"{new string('#', 30)}");
        Console.WriteLine($"{new string(' ', 7)} ADOTAR UM MASCOTE {new string(' ', 7)}");
        Console.WriteLine($"{new string('#', 30)}");
        result.Mascotes.ForEach(m => Console.WriteLine($"{m.Nome}"));
        await Menu.ExibirSubMenuAdocao();
    }

    public static void ListarMascotesAdotador()
    {
        Console.Clear();   
        Console.WriteLine($"{new string('#', 30)}");
        Console.WriteLine($"{new string(' ', 8)} SEUS MASCOTES {new string(' ', 8)}");
        Console.WriteLine($"{new string('#', 30)}");
        Menu.Mascotes.ForEach(m => Console.WriteLine($"{m}\n"));
    }

    public override string ToString()
    {
        return $"Nome Pokemon: {Nome}\n" +
               $"Altura: {Altura}\n" +
               $"Peso: {Peso}\n" +
               $"Habilidades: {string.Join("", Habilidades)}";
    }
}
