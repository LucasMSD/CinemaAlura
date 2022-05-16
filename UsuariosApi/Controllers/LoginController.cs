using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest request)
        {
            var result = _service.LogarUsuario(request);

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors[0]);
            }

            return Ok(result.Successes[0]);
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitarResetSenhaUsuario([FromBody] SolicitarResetRequest SolicitarResetRequest)
        {
            var result = _service.SolicitarResetSenhaUsuario(SolicitarResetRequest);

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors);
            }

            return Ok(result.Successes[0]);
        }

        [HttpPost("/efetua-reset")]
        public IActionResult ResetSenhaUsuario([FromBody] EfetuarResetRequest efetuarResetRequest)
        {
            var result = _service.ResetSenhaUsuario(efetuarResetRequest);

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors);
            }

            return Ok();
        }
    }
}
