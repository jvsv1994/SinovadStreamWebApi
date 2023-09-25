using Generic.Core.Models;
using Microsoft.EntityFrameworkCore;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;
using System.Linq.Expressions;

namespace SinovadDemo.Persistence.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Role> GetRoleWithMenusAsync(Expression<Func<Role, bool>> predicate)
        {
            return await _context.Roles.Include(x => x.RoleMenus).ThenInclude(x => x.Menu).FirstOrDefaultAsync(predicate);
        }

    }
}
