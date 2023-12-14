using AutenticacaoUsuarioAPI.Data.Dtos;
using AutenticacaoUsuarioAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AutenticacaoUsuarioAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController( UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("CadastrarUsuario")]
    public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto)
    {
        var result = await _usuarioService.Cadastrar(dto);

        if (!result)
        {
            return BadRequest();
        }

        return Ok();
       
    }


    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        var result = await _usuarioService.AutenticarUsuario(dto);

        return Ok(result);
    }
}
