using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class TvSerieRepository : GenericRepository<TvSerie>, ITvSerieRepository
    {
        private ApplicationDbContext _context;
        public TvSerieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<TvSerie> GetTvSeriesByTMDdIds(List<string> listTMDbIds)
        {
            return _context.TvSeries.Where(tvs => tvs.TmdbId != null && listTMDbIds.Contains(((int)tvs.TmdbId).ToString())).ToList();
        }

        public List<int> GetListTmdbIdsExistingInOwnDataBase(List<int> listTMDbIds)
        {
            return _context.TvSeries.Where(tvs => tvs.TmdbId != null && listTMDbIds.Contains(((int)tvs.TmdbId))).Select(tvs => tvs.TmdbId != null ? (int)tvs.TmdbId : 0).ToList();
        }

        public ItemDto GetTvSerieDataByAccount(string accountId, int tvSerieId)
        {
            var query = from tvserie in _context.TvSeries
                        join video in _context.Videos on tvserie.Id equals video.TvSerieId
                        join accountstorage in _context.AccountStorages on video.AccountStorageId equals accountstorage.Id
                        join accountserver in _context.AccountServers on accountstorage.AccountServerId equals accountserver.Id
                        where accountserver.AccountId == accountId && accountstorage.AccountStorageTypeId == 2 && tvserie.Id == tvSerieId
                        select new ItemDto
                        {
                            Title = tvserie.Name + (tvserie.LastAirDate.Value.Year > tvserie.FirstAirDate.Value.Year ? " (" + tvserie.FirstAirDate.Value.Year + "-" + tvserie.LastAirDate.Value.Year + ")" : " (" + tvserie.FirstAirDate.Value.Year + ")"),
                            Name = tvserie.Name,
                            Overview = tvserie.Overview,
                            FirstAirDate = tvserie.FirstAirDate,
                            LastAirDate = tvserie.LastAirDate,
                            TmdbId = tvserie.TmdbId,
                            PosterPath = tvserie.PosterPath,
                            TvSerieId = tvserie.Id,
                            IpAddress = accountserver.IpAddress,
                            HostUrl = accountserver.HostUrl,
                            HostState = accountserver.StateCatalogDetailId,
                            AccountServerId = accountserver.Id,
                            AccountStorageTypeId = accountstorage.AccountStorageTypeId
                        } into x
                        group x by new { x.TvSerieId, x } into g
                        select g.Key.x;
            return query.ToList().FirstOrDefault();
        }

        public object GetTvSeriesByAccountIdAndSerchText(string accountId, string searchText)
        {
            var query = from tvserie in _context.TvSeries
                        join video in _context.Videos on tvserie.Id equals video.TvSerieId
                        join accountstorage in _context.AccountStorages on video.AccountStorageId equals accountstorage.Id
                        join accountserver in _context.AccountServers on accountstorage.AccountServerId equals accountserver.Id
                        where accountserver.AccountId == accountId && accountstorage.AccountStorageTypeId == 2 && tvserie.Name.ToLower().Contains(searchText.ToLower()) == true
                        select new ItemDto
                        {
                            Title = tvserie.Name + (tvserie.LastAirDate.Value.Year > tvserie.FirstAirDate.Value.Year ? " (" + tvserie.FirstAirDate.Value.Year + "-" + tvserie.LastAirDate.Value.Year + ")" : " (" + tvserie.FirstAirDate.Value.Year + ")"),
                            Name=tvserie.Name,
                            Overview = tvserie.Overview,
                            FirstAirDate = tvserie.FirstAirDate,
                            LastAirDate = tvserie.LastAirDate,
                            TmdbId = tvserie.TmdbId,
                            PosterPath = tvserie.PosterPath,
                            TvSerieId = tvserie.Id,
                            IpAddress = accountserver.IpAddress,
                            HostUrl = accountserver.HostUrl,
                            HostState = accountserver.StateCatalogDetailId,
                            AccountServerId = accountserver.Id,
                            AccountStorageTypeId = accountstorage.AccountStorageTypeId
                        } into x
                        group x by new { x.TvSerieId, x } into g
                        select g.Key.x;
            return query.ToList();
        }

        public object GetTvSeriesByAccountId(string accountId)
        {
            var result = (from tvseriegenre in _context.TvSerieGenres
                          join genre in _context.Genres on tvseriegenre.GenreId equals genre.Id
                          join tvserie in _context.TvSeries on tvseriegenre.TvSerieId equals tvserie.Id
                          join video in _context.Videos on tvserie.Id equals video.TvSerieId
                          join accountstorage in _context.AccountStorages on video.AccountStorageId equals accountstorage.Id
                          join accountserver in _context.AccountServers on accountstorage.AccountServerId equals accountserver.Id
                          where accountserver.AccountId == accountId && accountstorage.AccountStorageTypeId == 2
                          select new ItemDto
                          {
                              Title = tvserie.Name + (tvserie.LastAirDate.Value.Year > tvserie.FirstAirDate.Value.Year ? " (" + tvserie.FirstAirDate.Value.Year + "-" + tvserie.LastAirDate.Value.Year + ")" : " (" + tvserie.FirstAirDate.Value.Year + ")"),
                              Name = tvserie.Name,
                              Overview = tvserie.Overview,
                              FirstAirDate = (DateTime)tvserie.FirstAirDate,
                              LastAirDate = (DateTime)tvserie.LastAirDate,
                              TmdbId = tvserie.TmdbId != null ? (int)tvserie.TmdbId : 0,
                              PosterPath=tvserie.PosterPath,
                              TvSerieId = tvserie.Id,
                              GenreId = tvseriegenre.GenreId,
                              TvSerieGenreId = tvseriegenre.Id,
                              GenreName = genre.Name,
                              IpAddress = accountserver.IpAddress,
                              HostUrl = accountserver.HostUrl,
                              HostState = accountserver.StateCatalogDetailId,
                              AccountServerId = accountserver.Id,
                              AccountStorageTypeId = accountstorage.AccountStorageTypeId,
                              Created = (DateTime)video.Created
                          }).AsEnumerable().GroupBy(a => a.TvSerieGenreId).Select(x => x.First()).ToList();
            return result;
        }

        public object GetRecentlyTvSeriesAdded(string accountId)
        {
            var result = (from tvserie in _context.TvSeries
                          join video in _context.Videos on tvserie.Id equals video.TvSerieId
                          join accountstorage in _context.AccountStorages on video.AccountStorageId equals accountstorage.Id
                          join accountserver in _context.AccountServers on accountstorage.AccountServerId equals accountserver.Id
                          where accountserver.AccountId == accountId && accountstorage.AccountStorageTypeId == 2
                          orderby video.Created descending
                          select new ItemDto
                          {
                              Title = tvserie.Name + (tvserie.LastAirDate.Value.Year > tvserie.FirstAirDate.Value.Year ? " (" + tvserie.FirstAirDate.Value.Year + "-" + tvserie.LastAirDate.Value.Year + ")" : " (" + tvserie.FirstAirDate.Value.Year + ")"),
                              Name = tvserie.Name,
                              Overview = tvserie.Overview,
                              FirstAirDate = (DateTime)tvserie.FirstAirDate,
                              LastAirDate = (DateTime)tvserie.LastAirDate,
                              TmdbId = tvserie.TmdbId != null ? (int)tvserie.TmdbId : 0,
                              PosterPath = tvserie.PosterPath,
                              TvSerieId = tvserie.Id,
                              IpAddress = accountserver.IpAddress,
                              HostUrl = accountserver.HostUrl,
                              HostState = accountserver.StateCatalogDetailId,
                              AccountServerId = accountserver.Id,
                              AccountStorageTypeId = accountstorage.AccountStorageTypeId,
                              Created = (DateTime)video.Created
                          }).AsEnumerable().GroupBy(a => a.TvSerieId).Take(10).Select(x => x.First()).ToList();
            return result;
        }

        public object GetTvSeriesByProfileId(int profileId)
        {
            var result = (from tvserie in _context.TvSeries
                          join video in _context.Videos on tvserie.Id equals video.TvSerieId
                          join videoprofile in _context.VideoProfiles on video.Id equals videoprofile.VideoId
                          join accountstorage in _context.AccountStorages on video.AccountStorageId equals accountstorage.Id
                          join accountserver in _context.AccountServers on accountstorage.AccountServerId equals accountserver.Id
                          where videoprofile.ProfileId == profileId && accountstorage.AccountStorageTypeId == 2
                          orderby videoprofile.LastModified descending
                          select new ItemDto
                          {
                              Title = tvserie.Name,
                              Subtitle = video.Subtitle,
                              CurrentTime = videoprofile.CurrentTime,
                              DurationTime = videoprofile.DurationTime,
                              SeasonNumber = (int)video.SeasonNumber,
                              EpisodeNumber = (int)video.EpisodeNumber,
                              LastModified = (DateTime)videoprofile.LastModified,
                              PhysicalPath = video.PhysicalPath,
                              Name = tvserie.Name,
                              Overview = tvserie.Overview,
                              FirstAirDate = (DateTime)tvserie.FirstAirDate,
                              LastAirDate = (DateTime)tvserie.LastAirDate,
                              TmdbId = tvserie.TmdbId != null ? (int)tvserie.TmdbId : 0,
                              PosterPath = tvserie.PosterPath,
                              TvSerieId = tvserie.Id,
                              IpAddress = accountserver.IpAddress,
                              HostUrl = accountserver.HostUrl,
                              HostState = accountserver.StateCatalogDetailId,
                              VideoId = video.Id,
                              AccountServerId = accountserver.Id,
                              AccountStorageTypeId = accountstorage.AccountStorageTypeId,
                              ContinueVideo = true
                          }).AsEnumerable().GroupBy(a => a.TvSerieId).Select(x => x.First()).ToList();
            return result;
        }
    }
}
