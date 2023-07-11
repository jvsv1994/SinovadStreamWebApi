using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO
{
    public class ValidateResetPasswordTokenDto
    {
        public string UserId { get; set; }
        public string ResetPasswordToken { get; set; }

    }
}
