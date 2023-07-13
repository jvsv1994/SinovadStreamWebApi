using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Domain.Enums;

namespace SinovadDemo.Persistence.Repositories
{
    public class VideoRepository : GenericRepository<Video>, IVideoRepository
    {
        private ApplicationDbContext _context;
        public VideoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Video> GetVideoByStorageId(int storageId)
        {
            return _context.Videos.Where(video => video.StorageId == storageId).ToList();
        }

        public object GetVideosByTvSerieAndUser(int tvSerieId, int userId)
        {
            var result = _context.TvSeries.Join(_context.Videos, tvSerie => tvSerie.Id, video => video.TvSerieId, (tvserie, video) => new { tvserie, video })
                .Join(_context.Storages, video => video.video.StorageId, storage => storage.Id, (video, storage) => new { video, storage })
                .Join(_context.MediaServers, storage => storage.storage.MediaServerId, mediaServer => mediaServer.Id, (storage, mediaServer) =>
                new VideoDto
                {
                    UserId = mediaServer.UserId,
                    MediaServerId = mediaServer.Id,
                    MediaServerUrl=mediaServer.Url,
                    MediaType = (MediaType)storage.storage.MediaTypeCatalogDetailId,
                    TmdbId = storage.video.tvserie.TmdbId != null ? (int)storage.video.tvserie.TmdbId : 0,
                    SeasonNumber = storage.video.video.SeasonNumber != null ? (int)storage.video.video.SeasonNumber : 0,
                    EpisodeNumber = storage.video.video.EpisodeNumber != null ? (int)storage.video.video.EpisodeNumber : 0,
                    VideoId = storage.video.video.Id,
                    TvSerieId = storage.video.video.TvSerieId != null ? (int)storage.video.video.TvSerieId : 0,
                    PhysicalPath=storage.video.video.PhysicalPath
                })
                .Where(item => item.MediaType == MediaType.TvSerie && item.UserId == userId && item.TvSerieId == tvSerieId).ToList();
            return result;
        }
    }
}
