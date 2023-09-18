using SinovadDemo.Application.DTO;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {

        List<int> GetListTMDdMovieIdsFinded(List<int> listTMDbIds);
        List<string> GetListImdbMovieIdsFinded(List<string> listImdbIds);
        Task<Movie> GetMovie(int id, CancellationToken cancellationToken = default);
    }
}
