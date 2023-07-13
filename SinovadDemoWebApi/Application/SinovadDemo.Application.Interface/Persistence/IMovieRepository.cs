using SinovadDemo.Application.DTO;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {

        ItemDto GetMovieDataByUser(int userId,int movieId);
        List<int> GetListTMDdMovieIdsFinded(List<int> listTMDbIds);
        List<string> GetListImdbMovieIdsFinded(List<string> listImdbIds);
        object GetMoviesByUserAndSearchText(int userId, string searchText);
        object GetMoviesByUser(int userId);
        object GetRecentlyAddedMoviesByUser(int userId);
        object GetMoviesByProfile(int profileId);
    }
}
