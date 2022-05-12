using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateGerenteDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório.")]
        public string? Nome { get; set; }
    }
}
