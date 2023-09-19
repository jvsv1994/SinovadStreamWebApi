namespace SinovadDemo.Application.DTO.TvSerie
{
    public class TvSerieWithGenresDto:TvSerieDto
    {
        public List<TvSerieGenreDto> TvSerieGenres { get; set; }

    }
}
