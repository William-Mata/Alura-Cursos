using AutoMapper;
using Azure;
using FilmesApi.DataBase;
using FilmesApi.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : Controller
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext filmeContext, IMapper mapper)
    {
        _context = filmeContext;
        _mapper = mapper;
    }

    ///<summary>
    ///Adiciona um filme ao banco de dados
    ///</summary>
    ///<param name="createFilme" > Objeto com os campos necessários para criação de um filme</param>
    ///<returns>IActionResult</returns>
    ///<response code = "201" > Caso inserção seja feita com sucesso</response>
    [HttpPost("AdicionarFilme")] // TIPO DE REQUISIÇÃO E NOME DO METODO
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto createFilme) //FROMBODY DEFINE QUE O CONTEUDO DA REQUISIÇÃO DEVERA VIR NO CORPO
    {
        var filme = _mapper.Map<Filme>(createFilme);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        Console.WriteLine(filme);

        return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = filme.Id});
    }

    [HttpGet("ListarFilmes")] 
    public IActionResult ListarFilmes([FromQuery] int skip, [FromQuery] int take = 50) //FROMQUERY  DEFINE QUE O CONTEUDO DA REQUISIÇÃO DEVERA VIR NA URL 
    {
        var filmes =  _context.Filmes.Skip(skip).Take(take);

        var filmeDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
        return Ok(filmeDto);
    }

    [HttpGet("RecuperarFilmePorId")] 
    public IActionResult RecuperarFilmePorId(int id) 
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id)!;
        if (filme == null) { return NotFound(); }

        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarFilme([FromQuery] int id, [FromBody] UpdateFilmeDto updateFilmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if(filme != null)
        {
            filme = _mapper.Map(updateFilmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }
        else 
        { 
            return NotFound(); 
        }
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarFilmeParcial([FromQuery] int id, [FromBody] JsonPatchDocument<UpdateFilmeDto> jsonPatch)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme != null)
        {
            var filmeUpdate = _mapper.Map<UpdateFilmeDto>(filme);
            jsonPatch.ApplyTo(filmeUpdate, ModelState);

            if (!TryValidateModel(ModelState))
            {
                return ValidationProblem(ModelState);
            }

            filme = _mapper.Map(filmeUpdate, filme);
            _context.SaveChanges();
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id)!;
        if (filme == null) { return NotFound(); }

        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}