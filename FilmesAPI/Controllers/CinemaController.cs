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
            var result = _service.AdicionarCinema(createCinemaDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { CinemaId = result.Value.Id }, result.Value);
        }

        [HttpGet("{cinemaId}")]
        public IActionResult RecuperarCinemaPorId(int cinemaId)
        {
            var result = _service.RecuperarCinemaPorId(cinemaId);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string? filmeTitulo)
        {
            var result = _service.RecuperarCinemas(filmeTitulo);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpPut("{cinemaId}")]
        public IActionResult AtualizarCinemaPorId(int cinemaId, [FromBody] UpdateCinemaDto updateCinemaDto)
        {
            var result = _service.AtualizarCinemaPorId(cinemaId, updateCinemaDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{cinemaId}")]
        public IActionResult DeletarCinemaPorId(int cinemaId)
        {
            var result = _service.DeletarCinemaPorId(cinemaId);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
