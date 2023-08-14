using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Persistence.Repositories
{
    public class EpisodeRepository : GenericRepository<Episode>, IEpisodeRepository
    {
        private ApplicationDbContext _context;
        public EpisodeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Episode> GetEpisodesByTvSerieId(int tvSerieId)
        {
            var list = _context.Episodes.Join(_context.Seasons, episode => episode.SeasonId, season => season.Id, (episode, season) => new
            {
                episode,
                season
            }).Join(_context.TvSeries, season => season.season.TvSerieId, tvserie => tvserie.Id, (season, tvserie) => new
            {
                season.episode,
                tvSerieId = tvserie.Id
            }).Where(item => item.tvSerieId == tvSerieId).Select(item => item.episode).ToList();
            return list;
        }

        public Episode GetEpisode(int tvSerieId,int seasonNumber,int episodeNumber)
        {
            var ep = (from episode in _context.Episodes
                              join season in _context.Seasons on episode.SeasonId equals season.Id
                              join tvserie in _context.TvSeries on season.TvSerieId equals tvserie.Id
                              where tvserie.Id == tvSerieId && season.SeasonNumber == seasonNumber && episode.EpisodeNumber == episodeNumber
                              select episode).FirstOrDefault();
            return ep;
        }

    }
}
