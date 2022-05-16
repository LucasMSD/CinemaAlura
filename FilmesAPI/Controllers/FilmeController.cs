using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _service;

        public FilmeController(FilmeService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto createFilmeDto)
        {
            var result = _service.AdicionarFilme(createFilmeDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(RecuperarFilmePorId), new { FilmeId = result.Value.Id }, result.Value);
        }

        [HttpGet("{filmeId}")]
        public IActionResult RecuperarFilmePorId(int filmeId)
        {
            var result = _service.RecuperarFilmePorId(filmeId);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria)
        {
            var result = _service.RecuperarFilmes(classificacaoEtaria);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpPut("{filmeId}")]
        public IActionResult AtualizarFilmePorId(int filmeId, [FromBody] UpdateFilmeDto updateFilmeDto)
        {
            var result = _service.AtualizarFilmePorId(filmeId, updateFilmeDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{filmeId}")]
        public IActionResult DeletarFilmePorId(int filmeId)
        {
            var result = _service.DeletarFilmePorId(filmeId);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}