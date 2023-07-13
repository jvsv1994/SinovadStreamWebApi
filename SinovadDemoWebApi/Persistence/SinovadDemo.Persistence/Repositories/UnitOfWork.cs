using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;
        private IGenericRepository<User> _users;
        private IMenuRepository _menus;
        private IGenericRepository<MediaServer> _mediaServers;
        private IGenericRepository<Storage> _accountStorages;
        private IGenericRepository<Catalog> _catalogs;
        private IGenericRepository<CatalogDetail> _catalogDetails;
        private IGenreRepository _genres;
        private IMovieRepository _movies;
        private IGenericRepository<MovieGenre> _movieGenres;
        private IGenericRepository<Profile> _profiles;
        private ISeasonRepository _seasons;
        private IGenericRepository<TranscoderSettings> _transcoderSettings;
        private IGenericRepository<TranscodingProcess> _transcodingProcesses;
        private ITvSerieRepository _tvSeries;
        private IGenericRepository<TvSerieGenre> _tvSerieGenres;
        private IVideoRepository _videos;
        private IGenericRepository<VideoProfile> _videoProfiles;
        private IEpisodeRepository _episodes;
        private IAppUserRepository _appUsers;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IAppUserRepository AppUsers
        {
            get
            {
                return _appUsers == null ?
                _appUsers = new AppUserRepository(_context) :
                _appUsers;
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

        public IEpisodeRepository Episodes
        {
            get
            {
                return _episodes == null ?
                _episodes = new EpisodeRepository(_context) :
                _episodes;
            }
        }

        public IGenericRepository<User> Users
        {
            get
            {
                return _users == null ?
                _users = new GenericRepository<User>(_context) :
                _users;
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

        public IGenericRepository<Storage> Storages
        {
            get
            {
                return _accountStorages == null ?
                _accountStorages = new GenericRepository<Storage>(_context) :
                _accountStorages;
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

        public ISeasonRepository Seasons
        {
            get
            {
                return _seasons == null ?
                _seasons = new SeasonRepository(_context) :
                _seasons;
            }
        }

        public IGenericRepository<TranscoderSettings> TranscoderSettings
        {
            get
            {
                return _transcoderSettings == null ?
                _transcoderSettings = new GenericRepository<TranscoderSettings>(_context) :
                _transcoderSettings;
            }
        }

        public IGenericRepository<TranscodingProcess> TranscodingProcesses
        {
            get
            {
                return _transcodingProcesses == null ?
                _transcodingProcesses = new GenericRepository<TranscodingProcess>(_context) :
                _transcodingProcesses;
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

        public IVideoRepository Videos
        {
            get
            {
                return _videos == null ?
                _videos = new VideoRepository(_context) :
                _videos;
            }
        }

        public IGenericRepository<VideoProfile> VideoProfiles
        {
            get
            {
                return _videoProfiles == null ?
                _videoProfiles = new GenericRepository<VideoProfile>(_context) :
                _videoProfiles;
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
