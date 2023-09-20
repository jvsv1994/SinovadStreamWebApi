using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is mandatory")]
        [StringLength(20, ErrorMessage = "{0} must be at least {2} characters long", MinimumLength = 5)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        [StringLength(50, ErrorMessage = "{0} must be at least {2} characters long", MinimumLength = 5)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is mandatory")]
        [Compare("Password", ErrorMessage = "Password and Password confirmation do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First name is mandatory")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is mandatory")]
        public string LastName { get; set; }
        public string ConfirmEmailUrl { get; set; }

    }
}
