using AutenticacaoUsuarioAPI.Data.Dtos;
using AutenticacaoUsuarioAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace AutenticacaoUsuarioAPI.Services;

public class UsuarioService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;
    private SignInManager<Usuario> _singInManager;
    private TokenService _tokenService;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> singInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _singInManager = singInManager;
        _tokenService = tokenService;
    }

    public async Task<bool> Cadastrar(CreateUsuarioDto dto)
    {
        try
        {
            var usuario = _mapper.Map<Usuario>(dto);

            IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

            return result.Succeeded;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<string> AutenticarUsuario(LoginUsuarioDto dto)
    {
        try
        {
            var result = await _singInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            
            if(result.Succeeded)
            {
                var usuario = _userManager.Users.FirstOrDefault(u => u.NormalizedUserName == dto.Username.ToUpper());
                var token = _tokenService.GerarToken(usuario);
                return token;
            }

            throw new ApplicationException("Usuário não autenticado.");
           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
