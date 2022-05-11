using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _service;

        public SessaoController(SessaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto createSessaoDto)
        {
            var result = _service.AdicionarSessao(createSessaoDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { Id = result.Value.Id }, result.Value);
        }

        [HttpGet("{sessaoId}")]
        public IActionResult RecuperarSessaoPorId(int sessaoId)
        {
            var result = _service.RecuperarSessaoPorId(sessaoId);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            var result = _service.RecuperarSessoes();

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpPut("{sessaoId}")]
        public IActionResult AtualizarSessaoPorId(int sessaoId, [FromBody] UpdateSessaoDto updateSessaoDto)
        {
            var result = _service.AtualizarSessaoPorId(sessaoId, updateSessaoDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{sessaoId}")]
        public IActionResult DeletarSessaoPorId(int sessaoId)
        {
            var result = _service.DeletarSessaoPorId(sessaoId);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
