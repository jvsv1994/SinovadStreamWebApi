using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO.User
{
    public class ValidateUserDto
    {
        [Required(ErrorMessage ="El nombre de usuario es requerido")]
        public string UserName { get; set; }

    }
}
