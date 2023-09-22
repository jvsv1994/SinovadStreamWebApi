using SinovadDemo.Application.DTO.User;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IUserService
    {
        Task<Response<UserSessionDto>> GetUserByMediaServerSecurityIdentifier(string securityIdentifier);
        Task<Response<UserSessionDto>> GetUserByGuid(string guid);
        Task<Response<bool>> ChangeNames(ChangeNamesDto dto);
        Task<Response<bool>> ChangeUserName(ChangeUserNameDto dto);
        Task<Response<bool>> ResetPassword(ResetPasswordDto dto);
        Task<Response<bool>> ChangePassword(ChangePasswordDto dto);
        Task<Response<bool>> SetPassword(SetPasswordDto dto);
        Task<Response<bool>> ValidateResetPasswordToken(ValidateResetPasswordTokenDto dto);
        Task<Response<bool>> RecoverPassword(RecoverPasswordDto dto);
        Task<Response<bool>> ValidateConfirmEmailToken(ValidateConfirmEmailTokenDto dto);
        Task<Response<UserDto>> GetAsync(int id);
        Task<Response<UserWithRolesDto>> GetUserWithRolesAsync(int id);
        Task<Response<object>> UpdateUserRolesAsync(int userId, List<UserRoleDto> userRoles);
        Task<ResponsePagination<List<UserDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<object>> DeleteAsync(int id);
        Task<bool> CheckIfExistAsync(int id);
    }
}
