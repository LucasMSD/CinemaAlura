using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _service;

        public CadastroController(CadastroService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CadastrarUsuraio([FromBody] CreateUsuarioDto createUsuarioDto)
        {
            var result = _service.CadastrarUsuario(createUsuarioDto);

            if (result.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok(result.Successes[0]);
        }

        [HttpGet("/ativar")]
        public IActionResult AtivarContaUsuario([FromQuery] AtivarContaRequest ativarContaRequest)
        {
            var result = _service.AtivarContaUsuario(ativarContaRequest);

            if (result.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
