using SinovadDemo.Application.DTO.MediaServer;
using SinovadDemo.Application.DTO.User;

namespace SinovadDemo.Application.DTO.Authenticate
{
    public class AuthenticationMediaServerResponseDto
    {
        public string ApiToken { get; set; }
        public MediaServerDto MediaServer { get; set; }
        public UserDto User { get; set; }

    }
}
