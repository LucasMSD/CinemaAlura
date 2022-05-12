﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateSessaoDto
    {
        [Required]
        public int CinemaId { get; set; }
        [Required]
        public int FilmeId { get; set; }
        [Required]
        public DateTime HorarioDeInicio { get; set; }
    }
}
