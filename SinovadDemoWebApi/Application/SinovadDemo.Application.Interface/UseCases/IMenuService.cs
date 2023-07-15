using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IMenuService
    {
        Task<Response<List<MenuDto>>> GetAllAsync();
        Task<ResponsePagination<List<MenuDto>>> GetAllWithPaginationAsync(int page, int take);
        Response<object> Create(MenuDto menuDto);
        Response<object> Update(MenuDto menuDto);
        Task<Response<List<MenuDto>>> GetListMenusByUser(int userId);

    }

}
