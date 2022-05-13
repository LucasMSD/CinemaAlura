using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Requests
{
    public class AtivarContaRequest
    {
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public string CodigoAtivacao { get; set; }
    }
}
