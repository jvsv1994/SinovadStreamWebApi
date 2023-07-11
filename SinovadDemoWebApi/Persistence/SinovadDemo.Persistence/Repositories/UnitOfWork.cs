using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;
        private IGenericRepository<AppUser> _accounts;
        private IGenericRepository<AccountServer> _accountServers;
        private IGenericRepository<AccountStorage> _accountStorages;
        private IGenericRepository<Catalog> _catalogs;
        private IGenericRepository<CatalogDetail> _catalogDetails;
        private IGenreRepository _genres;
        private IMovieRepository _movies;
        private IGenericRepository<MovieGenre> _movieGenres;
        private IGenericRepository<Profile> _profiles;
        private ISeasonRepository _seasons;
        private IGenericRepository<TranscodeSetting> _transcodeSettings;
        private IGenericRepository<TranscodeVideoProcess> _transcodeVideoProcesses;
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

        public IEpisodeRepository Episodes
        {
            get
            {
                return _episodes == null ?
                _episodes = new EpisodeRepository(_context) :
                _episodes;
            }
        }

        public IGenericRepository<AppUser> Accounts
        {
            get
            {
                return _accounts == null ?
                _accounts = new GenericRepository<AppUser>(_context) :
                _accounts;
            }
        }

        public IGenericRepository<AccountServer> AccountServers
        {
            get
            {
                return _accountServers == null ?
                _accountServers = new GenericRepository<AccountServer>(_context) :
                _accountServers;
            }
        }

        public IGenericRepository<AccountStorage> AccountStorages
        {
            get
            {
                return _accountStorages == null ?
                _accountStorages = new GenericRepository<AccountStorage>(_context) :
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

        public IGenericRepository<TranscodeSetting> TranscodeSettings
        {
            get
            {
                return _transcodeSettings == null ?
                _transcodeSettings = new GenericRepository<TranscodeSetting>(_context) :
                _transcodeSettings;
            }
        }

        public IGenericRepository<TranscodeVideoProcess> TranscodeVideoProcesses
        {
            get
            {
                return _transcodeVideoProcesses == null ?
                _transcodeVideoProcesses = new GenericRepository<TranscodeVideoProcess>(_context) :
                _transcodeVideoProcesses;
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
