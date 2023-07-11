using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO
{
    public class ValidateConfirmEmailTokenDto
    {
        public string UserId { get; set; }
        public string ConfirmEmailToken { get; set; }

    }
}
