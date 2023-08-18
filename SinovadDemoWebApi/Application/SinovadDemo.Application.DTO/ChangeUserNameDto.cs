using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO
{
    public class ChangeUserNameDto
    {
        [Required(ErrorMessage = "Username is mandatory")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User Id is mandatory")]
        public int UserId { get; set; }
    }
}
