using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public class ReadEnderecoDto
{
    public string Cidade { get; set; }

    public string Bairro { get; set; }

    public string Logradouro { get; set; }

    public string Numero { get; set; }
}
