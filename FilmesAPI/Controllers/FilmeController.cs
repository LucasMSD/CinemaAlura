using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
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

            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id}, filme);
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
        public IActionResult RecuperarFilmePorId(int id)
        {
            var readFilmeDto = _service.RecuperarFilmePorId(id);

            if (readFilmeDto == null)
            {
                return NotFound();
            }

            return Ok(readFilmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilmePorId(int id, [FromBody] UpdateFilmeDto updateFilmeDto)
        {
            _service.AtualizarFilmePorId(id, updateFilmeDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilmePorId(int id)
        {
            _service.DeletarFilmePorId(id);

            return NoContent();
        }
    }
}