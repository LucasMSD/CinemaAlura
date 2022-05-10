using FilmesAPI.Data.Dtos;
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
            var result = _service.AdicionarGerente(createGerenteDto);

            if (result.IsFailed)
            {
                NotFound();
            }

            return CreatedAtAction(nameof(RecuperarGerentePorId), new { Id = result.Value.Id }, result.Value);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int gerenteId)
        {
            var result = _service.RecuperarGerentePorId(gerenteId);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public IActionResult RecuperarGerentes()
        {
            var result = _service.RecuperarGerentes();

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerentePorId(int gerenteId, [FromBody] UpdateGerenteDto udpateGerenteDto)
        {
            var result = _service.AtualizarGerentePorId(gerenteId, udpateGerenteDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerentePorId(int gerenteId)
        {
            var result = _service.DeletarGerentePorId(gerenteId);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
