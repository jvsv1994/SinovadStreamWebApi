namespace SinovadDemo.Application.DTO.Movie
{
    public class MovieWithGenresDto : MovieDto
    {
        public List<MovieGenreDto> MovieGenres { get; set; }

    }
}
