﻿
using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO
{
    public class MovieDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="El campo Título es requerido")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Lanzamiento es requerido")]
        public DateTime ReleaseDate { get; set; }
        public bool? Adult { get; set; }
        public int? TmdbId { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double? Popularity { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public string Directors { get; set; }
        public string Actors { get; set; }
        public string Genres { get; set; }
        public string Imdbid { get; set; }
        public virtual List<string> ListGenreNames { get; set; }
        public virtual List<MovieGenreDto> ListItemGenres { get; set; }
        public virtual List<MovieGenreDto> MovieGenres { get; set; }

    }
}
