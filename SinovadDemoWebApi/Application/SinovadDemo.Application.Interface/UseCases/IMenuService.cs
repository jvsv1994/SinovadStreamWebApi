using SinovadDemo.Application.DTO.Menu;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IMenuService
    {
        Task<Response<List<MenuDto>>> GetAllAsync();
        Task<ResponsePagination<List<MenuDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Response<object> Create(MenuDto menuDto);
        Response<object> Update(MenuDto menuDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
        Task<Response<List<MenuDto>>> GetListMenusByUser(int userId);

    }

}
