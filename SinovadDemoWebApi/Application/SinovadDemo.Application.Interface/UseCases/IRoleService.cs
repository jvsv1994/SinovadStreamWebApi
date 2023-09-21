using SinovadDemo.Application.DTO.Role;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IRoleService
    {
        Task<Response<RoleDto>> GetAsync(int roleId);
        Task<ResponsePagination<List<RoleDto>>> GetAllWithPaginationAsync(int page, int take,string sortBy,string sortDirection, string searchText, string searchBy);
        Task<Response<RoleDto>> CreateAsync(RoleCreationDto dto);
        Task<Response<object>> UpdateAsync(int roleId,RoleCreationDto dto);
        Task<Response<object>> DeleteAsync(int id);
        Task<Response<object>> DeleteListAsync(string ids);
        Task<bool> CheckIfExistAsync(int id);


    }

}
