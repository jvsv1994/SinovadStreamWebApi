using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.Seasons
{

    public class SeasonService : ISeasonService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SharedService _sharedService;

        public SeasonService(IUnitOfWork unitOfWork, SharedService sharedService)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
        }

        public async Task<Response<SeasonDto>> GetAsync(int id)
        {
            var response = new Response<SeasonDto>();
            try
            {
                var result = await _unitOfWork.Seasons.GetAsync(id);
                response.Data = result.MapTo<SeasonDto>();
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


        public async Task<ResponsePagination<List<SeasonDto>>> GetAllWithPaginationByTvSerieAsync(int tvSerieId, int page, int take)
        {
            var response = new ResponsePagination<List<SeasonDto>>();
            try
            {
                var result = await _unitOfWork.Seasons.GetAllWithPaginationByExpressionAsync(page, take, "SeasonNumber", true, x => x.TvSerieId == tvSerieId);
                response.Data = result.Items.MapTo<List<SeasonDto>>();
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

        public Response<object> Create(SeasonDto seasonDto)
        {
            var response = new Response<object>();
            try
            {
                var season = seasonDto.MapTo<Season>();
                _unitOfWork.Seasons.Add(season);
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

        public Response<object> Update(SeasonDto seasonDto)
        {
            var response = new Response<object>();
            try
            {
                var season = seasonDto.MapTo<Season>();
                _unitOfWork.Seasons.Update(season);
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
                _unitOfWork.Seasons.Delete(id);
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
                _unitOfWork.Seasons.DeleteByExpression(x => listIds.Contains(x.Id));
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

        public List<SeasonDto> GetSeasonsByVideos(List<VideoDto> listVideos)
        {
            List<SeasonDto> listSeasons = new List<SeasonDto>();
            for (var i = 0; i < listVideos.Count; i++)
            {
                var video = listVideos[i];
                var seasonNumber = video.SeasonNumber;
                var season = new SeasonDto();
                season.SeasonNumber = seasonNumber;
                season.TvSerieTmdbId = video.TmdbId!=null?(int)video.TmdbId:0;
                season.TvSerieId = video.TvSerieId;
                var index = listSeasons.FindIndex(item => item.SeasonNumber == seasonNumber);
                if (index == -1)
                {
                    listSeasons.Add(season);
                }
            }
            return listSeasons;
        }
    }
}
