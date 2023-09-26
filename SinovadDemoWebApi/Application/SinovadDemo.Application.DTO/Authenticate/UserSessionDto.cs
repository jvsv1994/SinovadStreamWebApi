using SinovadDemo.Application.DTO.Authenticate;
using SinovadDemo.Application.DTO.MediaServer;
using SinovadDemo.Application.DTO.Menu;
using SinovadDemo.Application.DTO.Profile;
using SinovadDemo.Application.DTO.Role;

namespace SinovadDemo.Application.DTO.User
{
    public class UserSessionDto
    {
        public UserDto User { get; set; }
        public List<LinkedAccountDto> LinkedAccounts { get; set; }
        public List<ProfileDto> Profiles { get; set; }
        public List<MediaServerDto> MediaServers { get; set; }
        public List<RoleDto> Roles { get; set; }
        public List<MenuDto> Menus { get; set; }

    }
}
