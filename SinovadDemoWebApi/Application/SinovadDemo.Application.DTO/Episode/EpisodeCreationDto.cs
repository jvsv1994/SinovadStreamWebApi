using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO.Episode
{
    public class EpisodeCreationDto
    {
        [Required(ErrorMessage = "El campo Número de episodio es requerido")]
        public int? EpisodeNumber { get; set; }

        [Required(ErrorMessage = "El campo Título es requerido")]
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }

    }
}
