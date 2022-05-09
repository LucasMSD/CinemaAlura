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
            var sessao = _service.AdicionarSessao(createSessaoDto);

            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int sessaoId)
        {
            var readSessaoDto = _service.RecuperarSessaoPorId(sessaoId);

            return Ok(readSessaoDto);
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            var readSessaoDtoList = _service.RecuperarSessoes();

            return Ok(readSessaoDtoList);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSessaoPorId(int sessaoId, [FromBody] UpdateSessaoDto updateSessaoDto)
        {
            _service.AtualizarSessaoPorId(sessaoId, updateSessaoDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarSessaoPorId(int sessaoId)
        {
            _service.DeletarSessaoPorId(sessaoId);

            return NoContent();
        }
    }
}
