using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IRoleService
    {
        Task<ResponsePagination<List<RoleDto>>> GetAllWithPaginationAsync(int page, int take);
        Response<object> Create(RoleDto dto);
        Response<object> Update(RoleDto dto);

    }

}
