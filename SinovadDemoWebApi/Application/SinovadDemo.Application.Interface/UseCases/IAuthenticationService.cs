using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public  interface IAuthenticationService
    {
        Task<Response<bool>> ValidateUser(string username);
        Task<Response<AuthenticationUserResponseDto>> AuthenticateUser(AccessUserDto dto);
        Task<Response<AuthenticationMediaServerResponseDto>> AuthenticateMediaServer(string securityIdentifier);
        Task<Response<AuthenticationUserResponseDto>> AuthenticateLinkedAccount(AuthenticateLinkedAccountRequestDto linkedAccountDto);
        Task<Response<AuthenticationUserResponseDto>> AuthenticatePasswordAndConfirmLinkAccountToUser(ConfirmLinkAccountDto confirmLinkAccountDto);
    }
}
