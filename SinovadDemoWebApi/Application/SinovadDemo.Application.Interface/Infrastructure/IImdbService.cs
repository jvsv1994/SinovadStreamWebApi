using SinovadDemo.Application.DTO.Movie;

namespace SinovadDemo.Application.Interface.Infrastructure
{
    public interface IImdbService
    {
        MovieDto SearchMovie(string movieName, string year);

    }
}
