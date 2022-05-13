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
    }
}
