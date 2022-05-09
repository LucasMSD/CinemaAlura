using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
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
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto createFilmeDto)
        {
            var filme = _service.AdicionarFilme(createFilmeDto);

            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria)
        {
            var readFilmeDtoList = _service.RecuperarFilmes(classificacaoEtaria);

            if (!readFilmeDtoList.Any())
            {
                return NotFound();
            }

            return Ok(readFilmeDtoList);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int filmeId)
        {
            var readFilmeDto = _service.RecuperarFilmePorId(filmeId);

            if (readFilmeDto == null)
            {
                return NotFound();
            }

            return Ok(readFilmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilmePorId(int filmeId, [FromBody] UpdateFilmeDto updateFilmeDto)
        {
            _service.AtualizarFilmePorId(filmeId, updateFilmeDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilmePorId(int filmeId)
        {
            _service.DeletarFilmePorId(filmeId);

            return NoContent();
        }
    }
}