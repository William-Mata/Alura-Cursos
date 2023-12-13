using System.Text.Json.Serialization;

namespace SevenDaysOfCode.Models;

public class Habildiade
{
    [JsonPropertyName("name")]
    public string Nome { get; set; }
}