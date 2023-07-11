using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.Infrastructure
{
    public interface IImdbService
    {
        MovieDto SearchMovie(string movieName, string year);
        ItemDetailDto GetMovieDetail(ItemDetailDto movieDetail);
    }
}
