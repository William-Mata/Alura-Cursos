using AutoMapper;
using FilmesApi.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Mapper;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        #region DTOS TO MODELS
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        #endregion

        #region MODELS TO DTOS
        CreateMap<Filme, ReadFilmeDto>().ForMember(filmeDto => filmeDto.Sessoes, opt => opt.MapFrom(filme => filme.Sessoes));
        #endregion
    }
}
