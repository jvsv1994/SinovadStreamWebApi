using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface ISeasonRepository : IGenericRepository<Season>
    {
        List<Season> GetSeasonsByTvSerieId(int tvSerieId);

    }
}
