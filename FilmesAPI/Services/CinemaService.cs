using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

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

        public Cinema AdicionarCinema(CreateCinemaDto createCinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(createCinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return cinema;
        }

        public ReadCinemaDto? RecuperarCinemaPorId(int cinemaId)
        {
            var filme = _context.Cinemas.Where(x => x.Id == cinemaId).FirstOrDefault();

            if (filme == null)
            {
                return null;
            }

            var readCinemaDto = _mapper.Map<ReadCinemaDto>(filme);

            return readCinemaDto;
        }

        public IEnumerable<ReadCinemaDto> RecuperarCinemas()
        {
            var filmes = _context.Cinemas.ToList();

            var readCinemaDtoList = _mapper.Map<List<ReadCinemaDto>>(filmes);

            return readCinemaDtoList;
        }

        public void AtualizarCinemaPorId(int cinemaId, UpdateCinemaDto updateCinemaDto)
        {
            var cinema = _context.Cinemas.Where(x => x.Id == cinemaId).FirstOrDefault();

            if (cinema == null)
            {
                return;
            }

            _mapper.Map(updateCinemaDto, cinema);

            _context.SaveChanges();

            return;
        }

        public void DeletarCinemaPorId(int cinemaId)
        {
            var cinema = _context.Cinemas.Where(x => x.Id == cinemaId).FirstOrDefault();

            if (cinema == null)
            {
                return;
            }

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();

            return;
        }
    }
}
