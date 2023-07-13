using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO
{
    public class ValidateConfirmEmailTokenDto
    {
        public int UserId { get; set; }
        public string ConfirmEmailToken { get; set; }

    }
}
