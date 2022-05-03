﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Required(ErrorMessage = "O Título é um campo obrigatório.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O Título é um campo obrigatório.")]
        public string Diretor { get; set; }
        [Required(ErrorMessage = "O Título é um campo obrigatório.")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 minuto e no máximo 600 minutos.")]
        public int Duracao { get; set; }
    }
}
