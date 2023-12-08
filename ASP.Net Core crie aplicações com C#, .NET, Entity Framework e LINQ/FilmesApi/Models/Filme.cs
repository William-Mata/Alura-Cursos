using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O titulo do filme é obrigatório.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "A descrição do filme é obrigatória.")]
    public string Descricao { get; set; }
    
    [Required]
    [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres.")]
    public string Genero { get; set; }

    [Required]
    [Range(60.0, 240.0, ErrorMessage = "O tempo do filme deve está entre 60 a 240 minutos")]
    public float Duracao { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}\n" +
               $"Titulo: {Titulo}\n" +
               $"$Descrição: {Descricao}\n" +
               $"Genero: {Genero}\n" +
               $"Duracao: {Duracao}\n";
    }
}
