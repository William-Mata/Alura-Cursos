using AutenticacaoUsuarioAPI.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutenticacaoUsuarioAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AcessoController : ControllerBase
{

    [HttpGet("TesteAceso")]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult TesteAceso()
    {
        return Ok("Acesso Permitido!");
    }
}
