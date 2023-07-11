using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IEpisodeRepository : IGenericRepository<Episode>
    {
        public object GetEpisodesFromOwnDataBase();

        List<Episode> GetEpisodesByTvSerieId(int tvSerieId);

    }
}
