using SevenDaysOfCode.Models;
using System.Text.Json.Serialization;

namespace SevenDaysOfCode.Dtos;
public class ListMascoteDto
{
    [JsonPropertyName("count")]
    public int Quantidade { get; set; }

    [JsonPropertyName("results")]
    public List<Mascote> Mascotes { get; set; } = new List<Mascote>();
}
