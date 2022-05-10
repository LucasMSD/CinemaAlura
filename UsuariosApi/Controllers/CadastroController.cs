using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
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
        public IActionResult CadastrarUsuraio(CreateUsuarioDto createUsuarioDto)
        {
            var result = _service.CadastrarUsuario(createUsuarioDto);

            if (result.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
