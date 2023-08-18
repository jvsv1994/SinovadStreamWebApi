using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.Infrastructure
{
    public interface IFirebaseAuthService
    {
        Task<UserDto> ValidateGoogleCredentials(string accessToken);

    }
}
