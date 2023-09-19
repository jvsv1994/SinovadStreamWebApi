using Microsoft.EntityFrameworkCore;
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

        public async Task<TvSerie> GetTvSerie(int id, CancellationToken cancellationToken = default)
        {
            return await _context.TvSeries.Include(tvSerie => tvSerie.TvSerieGenres).ThenInclude(tvSerieGenre => tvSerieGenre.Genre).FirstOrDefaultAsync(tvSerie => tvSerie.Id == id, cancellationToken);
        }

        public async Task<TvSerie> SearchTvSerie(string query, CancellationToken cancellationToken = default)
        {
            return await _context.TvSeries.Include(tvSerie => tvSerie.TvSerieGenres).ThenInclude(tvSerieGenre => tvSerieGenre.Genre).FirstOrDefaultAsync(x => x.Name.ToLower().Trim().Contains(query.ToLower().Trim()), cancellationToken);
        }
    }
}
