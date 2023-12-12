using AutoMapper;
using FilmesApi.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Mapper;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        #region DTOS TO MODELS
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<UpdateEnderecoDto, Endereco>();
        #endregion

        #region MODELS TO DTOS
        CreateMap<Endereco, ReadEnderecoDto>();
        #endregion
    }
}
