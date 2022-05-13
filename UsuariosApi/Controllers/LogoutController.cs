using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private LogoutService _service;

        public LogoutController(LogoutService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult DeslogarUsuario()
        {
            var result = _service.DeslogarUsuario();

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors);
            }

            return Ok(result.Successes);
        }
    }
}
