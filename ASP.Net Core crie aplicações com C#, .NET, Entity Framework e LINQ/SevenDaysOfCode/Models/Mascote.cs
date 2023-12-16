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

    private int Alimentacao { get; set; }

    private int Humor { get; set; }

    private int Cansaco { get; set; }

    public Mascote()
    {
        var random =  new Random();
        Alimentacao = int.Parse(random.NextInt64(0, 11).ToString());
        Humor = int.Parse(random.NextInt64(0, 11).ToString());
        Cansaco = int.Parse(random.NextInt64(0, 11).ToString());
    }

    public void Alimentar()
    {
        if(Alimentacao < 10) 
        {
            Alimentacao++;
            Humor--;
        }
    }

    public void Brincar()
    {
        if(Humor < 10) 
        { 
            Humor++;
            Alimentacao--;
            Cansaco--;
        }
    }

    public void Descansar()
    {
        if (Cansaco < 10)
        {
            Cansaco++;
            Humor++;
            Alimentacao--;
        }
    }

    public override string ToString()
    {
        return $"Nome Pokemon: {Nome}\n" +
               $"Altura: {Altura}\n" +
               $"Peso: {Peso}\n" +
               $"Alimentação: {Alimentacao}\n" +
               $"Humor: {Humor}\n" +
               $"Cansaço: {Cansaco}\n" +
               $"Habilidades: {string.Join("", Habilidades)}";
    }
}
