using SinovadDemo.Application.DTO.Role;

namespace SinovadDemo.Application.DTO.User
{
    public class UserWithRolesDto : UserDto
    {
        public List<RoleDto> Roles { get; set; }

    }
}
