using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace SinovadDemo.Application.DTO
{
    public class MovieGenreDto
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int TmdbId { get; set; }
        public string ImdbId { get; set; }

    }
}
