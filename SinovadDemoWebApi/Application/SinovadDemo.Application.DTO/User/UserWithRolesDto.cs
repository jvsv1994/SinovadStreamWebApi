namespace SinovadDemo.Application.DTO.User
{
    public class UserWithRolesDto : UserDto
    {
        public List<UserRoleDto> UserRoles { get; set; }

    }
}
