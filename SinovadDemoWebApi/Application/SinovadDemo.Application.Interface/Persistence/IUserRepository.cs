using SinovadDemo.Domain.Entities;
using System.Linq.Expressions;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserRelatedData(Expression<Func<User, bool>> predicate);

        Task<User> GetUserWithRolesAsync(Expression<Func<User, bool>> predicate);
    }
}
