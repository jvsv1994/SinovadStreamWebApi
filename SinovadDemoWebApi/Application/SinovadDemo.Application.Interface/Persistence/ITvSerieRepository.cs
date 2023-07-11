using SinovadDemo.Application.DTO;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface ITvSerieRepository : IGenericRepository<TvSerie>
    {
        ItemDto GetTvSerieDataByAccount(string accountId, int tvSerieId);
        List<TvSerie> GetTvSeriesByTMDdIds(List<string> listTMDbIds);
        List<int> GetListTmdbIdsExistingInOwnDataBase(List<int> listTMDbIds);
        object GetTvSeriesByAccountIdAndSerchText(string accountId, string searchText);
        object GetTvSeriesByAccountId(string accountId);
        object GetRecentlyTvSeriesAdded(string accountId);
        object GetTvSeriesByProfileId(int profileId);

    }
}
