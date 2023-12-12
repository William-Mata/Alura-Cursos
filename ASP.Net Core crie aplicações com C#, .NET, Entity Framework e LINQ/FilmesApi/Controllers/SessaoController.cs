using AutoMapper;
using FilmesApi.DataBase;
using FilmesApi.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessaoController : Controller
    {
        private IMapper _mapper;
        private FilmeContext _context;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarSessao), new { IdFilme = sessao.IdFilme, IdCinema = sessao.IdCinema });
        }

        [HttpGet]
        public IActionResult ListarSessoes([FromQuery] int skip, int take = 50)
        {
            var sessaos = _context.Sessoes.Skip(skip).Take(take).ToList();
            var sessaosDto = _mapper.Map<List<ReadSessaoDto>>(sessaos);
            return Ok(sessaosDto.ToList());
        }

        [HttpGet("BuscarSessao")]
        public IActionResult BuscarSessao([FromQuery] int IdFilme, int IdCinema)
        {
            var sessao = _context.Sessoes.FirstOrDefault(x => x.IdFilme == IdFilme && x.IdCinema == IdCinema);
            if (sessao == null) { NotFound(); }
            var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return Ok(sessaoDto);
        }

        [HttpDelete("{IdFilme, IdCinema}")]
        public IActionResult RemoverSessao(int IdFilme, int IdCinema)
        {
            var sessao = _context.Sessoes.FirstOrDefault(x => x.IdFilme == IdFilme && x.IdCinema == IdCinema);
            if (sessao == null) { return NotFound(); }
            _context.Remove(sessao);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
