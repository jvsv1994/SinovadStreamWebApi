using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO.TvSerie
{
    public class TvSerieCreationDto
    {
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Name { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }

        [Required(ErrorMessage = "El campo Primera fecha de emisión es requerido")]
        public DateTime FirstAirDate { get; set; }

        [Required(ErrorMessage = "El campo Última fecha de emisión es requerido")]
        public DateTime LastAirDate { get; set; }
        public string Directors { get; set; }
        public string Genres { get; set; }
        public string Actors { get; set; }
        public List<int> GenresIds { get; set; }

    }
}
