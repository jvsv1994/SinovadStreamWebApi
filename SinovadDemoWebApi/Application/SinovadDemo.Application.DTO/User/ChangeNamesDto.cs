using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO.User
{
    public class ChangeNamesDto
    {
        [Required(ErrorMessage = "FirstName is mandatory")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is mandatory")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User Id is mandatory")]
        public int UserId { get; set; }
    }
}
