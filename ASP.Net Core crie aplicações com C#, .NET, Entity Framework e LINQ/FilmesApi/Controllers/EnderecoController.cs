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
    public class EnderecoController : Controller
    {
        private IMapper _mapper;
        private FilmeContext _context;

        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarEndereco), new { id = endereco.Id });
        }

        [HttpGet]
        public IActionResult ListarEnderecos([FromQuery] int skip, int take = 50)
        {
            var enderecos = _context.Enderecos.Skip(skip).Take(take).ToList();
            var enderecosDto = _mapper.Map<List<ReadEnderecoDto>>(enderecos);
            return Ok(enderecosDto);
        }

        [HttpGet("BuscarEndereco")]
        public IActionResult BuscarEndereco([FromQuery] int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);
            if (endereco == null) { NotFound(); }
            var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

            return Ok(enderecoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);
            if (endereco == null) { return NotFound(); }
            endereco = _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizarEnderecoParcial(int id, [FromBody] JsonPatchDocument<UpdateEnderecoDto> enderecoPatch)
        {
            var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);
            if (endereco == null) { return NotFound(); }

            var enderecoDto = _mapper.Map<UpdateEnderecoDto>(enderecoPatch);
            enderecoPatch.ApplyTo(enderecoDto, ModelState);

            if (!TryValidateModel(ModelState))
            {
                return ValidationProblem(ModelState);
            }

            endereco = _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);
            if (endereco == null) { return NotFound(); }
            _context.Remove(endereco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
