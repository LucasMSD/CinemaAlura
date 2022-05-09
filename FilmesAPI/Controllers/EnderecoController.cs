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
            var endereco = _service.AdicionarEndereco(createEnderecoDto);

            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int enderecoId)
        {
            var readEnderecoDto = _service.RecuperarEnderecoPorId(enderecoId);

            return Ok(readEnderecoDto);
        }

        [HttpGet]
        public IActionResult RecuperarEnderecos()
        {
            var readEnderecoDtoList = _service.RecuperarEnderecos();

            return Ok(readEnderecoDtoList);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEnderecoPorId(int enderecoId, [FromBody] UpdateEnderecoDto updateEnderecoDto)
        {
            _service.AtualizarEnderecoPorId(enderecoId, updateEnderecoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEnderecoPorId(int idenderecoId)
        {
            _service.DeletarEnderecoPorId(idenderecoId);

            return NoContent();
        }
    }
}
