﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "O campo de logradouro é obrigatório.")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo de bairro é obrigatório.")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo de número é obrigatório.")]
        public int Numero { get; set; }
    }
}
