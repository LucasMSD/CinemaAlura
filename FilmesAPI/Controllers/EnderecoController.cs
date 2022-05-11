using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _service;

        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto createEnderecoDto)
        {
            var result = _service.AdicionarEndereco(createEnderecoDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { Id = result.Value.Id }, result.Value);
        }

        [HttpGet("{enderecoId}")]
        public IActionResult RecuperarEnderecoPorId(int enderecoId)
        {
            var result = _service.RecuperarEnderecoPorId(enderecoId);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public IActionResult RecuperarEnderecos()
        {
            var result = _service.RecuperarEnderecos();

            if (result.IsFailed)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{enderecoId}")]
        public IActionResult AtualizarEnderecoPorId(int enderecoId, [FromBody] UpdateEnderecoDto updateEnderecoDto)
        {
            var result = _service.AtualizarEnderecoPorId(enderecoId, updateEnderecoDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{enderecoId}")]
        public IActionResult DeletarEnderecoPorId(int enderecoId)
        {
            var result = _service.DeletarEnderecoPorId(enderecoId);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
