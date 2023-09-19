using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO.Season
{
    public class SeasonCreationDto
    {
        [Required(ErrorMessage = "El campo Número de temporada es requerido")]
        public int? SeasonNumber { get; set; }

        [Required(ErrorMessage = "El campo Nombre de temporada es requerido")]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }

    }
}
