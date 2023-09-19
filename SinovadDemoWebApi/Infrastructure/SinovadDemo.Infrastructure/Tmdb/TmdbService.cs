using Microsoft.Extensions.Options;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO.Genre;
using SinovadDemo.Application.DTO.Movie;
using SinovadDemo.Application.DTO.TvSerie;
using SinovadDemo.Application.Interface.Infrastructure;
using SinovadDemo.Application.Shared;
using TMDbLib.Client;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;

namespace SinovadDemo.Infrastructure.Tmdb
{
    public class TmdbService: ITmdbService
    {

        private readonly SharedService _sharedService;

        private readonly TMDbClient _tmdbClient;

        public TmdbService(SharedService sharedService, IOptions<MyConfig> options)
        {
            _sharedService = sharedService;
            _tmdbClient = new TMDbClient(options.Value.TMDbApiKey);
        }

        public MovieDto SearchMovie(string movieName, string year)
        {
            TMDbLib.Objects.Movies.Movie movieFinded = null;
            string language = "es-MX";
            TMDbLib.Objects.General.SearchContainer<SearchMovie> search = _tmdbClient.SearchMovieAsync(movieName, language, 1, false, int.Parse(year)).Result;
            if (search.Results.Count > 0)
            {
                movieFinded = GetValidMovie(movieName, search.Results, language);
            }
            else
            {
                language = "es-ES";
                search = _tmdbClient.SearchMovieAsync(movieName, language, 1, false, int.Parse(year)).Result;
                if (search.Results.Count > 0)
                {
                    movieFinded = GetValidMovie(movieName, search.Results, language);
                }
                else
                {
                    language = "en-US";
                    search = _tmdbClient.SearchMovieAsync(movieName, language, 1, false, int.Parse(year)).Result;
                    if (search.Results.Count > 0)
                    {
                        movieFinded = GetValidMovie(movieName, search.Results, language);
                    }
                }
            }
            MovieDto movieDto = null;
            if (movieFinded!=null)
            {
                movieDto= new MovieDto();
                movieDto.Adult = movieFinded.Adult;
                movieDto.OriginalLanguage = movieFinded.OriginalLanguage;
                movieDto.OriginalTitle = movieFinded.OriginalTitle;
                movieDto.Overview = movieFinded.Overview;
                movieDto.Popularity = (double)movieFinded.Popularity;
                movieDto.PosterPath = movieFinded.PosterPath;
                movieDto.BackdropPath = movieFinded.BackdropPath;
                movieDto.ReleaseDate = (DateTime)movieFinded.ReleaseDate;
                movieDto.Title = movieFinded.Title; 
            }
            return movieDto;
        }

        public TvSerieDto SearchTvShow(string name)
        {
            TvSerieDto tvSerieDto = null;
            TvShow tvShow = null;
            string language = "es-MX";
            TMDbLib.Objects.General.SearchContainer<SearchTv> search = _tmdbClient.SearchTvShowAsync(name, language, 1, false).Result;
            if (search.Results.Count > 0)
            {
                tvShow = GetValidTvSerie(name, search.Results, language);
            }else{
                language = "es-ES";
                search = _tmdbClient.SearchTvShowAsync(name, language, 1, false).Result;
                if (search.Results.Count > 0)
                {
                    tvShow = GetValidTvSerie(name, search.Results, language);
                }else
                {
                    language = "en-US";
                    search = _tmdbClient.SearchTvShowAsync(name, language, 1, false).Result;
                    if (search.Results.Count > 0)
                    {
                        tvShow = GetValidTvSerie(name, search.Results, language);
                    }
                }
            }
            if(tvShow!=null)
            {
                tvSerieDto= new TvSerieDto();
                tvSerieDto.TmdbId = tvShow.Id;
                tvSerieDto.OriginalLanguage = tvShow.OriginalLanguage;
                tvSerieDto.OriginalName = tvShow.OriginalName;
                tvSerieDto.Overview = tvShow.Overview;
                tvSerieDto.Popularity = (double)tvShow.Popularity;
                tvSerieDto.PosterPath = tvShow.PosterPath;
                tvSerieDto.BackdropPath = tvShow.BackdropPath;
                tvSerieDto.FirstAirDate = (DateTime)tvShow.FirstAirDate;
                tvSerieDto.LastAirDate = (DateTime)tvShow.LastAirDate;
                tvSerieDto.Name = tvShow.Name;
            }
            return tvSerieDto;
        }

        public TvEpisode SearchEpisode(int tvShowId, int seasonNumber, int episodeNumber)
        {
            return _tmdbClient.GetTvEpisodeAsync(tvShowId, seasonNumber, episodeNumber, TvEpisodeMethods.Undefined, "es-MX").Result;
        }

        public string GetEpisodeName(int tvShowId, int seasonNumber, int episodeNumber)
        {
           var episode=_tmdbClient.GetTvEpisodeAsync(tvShowId, seasonNumber, episodeNumber, TvEpisodeMethods.Undefined, "es-MX").Result;
          if(episode != null)
          {
            return episode.Name;
          }
            return null;
        }


        public List<GenreDto> GetListGenres()
        {
            List<TMDbLib.Objects.General.Genre> movieGenres = _tmdbClient.GetMovieGenresAsync("es-MX").Result;
            List<int> movieGenresIds = movieGenres.Select(it =>it.Id).ToList();
            List<TMDbLib.Objects.General.Genre> tvSerieGenres = _tmdbClient.GetTvGenresAsync("es-MX").Result;
            tvSerieGenres = tvSerieGenres.Where(it=> !movieGenresIds.Contains(it.Id)).ToList();
            var allGenres=movieGenres.Concat(tvSerieGenres);
            List<GenreDto> listGenres = new List<GenreDto>();
            foreach (var genre in allGenres)
            {
                var genreDto = new GenreDto();
                genreDto.Name= genre.Name;
                listGenres.Add(genreDto);
            }
            return listGenres;
        }
        private TMDbLib.Objects.Movies.Movie GetValidMovie(string movieName, List<SearchMovie> listSearchTv, string language)
        {
            TMDbLib.Objects.Movies.Movie movieFinded = null;
            TMDbLib.Objects.Movies.Movie firstMovieFinded = null;
            for (int i = 0; i < listSearchTv.Count; i++)
            {
                var searched = listSearchTv[i];
                TMDbLib.Objects.Movies.Movie movie = _tmdbClient.GetMovieAsync(searched.Id, language).Result;
                if (i == 0)
                {
                    firstMovieFinded = movie;
                }
                if (movie.Genres != null && movie.Genres.Count > 0 && _sharedService.GetFormattedText(movieName) == _sharedService.GetFormattedText(movie.Title))
                {
                    movieFinded = movie;
                    break;
                }
            }
            if (movieFinded == null)
            {
                movieFinded = firstMovieFinded;
            }
            return movieFinded;
        }

        private TvShow GetValidTvSerie(string tvSerieName, List<SearchTv> listSearchTv, string language)
        {
            TvShow tvShowFinded = null;
            TvShow firstTvShowFinded = null;
            for (int i = 0; i < listSearchTv.Count; i++)
            {
                var searched = listSearchTv[i];
                TvShow tvshow = _tmdbClient.GetTvShowAsync(searched.Id, TvShowMethods.Undefined, language).Result;
                if (i == 0)
                {
                    firstTvShowFinded = tvshow;
                }
                if (tvshow.Genres != null && tvshow.Genres.Count > 0 && _sharedService.GetFormattedText(tvSerieName) == _sharedService.GetFormattedText(tvshow.Name))
                {
                    tvShowFinded = tvshow;
                    break;
                }
            }
            if (tvShowFinded == null)
            {
                tvShowFinded = firstTvShowFinded;
            }
            return tvShowFinded;
        }

    }
}
