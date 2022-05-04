using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Cinema;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto createCinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(createCinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            var cinema = _context.Cinemas.Where(x => x.Id == id).FirstOrDefault();

            if (cinema == null)
            {
                return NotFound();
            }

            ReadCinemaDto readCinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(readCinemaDto);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas()
        {
            return Ok(_context.Cinemas);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinemaPorId(int id, [FromBody] UpdateCinemaDto updateCinemaDto)
        {
            var cinema = _context.Cinemas.Where(x => x.Id == id).FirstOrDefault();

            if (cinema == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCinemaDto, cinema);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinemaPorId(int id)
        {
            var cinema = _context.Cinemas.Where(x => x.Id == id).FirstOrDefault();
            if (cinema == null)
            {
                return NotFound();
            }

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
