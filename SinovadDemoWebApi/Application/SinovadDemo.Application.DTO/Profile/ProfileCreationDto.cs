using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO.Profile
{
    public class ProfileCreationDto
    {
        [Required(ErrorMessage ="El nombre del perfil es requerido")]
        public string FullName { get; set; }

    }
}
