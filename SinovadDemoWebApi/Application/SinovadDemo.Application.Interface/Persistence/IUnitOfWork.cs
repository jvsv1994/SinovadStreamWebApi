using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get; }
        public IMenuRepository Menus { get; }
        public IRoleRepository Roles { get; }
        public IGenericRepository<MediaServer> MediaServers { get; }
        public IGenericRepository<Catalog> Catalogs { get; }
        public IGenericRepository<CatalogDetail> CatalogDetails { get; }
        public IGenreRepository Genres { get; }
        public IMovieRepository Movies { get; }
        public IGenericRepository<MovieGenre> MovieGenres { get; }
        public IGenericRepository<Profile> Profiles { get; }
        public IGenericRepository<LinkedAccount> LinkedAccounts { get; }
        public ISeasonRepository Seasons { get; }
        public ITvSerieRepository TvSeries { get; }
        public IGenericRepository<TvSerieGenre> TvSerieGenres { get; }
        public IEpisodeRepository Episodes { get; }
        public void Save();
        public Task SaveAsync();
    }
}
