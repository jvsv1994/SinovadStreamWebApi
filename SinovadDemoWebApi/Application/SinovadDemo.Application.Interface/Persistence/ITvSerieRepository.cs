using SinovadDemo.Application.DTO;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface ITvSerieRepository : IGenericRepository<TvSerie>
    {
        ItemDto GetTvSerieDataByUser(int userId, int tvSerieId);
        List<TvSerie> GetTvSeriesByTMDdIds(List<string> listTMDbIds);
        List<int> GetListTmdbIdsExistingInOwnDataBase(List<int> listTMDbIds);
        object GetTvSeriesByUserIdAndSerchText(int userId, string searchText);
        object GetTvSeriesByUserId(int userId);
        object GetRecentlyTvSeriesAdded(int userId);
        object GetTvSeriesByProfileId(int profileId);

    }
}
