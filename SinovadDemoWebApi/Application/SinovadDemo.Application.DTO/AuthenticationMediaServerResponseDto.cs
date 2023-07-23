namespace SinovadDemo.Application.DTO
{
    public class AuthenticationMediaServerResponseDto
    {
        public string ApiToken { get; set; }
        public MediaServerDto MediaServer { get; set; }
        public UserDto User { get; set; }

    }
}
