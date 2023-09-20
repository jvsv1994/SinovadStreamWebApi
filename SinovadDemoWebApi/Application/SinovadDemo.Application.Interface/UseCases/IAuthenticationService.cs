using SinovadDemo.Application.DTO;
using SinovadDemo.Application.DTO.Authenticate;
using SinovadDemo.Application.DTO.SignUp;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public  interface IAuthenticationService
    {
        Task<Response<bool>> ValidateUser(string username);
        Task<Response<AuthenticationUserResponseDto>> AuthenticateUser(AuthenticateUserDto dto);
        Task<Response<AuthenticationMediaServerResponseDto>> AuthenticateMediaServer(string securityIdentifier);
        Task<Response<AuthenticationUserResponseDto>> AuthenticateLinkedAccount(RegisterUserFromProviderDto registerUserFromProviderDto);
        Task<Response<AuthenticationUserResponseDto>> AuthenticatePasswordAndConfirmLinkAccountToUser(ConfirmLinkAccountDto confirmLinkAccountDto);
    }
}
