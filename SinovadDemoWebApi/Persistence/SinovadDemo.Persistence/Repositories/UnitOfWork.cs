using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;
        private IMenuRepository _menus;
        private IRoleRepository _roles;
        private IGenericRepository<MediaServer> _mediaServers;
        private IGenericRepository<Catalog> _catalogs;
        private IGenericRepository<CatalogDetail> _catalogDetails;
        private IGenreRepository _genres;
        private IMovieRepository _movies;
        private IGenericRepository<MovieGenre> _movieGenres;
        private IGenericRepository<Profile> _profiles;
        private IGenericRepository<LinkedAccount> _linkedAccounts;
        private ISeasonRepository _seasons;
        private ITvSerieRepository _tvSeries;
        private IGenericRepository<TvSerieGenre> _tvSerieGenres;
        private IEpisodeRepository _episodes;
        private IUserRepository _users;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users
        {
            get
            {
                return _users == null ?
                _users = new UserRepository(_context) :
                _users;
            }
        }

        public IMenuRepository Menus
        {
            get
            {
                return _menus == null ?
                _menus = new MenuRepository(_context) :
                _menus;
            }
        }
        public IRoleRepository Roles
        {
            get
            {
                return _roles == null ?
                _roles = new RoleRepository(_context) :
                _roles;
            }
        }

        public IEpisodeRepository Episodes
        {
            get
            {
                return _episodes == null ?
                _episodes = new EpisodeRepository(_context) :
                _episodes;
            }
        }

        public IGenericRepository<MediaServer> MediaServers
        {
            get
            {
                return _mediaServers == null ?
                _mediaServers = new GenericRepository<MediaServer>(_context) :
                _mediaServers;
            }
        }

        public IGenericRepository<Catalog> Catalogs
        {
            get
            {
                return _catalogs == null ?
                _catalogs = new GenericRepository<Catalog>(_context) :
                _catalogs;
            }
        }

        public IGenericRepository<CatalogDetail> CatalogDetails
        {
            get
            {
                return _catalogDetails == null ?
                _catalogDetails = new GenericRepository<CatalogDetail>(_context) :
                _catalogDetails;
            }
        }

        public IGenreRepository Genres
        {
            get
            {
                return _genres == null ?
                _genres = new GenreRepository(_context) :
                _genres;
            }
        }

        public IMovieRepository Movies
        {
            get
            {
                return _movies == null ?
                _movies = new MovieRepository(_context) :
                _movies;
            }
        }

        public IGenericRepository<MovieGenre> MovieGenres
        {
            get
            {
                return _movieGenres == null ?
                _movieGenres = new GenericRepository<MovieGenre>(_context) :
                _movieGenres;
            }
        }

        public IGenericRepository<Profile> Profiles
        {
            get
            {
                return _profiles == null ?
                _profiles = new GenericRepository<Profile>(_context) :
                _profiles;
            }
        }

        public IGenericRepository<LinkedAccount> LinkedAccounts
        {
            get
            {
                return _linkedAccounts == null ?
                _linkedAccounts = new GenericRepository<LinkedAccount>(_context) :
                _linkedAccounts;
            }
        }

        public ISeasonRepository Seasons
        {
            get
            {
                return _seasons == null ?
                _seasons = new SeasonRepository(_context) :
                _seasons;
            }
        }

        public ITvSerieRepository TvSeries
        {
            get
            {
                return _tvSeries == null ?
                _tvSeries = new TvSerieRepository(_context) :
                _tvSeries;
            }
        }

        public IGenericRepository<TvSerieGenre> TvSerieGenres
        {
            get
            {
                return _tvSerieGenres == null ?
                _tvSerieGenres = new GenericRepository<TvSerieGenre>(_context) :
                _tvSerieGenres;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
