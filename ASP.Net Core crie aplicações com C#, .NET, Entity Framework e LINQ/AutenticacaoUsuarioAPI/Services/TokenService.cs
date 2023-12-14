using AutenticacaoUsuarioAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AutenticacaoUsuarioAPI.Services;

public class TokenService
{
    private IConfiguration _config;

    public TokenService(IConfiguration config)
    {
        _config = config;
    }

    public string GerarToken(Usuario usuario)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("Username", usuario.UserName),
            new Claim("Id", usuario.Id),
            new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SymmetricSecurityKey"]));

        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(expires: DateTime.Now.AddHours(12), claims: claims, signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}