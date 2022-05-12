using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Result<Cinema> AdicionarCinema(CreateCinemaDto createCinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(createCinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return Result.Ok(cinema);
        }

        public Result<ReadCinemaDto> RecuperarCinemaPorId(int cinemaId)
        {
            var filme = _context.Cinemas.Where(x => x.Id == cinemaId).FirstOrDefault();

            if (filme == null)
            {
                return Result.Fail("Cinema não encontrado.");
            }

            var readCinemaDto = _mapper.Map<ReadCinemaDto>(filme);

            return Result.Ok(readCinemaDto);
        }

        public Result<List<ReadCinemaDto>> RecuperarCinemas(string? filmeTitulo)
        {
            //var cinemas = _context.Cinemas.Where(x => x.Sessoes.Any(sessao => string.IsNullOrEmpty(filmeTitulo) || sessao.Filme.Titulo == filmeTitulo)).ToList();
            var cinemas = from cinema in _context.Cinemas
                          where cinema.Sessoes.Any(sessao => true)
                          select cinema;

            var readCinemaDtoList = _mapper.Map<List<ReadCinemaDto>>(cinemas);

            return Result.Ok(readCinemaDtoList);
        }

        public Result AtualizarCinemaPorId(int cinemaId, UpdateCinemaDto updateCinemaDto)
        {
            var cinema = _context.Cinemas.Where(x => x.Id == cinemaId).FirstOrDefault();

            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado.");
            }

            _mapper.Map(updateCinemaDto, cinema);

            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletarCinemaPorId(int cinemaId)
        {
            var cinema = _context.Cinemas.Where(x => x.Id == cinemaId).FirstOrDefault();

            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado.");
            }

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
