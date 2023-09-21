namespace SinovadDemo.Application.DTO.User
{
    public class ValidateResetPasswordTokenDto
    {
        public int UserId { get; set; }
        public string ResetPasswordToken { get; set; }

    }
}
