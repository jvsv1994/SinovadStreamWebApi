using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IMenuService
    {
        Task<Response<List<MenuDto>>> GetListMenusByUser(int userId);

    }

}
