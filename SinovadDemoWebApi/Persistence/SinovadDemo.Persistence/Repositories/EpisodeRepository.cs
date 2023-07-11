using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Domain.Entities;

namespace SinovadDemo.Persistence.Repositories
{
    public class EpisodeRepository : GenericRepository<Episode>, IEpisodeRepository
    {
        private ApplicationDbContext _context;
        public EpisodeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public object GetEpisodesFromOwnDataBase()
        {
            var list = _context.Episodes.Join(_context.Seasons, episode => episode.SeasonId, season => season.Id, (episode, season) => new
            {
                episode,
                season
            }).Join(_context.TvSeries, season => season.season.TvSerieId, tvserie => tvserie.Id, (season, tvserie) => new EpisodeDto
            {
                TvSerieId = tvserie.Id,
                Name = season.episode.Title,
                TvSerieName = tvserie.Name,
                EpisodeId = season.episode.Id,
                EpisodeNumber = season.episode.EpisodeNumber,
                SeasonNumber = season.season.SeasonNumber != null ? (int)season.season.SeasonNumber : 0,
                StillPath = tvserie.PosterPath,
                TvSerieTmdbId = tvserie.TmdbId != null ? (int)tvserie.TmdbId : 0
            }).Where(item => item.TvSerieTmdbId == 0).ToList();
            return list;
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

    }
}
