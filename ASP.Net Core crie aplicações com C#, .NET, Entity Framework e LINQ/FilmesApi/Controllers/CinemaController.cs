using AutoMapper;
using FilmesApi.DataBase;
using FilmesApi.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : Controller
{
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        var cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();

        return CreatedAtAction(nameof(BuscarCinema), new { id = cinema.Id });
    }

    [HttpGet]
    public IActionResult ListarCinemas([FromQuery] int IdEndereco)
    {
        var cinemas = _context.Cinemas.FromSqlRaw($"SELECT Id, Nome, IdEndereco FROM Cinemas WHERE IdEndereco = {IdEndereco}").ToList();
        if (cinemas == null) { NotFound(); }
        var readCinemas = _mapper.Map<List<ReadCinemaDto>>(cinemas);

        return Ok(readCinemas);
    }

    [HttpGet("BuscarCinema")]
    public IActionResult BuscarCinema([FromQuery] int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
        if (cinema == null) { NotFound(); }
        var readCinema = _mapper.Map<ReadCinemaDto>(cinema);

        return Ok(readCinema);
    }

    [HttpPut]
    public IActionResult AtualizarCinema([FromQuery] int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
        if (cinema == null) { NotFound(); }
        
        cinema = _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch]
    public IActionResult AtualizarCinemaParcial([FromQuery] int id, [FromBody] JsonPatchDocument<UpdateCinemaDto> cinemaPatch)
    {
        var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
        if (cinema == null) { NotFound(); }

        var cinemaDto = _mapper.Map<UpdateCinemaDto>(cinemaPatch);
        cinemaPatch.ApplyTo(cinemaDto, ModelState);

        if (!TryValidateModel(ModelState))
        {
            return ValidationProblem(ModelState);
        }

        cinema = _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    public IActionResult RemoverCinema([FromQuery] int id)
    {
        var cinema =  _context.Cinemas.FirstOrDefault(x => x.Id == id);
        if (cinema == null) {return NotFound(); }
        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    } 

}
