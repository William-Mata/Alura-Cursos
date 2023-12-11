using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O titulo do filme é obrigatório.")]
        public required string Titulo { get; set; }

        [Required(ErrorMessage = "A descrição do filme é obrigatória.")]
        public required string Descricao { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres.")]
        public required string Genero { get; set; }

        [Required]
        [Range(60.0, 240.0, ErrorMessage = "O tempo do filme deve está entre 60 a 240 minutos")]
        public float Duracao { get; set; }
    }
}
