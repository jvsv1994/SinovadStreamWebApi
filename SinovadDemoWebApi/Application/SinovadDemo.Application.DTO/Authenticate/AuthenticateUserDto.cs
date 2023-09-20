using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO.Authenticate
{
    public class AuthenticateUserDto
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }

    }
}
