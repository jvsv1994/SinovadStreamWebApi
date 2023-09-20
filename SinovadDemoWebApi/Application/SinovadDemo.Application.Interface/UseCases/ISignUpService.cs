using SinovadDemo.Application.DTO;
using SinovadDemo.Application.DTO.User;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ISignUpService
    {
        Task<Response<bool>> Register(RegisterUserDto dto);
        Task RegisterWithLinkedAccount(RegisterUserFromProviderDto registerUserFromProviderDto);
    }
}
