using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IVideoRepository : IGenericRepository<Video>
    {
        List<Video> GetVideoByLibraryId(int libraryId);

        object GetVideosByTvSerieAndUser(int tvSerieId, int userId);
    }
}
