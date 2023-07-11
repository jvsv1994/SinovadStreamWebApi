using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IVideoRepository : IGenericRepository<Video>
    {
        List<Video> GetVideoByAccountStorageId(int accountStorageId);

        object GetVideosByTvSerieAndAccount(int tvSerieId, string accountId);
    }
}
