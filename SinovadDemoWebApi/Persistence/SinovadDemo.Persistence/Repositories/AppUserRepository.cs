using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class AppUserRepository : GenericRepository<User>, IAppUserRepository
    {
        private ApplicationDbContext _context;
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
