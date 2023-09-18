using Microsoft.EntityFrameworkCore;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<int> GetListTMDdMovieIdsFinded(List<int> listTMDbIds)
        {
            return _context.Movies.Where(movie => movie.TmdbId != null && listTMDbIds.Contains(((int)movie.TmdbId))).Select(it=>(int)it.TmdbId).ToList();
        }

        public List<string> GetListImdbMovieIdsFinded(List<string> listImdbIds)
        {
            return _context.Movies.Where(movie => movie.Imdbid != null && listImdbIds.Contains(movie.Imdbid)).Select(it => it.Imdbid).ToList();
        }

        public async Task<Movie> GetMovie(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Movies.Include(movie=>movie.MovieGenres).ThenInclude(movieGenre=>movieGenre.Genre).FirstOrDefaultAsync(movie=>movie.Id==id, cancellationToken);
        }
    }
}
