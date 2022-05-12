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
                .ForMember(readSessaoDto => readSessaoDto.HorarioDeEncerramento, opts => opts
                .MapFrom(sessao => sessao.HorarioDeInicio.AddMinutes(sessao.Filme.Duracao)));
            CreateMap<UpdateSessaoDto, Sessao>();
        }
    }
}
