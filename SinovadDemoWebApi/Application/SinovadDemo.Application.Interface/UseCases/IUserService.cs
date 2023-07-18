using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IUserService
    {
        Task<ResponsePagination<List<UserDto>>> GetAllWithPaginationAsync(int page, int take);
        Task<Response<UserDto>> GetAsync(string username);
        Task<Response<UserDto>> GetAsync(int id);
        Task<Response<bool>> ResetPassword(ResetPasswordDto dto);
        Task<Response<bool>> ChangePassword(ChangePasswordDto dto);
        Task<Response<bool>> ValidateResetPasswordToken(ValidateResetPasswordTokenDto dto);
        Task<Response<bool>> RecoverPassword(RecoverPasswordDto dto);
        Task<Response<string>> Login(AccessUserDto dto);
        Task<Response<bool>> ValidateConfirmEmailToken(ValidateConfirmEmailTokenDto dto);
        Task<Response<bool>> Register(RegisterUserDto dto);
        Response<object> Create(UserDto userDto);
        Response<object> Update(UserDto userDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }
}
