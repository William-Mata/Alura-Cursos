using AutenticacaoUsuarioAPI.Data.Dtos;
using AutenticacaoUsuarioAPI.Models;
using AutoMapper;

namespace AutenticacaoUsuarioAPI.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    }
}
