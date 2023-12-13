using System.Text.Json.Serialization;

namespace SevenDaysOfCode.Models;

public class Habilidades
{
    [JsonPropertyName("is_hidden")]
    public bool Oculto { get; set; }
    public int slot { get; set; }

    [JsonPropertyName("ability")]
    public Habildiade Habildiade { get; set; }

    public override string ToString()
    {
        return $"\n{Habildiade.Nome.ToUpper()}";
    }
}
