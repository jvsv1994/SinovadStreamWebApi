using SinovadDemo.Application.DTO;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Application.Interface.Persistence
{
    public interface IEpisodeRepository : IGenericRepository<Episode>
    {
        List<Episode> GetEpisodesByTvSerieId(int tvSerieId);

        Episode GetEpisode(int tvSerieId, int seasonNumber, int episodeNumber);

    }
}
