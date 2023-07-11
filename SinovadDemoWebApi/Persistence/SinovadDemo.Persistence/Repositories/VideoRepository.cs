using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class VideoRepository : GenericRepository<Video>, IVideoRepository
    {
        private ApplicationDbContext _context;
        public VideoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Video> GetVideoByAccountStorageId(int accountStorageId)
        {
            return _context.Videos.Where(video => video.AccountStorageId == accountStorageId).ToList();
        }

        public object GetVideosByTvSerieAndAccount(int tvSerieId, string accountId)
        {
            var result = _context.TvSeries.Join(_context.Videos, tvSerie => tvSerie.Id, video => video.TvSerieId, (tvserie, video) => new { tvserie, video })
                .Join(_context.AccountStorages, video => video.video.AccountStorageId, accountstorage => accountstorage.Id, (video, accountstorage) => new { video, accountstorage })
                .Join(_context.AccountServers, accountstorage => accountstorage.accountstorage.AccountServerId, accountserver => accountserver.Id, (accountstorage, accountserver) =>
                new VideoDto
                {
                    AccountId = accountserver.AccountId,
                    AccountServerId = accountserver.Id,
                    HostUrl=accountserver.HostUrl,
                    AccountStorageTypeId = accountstorage.accountstorage.AccountStorageTypeId,
                    TmdbId = accountstorage.video.tvserie.TmdbId != null ? (int)accountstorage.video.tvserie.TmdbId : 0,
                    SeasonNumber = accountstorage.video.video.SeasonNumber != null ? (int)accountstorage.video.video.SeasonNumber : 0,
                    EpisodeNumber = accountstorage.video.video.EpisodeNumber != null ? (int)accountstorage.video.video.EpisodeNumber : 0,
                    VideoId = accountstorage.video.video.Id,
                    TvSerieId = accountstorage.video.video.TvSerieId != null ? (int)accountstorage.video.video.TvSerieId : 0,
                    PhysicalPath=accountstorage.video.video.PhysicalPath
                })
                .Where(item => item.AccountStorageTypeId == 2 && item.AccountId == accountId && item.TvSerieId == tvSerieId).ToList();
            return result;
        }
    }
}
