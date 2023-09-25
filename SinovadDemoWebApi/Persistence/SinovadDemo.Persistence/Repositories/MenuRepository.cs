using Generic.Core.Models;
using Microsoft.EntityFrameworkCore;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        private ApplicationDbContext _context;
        public MenuRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Menu>> GetListMenusByUser(int userId)
        {



            var res = from menu in _context.Menus
                        join rolemenu in _context.RoleMenus on menu.Id equals rolemenu.MenuId
                        join role in _context.Roles on rolemenu.RoleId equals role.Id
                        join userrole in _context.UserRoles on role.Id equals userrole.RoleId
                        where userrole.UserId == userId
                        select menu;
            return await res.Distinct().ToListAsync();
        }

    }
}
