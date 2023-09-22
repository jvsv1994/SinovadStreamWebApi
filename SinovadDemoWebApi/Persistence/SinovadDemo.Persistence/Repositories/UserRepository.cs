using Microsoft.EntityFrameworkCore;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;
using System.Linq.Expressions;

namespace SinovadDemo.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserRelatedData(Expression<Func<User, bool>> predicate)
        {
          return await _context.Users.Include(x=>x.MediaServers).Include(x=>x.LinkedAccounts).Include(x=>x.Profiles).Include(x=>x.UserRoles).ThenInclude(x=>x.Role).FirstOrDefaultAsync(predicate);
        }

        public async Task<User> GetUserWithRolesAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(predicate);
        }

    }
}
