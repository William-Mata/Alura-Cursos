using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public class CreateEnderecoDto
{
    [Required(ErrorMessage = "O preenchimento do campo Cidade é obrigatório.")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "O preenchimento do campo Bairro é obrigatório.")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "O preenchiemento do campo Logradouro é obrigatório.")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O preenchimento do campo Número é obrigatório.")]
    public string Numero { get; set; }

}
