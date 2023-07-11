using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Genre> GetGenresByTvSerieId(int tvSerieId)
        {

            var list = _context.Genres.Join(_context.TvSerieGenres, genre => genre.Id, tvseriegenre => tvseriegenre.GenreId, (genre, tvseriegenre) => new
            {
                genre,
                tvseriegenre
            }).Join(_context.TvSeries, tvseriegenre => tvseriegenre.tvseriegenre.TvSerieId, tvserie => tvserie.Id, (tvseriegenre, tvserie) => new
            {
                tvseriegenre.genre,
                tvSerieId = tvserie.Id
            }).Where(item => item.tvSerieId == tvSerieId).Select(item => item.genre).ToList();
            return list;
        }

    }
}
