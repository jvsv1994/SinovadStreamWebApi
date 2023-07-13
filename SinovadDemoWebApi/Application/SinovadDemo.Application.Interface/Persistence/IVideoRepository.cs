using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IVideoRepository : IGenericRepository<Video>
    {
        List<Video> GetVideoByStorageId(int storageId);

        object GetVideosByTvSerieAndUser(int tvSerieId, int userId);
    }
}
