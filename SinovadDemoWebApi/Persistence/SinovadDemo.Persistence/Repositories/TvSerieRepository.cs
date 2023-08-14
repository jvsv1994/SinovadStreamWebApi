using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class TvSerieRepository : GenericRepository<TvSerie>, ITvSerieRepository
    {
        private ApplicationDbContext _context;
        public TvSerieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<TvSerie> GetTvSeriesByTMDdIds(List<string> listTMDbIds)
        {
            return _context.TvSeries.Where(tvs => tvs.TmdbId != null && listTMDbIds.Contains(((int)tvs.TmdbId).ToString())).ToList();
        }

        public List<int> GetListTmdbIdsExistingInOwnDataBase(List<int> listTMDbIds)
        {
            return _context.TvSeries.Where(tvs => tvs.TmdbId != null && listTMDbIds.Contains(((int)tvs.TmdbId))).Select(tvs => tvs.TmdbId != null ? (int)tvs.TmdbId : 0).ToList();
        }

    }
}
