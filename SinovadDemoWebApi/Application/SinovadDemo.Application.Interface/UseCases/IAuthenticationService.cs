using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public  interface IAuthenticationService
    {
        Task<Response<AuthenticationUserResponseDto>> AuthenticateUser(AccessUserDto dto);
        Task<Response<AuthenticationMediaServerResponseDto>> AuthenticateMediaServer(string securityIdentifier);
    }
}
