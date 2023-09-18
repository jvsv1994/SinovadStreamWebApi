using SinovadDemo.Domain.Entities;
using System.Linq.Expressions;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        List<Genre> GetGenresByTvSerieId(int tvSerieId);
        Task<List<int>> GetIdsByExpression(Expression<Func<Genre, bool>> expression);

    }
}
