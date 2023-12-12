using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Models;

public class Sessao
{
    [ForeignKey(nameof(Cinema))]
    public int IdCinema { get; set; }

    [ForeignKey(nameof(Filme))]
    public int IdFilme { get; set; }

    public virtual Cinema Cinema { get; set; }

    public virtual Filme Filme { get; set; }
}
