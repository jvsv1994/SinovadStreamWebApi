using SinovadDemo.Application.DTO.Menu;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IMenuService
    {
        Task<Response<MenuDto>> GetAsync(int menuId);
        Task<Response<List<MenuDto>>> GetAllAsync();
        Task<ResponsePagination<List<MenuDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<MenuDto>> CreateAsync(MenuCreationDto menuCreationDto);
        Task<Response<object>> UpdateAsync(int menuId,MenuCreationDto menuCreationDto);
        Task<Response<object>> DeleteAsync(int id);
        Task<Response<object>> DeleteListAsync(string ids);
        Task<bool> CheckIfExistsAsync(int menuId);

    }

}
