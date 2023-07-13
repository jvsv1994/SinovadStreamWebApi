using Generic.Core.Models;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IMenuRepository : IGenericRepository<Menu>
    {
        Task<List<Menu>> GetListMenusByUser(int userId);

    }
}
