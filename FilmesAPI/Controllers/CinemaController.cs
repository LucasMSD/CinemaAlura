using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _service;

        public CinemaController(CinemaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto createCinemaDto)
        {
            var cinema = _service.AdicionarCinema(createCinemaDto);

            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int cinemaId)
        {
            var readCinemaDto = _service.RecuperarCinemaPorId(cinemaId);

            return Ok(readCinemaDto);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas()
        {
            var readCinemaDtoList = _service.RecuperarCinemas();

            return Ok(readCinemaDtoList);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinemaPorId(int cinemaId, [FromBody] UpdateCinemaDto updateCinemaDto)
        {
            _service.AtualizarCinemaPorId(cinemaId, updateCinemaDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinemaPorId(int cinemaId)
        {
            _service.DeletarCinemaPorId(cinemaId);

            return NoContent();
        }
    }
}
