using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO.User
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "Password is mandatory")]
        [StringLength(50, ErrorMessage = "{0} must be at least {2} characters long", MinimumLength = 5)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is mandatory")]
        [Compare("Password", ErrorMessage = "Password and Password confirmation do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Current password is mandatory")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "User Id is mandatory")]
        public int UserId { get; set; }
    }
}
