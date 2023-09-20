using SinovadDemo.Application.DTO.User;

namespace SinovadDemo.Application.DTO.Authenticate
{
    public class AuthenticationUserResponseDto
    {
        public string ApiToken { get; set; }
        public UserDto User { get; set; }
        public UserSessionDto UserData { get; set; }
        public ConfirmLinkAccountDto ConfirmLinkAccountData { get; set; }

    }
}
