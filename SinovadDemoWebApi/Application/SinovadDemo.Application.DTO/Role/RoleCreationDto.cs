using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO.Role
{
    public class RoleCreationDto
    {
        [Required(ErrorMessage ="El nombre del rol es requerido")]
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
