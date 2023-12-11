using AutoMapper;
using FilmesApi.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        #region DTOS TO MODELS
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        #endregion

        #region MODELS TO DTOS
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>();
        #endregion
    }
}
