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
    public class GerenteController : ControllerBase
    {
        private GerenteService _service;

        public GerenteController(GerenteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDto createGerenteDto)
        {
            var gerente = _service.AdicionarGerente(createGerenteDto);

            return CreatedAtAction(nameof(RecuperarGerentePorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int gerenteId)
        {
            var readGerenteDto = _service.RecuperarGerentePorId(gerenteId);

            return Ok(readGerenteDto);
        }

        [HttpGet]
        public IActionResult RecuperarGerentes()
        {
            var readGerenteDtoList = _service.RecuperarGerentes();

            return Ok(readGerenteDtoList);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerentePorId(int gerenteId, [FromBody] UpdateGerenteDto udpateGerenteDto)
        {
            _service.AtualizarGerentePorId(gerenteId, udpateGerenteDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult  DeletarGerentePorId(int gerenteId)
        {
            _service.DeletarGerentePorId(gerenteId);

            return NoContent();
        }
    }
}
