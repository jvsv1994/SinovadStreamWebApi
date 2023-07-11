using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class SeasonRepository : GenericRepository<Season>, ISeasonRepository
    {
        private ApplicationDbContext _context;
        public SeasonRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Season> GetSeasonsByTvSerieId(int tvSerieId)
        {
            return _context.Seasons.Where(a => a.TvSerieId == tvSerieId).ToList();
        }

    }
}
