using FilmesApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos;

public class CreateSessaoDto
{
    public int IdCinema { get; set; }

    public int IdFilme { get; set; }
}
