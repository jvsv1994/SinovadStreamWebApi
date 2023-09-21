using SinovadDemo.Domain.Enums;

namespace SinovadDemo.Application.DTO.Authenticate
{
    public class ConfirmLinkAccountDto
    {
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public int UserId { get; set; }
        public LinkedAccountProvider LinkedAccountProvider { get; set; }
        public string Password { get; set; }

    }
}
