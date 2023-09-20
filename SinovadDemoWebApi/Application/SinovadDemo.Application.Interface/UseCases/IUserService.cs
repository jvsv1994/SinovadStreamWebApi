using SinovadDemo.Application.DTO;
using SinovadDemo.Application.DTO.User;
using SinovadDemo.Domain.Enums;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IUserService
    {
        Task<ResponsePagination<List<UserDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<UserSessionDto>> GetUserByGuid(string guid);
        Task<Response<UserSessionDto>> GetUserByMediaServerSecurityIdentifier(string securityIdentifier);
        Task<Response<UserDto>> GetAsync(int id);
        Task<Response<bool>> ChangeNames(ChangeNamesDto dto);
        Task<Response<bool>> ChangeUserName(ChangeUserNameDto dto);
        Task<Response<bool>> ResetPassword(ResetPasswordDto dto);
        Task<Response<bool>> ChangePassword(ChangePasswordDto dto);
        Task<Response<bool>> SetPassword(SetPasswordDto dto);
        Task<Response<bool>> ValidateResetPasswordToken(ValidateResetPasswordTokenDto dto);
        Task<Response<bool>> RecoverPassword(RecoverPasswordDto dto);
        Task<Response<AuthenticationUserResponseDto>> ValidateUser(AuthenticateUserDto dto);
        Task<Response<string>> Login(AuthenticateUserDto dto);
        Task<Response<bool>> ValidateConfirmEmailToken(ValidateConfirmEmailTokenDto dto);
        Task<Response<bool>> Register(RegisterUserDto dto);
        Response<object> Create(UserDto userDto);
        Response<object> Update(UserDto userDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
        Task<bool> CheckIfExistAsync(int id);
    }
}
