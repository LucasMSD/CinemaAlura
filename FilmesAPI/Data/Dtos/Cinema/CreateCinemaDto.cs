using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo de enderecoId é obrigatório.")]
        public int EnderecoId { get; set; }
        [Required(ErrorMessage = "O campo de gerenteId é o obrigatório.")]
        public int GerenteId { get; set; }
    }
}
