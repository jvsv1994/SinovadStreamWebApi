using Generic.Core.Models;
using System.Linq.Expressions;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role> GetRoleWithMenusAsync(Expression<Func<Role, bool>> predicate);
    }
}
