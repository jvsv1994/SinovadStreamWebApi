using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.Infrastructure
{
    public interface ITmdbService
    {
        MovieDto SearchMovie(string movieName, string year);
        TvSerieDto SearchTvShow(string name);
        string GetEpisodeName(int tvShowId, int seasonNumber, int episodeNumber);
        List<GenreDto> GetListGenres();

    }
}
