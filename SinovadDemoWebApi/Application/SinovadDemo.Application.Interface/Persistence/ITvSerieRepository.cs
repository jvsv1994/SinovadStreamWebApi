using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface ITvSerieRepository : IGenericRepository<TvSerie>
    {
        List<TvSerie> GetTvSeriesByTMDdIds(List<string> listTMDbIds);
        List<int> GetListTmdbIdsExistingInOwnDataBase(List<int> listTMDbIds);
        Task<TvSerie> GetTvSerie(int id, CancellationToken cancellationToken = default);
        Task<TvSerie> SearchTvSerie(string query, CancellationToken cancellationToken = default);

    }
}
