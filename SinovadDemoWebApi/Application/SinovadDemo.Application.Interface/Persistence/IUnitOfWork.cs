using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        public IAppUserRepository AppUsers { get; }
        public IGenericRepository<AppUser> Accounts { get; }
        public IGenericRepository<AccountServer> AccountServers { get; }
        public IGenericRepository<AccountStorage> AccountStorages { get; }
        public IGenericRepository<Catalog> Catalogs { get; }
        public IGenericRepository<CatalogDetail> CatalogDetails { get; }
        public IGenreRepository Genres { get; }
        public IMovieRepository Movies { get; }
        public IGenericRepository<MovieGenre> MovieGenres { get; }
        public IGenericRepository<Profile> Profiles { get; }
        public ISeasonRepository Seasons { get; }
        public IGenericRepository<TranscodeSetting> TranscodeSettings { get; }
        public IGenericRepository<TranscodeVideoProcess> TranscodeVideoProcesses { get; }
        public ITvSerieRepository TvSeries { get; }
        public IGenericRepository<TvSerieGenre> TvSerieGenres { get; }
        public IVideoRepository Videos { get; }
        public IGenericRepository<VideoProfile> VideoProfiles { get; }
        public IEpisodeRepository Episodes { get; }
        public void Save();
        public Task SaveAsync();
    }
}
