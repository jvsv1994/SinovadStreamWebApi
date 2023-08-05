using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Domain.Enums;

namespace SinovadDemo.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<int> GetListTMDdMovieIdsFinded(List<int> listTMDbIds)
        {
            return _context.Movies.Where(movie => movie.TmdbId != null && listTMDbIds.Contains(((int)movie.TmdbId))).Select(it=>(int)it.TmdbId).ToList();
        }

        public List<string> GetListImdbMovieIdsFinded(List<string> listImdbIds)
        {
            return _context.Movies.Where(movie => movie.Imdbid != null && listImdbIds.Contains(movie.Imdbid)).Select(it => it.Imdbid).ToList();
        }


        public ItemDto GetMovieDataByUser(int userId,int movieId)
        {
            var queryMovies = from movie in _context.Movies
                              join video in _context.Videos on movie.Id equals video.MovieId
                              join storage in _context.Storages on video.StorageId equals storage.Id
                              join mediaServer in _context.MediaServers on storage.MediaServerId equals mediaServer.Id
                              where mediaServer.UserId == userId && movie.Id == movieId
                              select new ItemDto
                              {
                                  Title = movie.Title + " (" + movie.ReleaseDate.Value.Year + ")",
                                  Name = movie.Title,
                                  Overview = movie.Overview,
                                  ReleaseDate = movie.ReleaseDate,
                                  TmdbId = movie.TmdbId,
                                  PosterPath = movie.PosterPath,
                                  MovieId = movie.Id,
                                  IpAddress = mediaServer.IpAddress,
                                  MediaServerUrl = mediaServer.Url,
                                  MediaServerState = (MediaServerState)mediaServer.StateCatalogDetailId,
                                  VideoId = video.Id,
                                  MediaServerId = mediaServer.Id,
                                  MediaType = (MediaType)storage.MediaTypeCatalogDetailId,
                                  PhysicalPath = video.PhysicalPath
                              } into x
                              group x by new { x.MovieId, x } into g
                              select g.Key.x; ;
            return queryMovies.ToList().FirstOrDefault();
        }

        public object GetMoviesByUserAndSearchText(int userId, string searchText)
        {
            var queryMovies = from movie in _context.Movies
                              join video in _context.Videos on movie.Id equals video.MovieId
                              join storage in _context.Storages on video.StorageId equals storage.Id
                              join mediaServer in _context.MediaServers on storage.MediaServerId equals mediaServer.Id
                              where mediaServer.UserId == userId && storage.MediaTypeCatalogDetailId == (int)MediaType.Movie && movie.Title.ToLower().Contains(searchText.ToLower()) == true
                              select new ItemDto
                              {
                                  Title = movie.Title + " (" + movie.ReleaseDate.Value.Year + ")",
                                  Name = movie.Title,
                                  Overview=movie.Overview,
                                  ReleaseDate = movie.ReleaseDate,
                                  TmdbId = movie.TmdbId,
                                  PosterPath = movie.PosterPath,
                                  MovieId = movie.Id,
                                  IpAddress = mediaServer.IpAddress,
                                  MediaServerUrl = mediaServer.Url,
                                  MediaServerState = (MediaServerState)mediaServer.StateCatalogDetailId,
                                  VideoId = video.Id,
                                  MediaServerId = mediaServer.Id,
                                  MediaType = (MediaType)storage.MediaTypeCatalogDetailId,
                                  PhysicalPath=video.PhysicalPath
                              } into x
                              group x by new { x.MovieId, x } into g
                              select g.Key.x; ;
            return queryMovies.ToList();
        }

        public object GetMoviesByUser(int userId)
        {
            var queryMovies = (from movieGenre in _context.MovieGenres
                               join genre in _context.Genres on movieGenre.GenreId equals genre.Id
                               join movie in _context.Movies on movieGenre.MovieId equals movie.Id
                               join video in _context.Videos on movie.Id equals video.MovieId
                               join storage in _context.Storages on video.StorageId equals storage.Id
                               join mediaServer in _context.MediaServers on storage.MediaServerId equals mediaServer.Id
                               where mediaServer.UserId == userId && storage.MediaTypeCatalogDetailId == (int)MediaType.Movie
                               select new ItemDto
                               {
                                   Title = movie.Title + " (" + movie.ReleaseDate.Value.Year + ")",
                                   Name = movie.Title,
                                   Overview = movie.Overview,
                                   ReleaseDate = (DateTime)movie.ReleaseDate,
                                   TmdbId = movie.TmdbId != null ? (int)movie.TmdbId : 0,
                                   Imdbid = movie.Imdbid,
                                   PosterPath = movie.PosterPath,
                                   MovieId = movie.Id,
                                   VideoId = video.Id,
                                   GenreId = movieGenre.GenreId,
                                   GenreName = genre.Name,
                                   IpAddress = mediaServer.IpAddress,
                                   MediaServerUrl = mediaServer.Url,
                                   MediaServerState = (MediaServerState)mediaServer.StateCatalogDetailId,
                                   MediaServerId = mediaServer.Id,
                                   MediaType = (MediaType)storage.MediaTypeCatalogDetailId,
                                   PhysicalPath = video.PhysicalPath,
                                   Created = (DateTime)video.Created
                               }).ToList();
            return queryMovies;
        }

        public object GetRecentlyAddedMoviesByUser(int userId)
        {
            var queryMovies = (from movie in _context.Movies
                               join video in _context.Videos on movie.Id equals video.MovieId
                               join storage in _context.Storages on video.StorageId equals storage.Id
                               join mediaServer in _context.MediaServers on storage.MediaServerId equals mediaServer.Id
                               where mediaServer.UserId == userId && storage.MediaTypeCatalogDetailId == (int)MediaType.Movie && movie.Adult == false
                               orderby video.Created descending
                               select new ItemDto
                               {
                                   Title = movie.Title + " (" + movie.ReleaseDate.Value.Year + ")",
                                   Name = movie.Title,
                                   VideoId = video.Id,
                                   Overview = movie.Overview,
                                   ReleaseDate = (DateTime)movie.ReleaseDate,
                                   TmdbId = movie.TmdbId != null ? (int)movie.TmdbId : 0,
                                   Imdbid = movie.Imdbid,
                                   PosterPath = movie.PosterPath,
                                   MovieId = movie.Id,
                                   IpAddress = mediaServer.IpAddress,
                                   MediaServerUrl = mediaServer.Url,
                                   MediaServerState = (MediaServerState)mediaServer.StateCatalogDetailId,
                                   MediaServerId = mediaServer.Id,
                                   MediaType = (MediaType)storage.MediaTypeCatalogDetailId,
                                   PhysicalPath = video.PhysicalPath,
                                   Created = (DateTime)video.Created
                               }).AsEnumerable().GroupBy(a => a.MovieId).Take(10).Select(x => x.First()).ToList();
            return queryMovies;
        }

        public object GetMoviesByProfile(int profileId)
        {
            var result = (from movie in _context.Movies
                          join video in _context.Videos on movie.Id equals video.MovieId
                          join videoprofile in _context.VideoProfiles on video.Id equals videoprofile.VideoId
                          join storage in _context.Storages on video.StorageId equals storage.Id
                          join mediaServer in _context.MediaServers on storage.MediaServerId equals mediaServer.Id
                          where videoprofile.ProfileId == profileId && storage.MediaTypeCatalogDetailId == (int)MediaType.Movie
                          orderby videoprofile.LastModified descending
                          select new ItemDto
                          {
                              Title = movie.Title + " (" + movie.ReleaseDate.Value.Year + ")",
                              CurrentTime = videoprofile.CurrentTime,
                              DurationTime = videoprofile.DurationTime,
                              LastModified = (DateTime)videoprofile.LastModified,
                              PhysicalPath = video.PhysicalPath,
                              Name = movie.Title,
                              Overview = movie.Overview,
                              ReleaseDate = (DateTime)movie.ReleaseDate,
                              TmdbId = movie.TmdbId != null ? (int)movie.TmdbId : 0,
                              Imdbid = movie.Imdbid,
                              PosterPath = movie.PosterPath,
                              MovieId = movie.Id,
                              IpAddress = mediaServer.IpAddress,
                              MediaServerUrl = mediaServer.Url,
                              MediaServerState = (MediaServerState)mediaServer.StateCatalogDetailId,
                              VideoId = video.Id,
                              MediaServerId = mediaServer.Id,
                              MediaType = (MediaType)storage.MediaTypeCatalogDetailId,
                              ContinueVideo=true
                          }).AsEnumerable().GroupBy(a => a.MovieId).Select(x => x.First()).ToList();
            return result;
        }


    }
}
