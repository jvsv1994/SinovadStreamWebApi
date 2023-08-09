using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Domain.Enums;

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

        public ItemDto GetTvSerieDataByUser(int userId, int tvSerieId)
        {
            var query = from tvserie in _context.TvSeries
                        join video in _context.Videos on tvserie.Id equals video.TvSerieId
                        join library in _context.Libraries on video.LibraryId equals library.Id
                        join mediaServer in _context.MediaServers on library.MediaServerId equals mediaServer.Id
                        where mediaServer.UserId == userId && library.MediaTypeCatalogDetailId == (int)MediaType.TvSerie && tvserie.Id == tvSerieId
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
                            IpAddress = mediaServer.IpAddress,
                            MediaServerUrl = mediaServer.Url,
                            MediaServerState = (MediaServerState)mediaServer.StateCatalogDetailId,
                            MediaServerGuid = mediaServer.Guid,
                            MediaServerId = mediaServer.Id,
                            LibraryId = library.Id,
                            LibraryGuid = library.Guid,
                            MediaType = (MediaType)library.MediaTypeCatalogDetailId
                        } into x
                        group x by new { x.TvSerieId, x } into g
                        select g.Key.x;
            return query.ToList().FirstOrDefault();
        }

        public object GetTvSeriesByUserIdAndSerchText(int userId, string searchText)
        {
            var query = from tvserie in _context.TvSeries
                        join video in _context.Videos on tvserie.Id equals video.TvSerieId
                        join library in _context.Libraries on video.LibraryId equals library.Id
                        join mediaServer in _context.MediaServers on library.MediaServerId equals mediaServer.Id
                        where mediaServer.UserId == userId && library.MediaTypeCatalogDetailId == (int)MediaType.TvSerie && tvserie.Name.ToLower().Contains(searchText.ToLower()) == true
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
                            IpAddress = mediaServer.IpAddress,
                            MediaServerUrl = mediaServer.Url,
                            MediaServerState = (MediaServerState)mediaServer.StateCatalogDetailId,
                            MediaServerGuid = mediaServer.Guid,
                            MediaServerId = mediaServer.Id,
                            LibraryId = library.Id,
                            LibraryGuid = library.Guid,
                            MediaType = (MediaType)library.MediaTypeCatalogDetailId
                        } into x
                        group x by new { x.TvSerieId, x } into g
                        select g.Key.x;
            return query.ToList();
        }

        public object GetTvSeriesByUserId(int userId)
        {
            var result = (from tvseriegenre in _context.TvSerieGenres
                          join genre in _context.Genres on tvseriegenre.GenreId equals genre.Id
                          join tvserie in _context.TvSeries on tvseriegenre.TvSerieId equals tvserie.Id
                          join video in _context.Videos on tvserie.Id equals video.TvSerieId
                          join library in _context.Libraries on video.LibraryId equals library.Id
                          join mediaServer in _context.MediaServers on library.MediaServerId equals mediaServer.Id
                          where mediaServer.UserId == userId && library.MediaTypeCatalogDetailId == (int)MediaType.TvSerie
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
                              GenreName = genre.Name,
                              IpAddress = mediaServer.IpAddress,
                              MediaServerUrl = mediaServer.Url,
                              MediaServerState = (MediaServerState)mediaServer.StateCatalogDetailId,
                              MediaServerGuid = mediaServer.Guid,
                              MediaServerId = mediaServer.Id,
                              LibraryId = library.Id,
                              LibraryGuid = library.Guid,
                              MediaType = (MediaType)library.MediaTypeCatalogDetailId,
                              Created = (DateTime)video.Created
                          }).AsEnumerable().GroupBy(a => new { a.GenreId, a.TvSerieId }).Select(x => x.First()).ToList();
            return result;
        }

        public object GetRecentlyTvSeriesAdded(int userId)
        {
            var result = (from tvserie in _context.TvSeries
                          join video in _context.Videos on tvserie.Id equals video.TvSerieId
                          join library in _context.Libraries on video.LibraryId equals library.Id
                          join mediaServer in _context.MediaServers on library.MediaServerId equals mediaServer.Id
                          where mediaServer.UserId == userId && library.MediaTypeCatalogDetailId == (int)MediaType.TvSerie
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
                              IpAddress = mediaServer.IpAddress,
                              MediaServerUrl = mediaServer.Url,
                              MediaServerState = (MediaServerState)mediaServer.StateCatalogDetailId,
                              MediaServerGuid = mediaServer.Guid,
                              MediaServerId = mediaServer.Id,
                              LibraryId = library.Id,
                              LibraryGuid = library.Guid,
                              MediaType = (MediaType)library.MediaTypeCatalogDetailId,
                              Created = (DateTime)video.Created
                          }).AsEnumerable().GroupBy(a => a.TvSerieId).Take(10).Select(x => x.First()).ToList();
            return result;
        }

        public object GetTvSeriesByProfileId(int profileId)
        {
            var result = (from tvserie in _context.TvSeries
                          join video in _context.Videos on tvserie.Id equals video.TvSerieId
                          join videoprofile in _context.VideoProfiles on video.Id equals videoprofile.VideoId
                          join library in _context.Libraries on video.LibraryId equals library.Id
                          join mediaServer in _context.MediaServers on library.MediaServerId equals mediaServer.Id
                          where videoprofile.ProfileId == profileId && library.MediaTypeCatalogDetailId == (int)MediaType.TvSerie
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
                              IpAddress = mediaServer.IpAddress,
                              MediaServerUrl = mediaServer.Url,
                              MediaServerState = (MediaServerState)mediaServer.StateCatalogDetailId,
                              VideoId = video.Id,
                              MediaServerGuid = mediaServer.Guid,
                              MediaServerId = mediaServer.Id,
                              LibraryId = library.Id,
                              LibraryGuid = library.Guid,
                              MediaType = (MediaType)library.MediaTypeCatalogDetailId,
                              ContinueVideo = true
                          }).AsEnumerable().GroupBy(a => a.TvSerieId).Select(x => x.First()).ToList();
            return result;
        }
    }
}
