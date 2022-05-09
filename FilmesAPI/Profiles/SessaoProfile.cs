using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(readSessaoDto => readSessaoDto.HorarioDeInicio, opts => opts
                .MapFrom(readSessaoDto => readSessaoDto.HorarioDeEncerramento.AddMinutes(readSessaoDto.Filme.Duracao * (-1))));
        }
    }
}
