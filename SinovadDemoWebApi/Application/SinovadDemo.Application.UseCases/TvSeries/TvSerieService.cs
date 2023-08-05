using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.TvSeries
{

    public class TvSerieService : ITvSerieService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SharedService _sharedService;

        public TvSerieService(IUnitOfWork unitOfWork, SharedService sharedService)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
        }

        public async Task<Response<List<TvSerieDto>>> GetAllAsync()
        {
            var response = new Response<List<TvSerieDto>>();
            try
            {
                var result = await _unitOfWork.TvSeries.GetAllAsync();
                response.Data = result.MapTo<List<TvSerieDto>>();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<ResponsePagination<List<TvSerieDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<TvSerieDto>>();
            try
            {
                var result = await _unitOfWork.TvSeries.GetAllWithPaginationAsync(page, take,sortBy,sortDirection,searchText, searchBy);
                response.Data = result.Items.MapTo<List<TvSerieDto>>();
                response.PageNumber = page;
                response.TotalPages = result.Pages;
                response.TotalCount = result.Total;
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<TvSerieDto>> GetAsync(int id)
        {
            var response = new Response<TvSerieDto>();
            try
            {
                var tvSerie = await _unitOfWork.TvSeries.GetAsync(id);
                var mdto = tvSerie.MapTo<TvSerieDto>();
                var tvSerieGenres = await _unitOfWork.TvSerieGenres.GetAllAsync();
                var genres = await _unitOfWork.Genres.GetAllAsync();
                var listItemGenres = (from mg in tvSerieGenres
                                      join g in genres on mg.GenreId equals g.Id
                                      where mg.TvSerieId == id
                                      select new TvSerieGenreDto
                                      {
                                          TvSerieId = id,
                                          GenreId = g.Id,
                                          GenreName = g.Name
                                      }).ToList();
                mdto.ListItemGenres = listItemGenres;
                response.Data = mdto;
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Create(TvSerieDto tvSerieDto)
        {
            var response = new Response<object>();
            try
            {
                var tvSerie = tvSerieDto.MapTo<TvSerie>();
                MapTvSerieGenres(tvSerieDto, tvSerie);
                _unitOfWork.TvSeries.Add(tvSerie);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Update(TvSerieDto tvSerieDto)
        {
            var response = new Response<object>();
            try
            {
                var tvSerie = tvSerieDto.MapTo<TvSerie>();
                MapTvSerieGenres(tvSerieDto, tvSerie);
                var listtvSerieGenres = _unitOfWork.TvSerieGenres.GetAllByExpressionAsync(x => x.TvSerieId == tvSerie.Id).Result.ToList();
                if (listtvSerieGenres != null && listtvSerieGenres.Count > 0)
                {
                    _unitOfWork.TvSerieGenres.DeleteList(listtvSerieGenres);
                }
                _unitOfWork.TvSeries.Update(tvSerie);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Delete(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.TvSeries.Delete(id);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> DeleteList(string ids)
        {
            var response = new Response<object>();
            try
            {
                List<int> listIds = new List<int>();
                if (!string.IsNullOrEmpty(ids))
                {
                    listIds = ids.Split(",").Select(x => Convert.ToInt32(x)).ToList();
                }
                _unitOfWork.TvSerieGenres.DeleteByExpression(x => listIds.Contains(x.TvSerieId));
                _unitOfWork.TvSeries.DeleteByExpression(x => listIds.Contains(x.Id));
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        private void MapTvSerieGenres(TvSerieDto tvSerieDto, TvSerie tvSerie)
        {
            if (tvSerieDto.ListItemGenres != null && tvSerieDto.ListItemGenres.Count > 0)
            {
                var list = tvSerieDto.ListItemGenres.AsEnumerable();
                List<TvSerieGenre> tvSerieGenres = (from mg in list
                                                    select new TvSerieGenre
                                                    {
                                                        GenreId = mg.GenreId,
                                                    }).ToList();
                tvSerie.TvSerieGenres = tvSerieGenres;
            }
        }

        public ItemDetailDto GetTvSerieData(ItemDetailDto tvSerieDetail, List<SeasonDto> listSeasons, List<VideoDto> listVideos)
        {
            tvSerieDetail.Title = tvSerieDetail.Name;
            var listGenres = _unitOfWork.Genres.GetGenresByTvSerieId(tvSerieDetail.Id);
            tvSerieDetail.Genres = string.Join(", ", listGenres.Select(genre => genre.Name));
            List<Season> listAllSeasons = _unitOfWork.Seasons.GetSeasonsByTvSerieId(tvSerieDetail.Id);
            List<Episode> listAllEpisodes = _unitOfWork.Episodes.GetEpisodesByTvSerieId(tvSerieDetail.Id);
            for (var i = 0; i < listSeasons.Count; i++)
            {
                var season = listSeasons[i];
                Season seasonems = listAllSeasons.Find(item => item.SeasonNumber == season.SeasonNumber);
                season.Overview = seasonems.Summary;
                season.Name = seasonems.Name;
                List<Episode> listepisodesems = listAllEpisodes.FindAll(item => item.SeasonId == seasonems.Id);
                List<EpisodeDto> listEpisodesBySeason = new List<EpisodeDto>();
                List<VideoDto> listVideosBySeason = listVideos.FindAll(item => item.SeasonNumber == season.SeasonNumber);
                for (var j = 0; j < listVideosBySeason.Count; j++)
                {
                    var video = listVideosBySeason[j];
                    var episodeems = listepisodesems.Find(item => item.EpisodeNumber == video.EpisodeNumber);
                    if (episodeems != null)
                    {
                        var episode = new EpisodeDto();
                        episode.MediaServerId = video.MediaServerId;
                        episode.MediaServerUrl=video.MediaServerUrl;
                        episode.TvSerieName = tvSerieDetail.Name;
                        episode.EpisodeNumber = (int)episodeems.EpisodeNumber;
                        episode.SeasonNumber = (int)seasonems.SeasonNumber;
                        episode.Name = episodeems.Title;
                        episode.Overview = episodeems.Summary;
                        episode.PhysicalPath = video.PhysicalPath;
                        episode.StillPath = tvSerieDetail.PosterPath;
                        episode.VideoId = video.VideoId;
                        listEpisodesBySeason.Add(episode);
                    }
                }
                List<EpisodeDto> listEpisodesOrdered = listEpisodesBySeason.OrderBy(o => o.EpisodeNumber).ToList();
                season.ListEpisodes = listEpisodesOrdered;
            }
            List<SeasonDto> listSeasonsOrdered = listSeasons.OrderBy(o => o.SeasonNumber).ToList();
            tvSerieDetail.ListSeasons = listSeasonsOrdered;
            return tvSerieDetail;
        }
    }
}
