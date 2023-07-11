using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        List<Genre> GetGenresByTvSerieId(int tvSerieId);

    }
}
