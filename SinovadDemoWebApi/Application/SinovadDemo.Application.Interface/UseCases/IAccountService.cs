using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IAccountService
    {
        Task<ResponsePagination<List<AccountDto>>> GetAllAsync(int page, int take);
        Task<Response<AccountDto>> GetAsync(string username);
        Task<Response<AccountDto>> GetAsync(int id);
        Task<Response<bool>> ResetPassword(ResetPasswordDto dto);
        Task<Response<bool>> ValidateResetPasswordToken(ValidateResetPasswordTokenDto dto);
        Task<Response<bool>> RecoverPassword(RecoverPasswordDto dto);
        Task<Response<string>> Login(AccessUserDto dto);
        Task<Response<bool>> ValidateConfirmEmailToken(ValidateConfirmEmailTokenDto dto);
        Task<Response<bool>> Register(RegisterUserDto dto);
        Response<object> Create(AccountDto accountDto);
        Response<object> Update(AccountDto accountDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }
}
