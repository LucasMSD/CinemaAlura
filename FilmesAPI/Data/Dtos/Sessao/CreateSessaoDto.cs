﻿namespace FilmesAPI.Data.Dtos
{
    public class CreateSessaoDto
    {
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
