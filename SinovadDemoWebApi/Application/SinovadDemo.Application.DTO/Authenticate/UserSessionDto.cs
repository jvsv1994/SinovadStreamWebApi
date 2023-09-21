using SinovadDemo.Application.DTO.Authenticate;
using SinovadDemo.Application.DTO.MediaServer;
using SinovadDemo.Application.DTO.Profile;

namespace SinovadDemo.Application.DTO.User
{
    public class UserSessionDto
    {
        public UserDto User { get; set; }
        public List<LinkedAccountDto> LinkedAccounts { get; set; }
        public List<ProfileDto> Profiles { get; set; }
        public List<MediaServerDto> MediaServers { get; set; }

    }
}
