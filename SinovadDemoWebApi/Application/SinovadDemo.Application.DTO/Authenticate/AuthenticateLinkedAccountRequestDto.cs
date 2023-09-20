using SinovadDemo.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO.Authenticate
{
    public class AuthenticateLinkedAccountRequestDto
    {
        [Required(ErrorMessage = "El token de acceso es requerido")]
        public string AccessToken { get; set; }

        [Required(ErrorMessage = "El Id del proveedor de acceso es requerido")]
        public LinkedAccountProvider LinkedAccountProviderCatalogDetailId { get; set; }

    }
}
