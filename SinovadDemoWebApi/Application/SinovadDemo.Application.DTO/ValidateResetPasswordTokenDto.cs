using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO
{
    public class ValidateResetPasswordTokenDto
    {
        public int UserId { get; set; }
        public string ResetPasswordToken { get; set; }

    }
}
