using Generic.Core.Models;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        public IAppUserRepository AppUsers { get; }
        public IGenericRepository<User> Users { get; }
        public IMenuRepository Menus { get; }
        public IRoleRepository Roles { get; }
        public IGenericRepository<MediaServer> MediaServers { get; }
        public IGenericRepository<Storage> Storages { get; }
        public IGenericRepository<Catalog> Catalogs { get; }
        public IGenericRepository<CatalogDetail> CatalogDetails { get; }
        public IGenreRepository Genres { get; }
        public IMovieRepository Movies { get; }
        public IGenericRepository<MovieGenre> MovieGenres { get; }
        public IGenericRepository<Profile> Profiles { get; }
        public ISeasonRepository Seasons { get; }
        public IGenericRepository<TranscoderSettings> TranscoderSettings { get; }
        public IGenericRepository<TranscodingProcess> TranscodingProcesses { get; }
        public ITvSerieRepository TvSeries { get; }
        public IGenericRepository<TvSerieGenre> TvSerieGenres { get; }
        public IVideoRepository Videos { get; }
        public IGenericRepository<VideoProfile> VideoProfiles { get; }
        public IEpisodeRepository Episodes { get; }
        public void Save();
        public Task SaveAsync();
    }
}
