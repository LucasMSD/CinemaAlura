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
        public IActionResult RecuperarCinemaPorId(int id)
        {
            var readCinemaDto = _service.RecuperarCinemaPorId(id);

            return Ok(readCinemaDto);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas()
        {
            var readCinemaDtoList = _service.RecuperarCinemas();

            return Ok(readCinemaDtoList);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinemaPorId(int id, [FromBody] UpdateCinemaDto updateCinemaDto)
        {
            _service.AtualizarCinemaPorId(id, updateCinemaDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinemaPorId(int id)
        {
            _service.DeletarCinemaPorId(id);

            return NoContent();
        }
    }
}
