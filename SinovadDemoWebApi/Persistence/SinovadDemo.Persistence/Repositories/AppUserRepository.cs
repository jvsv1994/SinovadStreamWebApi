using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        private ApplicationDbContext _context;
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
