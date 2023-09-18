namespace SinovadDemo.Application.DTO
{
    public class MovieWithGenresDto:MovieDto
    {
        public List<MovieGenreDto> MovieGenres { get; set; }

    }
}
