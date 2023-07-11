using SinovadDemo.Application.DTO;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {

        ItemDto GetMovieDataByAccount(string accountId,int movieId);
        List<int> GetListTMDdMovieIdsFinded(List<int> listTMDbIds);
        List<string> GetListImdbMovieIdsFinded(List<string> listImdbIds);
        object GetMoviesByAccountAndSearchText(string accountId, string searchText);
        object GetMoviesByAccount(string accountId);
        object GetRecentlyAddedMoviesByAccount(string accountId);
        object GetMoviesByProfile(int profileId);
    }
}
