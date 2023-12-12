using AutoMapper;
using FilmesApi.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Mapper;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        #region DTOS TO MODELS
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<UpdateSessaoDto, Sessao>();
        #endregion

        #region MODELS TO DTOS
        CreateMap<Sessao, ReadSessaoDto>();
        #endregion
    }
}
