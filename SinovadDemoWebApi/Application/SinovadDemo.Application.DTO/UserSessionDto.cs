namespace SinovadDemo.Application.DTO
{
    public class UserSessionDto
    {
        public UserDto User { get; set; }
        public List<LinkedAccountDto> LinkedAccounts { get; set; }
        public List<ProfileDto> Profiles { get; set; }
        public List<MediaServerDto> MediaServers { get; set; }

    }
}
