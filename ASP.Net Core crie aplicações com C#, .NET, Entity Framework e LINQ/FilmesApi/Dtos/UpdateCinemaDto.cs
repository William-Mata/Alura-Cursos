using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo Nome é de preenchimento obrigatório.")]
    public string Nome { get; set; }
    public int IdEndereco { get; set; }
}
