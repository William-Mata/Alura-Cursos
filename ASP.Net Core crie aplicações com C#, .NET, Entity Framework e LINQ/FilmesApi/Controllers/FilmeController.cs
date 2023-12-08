using FilmesApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : Controller
{
    private static List<Filme> Filmes = new List<Filme>();
    private static int Id = 1;

    [HttpPost("AdicionarFilme")] // TIPO DE REQUISIÇÃO E NOME DO METODO
    public IActionResult AdicionarFilme([FromBody] Filme filme) //FROMBODY DEFINE QUE O CONTEUDO DA REQUISIÇÃO DEVERA VIR NO CORPO
    {
        filme.Id = Id++;
        Filmes.Add(filme);
        Console.WriteLine(filme);

        return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = filme.Id});
    }

    [HttpGet("ListarFilmes")] 
    public IActionResult ListarFilmes([FromQuery] int skip, [FromQuery] int take = 50) //FROMQUERY  DEFINE QUE O CONTEUDO DA REQUISIÇÃO DEVERA VIR NA URL 
    {
        var filmes =  Filmes.Skip(skip).Take(take);

        return Ok(filmes);
    }

    [HttpGet("RecuperarFilmePorId")] 
    public IActionResult RecuperarFilmePorId(int id) 
    {
        var filme = Filmes.FirstOrDefault(x => x.Id == id)!;

        if (filme == null) { return NotFound(); }

        return Ok(filme);
    }
}