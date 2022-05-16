using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Requests
{
    public class SolicitarResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
